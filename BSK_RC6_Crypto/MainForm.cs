// TODO:
// 1. Długość podbloku - wielokrotność bajtu, czy jak to ma być???

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;

namespace BSK_RC6_Crypto
{
    public partial class MainForm : Form
    {
        public static string InputFile { get; set; }
        public static string OutputFile { get; set; }
        public List<User> Users { get; set; }

        Encryptor _enc;
        Decryptor _dec;
        BindingSource bs = new BindingSource();

        public MainForm()
        {
            InitializeComponent();
            cbMode.SelectedItem = "ECB";
            cbKeyLength.SelectedItem = "192";
            Users = new List<User>();
            //LoadUsers();
            bs.DataSource = Users;
            lbKeys.DataSource = bs;
        }

        #region KLUCZE I USERZY
        private void btnAddKey_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.InitialDirectory = Path.Combine(Application.StartupPath, @"public");

            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.Multiselect = true;

            ofd.Filter = "Public key files | *.pub";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    foreach (var file in ofd.FileNames)
                    {
                        var name = Path.GetFileNameWithoutExtension(file);
                        if (Users.FirstOrDefault(u => u.Name == name) == null)
                            Users.Add(new User(name));
                        else
                            ShowError("Wskazany odbiorca jest juz dodany do listy. Nazwa: " + name);
                    }
                    bs.ResetBindings(false);
                }
                catch (IOException)
                {
                    ShowError("Błąd przy wyborze pliku");
                }
                catch (ArgumentException)
                {
                    ShowError("Wybrano nieprawidłowy plik");
                }
            }
        }

        private void btnRemoveKey_Click(object sender, EventArgs e)
        {
            var toRemove = lbKeys.SelectedItem;
            if (toRemove != null)
            {
                Users.Remove((User)toRemove);
                bs.ResetBindings(false);
            }
        }

        private void LoadUsers()
        {
            DirectoryInfo di = new DirectoryInfo("public");
            foreach (var f in di.GetFiles())
            {
                Users.Add(new User(Path.GetFileNameWithoutExtension(f.Name)));
            }
        }
        #endregion
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            lblEncProgress.Visible = true;
            if (!string.IsNullOrEmpty(InputFile) && (!string.IsNullOrEmpty(OutputFile)))
            {
                var users = lbKeys.Items;
                if (users.Count > 0)
                {
                    var mode = cbMode.Text;
                    var keyLength = Int32.Parse(cbKeyLength.Text);
                    int blockLength = 0;
                    if (mode == "CFB" || mode == "OFB")
                        blockLength = Int32.Parse(cbSubblockLength.Text);

                    var approvedUsers = new List<string>();
                    foreach (var u in users)
                    {
                        approvedUsers.Add(u.ToString());
                    }

                    _enc = new Encryptor(mode, keyLength, blockLength, approvedUsers);
                    _enc.OnProgressUpdate += enc_OnProgressUpdate;
                    _enc.OnWorkCompleted += OnWorkCompleted;
                    DisableControls(true);
                    _enc.bw.RunWorkerAsync();
                }
                else
                {
                    ShowError("Nie wybrano odbiorców!");
                }
            }
            else
            {
                ShowError("Nie wybrano pliku wejściowego lub wyjściowego!");
            }
        }


        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            lblDecProgress.Visible = true;
            if (!string.IsNullOrEmpty(InputFile) && (!string.IsNullOrEmpty(OutputFile)))
            {
                var selected = lbUsersAllowed.SelectedItem;
                if (selected != null)
                {
                    _dec = new Decryptor(selected.ToString(), tbPassword.Text);
                    _dec.OnProgressUpdate += dec_OnProgressUpdate;
                    _dec.OnWorkCompleted += OnWorkCompleted;
                    DisableControls(false);
                    _dec.bw.RunWorkerAsync();
                }
                else
                {
                    ShowError("Nie wybrano użytkownika!");
                }
            }
            else
            {
                ShowError("Nie wybrano pliku wejściowego lub wyjściowego!");
            }
        }

        private void dec_OnProgressUpdate(int value)
        {
            base.Invoke((Action)delegate
            {
                pbDecryption.Value = value;
                lblDecProgress.Text = value.ToString() + "%";
            });

        }

        private void enc_OnProgressUpdate(int value)
        {
            base.Invoke((Action)delegate
            {
                pbEncryption.Value = value;
                lblEncProgress.Text = value.ToString() + "%";
            });

        }


        #region PLIKI
        private void btnInputFile_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    InputFile = ofd.FileName;
                    if (tcMenu.SelectedTab == tabEncryption)
                        lblInputPath.Text = ofd.FileName;
                    else
                    {
                        lblDecInputPath.Text = ofd.FileName;
                        lbUsersAllowed.Items.Clear();
                        var allowedUsers = GetApprovedUsers();
                        if (allowedUsers != null)
                        {
                            foreach (var u in allowedUsers)
                            {
                                lbUsersAllowed.Items.Add(u);
                            }
                        }
                    }
                }
                catch (IOException)
                {
                    ShowError("Błąd przy wyborze pliku");
                }
                catch (ArgumentException)
                {
                    ShowError("Wybrano nieprawidłowy plik");
                }

            }

        }

        private void btnOutputFile_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    OutputFile = sfd.FileName;
                    if (tcMenu.SelectedTab == tabEncryption)
                        lblOutputPath.Text = sfd.FileName;
                    else
                        lblDecOutputPath.Text = sfd.FileName;
                }
                catch (IOException)
                {
                    ShowError("Błąd przy wyborze pliku");
                }
                catch (ArgumentException)
                {
                    ShowError("Wybrano nieprawidłowy plik");
                }
            }

        }
        #endregion

        private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMode.Text == "CFB" || cbMode.Text == "OFB")
            {
                cbSubblockLength.Enabled = true;
                cbSubblockLength.SelectedItem = "8";
            }
            else
            {
                cbSubblockLength.Enabled = false;
                cbSubblockLength.SelectedItem = null;
            }
        }

        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        public void OnWorkCompleted(int result, string message, bool forEncryption)
        {
            if (result == -1)
            {
                base.Invoke((Action)delegate ()
                    {
                        if (forEncryption)
                        {
                            pbEncryption.Value = 0;
                            lblEncProgress.Text = "Błąd";
                        }
                        else
                        {
                            pbDecryption.Value = 0;
                            lblDecProgress.Text = "Błąd";

                        }
                    });

                ShowError(message);
            }
            else if (result == 1)
            {
                base.Invoke((Action)delegate ()
                {
                    if (forEncryption)
                    {
                        pbEncryption.Value = 0;
                        lblEncProgress.Text = "Anulowano";
                    }
                    else
                    {
                        pbDecryption.Value = 0;
                        lblDecProgress.Text = "Anulowano";
                    }
                });
                MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                base.Invoke((Action)delegate ()
                {
                    if (forEncryption)
                    {
                        pbEncryption.Value = 100;
                        lblEncProgress.Text = "Zakończono";
                    }
                    else
                    {
                        pbDecryption.Value = 100;
                        lblDecProgress.Text = "Zakończono";
                    }
                });
                MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            EnableControls();

        }

        private void btnCancelEncrypt_Click(object sender, EventArgs e)
        {
            _enc.bw.CancelAsync();
        }

        private void btnCancelDecrypt_Click(object sender, EventArgs e)
        {
            _dec.bw.CancelAsync();
        }

        private void tcMenu_Selected(object sender, TabControlEventArgs e)
        {
            Users.Clear();
            bs.ResetBindings(false);
            lbUsersAllowed.Items.Clear();
            tbPassword.Text = string.Empty;
            lblInputPath.Text = "...";
            lblOutputPath.Text = "...";
            lblDecInputPath.Text = "...";
            lblDecOutputPath.Text = "...";
            InputFile = null;
            OutputFile = null;
            lblEncProgress.Text = "";
            lblDecProgress.Text = "";
            lblDecInputPath.Text = "...";
            lblDecOutputPath.Text = "...";

        }

        private void DisableControls(bool forEncryption)
        {
            gbSettings.Enabled = false;
            gbFiles.Enabled = false;
            gbKeys.Enabled = false;
            btnEncrypt.Enabled = false;
            btnDecrypt.Enabled = false;
            gbDecFiles.Enabled = false;
            gbDecKeys.Enabled = false;

            if (forEncryption)
            {
                btnCancelDecrypt.Enabled = false;
                btnCancelEncrypt.Enabled = true;
            }

            else
            {
                btnCancelDecrypt.Enabled = true;
                btnCancelEncrypt.Enabled = false;

            }
        }

        private void EnableControls()
        {
            base.Invoke((Action)delegate ()
            {
                gbSettings.Enabled = true;
                gbFiles.Enabled = true;
                gbKeys.Enabled = true;
                btnEncrypt.Enabled = true;
                btnDecrypt.Enabled = true;
                gbDecFiles.Enabled = true;
                gbDecKeys.Enabled = true;
                btnCancelDecrypt.Enabled = false;
                btnCancelEncrypt.Enabled = false;
                pbEncryption.Value = 0;
                pbDecryption.Value = 0;
            });
        }

        private List<string> GetApprovedUsers()
        {
            try
            {
                var xml = XDocument.Parse(Decryptor.ReadFileHeader());
                var users = xml.Element("EncryptedFileHeader").Element("ApprovedUsers").Descendants("User")
                            .Select(u => u.Element("Name").Value).ToList();

                if (users.Count == 0)
                    ShowError("Nie znaleziono odbiorców danego pliku");

                return users;
            }
            catch (IOException)
            {
                ShowError("Nie udało się otworzyć pliku");
                return null;
            }
            catch (Exception)
            {
                ShowError("Plik jest nieprawidłowy lub uszkodzony");
                return null;
            }
        }


    }
}
