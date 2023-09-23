using AutoMapper;
using CrmWinForm.VIewModels;
using ShopCRM.BLL.DTO;
using ShopCRM.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmWinForm.Catalogs
{
    public partial class ProductCatalog : Form
    {
        IMapper mapper;
        IProductService productService;

        public ProductCatalog()
        {
            InitializeComponent();
        }

        public ProductCatalog(IMapper mapper, IProductService productService)
        {
            InitializeComponent();
            this.mapper = mapper;
            this.productService = productService;
        }

        private void Catalog_Load(object sender, EventArgs e)
        {

        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            var form = new ProductForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var newProduct = mapper.Map<ProductDTO>(form.Product);
                await productService.CreateAsync(newProduct);
                dataGridView.Refresh();
            }

        }

        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            var id = dataGridView.SelectedRows[0].Cells[0].Value;

            var data = await productService.GetAsync((int)id);

            var product = mapper.Map<ProductViewModel>(data);

            if (product != null)
            {
                var form = new ProductForm(product);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    product = form.Product;
                    var updateProduct = mapper.Map<ProductDTO>(product);
                    await productService.UpdateAsync(updateProduct);
                    dataGridView.Refresh();
                }
            }
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            var id = dataGridView.SelectedRows[0].Cells[0].Value;

            var data = await productService.GetAsync((int)id);

            var product = mapper.Map<ProductViewModel>(data);

            if (product != null)
            {
                await productService.DeleteAsync((int)id);
                dataGridView.Refresh();
            }
        }
    }
}
