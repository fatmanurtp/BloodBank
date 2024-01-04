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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace BloodBank
{
    public partial class DonateBlood : Form
    {
        public DonateBlood()
        {
            InitializeComponent();
            populate();
            bloodStock();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\fatmanur\OneDrive\Belgeler\BloodBankDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string Query = "select * from DonorTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            // güncelleme yapmak için 
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DonorDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void bloodStock()
        {
            Con.Open();
            string Query = "select * from BloodTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BloodStock.DataSource = ds.Tables[0];
            Con.Close();

        }
        int oldstock;
        private void GetStock(string BType )
        {
            // helps to gets the actual stock of Blood based on particular blod Group
            Con.Open();
            string query = "select * from BloodTbl where ='" + BType+ ",";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                oldstock = Convert.ToInt32(dr["BStock"].ToString());
            }
            Con.Close();
        }


        private void DonorDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DNameTb.Text = DonorDGV.SelectedRows[0].Cells[1].Value.ToString();
            textBox1.Text = DonorDGV.SelectedRows[0].Cells[3].Value.ToString();
            GetStock(textBox1.Text);

        }
        private void reset()
        {
            DNameTb.Text = "";
            textBox1.Text = "";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (DNameTb.Text =="")
            {
                MessageBox.Show("Select A Donor");
            }
            else
            {
                try
                {
                    int stock = oldstock + 1; 
                    string query = "update BloodTbl set BStock =" + textBox1.Text + "where BType ='" + DNameTb.Text +"';";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donation Successfull");
                    Con.Close();
                    reset();
                    bloodStock();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void DonateBlood_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor Ob = new Donor();
            Ob.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            DonorsDGV Ob = new DonorsDGV();
            Ob.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Patient Ob = new Patient();
            Ob.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ViewPatients Ob = new ViewPatients();
            Ob.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            BloodStock Ob = new BloodStock();
            Ob.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            PatientName Ob = new PatientName();
            Ob.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Dashboard Ob = new Dashboard();
            Ob.Show();
            this.Hide();
        }
    }
}
