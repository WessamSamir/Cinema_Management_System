using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;


namespace Cinema_Management_System
{
    public partial class Form1 : Form
    {
        string ordb = "Data source=orcl;User Id=scott;Password=tiger;";
        OracleConnection conn;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from Movie where ReleasedYear=:year";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("year", textBox1.Text);
            OracleDataReader dr = cmd.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dr);
            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Insert_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into Ticketing values (:TicketId,:MovieId,:Type,:Price,:HalliD)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("TicketId", ticketid.Text);
            cmd.Parameters.Add("MovieId", Movie.Text);
            cmd.Parameters.Add("Type", type.Text);
            cmd.Parameters.Add("Price", price.Text);
            cmd.Parameters.Add("HalliD", HallId.Text);
            int r = cmd.ExecuteNonQuery();
            if(r!=-1)
            {
                MessageBox.Show("New Ticket is added");
            }
        }

        private void Seats_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "GetTotalSeats";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("seat", OracleDbType.Int32, ParameterDirection.Output);
            cmd.ExecuteNonQuery();
            
            int outParameterValue = Convert.ToInt32(cmd.Parameters["seat"].Value.ToString());
            MessageBox.Show("Maximum Seats number is : " + outParameterValue);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Payment_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "GetPaymentId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("method", txt_payment.Text);
            cmd.Parameters.Add("id", OracleDbType.RefCursor,ParameterDirection.Output);
            OracleDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                cmb_payment.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void txt_payment_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmb_payment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ticketid_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
