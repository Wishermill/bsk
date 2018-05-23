namespace _180101bsk
{
    partial class UsersManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addUserToReceivers = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.usersList = new System.Windows.Forms.ListBox();
            this.removeUserFromReceivers = new System.Windows.Forms.Button();
            this.receiversList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.createUser = new System.Windows.Forms.Button();
            this.deleteUsers = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addUserToReceivers
            // 
            this.addUserToReceivers.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addUserToReceivers.Location = new System.Drawing.Point(228, 25);
            this.addUserToReceivers.Name = "addUserToReceivers";
            this.addUserToReceivers.Size = new System.Drawing.Size(50, 60);
            this.addUserToReceivers.TabIndex = 5;
            this.addUserToReceivers.Text = "⇛";
            this.addUserToReceivers.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Użytkownicy";
            // 
            // usersList
            // 
            this.usersList.FormattingEnabled = true;
            this.usersList.Location = new System.Drawing.Point(12, 25);
            this.usersList.Name = "usersList";
            this.usersList.Size = new System.Drawing.Size(210, 160);
            this.usersList.TabIndex = 10;
            // 
            // removeUserFromReceivers
            // 
            this.removeUserFromReceivers.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold);
            this.removeUserFromReceivers.Location = new System.Drawing.Point(228, 125);
            this.removeUserFromReceivers.Name = "removeUserFromReceivers";
            this.removeUserFromReceivers.Size = new System.Drawing.Size(50, 60);
            this.removeUserFromReceivers.TabIndex = 11;
            this.removeUserFromReceivers.Text = "⇚ ";
            this.removeUserFromReceivers.UseVisualStyleBackColor = true;
            // 
            // receiversList
            // 
            this.receiversList.FormattingEnabled = true;
            this.receiversList.Location = new System.Drawing.Point(284, 25);
            this.receiversList.Name = "receiversList";
            this.receiversList.Size = new System.Drawing.Size(210, 160);
            this.receiversList.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Odbiorcy szyfrogramu";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(500, 25);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(140, 35);
            this.okButton.TabIndex = 14;
            this.okButton.Text = "Zatwierdź";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // createUser
            // 
            this.createUser.Location = new System.Drawing.Point(500, 66);
            this.createUser.Name = "createUser";
            this.createUser.Size = new System.Drawing.Size(140, 35);
            this.createUser.TabIndex = 15;
            this.createUser.Text = "Stwórz użytkownika";
            this.createUser.UseVisualStyleBackColor = true;
            // 
            // deleteUsers
            // 
            this.deleteUsers.Location = new System.Drawing.Point(500, 107);
            this.deleteUsers.Name = "deleteUsers";
            this.deleteUsers.Size = new System.Drawing.Size(140, 35);
            this.deleteUsers.TabIndex = 16;
            this.deleteUsers.Text = "Usuń zaznaczonych";
            this.deleteUsers.UseVisualStyleBackColor = true;
            // 
            // UsersManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 201);
            this.Controls.Add(this.deleteUsers);
            this.Controls.Add(this.createUser);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.receiversList);
            this.Controls.Add(this.removeUserFromReceivers);
            this.Controls.Add(this.usersList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addUserToReceivers);
            this.Name = "UsersManager";
            this.Text = "UsersManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addUserToReceivers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox usersList;
        private System.Windows.Forms.Button removeUserFromReceivers;
        private System.Windows.Forms.ListBox receiversList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button createUser;
        private System.Windows.Forms.Button deleteUsers;
    }
}