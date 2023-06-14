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
    public partial class Form2 : Form
    {
        OracleDataAdapter adapter;
        DataSet ds;
        public Form2()
        {
            InitializeComponent();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            String constr = "User Id=scott;Password=tiger;Data Source=orcl";
            string cmdstr = "select Name from Movie where Language=:L";
            adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("L", txt_search.Text);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.txt_search.AutoSize = false;
            this.txt_search.Size = new System.Drawing.Size(150, 28);

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            OracleCommandBuilder builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
            MessageBox.Show("All Changes Saved");
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
