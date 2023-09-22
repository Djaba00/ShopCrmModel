﻿using CrmBL.Models;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CrmWinForm
{
    public partial class ProductForm : Form
    {
        public ProductDTO Product { get; set; }
        public ProductForm()
        {
            InitializeComponent();
        }

        public ProductForm(ProductDTO product) : this()
        {
            Product = product;
            textBox1.Text = product.Name;
            numericUpDown1.Value = product.Price;
            numericUpDown2.Value = product.Count;
        }

        private void ProducForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product = Product ?? new ProductDTO();

            Product.Name = textBox1.Text;
            Product.Price = numericUpDown1.Value;
            Product.Count = Convert.ToInt32(numericUpDown2.Value);

            Close();
        }
    }
}
