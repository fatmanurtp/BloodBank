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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BloodBank
{
    public partial class PatientName : Form
    {
        public PatientName()
        {
            InitializeComponent();
            fillPatientCb();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\fatmanur\OneDrive\Belgeler\BloodBankDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void fillPatientCb()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select PNum from PatientTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PName", typeof(int));
            dt.Load(rdr);
            PatientId.ValueMember = "PNum";
            PatientId.DataSource = dt;
            Con.Close();
        }
        private void GetData()
        {
            // helps to gets the blood type and patient name
            Con.Open();
            string query = "select * from PatientTbl where PNum ='" + PatientId.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["PName"].ToString();
                BloodType.Text = dr["PBType"].ToString();
                

            }
            Con.Close();
        }

        int stock = 0;
        private void GetStock(string BType)
        {
            // helps to get the actual stock of Blood based on a particular blood group
            Con.Open();
            string query = "select * from BloodTbl where BType = '" + BType + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                stock = Convert.ToInt32(dr["BStock"].ToString());
            }
            Con.Close();
        }

        private void PatientName_Load(object sender, EventArgs e)
        {

        }
        int oldstock;
        /*private void GetStock(string BType)
        {
            // helps to gets the actual stock of Blood based on particular blod Group
            Con.Open();
            string query = "select * from BloodTbl where ='" + BType + ",";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                oldstock = Convert.ToInt32(dr["BStock"].ToString());
            }
            Con.Close();
        }
        */
        private void PatientId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetData();
            GetStock(BloodType.Text);
            if(stock > 0)
            {
                TransfertBtn.Visible = true;
                AvailableLbl.Text = "Available Stock";
                AvailableLbl.Visible = true;
            }
            else
            {
                AvailableLbl.Text = "Stock not Available";
                AvailableLbl.Visible = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Patient Pat = new Patient();
            Pat.Show();
            this.Hide();

        }
        public void Reset() 
        {
            textBox1.Text = "";
            //PatientId.SelectedIndex = -1;
            BloodType.Text = "";
            AvailableLbl.Visible= false;
            TransfertBtn.Visible= false;

        } 
        private void updateStock()
        {
            int newstock = stock -1;
            try
            {
                string query = "update BloodTbl set BStock = " +newstock+ "where Btype = '" +BloodType.Text+ "';";
                Con.Open();
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Patient Successfully Delete");
                Con.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }

        }
        private void TransfertBtn_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                try
                {
                    string query = "insert into TransferTbl values('" + textBox1.Text + "', '" + BloodType.Text + "' )";
                    Con.Open();
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully Transfer");
                    Con.Close();
                    GetStock(BloodType.Text);
                    updateStock();
                    Reset();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }



            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            BloodStock Bstock = new BloodStock();   
            Bstock.Show();
            this.Hide();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor Bstock = new Donor();
            Bstock.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            DonateBlood Bstock = new DonateBlood();
            Bstock.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            DonorsDGV Bstock = new DonorsDGV ();
            Bstock.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ViewPatients Bstock = new ViewPatients();
            Bstock.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Dashboard Bstock = new Dashboard();
            Bstock.Show();
            this.Hide();
        }
    }
}
