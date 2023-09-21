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
            entitiesToolStripMenuItem = new ToolStripMenuItem();
            productToolStripMenuItem = new ToolStripMenuItem();
            productAddToolStripMenuItem1 = new ToolStripMenuItem();
            sellerToolStripMenuItem = new ToolStripMenuItem();
            sellerAddToolStripMenuItem = new ToolStripMenuItem();
            customerToolStripMenuItem = new ToolStripMenuItem();
            customerAddToolStripMenuItem2 = new ToolStripMenuItem();
            checkToolStripMenuItem = new ToolStripMenuItem();
            ModelToolStripMenuItem = new ToolStripMenuItem();
            ProductList = new ListBox();
            UserCart = new ListBox();
            SummaryLadel = new Label();
            BuyButton = new Button();
            linkLabel1 = new LinkLabel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { entitiesToolStripMenuItem, ModelToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(461, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // entitiesToolStripMenuItem
            // 
            entitiesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { productToolStripMenuItem, sellerToolStripMenuItem, customerToolStripMenuItem, checkToolStripMenuItem });
            entitiesToolStripMenuItem.Name = "entitiesToolStripMenuItem";
            entitiesToolStripMenuItem.Size = new Size(76, 20);
            entitiesToolStripMenuItem.Text = "Сущности";
            // 
            // productToolStripMenuItem
            // 
            productToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { productAddToolStripMenuItem1 });
            productToolStripMenuItem.Name = "productToolStripMenuItem";
            productToolStripMenuItem.Size = new Size(139, 22);
            productToolStripMenuItem.Text = "Товар";
            productToolStripMenuItem.Click += ProductToolStripMenuItem_Click;
            // 
            // productAddToolStripMenuItem1
            // 
            productAddToolStripMenuItem1.Name = "productAddToolStripMenuItem1";
            productAddToolStripMenuItem1.Size = new Size(126, 22);
            productAddToolStripMenuItem1.Text = "Добавить";
            productAddToolStripMenuItem1.Click += ProductAddToolStripMenuItem1_Click;
            // 
            // sellerToolStripMenuItem
            // 
            sellerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sellerAddToolStripMenuItem });
            sellerToolStripMenuItem.Name = "sellerToolStripMenuItem";
            sellerToolStripMenuItem.Size = new Size(139, 22);
            sellerToolStripMenuItem.Text = "Продавец";
            sellerToolStripMenuItem.Click += SellerToolStripMenuItem_Click;
            // 
            // sellerAddToolStripMenuItem
            // 
            sellerAddToolStripMenuItem.Name = "sellerAddToolStripMenuItem";
            sellerAddToolStripMenuItem.Size = new Size(126, 22);
            sellerAddToolStripMenuItem.Text = "Добавить";
            sellerAddToolStripMenuItem.Click += SellerAddToolStripMenuItem2_Click;
            // 
            // customerToolStripMenuItem
            // 
            customerToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { customerAddToolStripMenuItem2 });
            customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            customerToolStripMenuItem.Size = new Size(139, 22);
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
            checkToolStripMenuItem.Size = new Size(139, 22);
            checkToolStripMenuItem.Text = "Чек";
            checkToolStripMenuItem.Click += CheckToolStripMenuItem_Click;
            // 
            // ModelToolStripMenuItem
            // 
            ModelToolStripMenuItem.Name = "ModelToolStripMenuItem";
            ModelToolStripMenuItem.Size = new Size(109, 20);
            ModelToolStripMenuItem.Text = "Моделирование";
            ModelToolStripMenuItem.Click += ModelToolStripMenuItem_Click;
            // 
            // ProductList
            // 
            ProductList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            ProductList.FormattingEnabled = true;
            ProductList.ItemHeight = 15;
            ProductList.Location = new Point(12, 27);
            ProductList.Name = "ProductList";
            ProductList.Size = new Size(202, 604);
            ProductList.TabIndex = 1;
            ProductList.DoubleClick += ProductList_DoubleClick;
            // 
            // UserCart
            // 
            UserCart.Anchor = AnchorStyles.Right;
            UserCart.FormattingEnabled = true;
            UserCart.ItemHeight = 15;
            UserCart.Location = new Point(242, 57);
            UserCart.Name = "UserCart";
            UserCart.Size = new Size(195, 499);
            UserCart.TabIndex = 2;
            // 
            // SummaryLadel
            // 
            SummaryLadel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            SummaryLadel.AutoSize = true;
            SummaryLadel.Location = new Point(242, 559);
            SummaryLadel.Name = "SummaryLadel";
            SummaryLadel.Size = new Size(40, 15);
            SummaryLadel.TabIndex = 3;
            SummaryLadel.Text = "Итого";
            // 
            // BuyButton
            // 
            BuyButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BuyButton.Location = new Point(242, 608);
            BuyButton.Name = "BuyButton";
            BuyButton.Size = new Size(195, 23);
            BuyButton.TabIndex = 4;
            BuyButton.Text = "Оплатить";
            BuyButton.UseVisualStyleBackColor = true;
            BuyButton.Click += BuyButton_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(242, 27);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(104, 15);
            linkLabel1.TabIndex = 5;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Здравствуй гость!";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(461, 649);
            Controls.Add(linkLabel1);
            Controls.Add(BuyButton);
            Controls.Add(SummaryLadel);
            Controls.Add(UserCart);
            Controls.Add(ProductList);
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
        private ToolStripMenuItem entitiesToolStripMenuItem;
        private ToolStripMenuItem productToolStripMenuItem;
        private ToolStripMenuItem sellerToolStripMenuItem;
        private ToolStripMenuItem customerToolStripMenuItem;
        private ToolStripMenuItem checkToolStripMenuItem;
        private ToolStripMenuItem productAddToolStripMenuItem1;
        private ToolStripMenuItem sellerAddToolStripMenuItem;
        private ToolStripMenuItem customerAddToolStripMenuItem2;
        private ToolStripMenuItem ModelToolStripMenuItem;
        private ListBox ProductList;
        private ListBox UserCart;
        private Label SummaryLadel;
        private Button BuyButton;
        private LinkLabel linkLabel1;
    }
}