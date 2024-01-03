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
    public partial class Administrator : Form
    {
        function fn = new function();
        String query;
        DataSet ds;

        String user = " ";
        String currentUser = "";

        public Administrator()
        {
            InitializeComponent();
        }

        //view user
        public string ID
        {
            get { return user.ToString();  }
        }

        public string Id
        {
            set { currentUser = value; }
        }


        public Administrator(String username) //view user
        {
            InitializeComponent();
            label18.Text = username;
            user = username;
            //panelViewuser.Id = ID;
            Id = ID;
            //panelProfile.Id = ID;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button1.BringToFront();
            panel2.Visible = true;
            panelAdduser.Visible = false;
            panelViewuser.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Administrator_Load(object sender, EventArgs e) //loadform
        {
            panel2.Visible = false;
            button6.PerformClick();
            panelAdduser.Visible = false;

            /*view user
            query = "select * from users";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
            */
        }

        private void button2_Click(object sender, EventArgs e) //add user
        {
            //button2.Visible = true;
            //button2.BringToFront();
            panelAdduser.Visible = true;
            panel2.Visible = true;
            //panelViewuser.Visible = true;
                   
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String role = comboBox1.Text;
            String name = textBox1.Text;
            String dob = dateTimePicker1.Text;
            Int64 mobile = Int64.Parse(textBox4.Text);
            String username = textBox2.Text;
            String password = textBox3.Text;

            try
            {
                query = "insert into users (UserRole, Name, DateOfBirth, MobileNumber, UserName, Password) values ('"+role+ "', '"+name+ "', '"+dob+"',"+mobile+", '"+username+"', '"+password+"') ";
                fn.setData(query, "Sign Up Successful.");
            }
            catch (Exception)
            {
                MessageBox.Show("Username Already Exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        public void clearAll()
        {
            textBox1.Clear();
            dateTimePicker1.ResetText();
            textBox4.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;


        }

        private void panel2_Paint(object sender, PaintEventArgs e) //dashboard
        {
            query = "select count(UserRole) from users where UserRole = 'Administrator'";
            ds = fn.getData(query);
            setLabel(ds, label9);

            query = "select count(UserRole) from users where UserRole = 'Pharmacist'";
            ds = fn.getData(query);
            setLabel(ds, label10);
        }
        private void setLabel(DataSet ds, Label lbl)
        {
            if (ds.Tables[0].Rows.Count!=0) 
            { 
                lbl.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            else
            {
                lbl.Text = "0";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2_Paint(this, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //button3.Visible = true;
            //button3.BringToFront();
            panelViewuser.Visible = true;
            panelProfile.Visible = false;
            //panelAdduser.Visible = false;
           // panel2.Visible = false;
           //panelViewuser.Visible = true;
        }

        private void panelViewuser_Paint(object sender, PaintEventArgs e)
        {
            //view user
            query = "select * from users";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //view user textchanged
            query = "select * from users where username like '"+textBox1.Text+"%'";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Administrator_Load(this, null); //view user refresh
        }

        //viewuser
        String userName;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                userName = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
            catch
            {

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Delete Confirmation!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                if (currentUser != userName)
                {
                    query = "delete from users where username = '" + userName + "'";
                    fn.setData(query, "User Record Deleted.");
                    panelViewuser_Paint(this, null);
                }
                else
                {
                    MessageBox.Show("You are trying to delete \n Your own Profile.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelProfile.Visible = true;
        }

        private void panelProfile_Paint(object sender, PaintEventArgs e)
        {

        }

        public String IDd
        {
            set { label22.Text = value;}
        }
        private void button11_Click(object sender, EventArgs e)
        {

        }
    }
}
