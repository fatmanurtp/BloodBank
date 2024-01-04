using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBank
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            DonateBlood Ob = new DonateBlood();
            Ob.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Donor donor = new Donor();
            donor.Show();
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
