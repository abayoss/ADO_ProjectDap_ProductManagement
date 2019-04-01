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
    public partial class A1_form : Form
    {
        int id;
        BL.CLS_LOGIN login = new BL.CLS_LOGIN();
        BL.CLS_PRODUCTS prd = new BL.CLS_PRODUCTS();
        BL.CLS_CUSTOMERS cust = new BL.CLS_CUSTOMERS();
        BL.CLS_ORDERS ord = new BL.CLS_ORDERS();

        public A1_form()
        {
            InitializeComponent();
            
            this.DG_Produit.DataSource = prd.GET_ALL_PRODUCTS();
            this.DG_Uti.DataSource = login.SearchUsers("");
            this.DG_Cust.DataSource = cust.GET_ALL_CUSTOMERS();
            this.DG_Commandes.DataSource = ord.SearchOrders("");

            DG_Cust.Columns[0].Visible = false;
            DG_Cust.Columns[5].Visible = false;

        }
        private void label20_Click(object sender, EventArgs e)
        {
           

        }
        private void button15_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
        //color Switch methods :
        #region "colorSwitch"
        void colorSwitch1()
        {
            Les_Produits.BackColor = Color.White;
            Les_Utilisateur.BackColor = Color.LightGray;
            Les_Commandes.BackColor = Color.LightGray;
            LesCustomers.BackColor = Color.LightGray;

        }
        void colorSwitch2()
        {
            Les_Produits.BackColor = Color.LightGray;
            Les_Utilisateur.BackColor = Color.White;
            Les_Commandes.BackColor = Color.LightGray;
            LesCustomers.BackColor = Color.LightGray;

        }
        void colorSwitch3()
        {
            Les_Produits.BackColor = Color.LightGray;
            Les_Utilisateur.BackColor = Color.LightGray;
            Les_Commandes.BackColor = Color.White;
            LesCustomers.BackColor = Color.LightGray;

        }
        void colorSwitch4()
        {
            Les_Produits.BackColor = Color.LightGray;
            Les_Utilisateur.BackColor = Color.LightGray;
            Les_Commandes.BackColor = Color.LightGray;
            LesCustomers.BackColor = Color.White;

        }
        #endregion
        //les produits :
        #region "les Produits"

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable Dt = new DataTable();
            Dt = prd.SearchProduct(txtSearch.Text);
            this.DG_Produit.DataSource = Dt;
        }

        private void Les_Utilisateur_Click(object sender, EventArgs e)
        {
            P_G_UTI.BringToFront();
            colorSwitch2();

        }

        private void Les_Produits_Click(object sender, EventArgs e)
        {
            P_G_prd.BringToFront();
            colorSwitch1();
        }

        private void Les_Commandes_Click(object sender, EventArgs e)
        {
            P_Com.BringToFront();
            colorSwitch3();
        }

        private void Btn_Ajouter_Click(object sender, EventArgs e)
        {

            A1_1_Form A1_1 = new A1_1_Form();
            A1_1.ShowDialog();
            this.DG_Produit.DataSource = prd.GET_ALL_PRODUCTS();

        }

        public void button12_Click(object sender, EventArgs e)
        {
            this.DG_Produit.DataSource = prd.GET_ALL_PRODUCTS();
        }
        private void button21_Click(object sender, EventArgs e)
        {
            colorSwitch4();
            P_G_Cust.BringToFront();
        }

        private void Btn_prd_Modifier_Click(object sender, EventArgs e)
        {
            A1_1_Form frm = new A1_1_Form();
            frm.state = "update";
            frm.txtRef.Text = this.DG_Produit.CurrentRow.Cells[0].Value.ToString();
            frm.txtDes.Text = this.DG_Produit.CurrentRow.Cells[1].Value.ToString();
            frm.txtQte.Text = this.DG_Produit.CurrentRow.Cells[2].Value.ToString();
            frm.txtPrice.Text = this.DG_Produit.CurrentRow.Cells[3].Value.ToString();
            frm.cmbCategories.Text = this.DG_Produit.CurrentRow.Cells[4].Value.ToString();
            frm.Text = "Modification de : " + this.DG_Produit.CurrentRow.Cells[1].Value.ToString();
            frm.btnOk.Text = "Modifier";
            frm.txtRef.ReadOnly = true;

            byte[] image = (byte[])prd.GET_IMAGE_PRODUCT(this.DG_Produit.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];
            MemoryStream ms = new MemoryStream(image);
            frm.pbox.Image = Image.FromStream(ms);
            frm.ShowDialog();
            this.DG_Produit.DataSource = prd.GET_ALL_PRODUCTS();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                A1.A1_2_Form frm = new A1.A1_2_Form();
                byte[] image = (byte[])prd.GET_IMAGE_PRODUCT(this.DG_Produit.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];
                MemoryStream ms = new MemoryStream(image);
                frm.pictureBox1.Image = Image.FromStream(ms);
                frm.ShowDialog();
            }
            catch
            {
                MessageBox.Show("No photo here");
            }
        }

        private void Btn_supprimer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez Vous Supprimer Ce Produit", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                prd.DeleteProduct(this.DG_Produit.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Produit Supprimé", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DG_Produit.DataSource = prd.GET_ALL_PRODUCTS();
            }
            else
            {
                MessageBox.Show("Produit NON Supprimé", "Suppression Anullée", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        #endregion        
        //les Utilisateur :
        #region "les Utilisateur"
        private void button11_Click(object sender, EventArgs e)
        {
            A2_Form frm = new A2_Form();
            frm.btnSave.Text = "Enregistrer";
            frm.ShowDialog();
            this.DG_Uti.DataSource = login.SearchUsers("");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            A2_Form frm = new A2_Form();
            frm.txtID.Text = DG_Uti.CurrentRow.Cells[0].Value.ToString();
            frm.txtFullName.Text = DG_Uti.CurrentRow.Cells[1].Value.ToString();
            frm.txtPWD.Text = DG_Uti.CurrentRow.Cells[2].Value.ToString();
            frm.txtPWDConfirm.Text = DG_Uti.CurrentRow.Cells[2].Value.ToString();
            frm.cmbType.Text = DG_Uti.CurrentRow.Cells[3].Value.ToString();
            frm.btnSave.Text = "Modifier";
            frm.ShowDialog();
            this.DG_Uti.DataSource = login.SearchUsers("");
        }

        private void text_search_Uti_TextChanged(object sender, EventArgs e)
        {
            this.DG_Uti.DataSource = login.SearchUsers(txtSearch.Text);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez Vous Supprimer Ce utilisateur", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                login.DELETE_USER(DG_Uti.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Supprimer", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DG_Uti.DataSource = login.SearchUsers("");
            }
        }
        #endregion
        //les Customers:
        #region "les Customers"
        private void button20_Click(object sender, EventArgs e)
        {
            
            A3.A3_add_cust frm1 = new A3.A3_add_cust();
            frm1.btnSave.Text = "Enregistrer";
            frm1.ShowDialog();
            DG_Cust.DataSource = cust.GET_ALL_CUSTOMERS();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                A3.A3_add_cust frm = new A3.A3_add_cust();
                frm.btnSave.Text = "Modifier";

                frm.id = Convert.ToInt32(DG_Cust.CurrentRow.Cells[0].Value);

                frm.txtLastName.Text = DG_Cust.CurrentRow.Cells[1].Value.ToString();
                frm.txtFirstName.Text = DG_Cust.CurrentRow.Cells[2].Value.ToString();
                frm.txtTel.Text = DG_Cust.CurrentRow.Cells[3].Value.ToString();
                frm.txtEmail.Text = DG_Cust.CurrentRow.Cells[4].Value.ToString();
            
                byte[] Picture = (byte[])DG_Cust.CurrentRow.Cells[5].Value;
                MemoryStream ms = new MemoryStream(Picture);
                frm.pbox.Image = Image.FromStream(ms);

                frm.ShowDialog();
            }
            catch
            {
                A3.A3_add_cust frm = new A3.A3_add_cust();
                frm.id = Convert.ToInt32(DG_Cust.CurrentRow.Cells[0].Value);

                frm.txtLastName.Text = DG_Cust.CurrentRow.Cells[1].Value.ToString();
                frm.txtFirstName.Text = DG_Cust.CurrentRow.Cells[2].Value.ToString();
                frm.txtTel.Text = DG_Cust.CurrentRow.Cells[3].Value.ToString();
                frm.txtEmail.Text = DG_Cust.CurrentRow.Cells[4].Value.ToString();

                frm.btnSave.Text = "Modifier";
                frm.ShowDialog();
            }
            
            DG_Cust.DataSource = cust.GET_ALL_CUSTOMERS();

        }

        private void button19_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt32(DG_Cust.CurrentRow.Cells[0].Value);
            if (id == 0)
            {
                MessageBox.Show("Client Non Disponible");
                return;
            }
            if (MessageBox.Show("Voulez Vous Supprimer Le client?", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                A3.A3_add_cust frm1 = new A3.A3_add_cust();
                cust.DELETE_CUSTOMER(id);
                this.DG_Cust.DataSource = cust.GET_ALL_CUSTOMERS();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DG_Cust.DataSource = cust.Search_Customer(textBox1.Text);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.DG_Cust.DataSource = cust.GET_ALL_CUSTOMERS();
        }

        private void A1_form_Load(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }




        #endregion
        //Les Commandes :

    }
}
