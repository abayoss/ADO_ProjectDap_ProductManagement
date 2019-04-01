using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Project_Dap.PL_Admin
{
    public partial class A1_1_Form : Form
    {
        public string state = "add";
        BL.CLS_PRODUCTS prd = new BL.CLS_PRODUCTS();

        public A1_1_Form()
        {
            InitializeComponent();
            cmbCategories.DataSource = prd.GET_ALL_CATEGORIES();
            cmbCategories.DisplayMember = "DESCRIPTION_CAT";
            cmbCategories.ValueMember = "ID_CAT";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (state == "add")
            {
                if (txtDes.Text == "" || txtRef.Text == "" || txtQte.Text == "" || txtPrice.Text == "")
                {
                    MessageBox.Show("Entrer Tous Les Information", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        MemoryStream ms = new MemoryStream();
                        pbox.Image.Save(ms, pbox.Image.RawFormat);
                        byte[] byteImage = ms.ToArray();

                        prd.ADD_PRODUCT(Convert.ToInt32(cmbCategories.SelectedValue), txtDes.Text
                            , txtRef.Text, Convert.ToInt32(txtQte.Text), txtPrice.Text, byteImage);

                        MessageBox.Show("Ajouté Avec Succée", "L'ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        byte[] byteImage;
                        byteImage = new byte[0];
                        prd.ADD_PRODUCT(Convert.ToInt32(cmbCategories.SelectedValue), txtDes.Text
                            , txtRef.Text, Convert.ToInt32(txtQte.Text), txtPrice.Text, byteImage);

                        MessageBox.Show("Ajouté Avec Succée", "L'ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }                                
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                pbox.Image.Save(ms, pbox.Image.RawFormat);
                byte[] byteImage = ms.ToArray();

                prd.UPDATE_PRODUCT(Convert.ToInt32(cmbCategories.SelectedValue), txtDes.Text
                    , txtRef.Text, Convert.ToInt32(txtQte.Text), txtPrice.Text, byteImage);

                MessageBox.Show("Modifié", " Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            A1_form refrch = new A1_form();
            refrch.button12_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = " Fichier Image |*.JPG; *.PNG; *.GIF; *.BMP";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbox.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void txtRef_TextChanged(object sender, EventArgs e)
        {
            if (state == "add")
            {
                DataTable Dt = new DataTable();
                Dt = prd.VerifyProductID(txtRef.Text);
                if (Dt.Rows.Count > 0)
                {

                    MessageBox.Show("Produit Existe Déja", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRef.Focus();
                    txtRef.SelectionStart = 0;
                    txtRef.SelectionLength = txtRef.TextLength;
                }
            }
               
        }

        private void A1_1_Form_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            A1_form refrch = new A1_form();
            refrch.button12_Click(sender, e);
            txtDes.Text = null;
            txtPrice.Text = null;
            txtQte.Text = null;
            txtRef.Text = null;
            pbox.Image = null;
            
        }
    }
}
