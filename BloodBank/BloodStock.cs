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

namespace BloodBank
{
    public partial class BloodStock : Form
    {
        public BloodStock()
        {
            InitializeComponent();
            bloodStock();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\fatmanur\OneDrive\Belgeler\BloodBankDb.mdf;Integrated Security=True;Connect Timeout=30");

      

        private void bloodStock()
        {
            Con.Open();
            string Query = "select * from BloodTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void BloodStock_Load(object sender, EventArgs e)
        {
           PatientName Ob = new PatientName();
            Ob.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            PatientName Bt = new PatientName();
            Bt.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor Ob = new Donor();
            Ob.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            DonateBlood Ob = new DonateBlood();
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

        private void label7_Click(object sender, EventArgs e)
        {
            Dashboard Ob = new Dashboard();
            Ob.Show();
            this.Hide();
        }
    }
}
