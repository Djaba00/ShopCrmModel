namespace CrmWinForm
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            сущностиToolStripMenuItem = new ToolStripMenuItem();
            productToolStripMenuItem = new ToolStripMenuItem();
            productAddToolStripMenuItem1 = new ToolStripMenuItem();
            sellerToolStripMenuItem = new ToolStripMenuItem();
            sellerAddToolStripMenuItem = new ToolStripMenuItem();
            customerToolStripMenuItem = new ToolStripMenuItem();
            customerAddToolStripMenuItem2 = new ToolStripMenuItem();
            checkToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { сущностиToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // сущностиToolStripMenuItem
            // 
            сущностиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { productToolStripMenuItem, sellerToolStripMenuItem, customerToolStripMenuItem, checkToolStripMenuItem });
            сущностиToolStripMenuItem.Name = "сущностиToolStripMenuItem";
            сущностиToolStripMenuItem.Size = new Size(76, 20);
            сущностиToolStripMenuItem.Text = "Сущности";
            // 
            // productToolStripMenuItem
            // 
            productToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { productAddToolStripMenuItem1 });
            productToolStripMenuItem.Name = "productToolStripMenuItem";
            productToolStripMenuItem.Size = new Size(180, 22);
            productToolStripMenuItem.Text = "Товар";
            productToolStripMenuItem.Click += ProductToolStripMenuItem_Click;
            // 
            // productAddToolStripMenuItem1
            // 
            productAddToolStripMenuItem1.Name = "productAddToolStripMenuItem1";
            productAddToolStripMenuItem1.Size = new Size(180, 22);
            productAddToolStripMenuItem1.Text = "Добавить";
            productAddToolStripMenuItem1.Click += ProductAddToolStripMenuItem1_Click;
            // 
            // sellerToolStripMenuItem
            // 
            sellerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sellerAddToolStripMenuItem });
            sellerToolStripMenuItem.Name = "sellerToolStripMenuItem";
            sellerToolStripMenuItem.Size = new Size(180, 22);
            sellerToolStripMenuItem.Text = "Продавец";
            sellerToolStripMenuItem.Click += SellerToolStripMenuItem_Click;
            // 
            // sellerAddToolStripMenuItem
            // 
            sellerAddToolStripMenuItem.Name = "sellerAddToolStripMenuItem";
            sellerAddToolStripMenuItem.Size = new Size(180, 22);
            sellerAddToolStripMenuItem.Text = "Добавить";
            sellerAddToolStripMenuItem.Click += SellerAddToolStripMenuItem2_Click;
            // 
            // customerToolStripMenuItem
            // 
            customerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { customerAddToolStripMenuItem2 });
            customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            customerToolStripMenuItem.Size = new Size(180, 22);
            customerToolStripMenuItem.Text = "Покупатель";
            customerToolStripMenuItem.Click += CustomerToolStripMenuItem_Click;
            // 
            // customerAddToolStripMenuItem2
            // 
            customerAddToolStripMenuItem2.Name = "customerAddToolStripMenuItem2";
            customerAddToolStripMenuItem2.Size = new Size(126, 22);
            customerAddToolStripMenuItem2.Text = "Добавить";
            customerAddToolStripMenuItem2.Click += CustomerAddToolStripMenuItem2_Click;
            // 
            // checkToolStripMenuItem
            // 
            checkToolStripMenuItem.Name = "checkToolStripMenuItem";
            checkToolStripMenuItem.Size = new Size(180, 22);
            checkToolStripMenuItem.Text = "Чек";
            checkToolStripMenuItem.Click += CheckToolStripMenuItem_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Main";
            Text = "Form1";
            Load += Main_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem сущностиToolStripMenuItem;
        private ToolStripMenuItem productToolStripMenuItem;
        private ToolStripMenuItem sellerToolStripMenuItem;
        private ToolStripMenuItem customerToolStripMenuItem;
        private ToolStripMenuItem checkToolStripMenuItem;
        private ToolStripMenuItem productAddToolStripMenuItem1;
        private ToolStripMenuItem sellerAddToolStripMenuItem;
        private ToolStripMenuItem customerAddToolStripMenuItem2;
    }
}