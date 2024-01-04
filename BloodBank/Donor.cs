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

namespace BloodBank
{
    public partial class Donor : Form
    {
        public Donor()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\fatmanur\OneDrive\Belgeler\BloodBankDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void Reset() 
        {
            DNameTb.Text = "";
            textBox1.Text = "";
            DAgeTb.Text = "" ;
            DGenCb.SelectedIndex = -1 ;
            DBTypeCb.SelectedIndex = -1 ;
            textBox2.Text = "";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (DNameTb.Text == "" || textBox1.Text == "" || DAgeTb.Text == "" || DGenCb.SelectedIndex == -1 || DBTypeCb.SelectedIndex == -1) 
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    string query = "insert into DonorTbl values('" + DNameTb.Text + "', " + DAgeTb.Text + ", '" + DGenCb.SelectedItem.ToString() + "', '" + textBox1.Text + "', '" + textBox2.Text + "', '" + DBTypeCb.SelectedItem.ToString() + "')";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Donor Successfully Saved");
                    Con.Close();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }



            }
        }

        private void DAddressTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void Donor_Load(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
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
