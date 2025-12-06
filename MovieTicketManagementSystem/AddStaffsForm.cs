using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MovieTicketManagementSystem
{
    public partial class AddStaffsForm : UserControl
    {

        // Dấu . thay cho tên máy cụ thể
        string conn = @"Data Source=.;
                      Initial Catalog=movie;
                      Integrated Security=True;
                      Encrypt=False";

        public AddStaffsForm()
        {
            InitializeComponent();
        }

        private void addStaff_addBtn_Click(object sender, EventArgs e)
        {
            if (isEmpty())
            {
                MessageBox.Show("Empty fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection connect = new SqlConnection(conn))
                {
                    connect.Open();

                    string selectUsername = "SELECT * FROM users WHERE username = @usern";

                    using (SqlCommand checkUsern = new SqlCommand(selectUsername, connect))
                    {
                        checkUsern.Parameters.AddWithValue("@usern", addStaff_username.Text.Trim());

                        SqlDataAdapter adapter = new SqlDataAdapter(checkUsern);
                        DataTable table = new DataTable();

                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            MessageBox.Show(addStaff_username.Text.Substring(0, 1).ToUpper()
                                + addStaff_username.Text.Substring(1) + " is Existing Already"
                                , "Error Message" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string insertData = "INSERT INTO users (username, password, role, status, date_reg) VALUES" +
                               "(@usern, @pass, @role, @status, @date)";

                            using (SqlCommand cmd = new SqlCommand(insertData, connect))
                            {
                                cmd.Parameters.AddWithValue("@usern", addStaff_username.Text.Trim());
                                cmd.Parameters.AddWithValue("@pass", addStaff_password.Text.Trim());
                                cmd.Parameters.AddWithValue("@role", "Staff");
                                cmd.Parameters.AddWithValue("@status", addStaff_status.SelectedItem.ToString());

                                DateTime today = DateTime.Today;

                                cmd.Parameters.AddWithValue("@date", today);

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Added successful", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }

        }

        public bool isEmpty()
        {
            if (addStaff_username.Text == "" || addStaff_password.Text == "" || addStaff_status.SelectedIndex == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
