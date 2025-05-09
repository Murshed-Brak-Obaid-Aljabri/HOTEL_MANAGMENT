using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Hotel_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            BackColor = Color.LawnGreen;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text =="" )
            {
                MessageBox.Show("Enter User Name");
            }
            else if(textBox2.Text =="")
            {
                MessageBox.Show("Enter Passward");

            }
          
            if (textBox1.Text =="Aljabri"&&textBox2.Text =="911")
            {

              
                Form2 f2 = new Form2();
                f2.ShowDialog();
                
            }
            
        }

        

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

         DialogResult rt= MessageBox.Show("Do You Want Exit?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rt == DialogResult.Yes)
            {
                this.Close();
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        bool ispasswordshwon;
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ispasswordshwon = !ispasswordshwon;
            textBox2.UseSystemPasswordChar = !ispasswordshwon; 
          
        }
    }
}
