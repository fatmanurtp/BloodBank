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
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\fatmanur\OneDrive\Belgeler\BloodBankDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void Reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            textBox4.Text = "";

        }
        private void Patient_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox1.Text == "" || comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1 || textBox4.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    string query = "insert into PatientTbl values('" + textBox1.Text + "', " + textBox2.Text + ", '" + textBox3.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + comboBox2.SelectedItem.ToString() + "' , '" + textBox4.Text + "')";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Successfully Saved");
                    Con.Close();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }



            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ViewPatients Vp = new ViewPatients();
            Vp.Show();
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
