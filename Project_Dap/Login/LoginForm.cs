using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Project_Dap
{
    public partial class LoginForm : Form
    {
        BL.CLS_LOGIN log = new BL.CLS_LOGIN();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtID.Focus();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable Dt = log.LOGIN(txtID.Text, txtPWD.Text);
            if (Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0][2].ToString() == "Admin")
                {
                    label2.ForeColor = Color.Black;
                    MessageBox.Show("you'r Loged in admin ");
                    PL_Admin.A1_form A1 = new PL_Admin.A1_form();
                    A1.ShowDialog();
                    this.Close();
                    txtID.Clear();
                }
                else if (Dt.Rows[0][2].ToString() == "User")
                {
                    label2.ForeColor = Color.Black;
                    MessageBox.Show("you'r Loged in");
                    PL_Utilisateur.UserPrincipal user = new PL_Utilisateur.UserPrincipal();
                    user.ShowDialog();
                    this.Close();
                    txtPWD.Clear();
                }

            }
            else
            {
                label2.ForeColor = Color.Red;
                MessageBox.Show("Login failed !");
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
