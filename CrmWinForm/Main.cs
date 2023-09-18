using CrmBL.DataAccess;
using CrmBL.DataAccess.ApplicationContext;
using CrmBL.Models;

namespace CrmWinForm
{
    public partial class Main : Form
    {
        CrmContext db;

        public Main()
        {
            InitializeComponent();
            db = new CrmContext();
        }

        private void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogProduct = new Catalog<Product>(db.Products);
            catalogProduct.Show();
        }
    }
}