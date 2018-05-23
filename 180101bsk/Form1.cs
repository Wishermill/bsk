using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _180101bsk
{
    public partial class Form1 : Form
    {
        private string PbKpath = "..\\..\\..\\..\\publick";
        private string PrKpath = "..\\..\\..\\..\\privatek";
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Zaszyfruj_Click(object sender, EventArgs e)
        {
            if (validEncryption())
            {
                //textBox1,2,3,4=64 (32-448)
                BlowfishEngine algorithm = new BlowfishEngine();
                int temp = algorithm.GetBlockSize(); //64b
                //KeyParameter parameter = new KeyParameter(passHS);
                //algorithm.Init(true, parameter);
                //BufferedBlockCipher mode = new PaddedBufferedBlockCipher(algorithm);
                //mode.Init(true, parameter);
                //byte[] privateKeyHashed2 = new byte[mode.GetOutputSize(privateCopy.Length) + 8];
                //Buffer.BlockCopy(privateCopy, 0, privateKeyHashed2, 0, privateCopy.Length);
                //byte[] byteArray = BitConverter.GetBytes(mode.GetOutputSize(privateCopy.Length) - privateCopy.Length + 1);
                //privateKeyHashed2[privateKeyHashed2.Length - 1] = byteArray[0];
                //byte[] cipheredKey = new byte[mode.GetOutputSize(privateKeyHashed2.Length)];
                //int size = mode.ProcessBytes(privateKeyHashed2, 0, privateKeyHashed2.Length, cipheredKey, 0);
                //mode.DoFinal(cipheredKey, size);
                //FileStream filePrK2 = new FileStream(PrKpath + "\\" + textBox11.Text + "2.prkey", FileMode.CreateNew, FileAccess.Write, FileShare.None);
                //filePrK2.Write(cipheredKey, 0, cipheredKey.Length);
                //filePrK2.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //if (validUserCreation())
            {
                //textBox11, 10, 9
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(2048);


                RSAParameters publicKey = RSA.ExportParameters(false);

                RSAParameters privateKey = RSA.ExportParameters(true);
                byte[] privateCopy = new byte[privateKey.D.Length + privateKey.DP.Length + privateKey.DQ.Length + privateKey.Exponent.Length + privateKey.InverseQ.Length + privateKey.Modulus.Length + privateKey.P.Length + privateKey.Q.Length];
                System.Buffer.BlockCopy(privateKey.D, 0, privateCopy, 0, privateKey.D.Length);
                System.Buffer.BlockCopy(privateKey.DP, 0, privateCopy, privateKey.D.Length, privateKey.DP.Length);
                System.Buffer.BlockCopy(privateKey.DQ, 0, privateCopy, privateKey.D.Length + privateKey.DP.Length, privateKey.DQ.Length);
                System.Buffer.BlockCopy(privateKey.Exponent, 0, privateCopy, privateKey.D.Length + privateKey.DP.Length + privateKey.DQ.Length, privateKey.Exponent.Length);
                System.Buffer.BlockCopy(privateKey.InverseQ, 0, privateCopy, privateKey.D.Length + privateKey.DP.Length + privateKey.DQ.Length + privateKey.Exponent.Length, privateKey.InverseQ.Length);
                System.Buffer.BlockCopy(privateKey.Modulus, 0, privateCopy, privateKey.D.Length + privateKey.DP.Length + privateKey.DQ.Length + privateKey.Exponent.Length + privateKey.InverseQ.Length, privateKey.Modulus.Length);
                System.Buffer.BlockCopy(privateKey.P, 0, privateCopy, privateKey.D.Length + privateKey.DP.Length + privateKey.DQ.Length + privateKey.Exponent.Length + privateKey.InverseQ.Length + privateKey.Modulus.Length, privateKey.P.Length);
                System.Buffer.BlockCopy(privateKey.Q, 0, privateCopy, privateKey.D.Length + privateKey.DP.Length + privateKey.DQ.Length + privateKey.Exponent.Length + privateKey.InverseQ.Length + privateKey.Modulus.Length + privateKey.P.Length, privateKey.Q.Length);

                HashAlgorithm hashShortcut = new SHA256CryptoServiceProvider();
                byte[] passHS = hashShortcut.ComputeHash(Encoding.ASCII.GetBytes(textBox10.Text));
                byte[] privateKeyHashed = new byte[privateCopy.Length];


                //
                BlowfishEngine algorithm = new BlowfishEngine();
                int temp = algorithm.GetBlockSize(); //64b
                KeyParameter parameter = new KeyParameter(passHS);
                algorithm.Init(true, parameter);
                BufferedBlockCipher mode = new PaddedBufferedBlockCipher(algorithm);
                mode.Init(true, parameter);
                byte[] privateKeyHashed2 = new byte[mode.GetOutputSize(privateCopy.Length) + 8];
                Buffer.BlockCopy(privateCopy, 0, privateKeyHashed2, 0, privateCopy.Length);
                byte[] byteArray = BitConverter.GetBytes(mode.GetOutputSize(privateCopy.Length) - privateCopy.Length + 1);
                privateKeyHashed2[privateKeyHashed2.Length - 1] = byteArray[0];
                byte[] cipheredKey = new byte[mode.GetOutputSize(privateKeyHashed2.Length)];
                int size = mode.ProcessBytes(privateKeyHashed2, 0, privateKeyHashed2.Length, cipheredKey, 0);
                mode.DoFinal(cipheredKey, size);
                FileStream filePrK2 = new FileStream(PrKpath + "\\" + textBox11.Text + "2.prkey", FileMode.CreateNew, FileAccess.Write, FileShare.None);
                filePrK2.Write(cipheredKey, 0, cipheredKey.Length);
                filePrK2.Close();
                //


                for (int i = 0; i < privateCopy.Length; i++)
                {
                    privateKeyHashed[i] = (byte)(privateCopy[i] ^ passHS[i % 32]);
                }
                System.IO.StreamWriter filePbK = new System.IO.StreamWriter(PbKpath + "\\" + textBox11.Text + ".pbkey");
                filePbK.WriteLine("<?xml version=\"1.0\"?>");
                filePbK.WriteLine("<pbKey>");
                filePbK.WriteLine("<\t<Name>" + textBox11.Text + "</Name>");
                filePbK.WriteLine("<\t<E>" + Convert.ToBase64String(publicKey.Exponent) + "</E>");
                filePbK.WriteLine("<\t<M>" + Convert.ToBase64String(publicKey.Modulus) + "</M>");
                filePbK.WriteLine("</pbKey>");
                filePbK.Close();

                FileStream filePrK = new FileStream(PrKpath + "\\" + textBox11.Text + ".prkey", FileMode.CreateNew, FileAccess.Write, FileShare.None);
                filePrK.Write(privateKeyHashed, 0, privateKeyHashed.Length);
                filePrK.Close();

                textBox11.Text = "";
                textBox10.Text = "";
                textBox9.Text = "";
            }
        }
        private bool validUserCreation()
        {
            if(textBox11.Text == "")
            {
                MessageBox.Show("Nieprawidlowa nazwa uzytkownika");
                return false;
            }
            if(textBox10.Text == "")
            {
                MessageBox.Show("Wprowadz haslo");
                return false;
            }
            if(textBox10.TextLength < 7)
            {
                MessageBox.Show("Haslo musi miec co najmniej 8 znakow, w tym chociaz: 1 cyfre, 1 litere, 1 znak specjalny");
                return false;
            }
            if(textBox9.Text != textBox10.Text)
            {
                MessageBox.Show("Haslo powtorzone jest bledne");
                return false;
            }
            int a, b, c;
            a = b = c = 0;
            var regexA = new Regex("[a-zA-Z]+");
            var regexB = new Regex("[0-9]+");
            string tak = textBox10.Text;
            c = textBox10.Text.Count(p => !char.IsLetterOrDigit(p));
            if (regexA.IsMatch(textBox10.Text)) a++;
            if (regexB.IsMatch(textBox10.Text)) b++;
            if (a == 0 || b == 0 || c == 0)
            {
                MessageBox.Show("Haslo musi miec chociaz 1 cyfre, 1 litere i 1 znak specjalny");
                return false;
            }
            return true;
        }
        private bool validEncryption()
        {
            return true;
        }
    }
}
