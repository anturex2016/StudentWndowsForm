using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace App._01
{
    public partial class UpdateFrom : Form
    {
        public UpdateFrom()
        {
            InitializeComponent();
        }

        private void UpdateFrom_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dsCmbRoll.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.dsCmbRoll.Student);
            cmbRoll.SelectedValue = -1;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            SqlConnection cn = new SqlConnection(@"Data Source=ANTU\SQLEXPRESS;Initial Catalog=Prectice01;Integrated Security=True");
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Update Student set Email=@email,Roll=@roll,[Address]=@address  where Id=@id ";
          
            cmd.Parameters.AddWithValue("id",cmbRoll.SelectedValue );
            cmd.Parameters.AddWithValue("email", txtEmail.Text);
            cmd.Parameters.AddWithValue("roll", txtRoll.Text);
            cmd.Parameters.AddWithValue("address", txtAddress.Text);
            int row = cmd.ExecuteNonQuery();
            cn.Close();

            if (row > 0)
            {
                lblMessage.Text = "Data updated";

                lblEmail.Text = txtEmail.Text;
                lblRoll.Text = txtRoll.Text;
                lblAddress.Text = txtAddress.Text;

            }
            else
            {
                lblMessage.Text = "update Fail";

            }
            cmbRoll.SelectedValue = -1;
            txtEmail.Text = "";
            txtRoll.Text = "";
            txtAddress.Text = "";

            
           
            
        }
    }
}
