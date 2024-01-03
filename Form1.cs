using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmEase_System
{
    public partial class Form1 : Form
    {
        function fn = new function();
        String query;
        DataSet ds;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            query = "select * from users";
            ds = fn.getData(query);
            if (ds.Tables[0].Rows.Count == 0)
            {
                if(textBox1.Text == "marjim" && textBox2.Text == "almo")
                {
                    Administrator admin = new Administrator();
                    admin.Show();
                    this.Hide();
                }
            }

            else
            {
                query = "select * from users where username = '" + textBox1.Text + "' and password = '" + textBox2.Text + "' ";
                ds = fn.getData(query);
                if (ds.Tables[0].Rows.Count!=0)
                {
                    String role = ds.Tables[0].Rows[0][1].ToString();
                    if(role == "Administrator") 
                    {
                        Administrator admin = new Administrator(textBox1.Text); //view user
                        admin.Show();
                        this.Hide();
                    }
                    else if (role == "Pharmacist")
                    {
                        Pharmacist pharm = new Pharmacist();
                        pharm.Show();
                        this.Hide();
                    }
                }

                else
                {
                    MessageBox.Show("Wrong Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            /*
            if(textBox1.Text == "marjim" && textBox2.Text == "almo")
            {
                Administrator am = new Administrator();
                am.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
        }
    }
}
