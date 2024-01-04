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

namespace BloodBank
{
    public partial class ViewPatients : Form
    {
        public ViewPatients()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\fatmanur\OneDrive\Belgeler\BloodBankDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string Query = "select * from PatientTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            patientsDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        int key = 0;

        private void DonorDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try 
            { 
                name.Text = patientsDGV.SelectedRows[0].Cells[1].Value.ToString();
                age.Text = patientsDGV.SelectedRows[0].Cells[2].Value.ToString();
                phone.Text = patientsDGV.SelectedRows[0].Cells[3].Value.ToString();
                gender.SelectedItem = patientsDGV.SelectedRows[0].Cells[4].Value.ToString();
                bloodtype.SelectedItem = patientsDGV.SelectedRows[0].Cells[5].Value.ToString();
                address.Text = patientsDGV.SelectedRows[0].Cells[6].Value.ToString();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);

            }
            /*if(name.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(patientsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
            this.Invalidate();
            */
        }
        private void Reset()
        {
            name.Text = "";
            age.Text = "";
            phone.Text = "";
            gender.SelectedIndex = -1;
            bloodtype.SelectedIndex = -1;
            address.Text = "";
            key = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the patient to Delete");
            }
            else
            {
                try
                {
                    string query = "Delete from PatientTbl where pNum =" +key+ ";";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Successfully Delete");
                    Con.Close();
                    Reset();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Patient Pat = new Patient();
            Pat.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (name.Text == "" || age.Text == "" || phone.Text == "" || gender.SelectedIndex == -1 || bloodtype.SelectedIndex == -1 || address.Text == "")
            {
                MessageBox.Show("Missing ınformation");
            }
            else
            {
                try
                {
                    string query = "update PatientTbl set ";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Patient Successfully Delete");
                    Con.Close();
                    Reset();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }

            }
        }

        private void ViewPatients_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor Ob = new Donor();
            Ob.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            DonateBlood Bstock = new DonateBlood();
            Bstock.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            DonorsDGV Bstock = new DonorsDGV();
            Bstock.Show();
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
