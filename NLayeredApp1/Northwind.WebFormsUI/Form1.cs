﻿using Northwind.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using Norhwind.DataAccess.Concrete.EntityFramework;
using Northwind.Business.Abstract;
using Norhwind.DataAccess.Concrete.Entity_Framework;
using Northwind.Business.Concrete;
using Northwind.Entities.Concrete;
using Northwind.Business.DependencyResolvers.Ninject;

namespace Northwind.WebFormsUI
{
    public partial class Form1 : Form
    {  
        public Form1()
        {
            InitializeComponent();
            _productService = InstanceFactory.GetInstance<IProductService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();

        }

        private IProductService _productService;
        private ICategoryService _categoryService;
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();

        }
        private void LoadCategories()
        {
            cbxCategory.DataSource = _categoryService.GetAll();
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryId";
            
            cbxCategoryID.DataSource = _categoryService.GetAll();
            cbxCategoryID.DisplayMember = "CategoryName";
            cbxCategoryID.ValueMember = "CategoryId";
            
            
            cbxCategoryIdUpdate.DataSource = _categoryService.GetAll();
            cbxCategoryIdUpdate.DisplayMember = "CategoryName";
            cbxCategoryIdUpdate.ValueMember = "CategoryId";
        }

        private void LoadProducts()
        {
            dgwProduct.DataSource = _productService.GetAll();
        }

        private void dgwProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProduct.DataSource = _productService.GetProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
            }
            catch 
            {

            }
           
        }

        private void tbxProductName_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxProductName.Text))
            {
                dgwProduct.DataSource = _productService.GetProductsByProductName(tbxProductName.Text);
            }
            else
            {
               LoadProducts();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Add(new Product
                {
                    CategoryId = Convert.ToInt32(cbxCategoryID.SelectedValue),
                    ProductName = tbxProductName2.Text,
                    QuantityPerUnit = tbxQuantityPerUnit.Text,
                    UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                    UnitsInStock = Convert.ToInt16(tbxStock.Text)


                });
                MessageBox.Show("Ürün Kaydedildi! !!!");
                LoadProducts();

            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
            
          

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Update(new Product
                {
                    ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                    ProductName = tbxUpdateProductName.Text,
                    CategoryId = Convert.ToInt32(cbxCategoryIdUpdate.SelectedValue),
                    UnitsInStock = Convert.ToInt16(tbxUnitsInStockUpdate),
                    QuantityPerUnit = tbxQuantityPerUnitUpdate.Text,
                    UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text)
                });
                MessageBox.Show("Ürün Güncellendi");
                LoadProducts();

            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
            

        }

        private void dgwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dgwProduct.CurrentRow;

            tbxUpdateProductName.Text= row.Cells[1].Value.ToString();
            cbxCategoryIdUpdate.SelectedValue = row.Cells[2].Value;
            tbxUnitPriceUpdate.Text = row.Cells[3].Value.ToString();
            tbxQuantityPerUnitUpdate.Text = row.Cells[4].Value.ToString();
            tbxUnitsInStockUpdate.Text = row.Cells[5].Value.ToString();


        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgwProduct.CurrentRow!=null)
          {
                try
                {
                    _productService.Delete(new Product
                    {
                        ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),

                    });
                    MessageBox.Show("Ürün Silindi !!!");
                    LoadProducts();

                }
                catch (Exception exception)
                {

                    MessageBox.Show(exception.Message);

                }
           
          }
           
        }
    }
}
