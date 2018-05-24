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
    public partial class UsersManager : Form
    {
        private Window window;

        public UsersManager(Window window)
        {
            InitializeComponent();
            this.window = window;
            usersList.SelectionMode = SelectionMode.MultiExtended;
            receiversList.SelectionMode = SelectionMode.MultiExtended;
            usersList.DataSource = window.users;
            receiversList.DataSource = window.receivers;
        }

        private void addUserToReceivers_Click(object sender, EventArgs e)
        {
            List<User> temp;
            temp = usersList.SelectedItems.Cast<User>().ToList();
            foreach (User user in temp)
            {
                window.receivers.Add(user);
                window.users.Remove(user);
            }
        }

        private void removeUserFromReceivers_Click(object sender, EventArgs e)
        {
            List<User> temp;
            temp = receiversList.SelectedItems.Cast<User>().ToList();
            foreach (User user in temp)
            {
                window.users.Add(user);
                window.receivers.Remove(user);
            }
        }

        private void createUser_Click(object sender, EventArgs e)
        {
            (new UserCreator(window)).Show();
        }

        private void deleteUsers_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Czy na pewno chcesz usunąć wybranych użytkowników?",
                                     "Usuwanie użytkowników",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                List<User> temp;
                temp = usersList.SelectedItems.Cast<User>().ToList();
                foreach (User user in temp)
                {
                    window.users.Remove(user);
                    window.fileManager.DeleteUserFiles(user.Name);
                }

                temp = receiversList.SelectedItems.Cast<User>().ToList();
                foreach (User user in temp)
                {
                    window.receivers.Remove(user);
                    window.fileManager.DeleteUserFiles(user.Name);
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
