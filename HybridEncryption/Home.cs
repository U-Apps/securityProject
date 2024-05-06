using HybridEncryption_BusinessLayer;
using System;
using System.Text.RegularExpressions;

namespace HybridEncryption_PresentaionLayer
{

    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        

        private void txtDES_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKeyDES.Text))
            {
                Guna.UI2.WinForms.MessageDialog.Show("please insert the key");
                txtDES.Text = "";
                txtDESEncrypted.Text = "";

                return;
            }


            if (string.IsNullOrWhiteSpace(txtDES.Text))
            {
                txtDESEncrypted.Text = "";
                return;
            }

            txtDESEncrypted.Text = clsDES.Encrypt(txtDES.Text, txtKeyDES.Text);
        }

        private void txtDESEncrypted_TextChanged(object sender, EventArgs e)
        {
            if (txtDES.Text != "")
            {
                return;
            }
            if (string.IsNullOrEmpty(txtKeyDES.Text))
            {
                Guna.UI2.WinForms.MessageDialog.Show("please insert the key");
                txtDES.Text = "";
                txtDESEncrypted.Text = "";
                return;
            }


            if (string.IsNullOrWhiteSpace(txtDESEncrypted.Text))
            {
                txtDES.Text = "";
                return;
            }

            txtDES.Text = clsDES.Decrypt(txtDESEncrypted.Text, txtKeyDES.Text);
        }

        private void txtTribleDES_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtkeyTripleDESText.Text))
            {
                return;
            }

            if (txtkeyTripleDESText.Text.Length != 16)
            {
                Guna.UI2.WinForms.MessageDialog.Show("please insert 16 digit for the key");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTribleDES.Text))
            {
                txtTribleDESEncrypted.Text = "";
                return;
            }

            txtTribleDESEncrypted.Text = clsTribleDES.EncryptText(txtTribleDES.Text, txtkeyTripleDESText.Text);
        }

        private void txtTribleDESEncrypted_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtkeyTripleDESText.Text))
            {
                return;
            }

            if (txtkeyTripleDESText.Text.Length != 16)
            {
                Guna.UI2.WinForms.MessageDialog.Show("please insert 16 digit for the key");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTribleDESEncrypted.Text))
            {
                txtTribleDES.Text = "";
                return;
            }
            try
            {
                txtTribleDES.Text = clsTribleDES.DecryptText(txtTribleDESEncrypted.Text, txtkeyTripleDESText.Text);

            }
            catch (Exception) { txtTribleDES.Text = ""; Guna.UI2.WinForms.MessageDialog.Show("not valid encrypted text"); }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (txtFilenamePath.Text == "" || txtKeyTripleDESFile.Text == "")
            {
                Guna.UI2.WinForms.MessageDialog.Show("pleas fill all the fields");
                return;
            }

            if (txtKeyTripleDESFile.Text.Length != 16)
            {
                Guna.UI2.WinForms.MessageDialog.Show("please insert 16 digit for the key");
                return;
            }


            try
            {

                clsTribleDES.EncryptFile(txtFilenamePath.Text, txtKeyTripleDESFile.Text);
                Guna.UI2.WinForms.MessageDialog.Show("file encrypted succefully");

            }
            catch (Exception)
            {
                Guna.UI2.WinForms.MessageDialog.Show("Error occured, check the file path");


            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (txtFilenamePath.Text == "" || txtKeyTripleDESFile.Text == "")
            {
                Guna.UI2.WinForms.MessageDialog.Show("pleas fill all the fields");
                return;
            }

            if (txtKeyTripleDESFile.Text.Length != 16)
            {
                Guna.UI2.WinForms.MessageDialog.Show("please insert 16 digit for the key");
                return;
            }


            try
            {

                clsTribleDES.DecryptFile(txtFilenamePath.Text, txtKeyTripleDESFile.Text);
                Guna.UI2.WinForms.MessageDialog.Show("file Decrypted succefully");

            }
            catch (Exception)
            {
                Guna.UI2.WinForms.MessageDialog.Show("Error occured, check the file path");


            }
        }
    }
}
