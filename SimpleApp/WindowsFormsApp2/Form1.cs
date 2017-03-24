using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private Database db;
       public  int id = 0;
        public Form1()
        {
            InitializeComponent();
            db = new Database();

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
             id = Convert.ToInt32(textBox3.Text);
            DisplayUser();
        }

        public void DisplayUser()
        {
          
            User use = db.GetUser(id);

            textBox1.Text = use.FirstName;
            textBox2.Text = use.LastName;
            textBox4.Text = use.UserId.ToString();
            textBox5.Text = use.DOB.ToString();
            textBox6.Text = use.Address;
            textBox7.Text = use.City;
            textBox8.Text = use.Amount.ToString();

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            SaveUser();
        }
        public void SaveUser()
        {
            string fname = textBox1.Text;
            string lname = textBox2.Text;
            string dob = textBox5.Text;
            string address = textBox6.Text;
            string city = textBox7.Text;
            decimal amount = Convert.ToDecimal(textBox8.Text);

            User use = db.AddUser(fname, lname, dob, address, city, amount);

        }
    }
}
