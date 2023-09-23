using AutoMapper;
using CrmWinForm.Helpers;
using ShopCRM.BLL.ComputerModel;

namespace CrmWinForm
{
    public partial class ModelForm : Form
    {
        IMapper mapper;
        ShopComputerModel model;

        public ModelForm(IMapper mapper)
        {
            InitializeComponent();

            this.mapper = mapper;
            model = new ShopComputerModel(mapper);
        }

        private void ModelForm_Load(object sender, EventArgs e)
        {
            CustomerSpeedValue.Value = model.CustomerSpeed;
            CashDeskSpeedValue.Value = model.CashDeskSpeed;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            var cashBoxes = new List<CashBoxView>();

            for (int i = 0; i < model.CashDesks.Count; i++)
            {
                var box = new CashBoxView(model.CashDesks[i], i, 10, 26 * i);
                cashBoxes.Add(box);
                Controls.Add(box.CashDeskName);
                Controls.Add(box.Price);
                Controls.Add(box.QueueLenght);
                Controls.Add(box.LeaveCustomersCount);
            }

            model.Start();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            model.Stop();
        }

        private void ModelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            model.Stop();
        }

        private void CustomerSpeedValue_ValueChanged(object sender, EventArgs e)
        {
            model.CustomerSpeed = Convert.ToInt32(CustomerSpeedValue.Value);
        }

        private void CashDeskSpeedValue_ValueChanged(object sender, EventArgs e)
        {
            model.CashDeskSpeed = Convert.ToInt32(CashDeskSpeedValue.Value);
        }
    }
}
