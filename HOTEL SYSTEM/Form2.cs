using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_System
{
    public partial class Form2 : Form
    {

        
        public Form2()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl21.Hide();
            userControl41.Hide();
            userControl51.Hide();
         
            userControl31.Show();
            userControl31.BringToFront();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void userControl51_Load(object sender, EventArgs e)
        {

        }

        private void userControl21_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            userControl21.Hide();
            userControl31.Hide();
            userControl41.Hide();
            userControl11.Hide();
          

            userControl51.Show();
            userControl51.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userControl21.Hide();
            userControl31.Hide();
            userControl41.Hide();
            userControl51.Hide();
         
            userControl11.Show();
            userControl11.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            userControl11.Hide();
            userControl31.Hide();
            userControl41.Hide();
            userControl51.Hide();
        
            userControl21.Show();
            userControl21.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl21.Hide();
            userControl31.Hide();
            userControl51.Hide();
       
            userControl41.Show();
            userControl41.BringToFront();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void userControl51_Load_1(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            userControl11.Hide();
            userControl21.Hide();
            userControl31.Hide();
            userControl41.Hide();
            userControl51.Hide();
            userControl61.Show();
            userControl61.BringToFront();
        }
    }
}
