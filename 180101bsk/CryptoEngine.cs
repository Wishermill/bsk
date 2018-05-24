using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto.Generators;
using System.IO;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Modes;

namespace _180101bsk
{
    public class CryptoEngine
    {
        private Window window;
        private BlowfishEngine engine;
        public FileManager fileManager;
        private Pkcs1Encoding RSAEncryptEngine = new Pkcs1Encoding(new RsaEngine());
        public int keyLength;
        public int blockLength = 16;//na 8 z 16 ktj
        public int subBlockLength = 1;

        public string cipherMode;
        public byte[] iv;
        public static int PUBLIC_KEY = 0;
        public static int PRIVATE_KEY = 1;
        public static bool ENCRYPT = true;
        public static bool DECRYPT = false;
        public byte[] sessionKey;
        public string password;

        public CryptoEngine(Window window, FileManager fileManager)
        {
            this.window = window;
            this.fileManager = fileManager;
            engine = new BlowfishEngine();
            iv = null;
            subBlockLength = 1;
        }

        public void StartEncryption()
        {
            fileManager.OpenOutputFile();
            GenerateKeys();

            if (cipherMode == "ECB")
            {
                subBlockLength = 1;//8?
                iv = null;
            }
            if (cipherMode == "CBC")
                subBlockLength = 1;//8? ktj
            fileManager.InsertFileHeader();
            typeof(CryptoEngine).GetMethod(cipherMode + "Process").Invoke(this, new object[] { true });

            fileManager.CloseFiles();
            Array.Clear(sessionKey, 0, sessionKey.Length);
        }
        private object PEMBytesToParameters(byte[] key)
        {

            var textReader = new StringReader(Encoding.Default.GetString(key));
            try
            {
                return (new PemReader(textReader)).ReadObject();
            }
            catch (Exception e)
            {
                window.WriteOutput("Błąd odczytu klucza prywatnego.");
                return null;
            }
        }
        public void StartDecryption(DecryptUser user)
        {
            fileManager.OpenOutputFile();
            byte[] pemPrivateKey;
            pemPrivateKey = QucikDecrypt(fileManager.GetUserEncryptedPrivateKey(user.Name), Sha256(password));
            if (pemPrivateKey == null)
                wrongPassMode(password);
            else
            {
                sessionKey = RSADecrypt(user.EncryptedKey, pemPrivateKey);
                var privateKey = PemToByte(Encoding.Default.GetString(pemPrivateKey));
                typeof(CryptoEngine).GetMethod(cipherMode + "Process").Invoke(this, new object[] { false });
            }

            fileManager.CloseFiles();
            Array.Clear(sessionKey, 0, sessionKey.Length);
        }
        private void wrongPassMode(string password)
        {
            var hash = Sha256(password);
            var rand = new Random(BitConverter.ToInt32(hash, 0));
            for (long i = 0; i < (fileManager.inputFileLength - fileManager.InputFile.BaseStream.Position) / 4; i++)
            {
                fileManager.Write(BitConverter.GetBytes(rand.Next(int.MinValue, int.MaxValue)));

            }
        }
        public byte[] QuickEncrypt(byte[] input, byte[] key)
        {
            return QuickProcess(input, key, true);
        }
        public byte[] QucikDecrypt(byte[] input, byte[] key)
        {
            return QuickProcess(input, key, false);
        }
        private byte[] QuickProcess(byte[] input, byte[] key, bool mode)
        {
            var cipher = new PaddedBufferedBlockCipher(engine);
            cipher.Init(mode, new KeyParameter(key));

            int blockLength = 16; //128 bitów //ktj 8
            byte[] output = new byte[cipher.GetOutputSize(input.Length)];
            var inputStream = new BinaryReader(new MemoryStream(input));
            var outputStream = new BinaryWriter(new MemoryStream(output));

            byte[] inputChunk;
            byte[] outputChunk;
            while ((inputChunk = inputStream.ReadBytes(blockLength)).Length == blockLength)
            {
                outputChunk = cipher.ProcessBytes(inputChunk);
                if (outputChunk != null)
                    outputStream.Write(outputChunk);
            }
            try
            {
                if (inputChunk.Length > 0)
                    outputChunk = cipher.DoFinal(inputChunk);
                else
                    outputChunk = cipher.DoFinal();
                outputStream.Write(outputChunk);
            }
            catch (Exception e)
            {
                return null;
            }
            int lastIndex = Array.FindLastIndex(output, b => b != 0);
            Array.Resize(ref output, lastIndex + 1);
            return output;
        }
        public byte[] RSAEncrypt(byte[] input, byte[] key)
        {
            return RSAProcess(input, key, true);
        }
        public byte[] RSADecrypt(byte[] input, byte[] key)
        {
            return RSAProcess(input, key, false);
        }
        private byte[] RSAProcess(byte[] input, byte[] key, bool mode)
        {
            var str = Encoding.Default.GetString(key);
            if (mode)
                RSAEncryptEngine.Init(mode, (RsaKeyParameters)PEMBytesToParameters(key));
            else
                RSAEncryptEngine.Init(mode, ((AsymmetricCipherKeyPair)PEMBytesToParameters(key)).Private);
            return RSAEncryptEngine.ProcessBlock(input, 0, input.Length);
        }
        public void CBCProcess(bool mode)
        {
            var cipher = new PaddedBufferedBlockCipher(new CbcBlockCipher(engine));
            cipher.Init(mode, new KeyParameter(sessionKey));
            Process(cipher, mode);
        }
        public void CFBProcess(bool mode)
        {
            var cipher = new PaddedBufferedBlockCipher(new CfbBlockCipher(engine, subBlockLength*8));
            cipher.Init(mode, new KeyParameter(sessionKey));
            Process(cipher, mode);
        }
        public void OFBProcess(bool mode)
        {
            var cipher = new PaddedBufferedBlockCipher(new OfbBlockCipher(engine, subBlockLength*8));
            cipher.Init(mode, new KeyParameter(sessionKey));
            Process(cipher, mode);
        }

        public void ECBProcess(bool mode)
        {
            var cipher = new PaddedBufferedBlockCipher(engine);
            cipher.Init(mode, new KeyParameter(sessionKey));
            Process(cipher, mode);
        }
        private void Process(PaddedBufferedBlockCipher cipher, bool isEncrypt)
        {
            int progress = 0;
            byte[] inputBytes;
            while ((inputBytes = fileManager.Read(blockLength)).Length == blockLength)
            {
                progress++;
                fileManager.Write(cipher.ProcessBytes(inputBytes)); 
                window.UpdateProgress(isEncrypt, (progress * blockLength) / (int)fileManager.inputFileLength);
            }
            if (inputBytes.Length > 0)
                fileManager.Write(cipher.DoFinal(inputBytes));
            else
                fileManager.Write(cipher.DoFinal());
            window.UpdateProgress(isEncrypt, 100);

        }
        public void GenerateKeys()
        {
            var rand = new RNGCryptoServiceProvider();
            var key = new byte[keyLength];
            rand.GetBytes(key);
            sessionKey = key;

            iv = new byte[blockLength];
            rand.GetBytes(iv);
        }

        public byte[] Sha256(string password)
        {
            byte[] bytes = Encoding.Default.GetBytes(password);
            SHA256Managed hashstring = new SHA256Managed();
            return hashstring.ComputeHash(bytes);
        }

        public KeyPair GetKeyPair()
        {
            var keyGenerationParameters = new KeyGenerationParameters(new SecureRandom(), 4096);
            var keyPairGenerator = new RsaKeyPairGenerator();
            keyPairGenerator.Init(keyGenerationParameters);
            var keys = keyPairGenerator.GenerateKeyPair();
            var keyPair = new KeyPair();

            var textWriter = new StringWriter();
            var pemWriter = new PemWriter(textWriter);
            pemWriter.WriteObject(keys.Public);
            pemWriter.Writer.Flush();
            keyPair.pemPublicKey = textWriter.ToString();
            var textReader = new StringReader(keyPair.pemPublicKey);
            var pemReader = new PemReader(textReader);
            keyPair.publicKey = pemReader.ReadPemObject().Content;

            textWriter = new StringWriter();
            pemWriter = new PemWriter(textWriter);
            pemWriter.WriteObject(keys.Private);
            pemWriter.Writer.Flush();
            keyPair.pemPrivateKey = textWriter.ToString();
            textReader = new StringReader(keyPair.pemPrivateKey);
            pemReader = new PemReader(textReader);
            keyPair.privateKey = pemReader.ReadPemObject().Content;

            return keyPair;
        }
        public byte[] PemToByte(string key)
        {
            var textReader = new StringReader(key);
            var pemReader = new PemReader(textReader);
            return pemReader.ReadPemObject().Content;
        }
    }
}
