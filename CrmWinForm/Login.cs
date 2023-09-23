
using CrmWinForm.VIewModels;

namespace CrmWinForm
{
    public partial class Login : Form
    {
        public CustomerViewModel Customer;

        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Customer = new CustomerViewModel()
            {
                Name = NameTextBox.Text
            };

            DialogResult = DialogResult.OK;
        }
    }
}
