﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMEntityFrameworkMarket
{
    public partial class Form1 : Form
    {
        ProductDal productDal = new ProductDal();
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
            using (EMarketContext context = new EMarketContext())
            {
                dgwProduct.DataSource = context.Products.ToList();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbxSearch.Visible = true;
            pbxSearch.Visible = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            productDal.Ekle(new Product {
                Name = tbxName.Text,
                Price = Convert.ToDecimal(tbxPrice.Text),
                StockAmount = Convert.ToDecimal(tbxStockAmount.Text),
                StockAmountType = cbxStockAmountType.Text,
                Category = tbxCategory.Text
            });
            dgwProduct.DataSource = productDal.Listeleme();
            MessageBox.Show("Ürün Eklendi!","Entity Framework Market");
        }
    }
}
