using HybridEncryption_BusinessLayer;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HybridEncryption_PresentaionLayer;


public partial class Home : Form
{
    public Home()
    {
        InitializeComponent();
    }





    //  -----------------------------------------------------------------------------------------------
    // DES Text -----------------------------------------------------------------------------------------------
    private void btnDESEncrypt_Click(object sender, EventArgs e)
    {
        try
        {
            txtDESEncryptedText.Text = clsDES.EncryptText(txtDESPlainText.Text, txtKeyDES.Text);
        }
        catch (Exception ex)
        {
            Guna.UI2.WinForms.MessageDialog.Show(ex.Message);
        }
    }

    private void btnDESDecrypt_Click(object sender, EventArgs e)
    {
        try
        {
            txtDESDecryptedText.Text = clsDES.DecryptText(txtDESEncryptedText.Text, txtKeyDES.Text);
        }
        catch (Exception ex)
        {
            Guna.UI2.WinForms.MessageDialog.Show(ex.Message);
        }
    }

    //  DES file ----------------------------------------------------------------------------------------
    private void btnDesFileEncrypt_Click(object sender, EventArgs e)
    {
        try
        {

            saveFileDialog1.Title = "Save Decrypted File";
            saveFileDialog1.FileName = Path.GetFileNameWithoutExtension(openFileDialog1.FileName) + "_Decrypt";
            saveFileDialog1.DefaultExt = Path.GetExtension(openFileDialog1.FileName);
            saveFileDialog1.Filter = "All Files (*.*)|*.*";
            saveFileDialog1.ShowDialog();
            clsDES.EncryptFile(txtDesFileNamePath.Text, saveFileDialog1.FileName, txtKeyDesFile.Text);
            MessageBox.Show("Decrypt done");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void btnDesFileDecrypt_Click(object sender, EventArgs e)
    {
        try
        {
            saveFileDialog1.Title = "Save Decrypted File";
            saveFileDialog1.FileName = Path.GetFileNameWithoutExtension(openFileDialog1.FileName) + "_Decrypt";
            saveFileDialog1.DefaultExt = Path.GetExtension(openFileDialog1.FileName);
            saveFileDialog1.Filter = "All Files (*.*)|*.*";
            saveFileDialog1.ShowDialog();

            clsDES.DecryptFile(txtDesFileNamePath.Text, saveFileDialog1.FileName, txtKeyDesFile.Text);

            MessageBox.Show("Decrypt done");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void btnDesChooseFile_Click(object sender, EventArgs e)
    {
        openFileDialog1.Title = "Select Input File";

        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {

            txtDesFileNamePath.Text = openFileDialog1.FileName;

        }
    }


    //  -----------------------------------------------------------------------------------------------
    //  -----------------------------------------------------------------------------------------------








    //  -----------------------------------------------------------------------------------------
    //  Triple Text  -----------------------------------------------------------------------------------------
    private void btnTripleEncrypt_Click(object sender, EventArgs e)
    {
        try
        {
            txtTripleEncryptedText.Text = clsTribleDES.EncryptText(txtTriplePlainText.Text, txtTripleKey.Text);
        }
        catch (Exception ex)
        {

            Guna.UI2.WinForms.MessageDialog.Show(ex.Message);
        }
    }

    private void btnTripleDecrypt_Click(object sender, EventArgs e)
    {
        try
        {
            txtTripleDecryptedText.Text = clsTribleDES.DecryptText(txtTripleEncryptedText.Text, txtTripleKey.Text);
        }
        catch (Exception ex)
        {

            Guna.UI2.WinForms.MessageDialog.Show(ex.Message);
        }
    }

    //  Triple File  -----------------------------------------------------------------------------------------

    private void btnTripleEncryptFile_Click(object sender, EventArgs e)
    {
        try
        {
            saveFileDialog1.Title = "Save Encrypted File";
            saveFileDialog1.FileName = Path.GetFileNameWithoutExtension(openFileDialog1.FileName) + "_Encrypt";
            saveFileDialog1.DefaultExt = Path.GetExtension(openFileDialog1.FileName);
            saveFileDialog1.Filter = "All Files (*.*)|*.*";
            saveFileDialog1.ShowDialog();
            clsTribleDES.EncryptFile(txtTrtipleFilenamePath.Text, saveFileDialog1.FileName, txtKeyTripleDESFile.Text);
            MessageBox.Show("encrypt done");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void btnTripleDecryptFile_Click(object sender, EventArgs e)
    {
        try
        {
            saveFileDialog1.Title = "Save Decrypted File";
            saveFileDialog1.FileName = Path.GetFileNameWithoutExtension(openFileDialog1.FileName) + "_Decrypt";
            saveFileDialog1.DefaultExt = Path.GetExtension(openFileDialog1.FileName);
            saveFileDialog1.Filter = "All Files (*.*)|*.*";
            saveFileDialog1.ShowDialog();
            clsTribleDES.DecryptFile(txtTrtipleFilenamePath.Text, saveFileDialog1.FileName, txtKeyTripleDESFile.Text);
            MessageBox.Show("Decrypt done");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void btnTripleChooseFile_Click(object sender, EventArgs e)
    {
        openFileDialog1.Title = "Select Input File";

        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {

            txtTrtipleFilenamePath.Text = openFileDialog1.FileName;

        }
    }

    private void btnDESGenerateKey_Click(object sender, EventArgs e)
    {
        txtKeyDES.Text = clsDES.genrateKey();
    }

    private void guna2Button2_Click(object sender, EventArgs e)
    {
        txtKeyDesFile.Text = clsDES.genrateKey();
    }

    private void guna2Button1_Click(object sender, EventArgs e)
    {
        txtKeyTripleDESFile.Text = clsTribleDES.genrateKey();
    }

    private void guna2Button8_Click(object sender, EventArgs e)
    {
        txtTripleKey.Text = clsTribleDES.genrateKey();
    }
}
