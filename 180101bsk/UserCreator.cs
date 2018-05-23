using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (passwordTextBox.Text == confirmPasswordTextBox.Text)
            {
                window.AddUser(userName.Text, passwordTextBox.Text);
                Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
