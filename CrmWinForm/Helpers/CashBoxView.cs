using CrmWinForm.VIewModels;
using ShopCRM.BLL.BusinesModels;
using ShopCRM.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace CrmWinForm.Helpers
{
    public class CashBoxView
    {
        CashDesk cashDesk;
        public Label CashDeskName { get; private set; }
        public NumericUpDown Price { get; private set; }
        public ProgressBar QueueLenght { get; private set; }
        public Label LeaveCustomersCount { get; private set; }

        public CashBoxView(CashDesk cashDesk, int number, int x, int y)
        {
            this.cashDesk = cashDesk;

            CashDeskName = new Label();
            Price = new NumericUpDown();
            QueueLenght = new ProgressBar();
            LeaveCustomersCount = new Label();

            CashDeskName.AutoSize = true;
            CashDeskName.Location = new Point(x, y);
            CashDeskName.Name = "label" + number;
            CashDeskName.Size = new Size(38, 15);
            CashDeskName.TabIndex = number;
            CashDeskName.Text = cashDesk.ToString();

            Price.Location = new Point(x + 60, y);
            Price.Name = "numericUpDown" + number;
            Price.Size = new Size(120, 20);
            Price.TabIndex = number;
            Price.Maximum = 100000000;

            QueueLenght.Location = new Point(x + 150, y);
            QueueLenght.Maximum = cashDesk.MaxQueueLenght;
            QueueLenght.Name = "progressBar" + number;
            QueueLenght.Size = new Size(100, 23);
            QueueLenght.TabIndex = number;
            QueueLenght.Value = 0;

            CashDeskName.AutoSize = true;
            CashDeskName.Location = new Point(x + 300, y);
            CashDeskName.Name = "label" + number;
            CashDeskName.Size = new Size(38, 15);
            CashDeskName.TabIndex = number;
            CashDeskName.Text = "";

            cashDesk.CheckClosed += CashDesk_CheckClosed;
        }

        private void CashDesk_CheckClosed(object sender, CheckDTO e)
        {
            Price?.Invoke((Action)delegate
            {
                Price.Value += e.Price;
                QueueLenght.Value = cashDesk.Count;
                CashDeskName.Text = cashDesk.ExitCustomer.ToString();
            });
        }
    }
}
