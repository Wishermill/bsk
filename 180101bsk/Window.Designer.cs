namespace _180101bsk
{
    partial class Window
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.keyLengthComboBox = new System.Windows.Forms.ComboBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.outputLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Zaszyfruj = new System.Windows.Forms.Button();
            this.listaOdbiorcow = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.subBlockLengthComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.Lista = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.progressBar3 = new System.Windows.Forms.ProgressBar();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(-3, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(417, 482);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(409, 456);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Szyfrowanie";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.keyLengthComboBox);
            this.groupBox2.Controls.Add(this.outputTextBox);
            this.groupBox2.Controls.Add(this.outputLabel);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.Zaszyfruj);
            this.groupBox2.Controls.Add(this.listaOdbiorcow);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.subBlockLengthComboBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 426);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ustawienia";
            // 
            // keyLengthComboBox
            // 
            this.keyLengthComboBox.FormattingEnabled = true;
            this.keyLengthComboBox.Location = new System.Drawing.Point(282, 64);
            this.keyLengthComboBox.Name = "keyLengthComboBox";
            this.keyLengthComboBox.Size = new System.Drawing.Size(86, 21);
            this.keyLengthComboBox.TabIndex = 17;
            this.keyLengthComboBox.SelectedIndexChanged += new System.EventHandler(this.keyLengthComboBox_SelectedIndexChanged);
            // 
            // outputTextBox
            // 
            this.outputTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.outputTextBox.ForeColor = System.Drawing.SystemColors.InfoText;
            this.outputTextBox.Location = new System.Drawing.Point(10, 341);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(376, 73);
            this.outputTextBox.TabIndex = 16;
            // 
            // outputLabel
            // 
            this.outputLabel.AutoSize = true;
            this.outputLabel.Location = new System.Drawing.Point(7, 326);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(47, 13);
            this.outputLabel.TabIndex = 15;
            this.outputLabel.Text = "Wyjscie:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 179);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 52);
            this.button2.TabIndex = 14;
            this.button2.Text = "Zarządzaj odbiorcami";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(311, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Wybierz plik";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(87, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(218, 20);
            this.textBox1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Plik wejsciowy";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(11, 255);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(375, 23);
            this.progressBar1.TabIndex = 10;
            // 
            // Zaszyfruj
            // 
            this.Zaszyfruj.Location = new System.Drawing.Point(8, 284);
            this.Zaszyfruj.Name = "Zaszyfruj";
            this.Zaszyfruj.Size = new System.Drawing.Size(378, 39);
            this.Zaszyfruj.TabIndex = 9;
            this.Zaszyfruj.Text = "Zaszyfruj";
            this.Zaszyfruj.UseVisualStyleBackColor = true;
            this.Zaszyfruj.Click += new System.EventHandler(this.Zaszyfruj_Click);
            // 
            // listaOdbiorcow
            // 
            this.listaOdbiorcow.FormattingEnabled = true;
            this.listaOdbiorcow.Location = new System.Drawing.Point(108, 162);
            this.listaOdbiorcow.Name = "listaOdbiorcow";
            this.listaOdbiorcow.Size = new System.Drawing.Size(278, 69);
            this.listaOdbiorcow.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Odbiorcy";
            // 
            // subBlockLengthComboBox
            // 
            this.subBlockLengthComboBox.Enabled = false;
            this.subBlockLengthComboBox.FormattingEnabled = true;
            this.subBlockLengthComboBox.Items.AddRange(new object[] {
            "2",
            "4",
            "8",
            "16",
            "32",
            "64"});
            this.subBlockLengthComboBox.Location = new System.Drawing.Point(155, 64);
            this.subBlockLengthComboBox.Name = "subBlockLengthComboBox";
            this.subBlockLengthComboBox.Size = new System.Drawing.Size(90, 21);
            this.subBlockLengthComboBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(279, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Dlugosc klucza";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(152, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Dlugosc podbloku";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton4);
            this.groupBox3.Controls.Add(this.radioButton3);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Location = new System.Drawing.Point(8, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(128, 111);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tryb szyfrowania";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 88);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(46, 17);
            this.radioButton4.TabIndex = 3;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "OFB";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(45, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "CFB";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(46, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "CBC";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(46, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "ECB";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(409, 456);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Deszyfrowanie";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Controls.Add(this.textBox7);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.progressBar2);
            this.groupBox5.Controls.Add(this.textBox8);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.button5);
            this.groupBox5.Controls.Add(this.Lista);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Location = new System.Drawing.Point(3, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(400, 423);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Ustawienia";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(314, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 18;
            this.button4.Text = "Wybierz plik";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(90, 16);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(218, 20);
            this.textBox7.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Plik wejsciowy";
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(11, 235);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(375, 23);
            this.progressBar2.TabIndex = 12;
            this.progressBar2.Click += new System.EventHandler(this.progressBar2_Click);
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(48, 166);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(289, 20);
            this.textBox8.TabIndex = 11;
            this.textBox8.UseSystemPasswordChar = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 169);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Haslo";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(8, 264);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(378, 57);
            this.button5.TabIndex = 9;
            this.button5.Text = "Deszyfruj";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // Lista
            // 
            this.Lista.FormattingEnabled = true;
            this.Lista.Location = new System.Drawing.Point(11, 62);
            this.Lista.Name = "Lista";
            this.Lista.Size = new System.Drawing.Size(326, 95);
            this.Lista.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Wybierz osobe deszyfrujaca";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(409, 456);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Odbiorcy";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.progressBar3);
            this.groupBox6.Controls.Add(this.button6);
            this.groupBox6.Controls.Add(this.textBox9);
            this.groupBox6.Controls.Add(this.textBox10);
            this.groupBox6.Controls.Add(this.textBox11);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Location = new System.Drawing.Point(3, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(400, 423);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Plik";
            // 
            // progressBar3
            // 
            this.progressBar3.Location = new System.Drawing.Point(11, 108);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(375, 23);
            this.progressBar3.TabIndex = 12;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(11, 137);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(383, 57);
            this.button6.TabIndex = 11;
            this.button6.Text = "Generuj klucz";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(90, 77);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(218, 20);
            this.textBox9.TabIndex = 10;
            this.textBox9.UseSystemPasswordChar = true;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(90, 47);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(218, 20);
            this.textBox10.TabIndex = 9;
            this.textBox10.UseSystemPasswordChar = true;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(90, 16);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(218, 20);
            this.textBox11.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Powtorz haslo";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 47);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Haslo";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Osoba";
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 457);
            this.Controls.Add(this.tabControl1);
            this.Name = "Window";
            this.Text = "grupa 11 149481 149385";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Zaszyfruj;
        private System.Windows.Forms.ListBox listaOdbiorcow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox subBlockLengthComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ListBox Lista;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.ComboBox keyLengthComboBox;
    }
}

