using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSK_RC6_Crypto
{
    public partial class NewUserForm : Form
    {
        public const int MIN_USERNAME_LENGTH = 1;
        public const int MIN_PASSWORD_LENGTH = 1;

        public bool IsValid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public NewUserForm()
        {
            InitializeComponent();
            IsValid = false;
        }

        private void btnAddUserOk_Click(object sender, EventArgs e)
        {
            if (tbUserName.Text.Length >= MIN_USERNAME_LENGTH)
            {
                if (tbPassword.Text.Length > MIN_PASSWORD_LENGTH && tbPassword.Text == tbRepeatPassword.Text)
                {
                    Username = tbUserName.Text;
                    Password = tbPassword.Text;
                    IsValid = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nieprawidłowe hasło!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Nieprawidłowa nazwa użytkownika!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
