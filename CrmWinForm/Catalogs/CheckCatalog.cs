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
    public partial class CheckCatalog : Form
    {
        IMapper mapper;
        ICheckService checkService;
        BindingList<CheckViewModel> Checks;

        public CheckCatalog()
        {
            InitializeComponent();
        }

        public CheckCatalog(IMapper mapper, ICheckService checkService)
        {
            InitializeComponent();
            this.mapper = mapper;
            this.checkService = checkService;

            Checks = new BindingList<CheckViewModel>();
        }

        private async void Catalog_Load(object sender, EventArgs e)
        {
            var data = await checkService.GetAllAsync();

            var checksList = data.Select(c => mapper.Map<CheckViewModel>(c)).ToList();

            foreach (var check in checksList)
            {
                Checks.Add(check);
            }

            dataGridView.DataSource = Checks;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
