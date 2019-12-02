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
    public partial class DeleteForm : Form
    {
        public DeleteForm()
        {
            InitializeComponent();
        }

        private void DeleteForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'prectice01DataSet.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.prectice01DataSet.Student);
            cmbDelete.SelectedValue = -1;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            lblDelete.Text = "";
            SqlConnection cn = new SqlConnection(@"Data Source=ANTU\SQLEXPRESS;Initial Catalog=Prectice01;Integrated Security=True");
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Delete  from Student where Id=@id ";

            cmd.Parameters.AddWithValue("id", cmbDelete.SelectedValue);
         
            int row = cmd.ExecuteNonQuery();
            cn.Close();

            if (row > 0)
            {
                lblDelete.Text = "Data Deleted";

              

            }
            else
            {
                lblDelete.Text = "Delete Failed";

            }

            

        }
    }
}
