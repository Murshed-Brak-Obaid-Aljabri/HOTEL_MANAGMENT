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
    public partial class UserControl6 : UserControl
    {
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public UserControl6()
        {
            InitializeComponent();
        }
        }

    //        string constr;
    //        SqlConnection conn;


        //            constr = ConfigurationManager.ConnectionStrings["appcon"].ConnectionString;
        //            conn = new SqlConnection(constr);
        //            //Instance = this;
        //        }

        //        public void refreshdatagrid ()
        //        {
        //            constr = ConfigurationManager.ConnectionStrings["appcon"].ConnectionString;
        //            conn = new SqlConnection(constr);
        //            string queryj = " select IDent_Num,NAME_Cus,Addres,Status_Cus,PHONE from CUSTOMERS";
        //            SqlCommand cmd = new SqlCommand(queryj, conn);
        //            SqlDataAdapter ad1 = new SqlDataAdapter(queryj, conn);
        //            DataTable dt1 = new DataTable();
        //            ad1.Fill(dt1);
        //            dataGridView1.DataSource = dt1;
        //        }

        //        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //        {

        //        }
        //        //public void fa(string n)
        //        //{ textBox1.Text = n;
        //        //}
        //        //public void fb(string a)
        //        //{ textBox2.Text = a; }
        //        //public void fc(string p)
        //        //{
        //        //    textBox3.Text = p;
        //        //}
        //        //public void fd(string c)
        //        //{
        //        //    textBox5.Text = c;
        //        //}
        //        //public void fe(string s)
        //        //{

        //        //    textBox6.Text = s;
        //        //}
        //        //public void ff(string t)
        //        //{
        //        //    textBox7.Text = t;
        //        //}
        //        //public void fh(string rh)
        //        //{
        //        //    textBox8.Text = rh;
        //        //}
        //        //public void fj(string rha)
        //        //{
        //        //    textBox9.Text = rha;
        //        //}
        //        //public void fk(string  np)
        //        //{
        //        //    textBox10.Text = np;
        //        //}
        //        //public void fL(string nd)
        //        //{
        //        //    textBox11.Text = nd;
        //        //}
        //        //public void fm(string da)
        //        //{
        //        //    textBox12.Text = da;
        //        //}
        //        //public void fn(string od)
        //        //{
        //        //    textBox13.Text = od;
        //        //}

        //        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //        //{

        //        //}
        //    }
    }
