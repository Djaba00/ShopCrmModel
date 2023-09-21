using CrmBL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmWinForm
{
    public partial class Login : Form
    {
        public Customer Customer;

        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Customer = new Customer()
            {
                Name = NameTextBox.Text
            };

            DialogResult = DialogResult.OK;
        }
    }
}
