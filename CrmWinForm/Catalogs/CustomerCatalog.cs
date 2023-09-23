using AutoMapper;
using CrmWinForm.VIewModels;
using ShopCRM.BLL.DTO;
using ShopCRM.BLL.Interfaces;
using ShopCRM.BLL.Services;
using ShopCRM.DAL.Entities;
using System.ComponentModel;
using System.Data;

namespace CrmWinForm
{
    public partial class CustomerCatalog : Form
    {
        IMapper mapper;
        ICustomerService customerService;
        BindingList<CustomerViewModel> Customers;

        public CustomerCatalog()
        {
            InitializeComponent();
        }

        public CustomerCatalog(IMapper mapper, ICustomerService customerService)
        {
            InitializeComponent();
            this.mapper = mapper;
            this.customerService = customerService;

            Customers = new BindingList<CustomerViewModel>();
        }

        private async void Catalog_Load(object sender, EventArgs e)
        {
            var data = await customerService.GetAllAsync();

            var customersList = data.Select(c => mapper.Map<CustomerViewModel>(c)).ToList();

            foreach (var customer in customersList)
            {
                Customers.Add(customer);
            }

            dataGridView.DataSource = Customers;
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            var form = new CustomerForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var newCustomer = mapper.Map<CustomerDTO>(form.Customer);
                var customer = await customerService.CreateAsync(newCustomer);

                Customers.Add(mapper.Map<CustomerViewModel>(customer));
                dataGridView.Refresh();
            }
        }

        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            var id = dataGridView.SelectedRows[0].Cells[0].Value;

            var data = await customerService.GetAsync((int)id);

            var customer = mapper.Map<CustomerViewModel>(data);

            if (customer != null)
            {
                var form = new CustomerForm(customer);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var updateCustomer = mapper.Map<CustomerDTO>(form.Customer);
                    await customerService.UpdateAsync(updateCustomer);
                    var index = Customers.IndexOf(Customers.First(c => c.CustomerId == updateCustomer.CustomerId));
                    Customers[index] = customer;

                    dataGridView.Refresh();
                }
            }
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            var id = dataGridView.SelectedRows[0].Cells[0].Value;

            var data = await customerService.GetAsync((int)id);

            var customer = mapper.Map<CustomerViewModel>(data);

            if (customer != null)
            {
                await customerService.DeleteAsync((int)id);
                Customers.Remove(Customers.First(c => c.CustomerId == (int)id));

                dataGridView.Refresh();
            }
        }
    }
}
