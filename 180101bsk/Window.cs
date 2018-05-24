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

        private string PbKpath = "..\\..\\..\\publick";
        private string PrKpath = "..\\..\\..\\privatek";
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

        private void Zaszyfruj_Click(object sender, EventArgs e) //linijki55-58 xd
        {
            if (validEncryption())
            {
                string nazwaDocelowa = "";
                SaveFileDialog okienko = new SaveFileDialog();
                //okienko.Filter = "Pliki textowe (txt)|*.txt"; //nie jest podane ze musza byc txt, na razie zostawie bez rozszerzenia s4 //ktj
                if (okienko.ShowDialog() == DialogResult.OK)
                {
                    nazwaDocelowa = okienko.FileName;
                    fileManager.outputFilePath = okienko.FileName;
                }

                crypto.cipherMode = cipherMode;
                crypto.StartEncryption();
                textBox1.Text = "";
                //algorithm.Init - true = szyfrowanie, false = deszyfrowanie
                //textbox1 = wczytany plik
                //comboBox2.Text = zaznaczony tryb
                //textBox1 = szyfrowany
                //textBox4=64 (32-448) - bo mieliśmy sobie wybrać, chwilowo 64, best (ze wzgl na bezpieczenstwo,
                // nie latwosc) 448 chyba :P s2+pytalem o to przy oddawaniu interfejsu //ktj
                /*
                na samym dole wzor
                do klucza sesyjnego to nizej, tak mi sie wydaje, ale nie jestem pewien, to musze ogarnac jeszcze //ktj
                tak na 90% jestem pewien ze to generowanie klucza sesyjnego //ktj
                AesCryptoServiceProvider klucz = new AesCryptoServiceProvider();
                klucz.KeySize = dlugoscKlucza;
                klucz.GenerateKey();
                */
                //BlowfishEngine algorithm = new BlowfishEngine();
                //int temp = algorithm.GetBlockSize(); //64b
                //KeyParameter parameter = null; //tu nie jestem pewien jak zrobić, chyba wczesniej klucz sesyjny i jazda //ktj
                //probably KeyParameter parameter = new KeyParameter(klucz.Key);
                //algorithm.Init(true, parameter);

                //BufferedBlockCipher mode = null;
                //if (cipherMode == "ECB")
                //{
                //    mode = new PaddedBufferedBlockCipher(algorithm);
                //}
                //else if (cipherMode == "CBC")
                //{
                //    mode = new PaddedBufferedBlockCipher(new CbcBlockCipher(algorithm));
                //}
                //else if (cipherMode == "CFB")
                //{
                //    mode = new PaddedBufferedBlockCipher(new CfbBlockCipher(algorithm, Int32.Parse(subBlockLengthComboBox.Text))); //chyba potem zmienie by do zmiennej to pakowac //ktj
                //}
                //else if (cipherMode == "OFB")
                //{
                //    mode = new PaddedBufferedBlockCipher(new OfbBlockCipher(algorithm, Int32.Parse(subBlockLengthComboBox.Text)));
                //}
                //mode.Init(true, parameter);
                //FileStream fileToCipher = new FileStream(textBox1.Text, FileMode.Open, FileAccess.Read); //co wczytalismy to textbox1

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

        /*
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
        */
        //not implemented, sprawdzenie czy wszystko wypelnione jak trzeba - do szyfrowania
        private bool validEncryption()
        {
            if (textBox1.Text == "")
            {
                WriteOutput("Nie mozna otworzyc pliku.");
                return false;
            }
            return true;
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
        //przyciski do trybu
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
            receivers.Clear();
            decryptUsers.Clear();
            progressBar1.Value = 0;
            progressBar2.Value = 0;
        }

        private void outputLabel_Click(object sender, EventArgs e)
        {

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