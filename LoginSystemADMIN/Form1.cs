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
using System.Data.Common;
using System.Data.SQLite;

namespace LoginSystemADMIN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetDatabase();
            selectedEntity();
        }


        public void GetDatabase()
        {            
            string sql = "Select uid, license, days, hwid, activated, CAST(start_date as text), CAST(end_date as text), email, orderID, banned from users";
            DataAccess.ExecuteSQL(sql);
            DataTable dt1 = DataAccess.GetDataTable(sql);
            dataGridView1.DataSource = dt1;

            dataGridView1.Columns[0].HeaderCell.Value = "UID";
            dataGridView1.Columns[1].HeaderCell.Value = "LICENSE KEY";
            dataGridView1.Columns[2].HeaderCell.Value = "DAYS";
            dataGridView1.Columns[3].HeaderCell.Value = "HWID";
            dataGridView1.Columns[4].HeaderCell.Value = "KEY ACTIVATED";
            dataGridView1.Columns[5].HeaderCell.Value = "START DATE";
            dataGridView1.Columns[6].HeaderCell.Value = "END DATE";
            dataGridView1.Columns[7].HeaderCell.Value = "EMAIL";
            dataGridView1.Columns[8].HeaderCell.Value = "ORDER ID";
            dataGridView1.Columns[9].HeaderCell.Value = "KEY BANNED";

            dataGridView1.Refresh();
        }
      
       
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null; 
            GetDatabase();
        }

        private void rEFRESHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearSearch();
            dataGridView1.DataSource = null;
            GetDatabase();
        }

        private void cLEARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        private void lOADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearSearch();
            GetDatabase();           
        }
        private void clearSearch()
        {
            toolStripTextBox1.Text = "";
            toolStripTextBox2.Text = "";
            toolStripTextBox3.Text = "";
            toolStripTextBox4.Text = "";
            GetDatabase();
            dataGridView1.Refresh();

        }

        
       
        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            clearSearch();
        }
        
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            string sql = "Select uid, license, days, hwid, activated, CAST(start_date as text), CAST(end_date as text), email, orderID, banned from users where license like '" + toolStripTextBox1.Text + "%' ";
            DataAccess.ExecuteSQL(sql);
            DataTable dt1 = DataAccess.GetDataTable(sql);
            dataGridView1.DataSource = dt1;
            dataGridView1.Refresh();
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            clearSearch();
            
        }

        private void toolStripTextBox3_Click(object sender, EventArgs e)
        {
            clearSearch();
        }

       
        private void toolStripTextBox2_TextChanged(object sender, EventArgs e)
        {
            string sql = "Select uid, license, days, hwid, activated, CAST(start_date as text), CAST(end_date as text), email, orderID, banned from users where hwid like '" + toolStripTextBox2.Text + "%' ";
            DataAccess.ExecuteSQL(sql);
            DataTable dt1 = DataAccess.GetDataTable(sql);
            dataGridView1.DataSource = dt1;
            dataGridView1.Refresh();
        }

        private void toolStripTextBox3_TextChanged(object sender, EventArgs e)
        {
            string sql = "Select uid, license, days, hwid, activated, CAST(start_date as text), CAST(end_date as text), email, orderID, banned from users where email like '" + toolStripTextBox3.Text + "%' ";
            DataAccess.ExecuteSQL(sql);
            DataTable dt1 = DataAccess.GetDataTable(sql);
            dataGridView1.DataSource = dt1;
            dataGridView1.Refresh();
        }

        private void toolStripTextBox4_Click(object sender, EventArgs e)
        {
            clearSearch();
        }

        private void toolStripTextBox4_TextChanged(object sender, EventArgs e)
        {
            string sql = "Select uid, license, days, hwid, activated, CAST(start_date as text), CAST(end_date as text), email, orderID, banned from users where orderID like '" + toolStripTextBox4.Text + "%' ";
            DataAccess.ExecuteSQL(sql);
            DataTable dt1 = DataAccess.GetDataTable(sql);
            dataGridView1.DataSource = dt1;
            dataGridView1.Refresh();
        }

        private void nONACTIVATEDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(nONACTIVATEDToolStripMenuItem.Checked == false)
            {
                string sql = "Select uid, license, days, hwid, activated, CAST(start_date as text), CAST(end_date as text), email, orderID, banned from users where activated = 1";
                DataAccess.ExecuteSQL(sql);
                DataTable dt1 = DataAccess.GetDataTable(sql);
                dataGridView1.DataSource = dt1;
                dataGridView1.Refresh();
                nONACTIVATEDToolStripMenuItem.Checked = true;
                fRESHLICENSEKEYSToolStripMenuItem.Enabled = false;
            }
            else
            {
                string sql = "Select uid, license, days, hwid, activated, CAST(start_date as text), CAST(end_date as text), email, orderID, banned from users";
                DataAccess.ExecuteSQL(sql);
                DataTable dt1 = DataAccess.GetDataTable(sql);
                dataGridView1.DataSource = dt1;
                dataGridView1.Refresh();
                nONACTIVATEDToolStripMenuItem.Checked = false;
                fRESHLICENSEKEYSToolStripMenuItem.Enabled = true;
            }
            
        }

        private void fRESHLICENSEKEYSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fRESHLICENSEKEYSToolStripMenuItem.Checked == false)
            {
                string sql = "Select uid, license, days, hwid, activated, CAST(start_date as text), CAST(end_date as text), email, orderID, banned from users where orderID like '1%'";
                DataAccess.ExecuteSQL(sql);
                DataTable dt1 = DataAccess.GetDataTable(sql);
                dataGridView1.DataSource = dt1;
                dataGridView1.Refresh();
                fRESHLICENSEKEYSToolStripMenuItem.Checked = true;
                nONACTIVATEDToolStripMenuItem.Enabled = false;

            }
            else
            {
                string sql = "Select uid, license, days, hwid, activated, CAST(start_date as text), CAST(end_date as text), email, orderID, banned from users";
                DataAccess.ExecuteSQL(sql);
                DataTable dt1 = DataAccess.GetDataTable(sql);
                dataGridView1.DataSource = dt1;
                dataGridView1.Refresh();
                fRESHLICENSEKEYSToolStripMenuItem.Checked = false;
                nONACTIVATEDToolStripMenuItem.Enabled = true;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            generate gn = new generate(this);
            gn.Show();
        }

        private void dELTEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void selectedEntity()
        {
            foreach (DataGridViewRow selected in dataGridView1.SelectedRows)
            {
                selectedUID.Text = selected.Cells[0].Value.ToString();
                selectedLIC.Text = selected.Cells[1].Value.ToString();
                selectedDAY.Text = selected.Cells[2].Value.ToString();
                selectedHWID.Text = selected.Cells[3].Value.ToString();
                selectedACT.Text = selected.Cells[4].Value.ToString();
                selectedSTART.Text = selected.Cells[5].Value.ToString();
                selectedEND.Text = selected.Cells[6].Value.ToString();
                selectedEMAIL.Text = selected.Cells[7].Value.ToString();
                selectedORDER.Text = selected.Cells[8].Value.ToString();
                selectedBAN.Text = selected.Cells[9].Value.ToString();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedEntity();
        }
    }
}
