using AutoMapper;
using CrmWinForm.VIewModels;
using ShopCRM.BLL.DTO;
using ShopCRM.BLL.Interfaces;
using ShopCRM.BLL.Services;
using ShopCRM.DAL.Entities;
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

        BindingList<ProductViewModel> Products;

        public ProductCatalog()
        {
            InitializeComponent();
        }

        public ProductCatalog(IMapper mapper, IProductService productService)
        {
            InitializeComponent();
            this.mapper = mapper;
            this.productService = productService;

            Products = new BindingList<ProductViewModel>();
        }

        private async void Catalog_Load(object sender, EventArgs e)
        {
            var data = await productService.GetAllAsync();

            var productsList = data.Select(c => mapper.Map<ProductViewModel>(c)).ToList();

            foreach (var product in productsList)
            {
                Products.Add(product);
            }

            dataGridView.DataSource = Products;
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            var form = new ProductForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var newProduct = mapper.Map<ProductDTO>(form.Product);
                var product = await productService.CreateAsync(newProduct);

                Products.Add(mapper.Map<ProductViewModel>(product));
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
                    var updateProduct = mapper.Map<ProductDTO>(form.Product);
                    await productService.UpdateAsync(updateProduct);
                    var index = Products.IndexOf(Products.First(c => c.ProductId == updateProduct.ProductId));
                    Products[index] = product;

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
                Products.Remove(Products.First(c => c.ProductId == (int)id));

                dataGridView.Refresh();
            }
        }
    }
}
