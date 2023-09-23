using AutoMapper;
using CrmWinForm.VIewModels;
using ShopCRM.BLL.DTO;
using ShopCRM.BLL.Interfaces;
using System.ComponentModel;
using System.Data;

namespace CrmWinForm
{
    public partial class CustomerCatalog : Form
    {
        IMapper mapper;
        ICustomerService customerService;

        public CustomerCatalog()
        {
            InitializeComponent();
        }

        public CustomerCatalog(IMapper mapper, ICustomerService customerService)
        {
            InitializeComponent();
            this.mapper = mapper;
            this.customerService = customerService;
        }

        private void Catalog_Load(object sender, EventArgs e)
        {

        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            var form = new CustomerForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var newCustomer = mapper.Map<CustomerDTO>(form.Customer);
                await customerService.CreateAsync(newCustomer);
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
                    customer = form.Customer;
                    var updateCustomer = mapper.Map<CustomerDTO>(customer);
                    await customerService.UpdateAsync(updateCustomer);
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
                dataGridView.Refresh();
            }
        }
    }
}
