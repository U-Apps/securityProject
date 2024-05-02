using HybridEncryption_BusinessLayer;

namespace HybridEncryption_PresentaionLayer
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
                int key = 0;
            if (string.IsNullOrEmpty(guna2TextBox1.Text))
            {
                Guna.UI2.WinForms.MessageDialog.Show("please fill the key field!");
                return;
            }
            else
            {
                if(int.TryParse(guna2TextBox1.Text,out  key))
                {

                }
            }

            if (string.IsNullOrEmpty(guna2TextBox2.Text))
                return;

            guna2TextBox3.Text = clsCaeser.encrypt(guna2TextBox2.Text, key);
        }
    }
}
