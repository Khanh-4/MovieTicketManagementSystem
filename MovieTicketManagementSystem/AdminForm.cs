using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieTicketManagementSystem
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to exit?", "Confirmation Message", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Application.Exit();
            }
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure you want to logout?", "Confirmation Message",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Form1 loginForm = new Form1();
                loginForm.Show();

                this.Hide();
            }
        }
    }
}
