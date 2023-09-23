using AutoMapper;
using CrmWinForm.VIewModels;
using ShopCRM.BLL.Interfaces;

namespace CrmWinForm
{
    public partial class CustomerForm : Form
    {
        public CustomerViewModel Customer { get; set; }

        public CustomerForm()
        {
            InitializeComponent();
        }

        public CustomerForm(CustomerViewModel customer) : this()
        {
            Customer = customer;
            textBox1.Text = customer.Name;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer = Customer ?? new CustomerViewModel();
            Customer.Name = textBox1.Text;

            Close();
        }
    }
}
