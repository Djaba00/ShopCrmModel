using AutoMapper;
using CrmWinForm.VIewModels;
using ShopCRM.BLL.BusinesModels;
using ShopCRM.DAL.Entities;
using ShopCRM.DAL.Interfaces;
using System.Diagnostics;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace CrmWinForm
{
    public partial class Main : Form
    {
        IServiceUnitOfWork services;
        IMapper mapper;
        Random rnd = new Random();
        Cart Cart;
        CustomerViewModel Customer;
        CashDesk CashDesk;

        public Main(IServiceUnitOfWork service, IMapper mapper)
        {
            InitializeComponent();
            this.services = service;
            var customerDto = mapper.Map<CustomerDTO>(Customer);

            Cart = new Cart(customerDto); 
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                ProductList.Invoke((Action)delegate
                {
                    ProductList.Items.AddRange(db.Products.ToArray());
                    UpdateLists();
                });
                var seller = await services.SellsDTO.GetAsync(rnd.Next(0, 3));

                CashDesk = new CashDesk(1, seller , services, mapper)
                {
                    IsModel = false
                };
            });
        }

        private void ProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogProduct = new Catalog<ProductDTO>(db.Products, db);
            catalogProduct.Show();
        }

        private void SellerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogSeller = new Catalog<SellerDTO>(db.Sellers, db);
            catalogSeller.Show();
        }

        private void CustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCustomer = new Catalog<CustomerDTO>(db.Customers, db);
            catalogCustomer.Show();
        }

        private void CheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogCheck = new Catalog<CheckDTO>(db.Checks, db);
            catalogCheck.Show();
        }

        private void CustomerAddToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var form = new CustomerForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Customers.Add(form.Customer);
                db.SaveChanges();
            }
        }

        private void SellerAddToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var form = new SellerForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Sellers.Add(form.Seller);
                db.SaveChanges();
            }
        }

        private void ProductAddToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new ProductForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Products.Add(form.Product);
                db.SaveChanges();
            }
        }

        private void ModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var modelForm = new ModelForm();
            modelForm.Show();
        }

        private void ProductList_DoubleClick(object sender, EventArgs e)
        {
            if (ProductList.SelectedItem is Product product)
            {
                Cart.Add(product);
                UserCart.Items.Add(product);
                UpdateLists();
            }
        }

        private void UpdateLists()
        {
            UserCart.Items.Clear();
            UserCart.Items.AddRange(Cart.GetAll().ToArray());
            SummaryLadel.Text = "Итого: " + Cart.Price.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new Login();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                var tempCustomer = db.Customers.FirstOrDefault(c => c.Name.Equals(form.Customer.Name));
                if (!(tempCustomer is null))
                {
                    Customer = tempCustomer;
                }
                else
                {
                    db.Customers.Add(form.Customer);
                    db.SaveChanges();
                    Customer = form.Customer;
                }
                Cart.Customer = Customer;
            }

            linkLabel1.Text = $"Здравсвуй, {Customer.Name}";
        }

        private void BuyButton_Click(object sender, EventArgs e)
        {
            if (!(Customer is null))
            {
                if(Cart.Products.Count > 0)
                {
                    CashDesk.Enqueue(Cart);
                    var price = CashDesk.Dequeue();
                    UserCart.Items.Clear();
                    Cart = new Cart(Customer);

                    MessageBox.Show($"Покупка выполнена успешно! Сумма: {price} руб.", "Покупка выполненна");
                }
                else
                {
                    MessageBox.Show($"Ваша корзина пуста!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Авторизируйтесь, пожалуйста", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}