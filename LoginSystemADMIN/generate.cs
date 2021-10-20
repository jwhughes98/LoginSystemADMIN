using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginSystemADMIN
{
    public partial class generate : Form
    {
        public generate(Form1 fm1)
        {
            InitializeComponent();

            frm1 = fm1;
        }

        private readonly Form1 frm1;
        private int getDays()
        {
            if(comboBox1.SelectedIndex == 0)
            {
                return 1;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                return 3;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                return 7;
            }
            if (comboBox1.SelectedIndex == 3)
            {
                return 30;
            }
            else
            {
                return 0;
            }

        }

        private static Random random = new Random();
        private string generateRandomKey()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 16)//16 chars in length
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int amount = ((int)numericUpDown1.Value);
            if (getDays() != 0)
            {
                for (int i = 0; i < amount; i++)
                {
                    string sql = "INSERT INTO users (license,days) VALUES (@license, @days)";
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, DataAccess.connection))
                    {
                        cmd.Parameters.AddWithValue("@license", generateRandomKey());
                        cmd.Parameters.AddWithValue("@days", getDays());
                        cmd.ExecuteNonQuery();
                    }

                }
            }
                       
            frm1.GetDatabase();
        }
    }
}
