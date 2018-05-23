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
            //decryptUsersList.DataSource = decryptUsers;
            //subBlockLengthComboBox.SelectedIndex = -1;
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

            //modeComboBox.DataSource = config.Mode;
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void progressBar2_Click(object sender, EventArgs e)
        {
            //mozna usunac, ale to trzeba w 2-3 miejscach - to na koniec zrobie
        }


        //tworzenie uzytkownika
        private void button6_Click(object sender, EventArgs e)
        {
            //if (validUserCreation()) //dopoki nie oddajemy, latwiej testowac //ktj
            {
                //textBox11 = osoba, 10=9=haslo
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
                BufferedBlockCipher mode = new PaddedBufferedBlockCipher(algorithm); //ecb
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

                /*
                for (int i = 0; i < privateCopy.Length; i++)
                {
                    privateKeyHashed[i] = (byte)(privateCopy[i] ^ passHS[i % 32]);
                }
                
                FileStream filePrK = new FileStream(PrKpath + "\\" + textBox11.Text + ".prkey", FileMode.CreateNew, FileAccess.Write, FileShare.None);
                filePrK.Write(privateKeyHashed, 0, privateKeyHashed.Length);
                filePrK.Close();
                
                //^to jest nieprawidlowa metoda^ //ktj
                */
                System.IO.StreamWriter filePbK = new System.IO.StreamWriter(PbKpath + "\\" + textBox11.Text + ".pbkey");
                filePbK.WriteLine("<?xml version=\"1.0\"?>");
                filePbK.WriteLine("<pbKey>");
                filePbK.WriteLine("<\t<Name>" + textBox11.Text + "</Name>");
                filePbK.WriteLine("<\t<E>" + Convert.ToBase64String(publicKey.Exponent) + "</E>");
                filePbK.WriteLine("<\t<M>" + Convert.ToBase64String(publicKey.Modulus) + "</M>");
                filePbK.WriteLine("</pbKey>");
                filePbK.Close();
                
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
        //not implemented, sprawdzenie czy wszystko wypelnione jak trzeba - do szyfrowania
        private bool validEncryption()
        {
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
        //not implemented, sprawdzenie czy wszystko wypelnione jak trzeba - do deszyfrowania
        private bool validDecryption()
        {
            return true;
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
            users.Add(user);
            fileManager.SaveUser(user, encryptedPrivateKey, keys.pemPublicKey);
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

/*
szyfrowanie z rok temu Twofish
if (sprawdzenie_bledow_przy_szyfrowaniu()==true)
            {
                AesCryptoServiceProvider klucz = new AesCryptoServiceProvider();
                klucz.KeySize = dlugoscKlucza;
                klucz.GenerateKey();
                TwofishEngine algorytm = new TwofishEngine();
                int a = algorytm.GetBlockSize();
                KeyParameter parametrklucza = new KeyParameter(klucz.Key);
                algorytm.Init(true, parametrklucza);
                BufferedBlockCipher tryb = null;
                if (trybSzyfrowania == "ECB")
                {
                    tryb = new PaddedBufferedBlockCipher(algorytm);
                }
                else if (trybSzyfrowania == "CBC")
                {
                    tryb = new PaddedBufferedBlockCipher(new CbcBlockCipher(algorytm));
                }
                else if (trybSzyfrowania == "CFB")
                {
                    tryb = new PaddedBufferedBlockCipher(new CfbBlockCipher(algorytm, dlugoscPodbloku));
                }
                else if (trybSzyfrowania == "OFB")
                {
                    tryb = new PaddedBufferedBlockCipher(new OfbBlockCipher(algorytm, dlugoscPodbloku));
                }

                tryb.Init(true, parametrklucza);
                FileStream plikOrginalny = new FileStream(sciezkaDoPlikuSzyfrowanego, FileMode.Open, FileAccess.Read);
                long wielkosc = plikOrginalny.Length;
                byte[] wiadomosc = new byte[wielkosc];
                plikOrginalny.Read(wiadomosc, 0, Convert.ToInt32(wielkosc));
                plikOrginalny.Close();

                System.IO.StreamWriter plikszyfrowany = new System.IO.StreamWriter(sciezkaDoZapisuPlikuSzyfrowanego + "\\" + nazwaPlikuSzyfrowanego );
                byte[] wiadomoscPelna = new byte[tryb.GetOutputSize(wiadomosc.Length) + 8];
                Buffer.BlockCopy(wiadomosc, 0, wiadomoscPelna, 0, wiadomosc.Length);

                byte[] byteArray = BitConverter.GetBytes(tryb.GetOutputSize(wiadomosc.Length) - wielkosc + 1);
                wiadomoscPelna[wiadomoscPelna.Length - 1] = byteArray[0];


                byte[] zaszyfrowaneDane = new byte[tryb.GetOutputSize(wiadomoscPelna.Length)];

                int rozmiar = tryb.ProcessBytes(wiadomoscPelna, 0, wiadomoscPelna.Length, zaszyfrowaneDane, 0);
                tryb.DoFinal(zaszyfrowaneDane, rozmiar);
                string shortVI = Convert.ToBase64String(klucz.IV, 0, 16);

                plikszyfrowany.WriteLine("<?xml version=\"1.0\"?>");
                plikszyfrowany.WriteLine("<EncryptedFile>");
                plikszyfrowany.WriteLine("\t<NameAlgorithm>Twofish</NameAlgorithm>");
                plikszyfrowany.WriteLine("\t<CipherMode>" + trybSzyfrowania + "</CipherMode>");
                if (trybSzyfrowania == "CFB" || trybSzyfrowania == "OFB")
                    plikszyfrowany.WriteLine("\t<SegmentSize>" + dlugoscPodbloku + "</SegmentSize>");
                plikszyfrowany.WriteLine("\t<KeySize>" + dlugoscKlucza + "</KeySize>");
                plikszyfrowany.WriteLine("\t<IV>" + shortVI + "</IV>");
                plikszyfrowany.WriteLine("\t<ApprovedUsers>");

                foreach (Uzytkownicy user in users)
                {
                    plikszyfrowany.WriteLine("\t\t<User>");
                    RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(2048);
                    RSAParameters publicznyKlucz = RSA.ExportParameters(false);
                    publicznyKlucz.Exponent = Convert.FromBase64String(user.E);
                    publicznyKlucz.Modulus = Convert.FromBase64String(user.modul);
                    RSA = new RSACryptoServiceProvider();
                    RSA.ImportParameters(publicznyKlucz);
                    byte[] szyfrowanyKlucz = RSA.Encrypt(klucz.Key, false);
                    string skonwertowanySzyfrowanyKlucz = Convert.ToBase64String(szyfrowanyKlucz);
                    plikszyfrowany.WriteLine("\t\t\t<Nick>" + user.nick + "</Nick>");
                    plikszyfrowany.WriteLine("\t\t\t<SessionKey>" + skonwertowanySzyfrowanyKlucz + "</SessionKey>");
                    plikszyfrowany.WriteLine("\t\t</User>");
                }
                foreach (Uzytkownicy user in userImport)
                {
                    plikszyfrowany.WriteLine("\t\t<UserImport>");
                    RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(2048);
                    RSAParameters publicznyKlucz = RSA.ExportParameters(false);
                    publicznyKlucz.Exponent = Convert.FromBase64String(user.E);
                    publicznyKlucz.Modulus = Convert.FromBase64String(user.modul);
                    RSA = new RSACryptoServiceProvider();
                    RSA.ImportParameters(publicznyKlucz);
                    byte[] szyfrowanyKlucz = RSA.Encrypt(klucz.Key, false);
                    string skonwertowanySzyfrowanyKlucz = Convert.ToBase64String(szyfrowanyKlucz);
                    plikszyfrowany.WriteLine("\t\t\t<Nick>" + user.nick + "</Nick>");
                    plikszyfrowany.WriteLine("\t\t\t<SessionKey>" + skonwertowanySzyfrowanyKlucz + "</SessionKey>");
                    plikszyfrowany.WriteLine("\t\t</UserImport>");
                }
                plikszyfrowany.WriteLine("\t</ApprovedUsers>");
                plikszyfrowany.WriteLine("</EncryptedFile>");
                plikszyfrowany.Close();
                FileStream szyfrowanyStrumien = new FileStream(sciezkaDoZapisuPlikuSzyfrowanego + "\\" + nazwaPlikuSzyfrowanego , FileMode.Append, FileAccess.Write, FileShare.None);
                szyfrowanyStrumien.Write(zaszyfrowaneDane, 0, zaszyfrowaneDane.Length);
                szyfrowanyStrumien.Close();
                wynikiOperacji.Text="Udało się pomyślnie zaszyfrować plik";
                if (messageBoxy.Checked)
                {
                    MessageBox.Show("Udało się pomyślnie zaszyfrować plik");
                }
                textBox_plik_wej_szyfrowanie.Text = "";
                textBox_plik_wyj_szyfrowanie.Text = "";
                textBox2.Text = "";
                wynikiBledow.Text = "";
                Odbiorcy.Items.Clear();
                users.Clear();
                userImport.Clear();
            }

*/