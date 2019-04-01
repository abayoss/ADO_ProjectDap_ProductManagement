using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project_Dap.PL_Admin
{
    public partial class A2_Form : Form
    {
        public A2_Form()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty || txtPWD.Text == string.Empty
                || txtFullName.Text == string.Empty || txtPWDConfirm.Text == string.Empty)
            {
                MessageBox.Show("Enter Tous Les Information", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtPWD.Text != txtPWDConfirm.Text)
            {
                MessageBox.Show("Les Deux Mots De Passe ne sont Pas Identiques", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (btnSave.Text == "Enregistrer")
            {

                BL.CLS_LOGIN user = new BL.CLS_LOGIN();
                user.ADD_USER(txtID.Text, txtFullName.Text, txtPWD.Text, cmbType.Text);
                MessageBox.Show("Utilisateur Crée Avec Succée", "L'ajout De Nouveau Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (btnSave.Text == "Modifier")
            {

                BL.CLS_LOGIN user = new BL.CLS_LOGIN();
                user.EDIT_USER(txtID.Text, txtFullName.Text, txtPWD.Text, cmbType.Text);
                MessageBox.Show("Utilisateur Modifier Avec Succée", "Modification De L'Utilisateur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            txtID.Clear();
            txtFullName.Clear();
            txtPWD.Clear();
            txtPWDConfirm.Clear();
            txtID.Focus();

        }
        private void txtPWDConfirm_Validated(object sender, EventArgs e)
        {
            if (txtPWD.Text != txtPWDConfirm.Text)
            {
                MessageBox.Show("Les Deux Mots De Passe ne sont Pas Identiques", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
        }
    }
}
