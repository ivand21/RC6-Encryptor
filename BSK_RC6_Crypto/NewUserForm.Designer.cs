namespace BSK_RC6_Crypto
{
    partial class NewUserForm
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
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbRepeatPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddUserOk = new System.Windows.Forms.Button();
            this.btnAddUserCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(147, 26);
            this.tbUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(172, 22);
            this.tbUserName.TabIndex = 0;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(147, 84);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(172, 22);
            this.tbPassword.TabIndex = 1;
            // 
            // tbRepeatPassword
            // 
            this.tbRepeatPassword.Location = new System.Drawing.Point(147, 145);
            this.tbRepeatPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbRepeatPassword.Name = "tbRepeatPassword";
            this.tbRepeatPassword.PasswordChar = '*';
            this.tbRepeatPassword.Size = new System.Drawing.Size(172, 22);
            this.tbRepeatPassword.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nazwa odbiorcy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Hasło";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 154);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Powtórz hasło";
            // 
            // btnAddUserOk
            // 
            this.btnAddUserOk.Location = new System.Drawing.Point(20, 210);
            this.btnAddUserOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddUserOk.Name = "btnAddUserOk";
            this.btnAddUserOk.Size = new System.Drawing.Size(100, 28);
            this.btnAddUserOk.TabIndex = 6;
            this.btnAddUserOk.Text = "OK";
            this.btnAddUserOk.UseVisualStyleBackColor = true;
            this.btnAddUserOk.Click += new System.EventHandler(this.btnAddUserOk_Click);
            // 
            // btnAddUserCancel
            // 
            this.btnAddUserCancel.Location = new System.Drawing.Point(128, 210);
            this.btnAddUserCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddUserCancel.Name = "btnAddUserCancel";
            this.btnAddUserCancel.Size = new System.Drawing.Size(100, 28);
            this.btnAddUserCancel.TabIndex = 7;
            this.btnAddUserCancel.Text = "Anuluj";
            this.btnAddUserCancel.UseVisualStyleBackColor = true;
            // 
            // NewUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 257);
            this.Controls.Add(this.btnAddUserCancel);
            this.Controls.Add(this.btnAddUserOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbRepeatPassword);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUserName);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewUserForm";
            this.Text = "Dodawanie odbiorcy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbRepeatPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddUserOk;
        private System.Windows.Forms.Button btnAddUserCancel;
    }
}