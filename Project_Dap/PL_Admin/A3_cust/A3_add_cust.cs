using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Project_Dap.PL_Admin.A3
{
    public partial class A3_add_cust : Form
    {
        BL.CLS_CUSTOMERS cust = new BL.CLS_CUSTOMERS();
        public int id ;
        public A3_add_cust()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtEmail.Text == "" || txtFirstName.Text == "" || txtLastName.Text == "" || txtTel.Text == "")
            {
                MessageBox.Show("Entrer Tous Les Information", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                if (btnSave.Text == "Enregistrer")
                {
                    byte[] Picture;
                    if (pbox.Image == null)
                    {
                        Picture = new byte[0];
                        cust.ADD_CUSTOMER(txtFirstName.Text, txtLastName.Text, txtTel.Text, txtEmail.Text, Picture, "without_image");
                        MessageBox.Show("Ajouté Avec Succés", "L'ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtEmail.Text = txtFirstName.Text = txtLastName.Text = txtTel.Text = "";
                    }
                    else
                    {

                        MemoryStream ms = new MemoryStream();
                        pbox.Image.Save(ms, pbox.Image.RawFormat);
                        Picture = ms.ToArray();
                        cust.ADD_CUSTOMER(txtFirstName.Text, txtLastName.Text, txtTel.Text, txtEmail.Text, Picture, "with_image");
                        MessageBox.Show("Ajouté Avec Succés", "L'ajout", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtEmail.Text = txtFirstName.Text = txtLastName.Text = txtTel.Text = "";
                    }
                }
                else if (btnSave.Text == "Modifier")
                {
                    try
                    {

                        if (id == 0)
                        {
                            MessageBox.Show("Client Non Disponible");
                            return;
                        }

                        byte[] Picture;
                        if (pbox.Image == null)
                        {
                            Picture = new byte[0];
                            cust.EDIT_CUSTOMER(txtFirstName.Text, txtLastName.Text, txtTel.Text, txtEmail.Text, Picture, "without_image", id);
                            MessageBox.Show("Modifier Avec Succés", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtEmail.Text = txtFirstName.Text = txtLastName.Text = txtTel.Text = "";
                            Close();
                        }
                        else
                        {

                            MemoryStream ms = new MemoryStream();
                            pbox.Image.Save(ms, pbox.Image.RawFormat);
                            Picture = ms.ToArray();
                            cust.EDIT_CUSTOMER(txtFirstName.Text, txtLastName.Text, txtTel.Text, txtEmail.Text, Picture, "with_image", id);
                            MessageBox.Show("Modifier Avec Succés", "Modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtEmail.Text = txtFirstName.Text = txtLastName.Text = txtTel.Text = "";
                            pbox.Image = null;
                            Close();
                        }
                    }
                    catch
                    {
                        return;
                    }
                }                
            }
        }

        private void pbox_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = " Fichier Image |*.JPG; *.PNG; *.GIF; *.BMP";
            if (op.ShowDialog() == DialogResult.OK)
            {
                pbox.Image = Image.FromFile(op.FileName);
            }
        }
    }
}
