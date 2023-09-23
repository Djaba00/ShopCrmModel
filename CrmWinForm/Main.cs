using AutoMapper;
using CrmWinForm.Catalogs;
using CrmWinForm.VIewModels;
using ShopCRM.BLL.BusinesModels;
using ShopCRM.BLL.DTO;
using ShopCRM.BLL.Interfaces;
using ShopCRM.BLL.Services;

namespace CrmWinForm
{
    public partial class Main : Form
    {
        ISellerService sellerService;
        IProductService productService;
        ICustomerService customerService;
        ICheckService checkService;

        IMapper mapper;
        Cart Cart;
        CustomerViewModel Customer;
        CashDesk CashDesk;

        public Main(ISellerService sellerService, IProductService productService, ICustomerService customerService, ICheckService checkService, IMapper mapper)
        {
            InitializeComponent();

            this.sellerService = sellerService;
            this.productService = productService;
            this.customerService = customerService;
            this.checkService = checkService;
            this.mapper = mapper;

            var customerDto = mapper.Map<CustomerDTO>(Customer);

            Cart = new Cart(customerDto);

            //CashDesk = new CashDesk(1, sellerService.Sellers.FirstOrDefault(), services, mapper)
            //{
            //    IsModel = false
            //};
        }

        private async void Main_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                ProductList.Invoke((Action)async delegate
                {
                    var products = await productService.GetAllAsync();
                    ProductList.Items.AddRange(products.Select(p => mapper.Map<ProductViewModel>(p)).ToArray());
                    UpdateLists();
                });
            });
        }

        private async void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var product = await productService.GetAllAsync();
            var productCustomer = new ProductCatalog(mapper, productService);
            productCustomer.Show();
        }

        private async void SellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var sellers = await sellerService.GetAllAsync();
            var catalogSellers = new SellerCatalog(mapper, sellerService);
            catalogSellers.Show();
        }

        private async void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var customers = await customerService.GetAllAsync();
            var catalogCustomer = new CustomerCatalog(mapper, customerService);
            catalogCustomer.Show();
        }

        private async void CheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var check = await checkService.GetAllAsync();
            var checkCustomer = new CheckCatalog(mapper, checkService);
            checkCustomer.Show();
        }

        private async void ModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var modelForm = new ModelForm(mapper);
            modelForm.Show();
        }

        private async void ProductList_DoubleClick(object sender, EventArgs e)
        {
            //if (ProductList.SelectedItem is Product product)
            //{
            //    Cart.Add(product);
            //    UserCart.Items.Add(product);
            //    UpdateLists();
            //}
        }

        private async void UpdateLists()
        {
            //UserCart.Items.Clear();
            //UserCart.Items.AddRange(Cart.GetAll().ToArray());
            //SummaryLadel.Text = "Итого: " + Cart.Price.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //var form = new Login();
            //form.ShowDialog();
            //if (form.DialogResult == DialogResult.OK)
            //{
            //    var tempCustomer = db.Customers.FirstOrDefault(c => c.Name.Equals(form.Customer.Name));
            //    if (!(tempCustomer is null))
            //    {
            //        Customer = tempCustomer;
            //    }
            //    else
            //    {
            //        db.Customers.Add(form.Customer);
            //        db.SaveChanges();
            //        Customer = form.Customer;
            //    }
            //    Cart.Customer = Customer;
            //}

            //linkLabel1.Text = $"Здравсвуй, {Customer.Name}";
        }

        private void BuyButton_Click(object sender, EventArgs e)
        {
            //if (!(Customer is null))
            //{
            //    if(Cart.Products.Count > 0)
            //    {
            //        CashDesk.Enqueue(Cart);
            //        var price = CashDesk.Dequeue();
            //        UserCart.Items.Clear();
            //        Cart = new Cart(Customer);

            //        MessageBox.Show($"Покупка выполнена успешно! Сумма: {price} руб.", "Покупка выполненна");
            //    }
            //    else
            //    {
            //        MessageBox.Show($"Ваша корзина пуста!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Авторизируйтесь, пожалуйста", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }
    }
}