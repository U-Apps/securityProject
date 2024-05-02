using HybridEncryption_BusinessLayer;
namespace HybridEncryption
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show( Class1.Test());
        }
    }
}
