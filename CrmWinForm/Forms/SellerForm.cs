

using CrmWinForm.VIewModels;

namespace CrmWinForm
{
    public partial class SellerForm : Form
    {
        public SellerViewModel Seller { get; set; }
        public SellerForm()
        {
            InitializeComponent();
        }

        public SellerForm(SellerViewModel seller) : this()
        {
            Seller = seller;
            textBox1.Text = seller.Name;
        }

        private void SellerForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Seller = Seller ?? new SellerViewModel();

            Seller.Name = textBox1.Text;

            Close();
        }
    }
}
