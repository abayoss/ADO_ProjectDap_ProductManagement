using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Project_Dap.PL_Utilisateur
{
    public partial class UserPrincipal : Form
    {
        List<PictureBox> pictureBoxes = new List<PictureBox>();

        BL.CLS_PRODUCTS prd = new BL.CLS_PRODUCTS();
        public UserPrincipal()
        {
            InitializeComponent();
            this.DG_Produit.DataSource = prd.GET_ALL_PRODUCTS();

        }

        private void button15_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control[] matches;
            for (int i = 1; i <= 100; i++)
            {
                matches = this.Controls.Find("pictureBox" + i.ToString(), true);
                if (matches.Length > 0 && matches[0] is PictureBox)
                {
                    pictureBoxes.Add((PictureBox)matches[0]);
                }
            }
            Console.WriteLine(pictureBoxes.Count.ToString());
        }
        private void UserPrincipal_Load(object sender, EventArgs e)
        {
            try
            {   
                //ussef idea :

                //foreach(DataRow dr in DG_Produit.Rows)
                //{
                //    for(int i =0; i <DG_Produit.Columns.Count;i++)
                //    {
                //        byte[] image = (byte[])prd.GET_IMAGE_PRODUCT(DG_Produit.Rows[i].Cells[0].Value.ToString()).Rows[0][0];
                //        MemoryStream ms = new MemoryStream(image);
                //    }
                //}
                for (int i = 1; i < 4; i++)
                {
                    byte[] image = (byte[])prd.GET_IMAGE_PRODUCT(DG_Produit.Rows[i].Cells[0].Value.ToString()).Rows[0][0];
                    MemoryStream ms = new MemoryStream(image);
                    i++;
                    byte[] image2 = (byte[])prd.GET_IMAGE_PRODUCT(DG_Produit.Rows[i].Cells[0].Value.ToString()).Rows[0][0];
                    MemoryStream ms2 = new MemoryStream(image2);
                    i++;
                    byte[] image3 = (byte[])prd.GET_IMAGE_PRODUCT(DG_Produit.Rows[i].Cells[0].Value.ToString()).Rows[0][0];
                    MemoryStream ms3 = new MemoryStream(image3);
                    i++;
                    byte[] image4 = (byte[])prd.GET_IMAGE_PRODUCT(DG_Produit.Rows[i].Cells[0].Value.ToString()).Rows[0][0];
                    MemoryStream ms4 = new MemoryStream(image4);
                    i++;
                    byte[] image5 = (byte[])prd.GET_IMAGE_PRODUCT(DG_Produit.Rows[i].Cells[0].Value.ToString()).Rows[0][0];
                    MemoryStream ms5 = new MemoryStream(image5);
                    i++;
                    byte[] image6 = (byte[])prd.GET_IMAGE_PRODUCT(DG_Produit.Rows[i].Cells[0].Value.ToString()).Rows[0][0];
                    MemoryStream ms6 = new MemoryStream(image6);
                    pictureBox1.Image = Image.FromStream(ms);
                    pictureBox2.Image = Image.FromStream(ms2);
                    pictureBox3.Image = Image.FromStream(ms3);
                    pictureBox4.Image = Image.FromStream(ms4);
                    pictureBox5.Image = Image.FromStream(ms5);
                    pictureBox6.Image = Image.FromStream(ms6);
                }

                for (int r = 1; r < 7; r++)
                {
                    label1.Text = DG_Produit.Rows[r].Cells[0].Value.ToString();
                    label2.Text = DG_Produit.Rows[r].Cells[2].Value.ToString();
                    label3.Text = DG_Produit.Rows[r].Cells[3].Value.ToString();
                    r++;
                    label6.Text = DG_Produit.Rows[r].Cells[0].Value.ToString();
                    label5.Text = DG_Produit.Rows[r].Cells[2].Value.ToString();
                    label4.Text = DG_Produit.Rows[r].Cells[3].Value.ToString();
                    r++;
                    label10.Text = DG_Produit.Rows[r].Cells[0].Value.ToString();
                    label9.Text = DG_Produit.Rows[r].Cells[2].Value.ToString();
                    label7.Text = DG_Produit.Rows[r].Cells[3].Value.ToString();
                    r++;
                    label13.Text = DG_Produit.Rows[r].Cells[0].Value.ToString();
                    label12.Text = DG_Produit.Rows[r].Cells[2].Value.ToString();
                    label11.Text = DG_Produit.Rows[r].Cells[3].Value.ToString();
                    r++;
                    label16.Text = DG_Produit.Rows[r].Cells[0].Value.ToString();
                    label15.Text = DG_Produit.Rows[r].Cells[2].Value.ToString();
                    label14.Text = DG_Produit.Rows[r].Cells[3].Value.ToString();
                    r++;
                    label19.Text = DG_Produit.Rows[r].Cells[0].Value.ToString();
                    label18.Text = DG_Produit.Rows[r].Cells[2].Value.ToString();
                    label17.Text = DG_Produit.Rows[r].Cells[3].Value.ToString();

                }

            }
            catch
            {
                MessageBox.Show("No Photo1 Here");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void DG_Produit_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          

        }

        private void DG_Produit_Click(object sender, EventArgs e)
        {
            try
            {

                byte[] image = (byte[])prd.GET_IMAGE_PRODUCT(DG_Produit.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];
                MemoryStream ms = new MemoryStream(image);
                pictureBox5.Image = Image.FromStream(ms);
                label16.Text = DG_Produit.CurrentRow.Cells[0].Value.ToString();
                label15.Text = DG_Produit.CurrentRow.Cells[2].Value.ToString();
                label14.Text = DG_Produit.CurrentRow.Cells[3].Value.ToString();
             
        }
            catch
            {
                MessageBox.Show("No Photo Here");
            }

}

        private void Header_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
