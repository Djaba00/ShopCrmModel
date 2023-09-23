using CrmWinForm.VIewModels;

namespace CrmWinForm
{
    public partial class ProductForm : Form
    {
        public ProductViewModel Product { get; set; }
        public ProductForm()
        {
            InitializeComponent();
        }

        public ProductForm(ProductViewModel product) : this()
        {
            Product = product;
            textBox1.Text = product.Name;
            numericUpDown1.Value = product.Price;
            numericUpDown2.Value = product.Count;
        }

        private void ProducForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product = Product ?? new ProductViewModel();

            Product.Name = textBox1.Text;
            Product.Price = numericUpDown1.Value;
            Product.Count = Convert.ToInt32(numericUpDown2.Value);

            Close();
        }
    }
}
