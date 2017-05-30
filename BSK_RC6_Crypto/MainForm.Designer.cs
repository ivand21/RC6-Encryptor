namespace BSK_RC6_Crypto
{
    partial class MainForm
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
            this.tabDecryption = new System.Windows.Forms.TabPage();
            this.lblDecProgress = new System.Windows.Forms.Label();
            this.btnCancelDecrypt = new System.Windows.Forms.Button();
            this.gbDecFiles = new System.Windows.Forms.GroupBox();
            this.lblDecOutputPath = new System.Windows.Forms.Label();
            this.lblDecInputPath = new System.Windows.Forms.Label();
            this.btnDecInputFile = new System.Windows.Forms.Button();
            this.btnDecOutputFile = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.gbDecKeys = new System.Windows.Forms.GroupBox();
            this.lbUsersAllowed = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.pbDecryption = new System.Windows.Forms.ProgressBar();
            this.label6 = new System.Windows.Forms.Label();
            this.tabEncryption = new System.Windows.Forms.TabPage();
            this.lblEncProgress = new System.Windows.Forms.Label();
            this.btnCancelEncrypt = new System.Windows.Forms.Button();
            this.gbFiles = new System.Windows.Forms.GroupBox();
            this.lblOutputPath = new System.Windows.Forms.Label();
            this.lblInputPath = new System.Windows.Forms.Label();
            this.btnInputFile = new System.Windows.Forms.Button();
            this.btnOutputFile = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.gbKeys = new System.Windows.Forms.GroupBox();
            this.btnRemoveKey = new System.Windows.Forms.Button();
            this.btnAddKey = new System.Windows.Forms.Button();
            this.lbKeys = new System.Windows.Forms.ListBox();
            this.pbEncryption = new System.Windows.Forms.ProgressBar();
            this.lblEncState = new System.Windows.Forms.Label();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSubblockLength = new System.Windows.Forms.Label();
            this.lblKeyLength = new System.Windows.Forms.Label();
            this.cbSubblockLength = new System.Windows.Forms.ComboBox();
            this.cbKeyLength = new System.Windows.Forms.ComboBox();
            this.lblMode = new System.Windows.Forms.Label();
            this.cbMode = new System.Windows.Forms.ComboBox();
            this.tcMenu = new System.Windows.Forms.TabControl();
            this.tabDecryption.SuspendLayout();
            this.gbDecFiles.SuspendLayout();
            this.gbDecKeys.SuspendLayout();
            this.tabEncryption.SuspendLayout();
            this.gbFiles.SuspendLayout();
            this.gbKeys.SuspendLayout();
            this.gbSettings.SuspendLayout();
            this.tcMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDecryption
            // 
            this.tabDecryption.Controls.Add(this.lblDecProgress);
            this.tabDecryption.Controls.Add(this.btnCancelDecrypt);
            this.tabDecryption.Controls.Add(this.gbDecFiles);
            this.tabDecryption.Controls.Add(this.btnDecrypt);
            this.tabDecryption.Controls.Add(this.gbDecKeys);
            this.tabDecryption.Controls.Add(this.pbDecryption);
            this.tabDecryption.Controls.Add(this.label6);
            this.tabDecryption.Location = new System.Drawing.Point(4, 22);
            this.tabDecryption.Margin = new System.Windows.Forms.Padding(2);
            this.tabDecryption.Name = "tabDecryption";
            this.tabDecryption.Padding = new System.Windows.Forms.Padding(2);
            this.tabDecryption.Size = new System.Drawing.Size(452, 479);
            this.tabDecryption.TabIndex = 2;
            this.tabDecryption.Text = "Deszyfrowanie";
            this.tabDecryption.UseVisualStyleBackColor = true;
            // 
            // lblDecProgress
            // 
            this.lblDecProgress.AutoSize = true;
            this.lblDecProgress.Location = new System.Drawing.Point(61, 366);
            this.lblDecProgress.Name = "lblDecProgress";
            this.lblDecProgress.Size = new System.Drawing.Size(68, 13);
            this.lblDecProgress.TabIndex = 11;
            this.lblDecProgress.Text = "Oczekiwanie";
            this.lblDecProgress.Visible = false;
            // 
            // btnCancelDecrypt
            // 
            this.btnCancelDecrypt.Enabled = false;
            this.btnCancelDecrypt.Location = new System.Drawing.Point(234, 426);
            this.btnCancelDecrypt.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelDecrypt.Name = "btnCancelDecrypt";
            this.btnCancelDecrypt.Size = new System.Drawing.Size(194, 29);
            this.btnCancelDecrypt.TabIndex = 10;
            this.btnCancelDecrypt.Text = "Anuluj";
            this.btnCancelDecrypt.UseVisualStyleBackColor = true;
            this.btnCancelDecrypt.Click += new System.EventHandler(this.btnCancelDecrypt_Click);
            // 
            // gbDecFiles
            // 
            this.gbDecFiles.Controls.Add(this.lblDecOutputPath);
            this.gbDecFiles.Controls.Add(this.lblDecInputPath);
            this.gbDecFiles.Controls.Add(this.btnDecInputFile);
            this.gbDecFiles.Controls.Add(this.btnDecOutputFile);
            this.gbDecFiles.Location = new System.Drawing.Point(26, 22);
            this.gbDecFiles.Margin = new System.Windows.Forms.Padding(2);
            this.gbDecFiles.Name = "gbDecFiles";
            this.gbDecFiles.Padding = new System.Windows.Forms.Padding(2);
            this.gbDecFiles.Size = new System.Drawing.Size(402, 88);
            this.gbDecFiles.TabIndex = 9;
            this.gbDecFiles.TabStop = false;
            this.gbDecFiles.Text = "Pliki";
            // 
            // lblDecOutputPath
            // 
            this.lblDecOutputPath.AutoSize = true;
            this.lblDecOutputPath.Location = new System.Drawing.Point(198, 61);
            this.lblDecOutputPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDecOutputPath.Name = "lblDecOutputPath";
            this.lblDecOutputPath.Size = new System.Drawing.Size(16, 13);
            this.lblDecOutputPath.TabIndex = 10;
            this.lblDecOutputPath.Text = "...";
            // 
            // lblDecInputPath
            // 
            this.lblDecInputPath.AutoSize = true;
            this.lblDecInputPath.Location = new System.Drawing.Point(198, 37);
            this.lblDecInputPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDecInputPath.Name = "lblDecInputPath";
            this.lblDecInputPath.Size = new System.Drawing.Size(16, 13);
            this.lblDecInputPath.TabIndex = 8;
            this.lblDecInputPath.Text = "...";
            // 
            // btnDecInputFile
            // 
            this.btnDecInputFile.Location = new System.Drawing.Point(15, 35);
            this.btnDecInputFile.Margin = new System.Windows.Forms.Padding(2);
            this.btnDecInputFile.Name = "btnDecInputFile";
            this.btnDecInputFile.Size = new System.Drawing.Size(178, 19);
            this.btnDecInputFile.TabIndex = 9;
            this.btnDecInputFile.Text = "Wybierz plik wejściowy";
            this.btnDecInputFile.UseVisualStyleBackColor = true;
            this.btnDecInputFile.Click += new System.EventHandler(this.btnInputFile_Click);
            // 
            // btnDecOutputFile
            // 
            this.btnDecOutputFile.Location = new System.Drawing.Point(15, 58);
            this.btnDecOutputFile.Margin = new System.Windows.Forms.Padding(2);
            this.btnDecOutputFile.Name = "btnDecOutputFile";
            this.btnDecOutputFile.Size = new System.Drawing.Size(178, 19);
            this.btnDecOutputFile.TabIndex = 0;
            this.btnDecOutputFile.Text = "Lokalizacja pliku wynikowego...";
            this.btnDecOutputFile.UseVisualStyleBackColor = true;
            this.btnDecOutputFile.Click += new System.EventHandler(this.btnOutputFile_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(26, 426);
            this.btnDecrypt.Margin = new System.Windows.Forms.Padding(2);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(194, 29);
            this.btnDecrypt.TabIndex = 3;
            this.btnDecrypt.Text = "Deszyfruj";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // gbDecKeys
            // 
            this.gbDecKeys.Controls.Add(this.lbUsersAllowed);
            this.gbDecKeys.Controls.Add(this.label7);
            this.gbDecKeys.Controls.Add(this.label3);
            this.gbDecKeys.Controls.Add(this.tbPassword);
            this.gbDecKeys.Location = new System.Drawing.Point(26, 136);
            this.gbDecKeys.Margin = new System.Windows.Forms.Padding(2);
            this.gbDecKeys.Name = "gbDecKeys";
            this.gbDecKeys.Padding = new System.Windows.Forms.Padding(2);
            this.gbDecKeys.Size = new System.Drawing.Size(402, 220);
            this.gbDecKeys.TabIndex = 8;
            this.gbDecKeys.TabStop = false;
            this.gbDecKeys.Text = "Klucz prywatny";
            // 
            // lbUsersAllowed
            // 
            this.lbUsersAllowed.FormattingEnabled = true;
            this.lbUsersAllowed.Location = new System.Drawing.Point(164, 31);
            this.lbUsersAllowed.Margin = new System.Windows.Forms.Padding(2);
            this.lbUsersAllowed.Name = "lbUsersAllowed";
            this.lbUsersAllowed.Size = new System.Drawing.Size(225, 108);
            this.lbUsersAllowed.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 31);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Odbiorca:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 177);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Hasło:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(164, 170);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(225, 20);
            this.tbPassword.TabIndex = 0;
            // 
            // pbDecryption
            // 
            this.pbDecryption.Location = new System.Drawing.Point(26, 391);
            this.pbDecryption.Margin = new System.Windows.Forms.Padding(2);
            this.pbDecryption.Name = "pbDecryption";
            this.pbDecryption.Size = new System.Drawing.Size(402, 19);
            this.pbDecryption.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 367);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Stan:";
            // 
            // tabEncryption
            // 
            this.tabEncryption.Controls.Add(this.lblEncProgress);
            this.tabEncryption.Controls.Add(this.btnCancelEncrypt);
            this.tabEncryption.Controls.Add(this.gbFiles);
            this.tabEncryption.Controls.Add(this.btnEncrypt);
            this.tabEncryption.Controls.Add(this.gbKeys);
            this.tabEncryption.Controls.Add(this.pbEncryption);
            this.tabEncryption.Controls.Add(this.lblEncState);
            this.tabEncryption.Controls.Add(this.gbSettings);
            this.tabEncryption.Location = new System.Drawing.Point(4, 22);
            this.tabEncryption.Margin = new System.Windows.Forms.Padding(2);
            this.tabEncryption.Name = "tabEncryption";
            this.tabEncryption.Padding = new System.Windows.Forms.Padding(2);
            this.tabEncryption.Size = new System.Drawing.Size(452, 479);
            this.tabEncryption.TabIndex = 0;
            this.tabEncryption.Text = "Szyfrowanie";
            this.tabEncryption.UseVisualStyleBackColor = true;
            // 
            // lblEncProgress
            // 
            this.lblEncProgress.AutoSize = true;
            this.lblEncProgress.Location = new System.Drawing.Point(61, 365);
            this.lblEncProgress.Name = "lblEncProgress";
            this.lblEncProgress.Size = new System.Drawing.Size(68, 13);
            this.lblEncProgress.TabIndex = 11;
            this.lblEncProgress.Text = "Oczekiwanie";
            this.lblEncProgress.Visible = false;
            // 
            // btnCancelEncrypt
            // 
            this.btnCancelEncrypt.Enabled = false;
            this.btnCancelEncrypt.Location = new System.Drawing.Point(234, 428);
            this.btnCancelEncrypt.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelEncrypt.Name = "btnCancelEncrypt";
            this.btnCancelEncrypt.Size = new System.Drawing.Size(194, 29);
            this.btnCancelEncrypt.TabIndex = 10;
            this.btnCancelEncrypt.Text = "Anuluj";
            this.btnCancelEncrypt.UseVisualStyleBackColor = true;
            this.btnCancelEncrypt.Click += new System.EventHandler(this.btnCancelEncrypt_Click);
            // 
            // gbFiles
            // 
            this.gbFiles.Controls.Add(this.lblOutputPath);
            this.gbFiles.Controls.Add(this.lblInputPath);
            this.gbFiles.Controls.Add(this.btnInputFile);
            this.gbFiles.Controls.Add(this.btnOutputFile);
            this.gbFiles.Location = new System.Drawing.Point(26, 259);
            this.gbFiles.Margin = new System.Windows.Forms.Padding(2);
            this.gbFiles.Name = "gbFiles";
            this.gbFiles.Padding = new System.Windows.Forms.Padding(2);
            this.gbFiles.Size = new System.Drawing.Size(402, 88);
            this.gbFiles.TabIndex = 9;
            this.gbFiles.TabStop = false;
            this.gbFiles.Text = "Pliki";
            // 
            // lblOutputPath
            // 
            this.lblOutputPath.AutoSize = true;
            this.lblOutputPath.Location = new System.Drawing.Point(198, 61);
            this.lblOutputPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOutputPath.Name = "lblOutputPath";
            this.lblOutputPath.Size = new System.Drawing.Size(16, 13);
            this.lblOutputPath.TabIndex = 10;
            this.lblOutputPath.Text = "...";
            // 
            // lblInputPath
            // 
            this.lblInputPath.AutoSize = true;
            this.lblInputPath.Location = new System.Drawing.Point(198, 37);
            this.lblInputPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInputPath.Name = "lblInputPath";
            this.lblInputPath.Size = new System.Drawing.Size(16, 13);
            this.lblInputPath.TabIndex = 8;
            this.lblInputPath.Text = "...";
            // 
            // btnInputFile
            // 
            this.btnInputFile.Location = new System.Drawing.Point(15, 35);
            this.btnInputFile.Margin = new System.Windows.Forms.Padding(2);
            this.btnInputFile.Name = "btnInputFile";
            this.btnInputFile.Size = new System.Drawing.Size(178, 19);
            this.btnInputFile.TabIndex = 9;
            this.btnInputFile.Text = "Wybierz plik wejściowy";
            this.btnInputFile.UseVisualStyleBackColor = true;
            this.btnInputFile.Click += new System.EventHandler(this.btnInputFile_Click);
            // 
            // btnOutputFile
            // 
            this.btnOutputFile.Location = new System.Drawing.Point(15, 58);
            this.btnOutputFile.Margin = new System.Windows.Forms.Padding(2);
            this.btnOutputFile.Name = "btnOutputFile";
            this.btnOutputFile.Size = new System.Drawing.Size(178, 19);
            this.btnOutputFile.TabIndex = 0;
            this.btnOutputFile.Text = "Lokalizacja pliku wynikowego...";
            this.btnOutputFile.UseVisualStyleBackColor = true;
            this.btnOutputFile.Click += new System.EventHandler(this.btnOutputFile_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(26, 428);
            this.btnEncrypt.Margin = new System.Windows.Forms.Padding(2);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(194, 29);
            this.btnEncrypt.TabIndex = 3;
            this.btnEncrypt.Text = "Szyfruj";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // gbKeys
            // 
            this.gbKeys.Controls.Add(this.btnRemoveKey);
            this.gbKeys.Controls.Add(this.btnAddKey);
            this.gbKeys.Controls.Add(this.lbKeys);
            this.gbKeys.Location = new System.Drawing.Point(26, 136);
            this.gbKeys.Margin = new System.Windows.Forms.Padding(2);
            this.gbKeys.Name = "gbKeys";
            this.gbKeys.Padding = new System.Windows.Forms.Padding(2);
            this.gbKeys.Size = new System.Drawing.Size(402, 119);
            this.gbKeys.TabIndex = 8;
            this.gbKeys.TabStop = false;
            this.gbKeys.Text = "Odbiorcy";
            // 
            // btnRemoveKey
            // 
            this.btnRemoveKey.Location = new System.Drawing.Point(274, 67);
            this.btnRemoveKey.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveKey.Name = "btnRemoveKey";
            this.btnRemoveKey.Size = new System.Drawing.Size(98, 45);
            this.btnRemoveKey.TabIndex = 2;
            this.btnRemoveKey.Text = "Usuń odbiorcę";
            this.btnRemoveKey.UseVisualStyleBackColor = true;
            this.btnRemoveKey.Click += new System.EventHandler(this.btnRemoveKey_Click);
            // 
            // btnAddKey
            // 
            this.btnAddKey.Location = new System.Drawing.Point(274, 18);
            this.btnAddKey.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddKey.Name = "btnAddKey";
            this.btnAddKey.Size = new System.Drawing.Size(98, 45);
            this.btnAddKey.TabIndex = 1;
            this.btnAddKey.Text = "Dodaj odbiorcę";
            this.btnAddKey.UseVisualStyleBackColor = true;
            this.btnAddKey.Click += new System.EventHandler(this.btnAddKey_Click);
            // 
            // lbKeys
            // 
            this.lbKeys.FormattingEnabled = true;
            this.lbKeys.Location = new System.Drawing.Point(15, 18);
            this.lbKeys.Margin = new System.Windows.Forms.Padding(2);
            this.lbKeys.Name = "lbKeys";
            this.lbKeys.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbKeys.Size = new System.Drawing.Size(225, 95);
            this.lbKeys.TabIndex = 0;
            // 
            // pbEncryption
            // 
            this.pbEncryption.Location = new System.Drawing.Point(26, 392);
            this.pbEncryption.Margin = new System.Windows.Forms.Padding(2);
            this.pbEncryption.Name = "pbEncryption";
            this.pbEncryption.Size = new System.Drawing.Size(402, 19);
            this.pbEncryption.TabIndex = 1;
            // 
            // lblEncState
            // 
            this.lblEncState.AutoSize = true;
            this.lblEncState.Location = new System.Drawing.Point(23, 366);
            this.lblEncState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEncState.Name = "lblEncState";
            this.lblEncState.Size = new System.Drawing.Size(32, 13);
            this.lblEncState.TabIndex = 8;
            this.lblEncState.Text = "Stan:";
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.label2);
            this.gbSettings.Controls.Add(this.label1);
            this.gbSettings.Controls.Add(this.lblSubblockLength);
            this.gbSettings.Controls.Add(this.lblKeyLength);
            this.gbSettings.Controls.Add(this.cbSubblockLength);
            this.gbSettings.Controls.Add(this.cbKeyLength);
            this.gbSettings.Controls.Add(this.lblMode);
            this.gbSettings.Controls.Add(this.cbMode);
            this.gbSettings.Location = new System.Drawing.Point(26, 30);
            this.gbSettings.Margin = new System.Windows.Forms.Padding(2);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Padding = new System.Windows.Forms.Padding(2);
            this.gbSettings.Size = new System.Drawing.Size(402, 101);
            this.gbSettings.TabIndex = 1;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Ustawienia algorytmu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "bitów";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "bitów";
            // 
            // lblSubblockLength
            // 
            this.lblSubblockLength.AutoSize = true;
            this.lblSubblockLength.Location = new System.Drawing.Point(13, 66);
            this.lblSubblockLength.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubblockLength.Name = "lblSubblockLength";
            this.lblSubblockLength.Size = new System.Drawing.Size(98, 13);
            this.lblSubblockLength.TabIndex = 5;
            this.lblSubblockLength.Text = "Długość podbloku:";
            // 
            // lblKeyLength
            // 
            this.lblKeyLength.AutoSize = true;
            this.lblKeyLength.Location = new System.Drawing.Point(13, 30);
            this.lblKeyLength.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblKeyLength.Name = "lblKeyLength";
            this.lblKeyLength.Size = new System.Drawing.Size(85, 13);
            this.lblKeyLength.TabIndex = 4;
            this.lblKeyLength.Text = "Długość klucza:";
            // 
            // cbSubblockLength
            // 
            this.cbSubblockLength.Enabled = false;
            this.cbSubblockLength.FormattingEnabled = true;
            this.cbSubblockLength.Items.AddRange(new object[] {
            "8",
            "16",
            "24",
            "32",
            "40",
            "48",
            "56",
            "64",
            "72",
            "80",
            "88",
            "96",
            "104",
            "112",
            "120",
            "128"});
            this.cbSubblockLength.Location = new System.Drawing.Point(116, 63);
            this.cbSubblockLength.Margin = new System.Windows.Forms.Padding(2);
            this.cbSubblockLength.Name = "cbSubblockLength";
            this.cbSubblockLength.Size = new System.Drawing.Size(58, 21);
            this.cbSubblockLength.TabIndex = 3;
            // 
            // cbKeyLength
            // 
            this.cbKeyLength.FormattingEnabled = true;
            this.cbKeyLength.Items.AddRange(new object[] {
            "128",
            "192",
            "256"});
            this.cbKeyLength.Location = new System.Drawing.Point(116, 27);
            this.cbKeyLength.Margin = new System.Windows.Forms.Padding(2);
            this.cbKeyLength.Name = "cbKeyLength";
            this.cbKeyLength.Size = new System.Drawing.Size(58, 21);
            this.cbKeyLength.TabIndex = 2;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(255, 27);
            this.lblMode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(60, 13);
            this.lblMode.TabIndex = 1;
            this.lblMode.Text = "Tryb pracy:";
            // 
            // cbMode
            // 
            this.cbMode.FormattingEnabled = true;
            this.cbMode.Items.AddRange(new object[] {
            "ECB",
            "CBC",
            "CFB",
            "OFB"});
            this.cbMode.Location = new System.Drawing.Point(330, 22);
            this.cbMode.Margin = new System.Windows.Forms.Padding(2);
            this.cbMode.Name = "cbMode";
            this.cbMode.Size = new System.Drawing.Size(58, 21);
            this.cbMode.TabIndex = 0;
            this.cbMode.SelectedIndexChanged += new System.EventHandler(this.cbMode_SelectedIndexChanged);
            // 
            // tcMenu
            // 
            this.tcMenu.Controls.Add(this.tabEncryption);
            this.tcMenu.Controls.Add(this.tabDecryption);
            this.tcMenu.Location = new System.Drawing.Point(9, 10);
            this.tcMenu.Margin = new System.Windows.Forms.Padding(2);
            this.tcMenu.Name = "tcMenu";
            this.tcMenu.SelectedIndex = 0;
            this.tcMenu.Size = new System.Drawing.Size(460, 505);
            this.tcMenu.TabIndex = 0;
            this.tcMenu.Selected += new System.Windows.Forms.TabControlEventHandler(this.tcMenu_Selected);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 523);
            this.Controls.Add(this.tcMenu);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Szyfrator";
            this.tabDecryption.ResumeLayout(false);
            this.tabDecryption.PerformLayout();
            this.gbDecFiles.ResumeLayout(false);
            this.gbDecFiles.PerformLayout();
            this.gbDecKeys.ResumeLayout(false);
            this.gbDecKeys.PerformLayout();
            this.tabEncryption.ResumeLayout(false);
            this.tabEncryption.PerformLayout();
            this.gbFiles.ResumeLayout(false);
            this.gbFiles.PerformLayout();
            this.gbKeys.ResumeLayout(false);
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.tcMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabDecryption;
        private System.Windows.Forms.Button btnCancelDecrypt;
        private System.Windows.Forms.GroupBox gbDecFiles;
        private System.Windows.Forms.Label lblDecOutputPath;
        private System.Windows.Forms.Label lblDecInputPath;
        private System.Windows.Forms.Button btnDecInputFile;
        private System.Windows.Forms.Button btnDecOutputFile;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.GroupBox gbDecKeys;
        private System.Windows.Forms.ProgressBar pbDecryption;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabEncryption;
        private System.Windows.Forms.Button btnCancelEncrypt;
        private System.Windows.Forms.GroupBox gbFiles;
        private System.Windows.Forms.Label lblOutputPath;
        private System.Windows.Forms.Label lblInputPath;
        private System.Windows.Forms.Button btnInputFile;
        private System.Windows.Forms.Button btnOutputFile;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.GroupBox gbKeys;
        private System.Windows.Forms.Button btnRemoveKey;
        private System.Windows.Forms.Button btnAddKey;
        private System.Windows.Forms.ListBox lbKeys;
        private System.Windows.Forms.ProgressBar pbEncryption;
        private System.Windows.Forms.Label lblEncState;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSubblockLength;
        private System.Windows.Forms.Label lblKeyLength;
        private System.Windows.Forms.ComboBox cbSubblockLength;
        private System.Windows.Forms.ComboBox cbKeyLength;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.ComboBox cbMode;
        private System.Windows.Forms.TabControl tcMenu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.ListBox lbUsersAllowed;
        private System.Windows.Forms.Label lblDecProgress;
        private System.Windows.Forms.Label lblEncProgress;
    }
}

