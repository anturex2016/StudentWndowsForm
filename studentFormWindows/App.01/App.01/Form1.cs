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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            SqlConnection cn = new SqlConnection(@"Data Source=ANTU\SQLEXPRESS;Initial Catalog=Prectice01;Integrated Security=True  ");
            cn.Open();
            SqlCommand cmd= new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandText = "Insert into Student(Name,Email,Roll,Address) values(@name,@email,@roll,@address)";
            cmd.Parameters.AddWithValue("name",txtName.Text);
            cmd.Parameters.AddWithValue("Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("roll", txtRoll.Text);
            cmd.Parameters.AddWithValue("address", txtAddress.Text);
            int row= cmd.ExecuteNonQuery();
            cn.Close();

            if (row > 0)
            {
                lblMessage.Text = "Data Saved";

            }
            else
                lblMessage.Text = "Saved Fail";


            txtName.Text = "";
            txtEmail.Text = "";
            txtRoll.Text = "";
            txtAddress.Text = "";
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            ViewForm frm = new ViewForm();
            frm.ShowDialog();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateFrom frmUpdate = new UpdateFrom();
            frmUpdate.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteForm frmDelete = new DeleteForm();
            frmDelete.ShowDialog();
        }
    }
}
