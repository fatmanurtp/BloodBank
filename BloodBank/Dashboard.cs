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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            GetData();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\fatmanur\OneDrive\Belgeler\BloodBankDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void GetData()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select count(*) from DonorTbl",Con);  
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DonorLbl.Text = dt.Rows[0][0].ToString();
            SqlDataAdapter sda1 = new SqlDataAdapter("Select count(*) from TransferTbl", Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            TransferLbl.Text = dt1.Rows[0][0].ToString();
            SqlDataAdapter sda2 = new SqlDataAdapter("Select count(*) from BloodTbl", Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            int BStock = Convert.ToInt32(dt2.Rows[0][0].ToString());
            TotalLbl.Text = "" + BStock;
            // 0+ type code
            SqlDataAdapter sda3 = new SqlDataAdapter("Select count(*) from BloodTbl where BType = '"+"0+"+"'", Con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            OPlusNum.Text = dt3.Rows[0][0].ToString();
            double OplusPercentage = (Convert.ToDouble(dt3.Rows[0][0].ToString())/ BStock)* 100;
            OPlus.Value = Convert.ToInt32(OplusPercentage);

            // AB+ type Code
            SqlDataAdapter sda4 = new SqlDataAdapter("Select count(*) from BloodTbl where BType = '" + "AB+" + "'", Con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            ABPlusLbl.Text = dt4.Rows[0][0].ToString();
            double ABplusPercentage = (Convert.ToDouble(dt4.Rows[0][0].ToString()) / BStock) * 100;
            ABPlus.Value = Convert.ToInt32(ABplusPercentage);
            
            // 0- type code
            SqlDataAdapter sda5 = new SqlDataAdapter("Select count(*) from BloodTbl where BType = '" + "0-" + "'", Con);
            DataTable dt5 = new DataTable();
            sda5.Fill(dt5);
            OMinusLbl.Text = dt5.Rows[0][0].ToString();
            double OMinusPercentage = (Convert.ToDouble(dt5.Rows[0][0].ToString()) / BStock) * 100;
            OMinus.Value = Convert.ToInt32(OMinusPercentage);
            // AB- type code
            SqlDataAdapter sda6 = new SqlDataAdapter("Select count(*) from BloodTbl where BType = '" + "AB-" + "'", Con);
            DataTable dt6 = new DataTable();
            sda6.Fill(dt6);
            ABMinusLbl.Text = dt6.Rows[0][0].ToString();
            double ABMinusPercentage = (Convert.ToDouble(dt6.Rows[0][0].ToString()) / BStock) * 100;
            ABMinus.Value = Convert.ToInt32(ABMinusPercentage);

            Con.Close();
        }
        
        private void Dashboard_Load(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor Bstock = new Donor();
            Bstock.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
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

        private void label3_Click(object sender, EventArgs e)
        {
            Patient Bstock = new Patient();
            Bstock.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ViewPatients Bstock = new ViewPatients();
            Bstock.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            BloodStock Bstock = new BloodStock();
            Bstock.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            PatientName Bstock = new PatientName();
            Bstock.Show();
            this.Hide();
        }
    }
}
