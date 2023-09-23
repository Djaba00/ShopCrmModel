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
    public partial class SellerCatalog : Form
    {
        IMapper mapper;
        ISellerService sellerService;
        BindingList<SellerViewModel> Sellers;

        public SellerCatalog()
        {
            InitializeComponent();
        }

        public SellerCatalog(IMapper mapper, ISellerService sellerService)
        {
            InitializeComponent();
            this.mapper = mapper;
            this.sellerService = sellerService;

            Sellers = new BindingList<SellerViewModel>();
        }

        private async void Catalog_Load(object sender, EventArgs e)
        {
            var data = await sellerService.GetAllAsync();

            var sellersList = data.Select(c => mapper.Map<SellerViewModel>(c)).ToList();

            foreach (var seller in sellersList)
            {
                Sellers.Add(seller);
            }

            dataGridView.DataSource = Sellers;
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            var form = new SellerForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var newSeller = mapper.Map<SellerDTO>(form.Seller);
                var seller = await sellerService.CreateAsync(newSeller);

                Sellers.Add(mapper.Map<SellerViewModel>(seller));
                dataGridView.Refresh();
            }
        }

        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            var id = dataGridView.SelectedRows[0].Cells[0].Value;

            var data = await sellerService.GetAsync((int)id);

            var seller = mapper.Map<SellerViewModel>(data);

            if (seller != null)
            {
                var form = new SellerForm(seller);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var updateSeller = mapper.Map<SellerDTO>(form.Seller);
                    await sellerService.UpdateAsync(updateSeller);

                    var index = Sellers.IndexOf(Sellers.First(c => c.SellerId == updateSeller.SellerId));
                    Sellers[index] = seller;

                    dataGridView.Refresh();
                }    
            }
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            var id = dataGridView.SelectedRows[0].Cells[0].Value;

            var data = await sellerService.GetAsync((int)id);

            var seller = mapper.Map<SellerViewModel>(data);

            if (seller != null)
            {
                await sellerService.DeleteAsync((int)id);

                Sellers.Remove(Sellers.First(c => c.SellerId == (int)id));

                dataGridView.Refresh();
            }
        }
    }
}
