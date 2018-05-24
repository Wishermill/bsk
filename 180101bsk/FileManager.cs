using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace _180101bsk
{
    public static class Extension
    {
        static public string Beautify(this XmlDocument doc)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                NewLineChars = "\r\n",
                NewLineHandling = NewLineHandling.Replace
            };
            using (XmlWriter writer = XmlWriter.Create(sb, settings))
            {
                doc.Save(writer);
            }
            return sb.ToString();
        }

    }
    public class FileManager
    {
        public BinaryReader InputFile { get; set; }
        public BinaryWriter OutputFile { get; set; }
        public long inputFileLength;
        private Window window;
        public string outputFilePath = "";
        public string extensionName = "";
        public FileManager(Window window)
        {
            this.window = window;
        }
        public void LoadConfig()
        {
            string[] lines;
            try
            {
                lines = File.ReadAllLines("config.ini");
            }
            catch (Exception e)
            {
                window.WriteOutput("Błąd wczytania konfiguracji.");
                return;
            }
            var config = window.config;
            foreach (var line in lines)
            {
                string[] splitLine = line.Split(' ');
                string key = splitLine.First();
                string[] values = splitLine.Skip(1).ToArray();

                var property = config.GetType().GetProperty(key);
                if (property == null)
                {
                    window.WriteOutput("Nie wczytano wszystkich konfiguracji!");
                    continue;
                }

                property.SetValue(config, Activator.CreateInstance(property.PropertyType));
                var type = property.PropertyType.GetGenericArguments()[0];
                var prop = property.GetValue(config, null);
                foreach (var value in values)
                    prop.GetType().GetMethod("Add").Invoke(prop, new[] { Convert.ChangeType(value, type) });
            }
        }
        public void LoadUsers()
        {
            var dir = new DirectoryInfo("public");
            foreach (FileInfo user in dir.GetFiles())
            {
                string name = Path.GetFileNameWithoutExtension(user.FullName);
                var streamReader = new StreamReader(user.OpenRead());
                byte[] publicKey = Encoding.Default.GetBytes(streamReader.ReadToEnd());
                streamReader.Close();
                window.users.Add(new User(name, publicKey));
            }

        }

        public void DeleteUserFiles(string name)
        {
            File.Delete("public/" + name + ".pub");
            File.Delete("private/" + name + ".ppk");
        }
        public void SaveUser(User user, byte[] encryptedPrivateKey, string pemPublicKey)
        {
            var fileStream = new FileStream("public/" + user.Name + ".pub", FileMode.Create);
            byte[] pk = Encoding.Default.GetBytes(pemPublicKey);
            fileStream.Write(pk, 0, pk.Length);
            fileStream.Close();

            fileStream = new FileStream("private/" + user.Name + ".ppk", FileMode.Create);
            fileStream.Write(encryptedPrivateKey, 0, encryptedPrivateKey.Length);
            fileStream.Close();

            var dir = new DirectoryInfo("public");
            foreach (FileInfo userz in dir.GetFiles())
            {
                string name = Path.GetFileNameWithoutExtension(userz.FullName);
                if (name == user.Name)
                {
                    var streamReader = new StreamReader(userz.OpenRead());
                    byte[] publicKey = Encoding.Default.GetBytes(streamReader.ReadToEnd());
                    streamReader.Close();
                    window.users.Add(new User(name, publicKey));
                }
            }
        }//ktjktj
        public void TryParseFileHeader()
        {
            if (InputFile == null)
                window.decryptUsers.Clear();
            if (InputFile != null && InputFile.BaseStream.Position == 0)
            {
                var fileStream = InputFile.BaseStream;

                string header = "";
                while (!header.Contains("?>") && header.Length < 500)
                    header += (char)fileStream.ReadByte();

                if (header.Length < 500)
                    ParseFileHeader();
                else
                {
                    fileStream.Position = 0;
                    window.decryptUsers.Clear();
                }

            }
        }
        public void ParseFileHeader()
        {
            var header = GetHeader();
            var doc = new XmlDocument();
            doc.LoadXml(header);

            window.crypto.keyLength = Int32.Parse(doc.SelectSingleNode("encryptionHeader/keyLength").InnerText) / 8;
            window.crypto.cipherMode = doc.SelectSingleNode("encryptionHeader/encryptionMode").InnerText;
            window.crypto.extensionName = doc.SelectSingleNode("encryptionHeader/extension").InnerText;
            if (doc.SelectSingleNode("encryptionHeader/subblockLength") != null)
                window.crypto.subBlockLength = Int32.Parse(doc.SelectSingleNode("encryptionHeader/subblockLength").InnerText) / 8;
            if (doc.SelectSingleNode("encryptionHeader/initializationVector") != null)
                window.crypto.iv = Convert.FromBase64String(doc.SelectSingleNode("encryptionHeader/initializationVector").InnerText);

            foreach (XmlNode user in doc.SelectNodes("encryptionHeader/allReceivers/receiver"))
            {
                var name = user.SelectSingleNode("name").InnerText;
                var encryptedKey = Convert.FromBase64String(user.SelectSingleNode("encryptedSessionKey").InnerText);
                window.decryptUsers.Add(new DecryptUser(name, encryptedKey));
            }
            window.WriteOutput("Wczytano nagłówek pliku.");
            window.WriteOutput("Długość klucza: " + window.crypto.keyLength * 8);
            window.WriteOutput("Tryb: " + window.crypto.cipherMode);
            window.WriteOutput("Rozszerzenie: " + window.crypto.extensionName);
        }
        public byte[] GetUserEncryptedPrivateKey(string name)
        {
            try
            {
                return File.ReadAllBytes("private/" + name + ".ppk");
            }
            catch (Exception e)
            {
                window.WriteOutput("Brak klucza prywatnego.");
                return null;
            }
        }
        private string GetHeader()
        {
            var fileStream = InputFile.BaseStream;
            string searchedWord = "</encryptionHeader>";
            string header = "";
            while (!header.Contains(searchedWord))
                header += (char)fileStream.ReadByte();
            return header;
        }
        public void InsertFileHeader()
        {
            Write(Encoding.Default.GetBytes("<?xml version = \"1.0\" encoding = \"UTF-8\" standalone = \"yes\" ?>"));
            var doc = new XmlDocument();
            var headerNode = doc.AppendChild(doc.CreateElement("encryptionHeader"));
            headerNode.AppendChild(doc.CreateElement("algorithm")).InnerText = "Blowfish";
            headerNode.AppendChild(doc.CreateElement("extension")).InnerText = extensionName;
            headerNode.AppendChild(doc.CreateElement("keyLength")).InnerText = (window.crypto.keyLength * 8).ToString();
            headerNode.AppendChild(doc.CreateElement("encryptionMode")).InnerText = window.crypto.cipherMode;
            if (window.crypto.subBlockLength != 0)
                headerNode.AppendChild(doc.CreateElement("subblockLength")).InnerText = (window.crypto.subBlockLength * 8).ToString();
            if (window.crypto.iv != null)
                headerNode.AppendChild(doc.CreateElement("initializationVector")).InnerText = Convert.ToBase64String(window.crypto.iv);
            var approvedUsersNode = headerNode.AppendChild(doc.CreateElement("allReceivers"));
            foreach (var user in window.receivers)
            {
                var userNode = approvedUsersNode.AppendChild(doc.CreateElement("receiver"));
                userNode.AppendChild(doc.CreateElement("name")).InnerText = user.Name;
                userNode.AppendChild(doc.CreateElement("encryptedSessionKey")).InnerText = GetEncryptedSessionKey(user);
            }
            Write(Encoding.Default.GetBytes(doc.Beautify()));
        }
        private string GetEncryptedSessionKey(User user)
        {
            var encryptedKey = window.crypto.RSAEncrypt(window.crypto.sessionKey, user.PublicKey);
            return Convert.ToBase64String(encryptedKey);
        }
        public string SetInputFile()
        {
            Stream fileStream;
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
                if ((fileStream = fileDialog.OpenFile()) != null)
                {
                    inputFileLength = fileStream.Length;
                    FileStream streamTemp = fileStream as FileStream;
                    extensionName = Path.GetExtension(streamTemp.Name);
                    InputFile = new BinaryReader(fileStream);
                    return fileDialog.FileName;
                }
            return "";
        }
        public string SetOutputFile()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                outputFilePath = fileDialog.FileName;
                return fileDialog.FileName;
            }
            return "";
        }
        public byte[] Read(int bytes)
        {
            return InputFile.ReadBytes(bytes);
        }
        public void Write(byte[] bytes)
        {
            if (bytes != null)
                OutputFile.Write(bytes);
        }
        public void OpenOutputFile()
        {
            OutputFile = new BinaryWriter(new FileStream(outputFilePath, FileMode.Create));

        }
        public void CloseFiles()
        {
            OutputFile.Close();
            OutputFile = null;
        }

    }
}
