using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _180101bsk
{
    public partial class UserCreator : Form
    {
        private Window window;
        public UserCreator(Window window)
        {
            this.window = window;
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (userName.Text == "")
            {
                MessageBox.Show("Nieprawidlowa nazwa uzytkownika");
            }
            else if (passwordTextBox.Text == "")
            {
                MessageBox.Show("Wprowadz haslo");
            }
            else if (passwordTextBox.TextLength < 7)
            {
                MessageBox.Show("Haslo musi miec co najmniej 8 znakow, w tym chociaz: 1 cyfre, 1 litere, 1 znak specjalny");
            }
            else if (passwordTextBox.Text != confirmPasswordTextBox.Text)
            {
                MessageBox.Show("Haslo powtorzone jest bledne");
            }
            else {
                string illegalChars = @"^(?!^(PRN|AUX|CLOCK\$|NUL|CON|COM\d|LPT\d|\..*)(\..+)?$)[^\x00-\x1f\\?*:\"";|/]+$";
                bool isValidName = Regex.IsMatch(userName.Text, illegalChars, RegexOptions.CultureInvariant);
                int a, b, c;
                a = b = c = 0;
                var regexA = new Regex("[a-zA-Z]+");
                var regexB = new Regex("[0-9]+");
                string tak = passwordTextBox.Text;
                c = passwordTextBox.Text.Count(p => !char.IsLetterOrDigit(p));
                if (regexA.IsMatch(passwordTextBox.Text)) a++;
                if (regexB.IsMatch(passwordTextBox.Text)) b++;
                if (a == 0 || b == 0 || c == 0)
                {
                    MessageBox.Show("Haslo musi miec chociaz 1 cyfre, 1 litere i 1 znak specjalny");
                }
                else if (!isValidName)
                {
                    MessageBox.Show("Nazwa uzytkownika nie moze miec takich znakow jak \\ / : * ? \" < > |");
                }
                else
                {
                    window.AddUser(userName.Text, passwordTextBox.Text);
                    Close();
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
