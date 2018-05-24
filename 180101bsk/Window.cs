using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
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

/*
  do zapytania - czy uzytkownik ma wybierac dlugosc podbloku dla OFB i CFB
  czy mamy sami ja narzucic?
  przy okazji jeszcze raz zapytam o wielkosc klucza
  //ktj
 */

namespace _180101bsk
{
    public partial class Window : Form
    {
        public FileManager fileManager;
        public CryptoEngine crypto;
        public Config config;
        public BindingList<User> users;
        public BindingList<User> receivers;
        public BindingList<DecryptUser> decryptUsers;

        private string cipherMode = "ECB";

        public Window()
        {
            InitializeComponent();
            fileManager = new FileManager(this);
            crypto = new CryptoEngine(this, fileManager);
            config = new Config();
            users = new BindingList<User>();
            receivers = new BindingList<User>();
            decryptUsers = new BindingList<DecryptUser>();
            fileManager.LoadConfig();
            fileManager.LoadUsers();
            InitComboBoxesValues();
            listaOdbiorcow.DataSource = receivers;
            Lista.DataSource = decryptUsers;
        }

        public void WriteOutput(string text)
        {
            outputTextBox.AppendText(text + "\n");
        }

        public void UpdateProgress(int progress)
        {
            progressBar1.Value = progress;
        }

        private void InitComboBoxesValues()
        {
            keyLengthComboBox.DataSource = config.KeyLength;
            subBlockLengthComboBox.DataSource = config.SubBlockLength;
            crypto.subBlockLength = 1;
        }

        private void keyLengthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            crypto.keyLength = int.Parse(keyLengthComboBox.SelectedValue.ToString()) / 8;
        }

        private void subBlockLengthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (subBlockLengthComboBox.Enabled)
                crypto.subBlockLength = int.Parse(subBlockLengthComboBox.SelectedValue.ToString()) / 8;
            else
                crypto.subBlockLength = 1;
        }

        private void Zaszyfruj_Click(object sender, EventArgs e)
        {
            string nazwaDocelowa = "";
            SaveFileDialog okienko = new SaveFileDialog();
            if (okienko.ShowDialog() == DialogResult.OK)
            {
                nazwaDocelowa = okienko.FileName;
                fileManager.outputFilePath = okienko.FileName;
            }

            crypto.cipherMode = cipherMode;
            crypto.StartEncryption();
            textBox1.Text = "";
        }

        //Dekryptowanie 
        private void button5_Click(object sender, EventArgs e)
        {
            string nazwaDocelowa = "";
            SaveFileDialog okienko = new SaveFileDialog();
            if (okienko.ShowDialog() == DialogResult.OK)
            {
                nazwaDocelowa = okienko.FileName;
                fileManager.outputFilePath = okienko.FileName;
            }


            if (fileManager.InputFile == null)
            {
                WriteOutput("Brak pliku wejściowego.");
                return;
            }
            if (fileManager.outputFilePath == "")
            {
                WriteOutput("Nie ustalono pliku wyjściowego.");
                return;
            }
            if (fileManager.InputFile.BaseStream.Position == 0)
            {
                WriteOutput("Niepoprawny plik.");
                return;
            }
            crypto.password = textBox8.Text;
            try
            {
                crypto.StartDecryption(decryptUsers.ElementAt(Lista.SelectedIndex));
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ClearAll();
            }
            WriteOutput("Zakończono");
            textBox8.Text = "";
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {
            //mozna usunac, ale to trzeba w 2-3 miejscach - to na koniec zrobie
        }

        //wybierz plik do szyfrowania
        private void button1_Click(object sender, EventArgs e)
        {
            if (fileManager.InputFile != null)
                fileManager.InputFile.Close();
            decryptUsers.Clear();
            try
            {
                textBox1.Text = fileManager.SetInputFile();
            }
            catch (Exception ex)
            {
                WriteOutput("Nie można otworzyć pliku.");
                return;
            }

            fileManager.TryParseFileHeader();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cipherMode = "ECB";
            subBlockLengthComboBox.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            cipherMode = "CBC";
            subBlockLengthComboBox.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            cipherMode = "CFB";
            subBlockLengthComboBox.Enabled = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            cipherMode = "OFB";
            subBlockLengthComboBox.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (new UsersManager(this)).Show();
        }

        public void AddUser(string name, string password)
        {
            byte[] hash = crypto.Sha256(password);
            KeyPair keys = crypto.GetKeyPair();
            byte[] encryptedPrivateKey = crypto.QuickEncrypt(Encoding.Default.GetBytes(keys.pemPrivateKey), hash);
            var user = new User(name, keys.publicKey);
            fileManager.SaveUser(user, encryptedPrivateKey, keys.pemPublicKey);
        }

        private void ClearAll()
        {
            if (receivers.Any())
            {
                foreach (User user in receivers)
                {
                    users.Add(user);
                }
                receivers.Clear();
            }
            decryptUsers.Clear();
            progressBar1.Value = 0;
            progressBar2.Value = 0;
        }
    }

    public class DecryptUser
    {
        public string Name { get; set; }
        public byte[] EncryptedKey { get; set; }
        public DecryptUser(string name, byte[] encrtyptedKey)
        {
            Name = name;
            EncryptedKey = encrtyptedKey;
        }
        public override string ToString()
        {
            return Name;
        }
    }

    public class User
    {
        public string Name { get; set; }
        public byte[] PublicKey { get; set; }
        public User(string name, byte[] publicKey)
        {
            Name = name;
            PublicKey = publicKey;
        }
        public override string ToString()
        {
            return Name;
        }
    }

    public class KeyPair
    {
        public byte[] publicKey;
        public byte[] privateKey;
        public string pemPublicKey;
        public string pemPrivateKey;
    }

    public class Config
    {
        public List<int> KeyLength { get; set; }
        public List<int> BlockLength { get; set; }
        public List<int> SubBlockLength { get; set; }
        public List<string> Mode { get; set; }
    }
}