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
using HotelSittings;

namespace Hotel_System
{
    public partial class UserControl1 : UserControl
    {
        //string constr;
        int SelectedRowIndex = -1;
        int SelectedColumnIndex = -1;
        SqlConnection conn;
        private void button1_Click(object sender, EventArgs e)
        {

        }
        public UserControl1()
        {
            InitializeComponent();
            //constr = ConfigurationManager.ConnectionStrings["appcon"].ConnectionString;
            conn = new SqlConnection(ConnectionStringHotel.ConnectionString);

        }
        private void loaddata()
        {
            //constr = ConfigurationManager.ConnectionStrings["appcon"].ConnectionString;
            //conn = new SqlConnection(constr);
            conn = new SqlConnection(ConnectionStringHotel.ConnectionString);
            string cr = "select* from CUSTOMERS";
            SqlDataAdapter ad1 = new SqlDataAdapter(cr, conn);
            DataTable dt1 = new DataTable();
            ad1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
                  string.IsNullOrWhiteSpace(comboBox1.Text))
                {
                    MessageBox.Show("الرجاء تعبية جميع الحقول");
                    return;
                }

                string query = "INSERT INTO CUSTOMERS (IDent_Num,NAME_Cus,Addres,Status_Cus,PHONE)values(@IDent_Num,@NAME_Cus,@Addres,@Status_Cus,@PHONE)";


                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                cmd.Parameters.AddWithValue("@NAME_Cus", (textBox1.Text));
                cmd.Parameters.AddWithValue("@Addres", (textBox2.Text));
                cmd.Parameters.AddWithValue("@IDent_Num", Convert.ToDouble(textBox3.Text));
                cmd.Parameters.AddWithValue("@PHONE", Convert.ToDouble(textBox4.Text));
                cmd.Parameters.AddWithValue("@Status_Cus", (comboBox1.Text));

                cmd.ExecuteNonQuery();
                loaddata();

                //conn.Close();
                MessageBox.Show("saved successful");
            }

            catch { MessageBox.Show("ربما البيانات تم ادخالها مسبقا"); }
        } 

        private void butdelete_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)//للتحقق من تحديد صف
            {
                MessageBox.Show("please select a row to delete . ");


                DialogResult dr = MessageBox.Show("Are you sure you want to delete this record?");
                if (dr == DialogResult.No)
                { MessageBox.Show("hi"); }
                try
                {
                    int selectID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["IDent_Num"].Value);
                    //constr = ConfigurationManager.ConnectionStrings["appcon"].ConnectionString;
                    ////SqlConnection conn = new SqlConnection(constr);
                    ///

                     conn = new SqlConnection(ConnectionStringHotel.ConnectionString);
                  

                    conn.Open();
                    string query1 = "DELETE from CUSTOMERS WHERE IDent_Num=@IDent_Num";

                    SqlCommand cmd1 = new SqlCommand(query1, conn);
                    cmd1.Parameters.AddWithValue("@IDent_Num", selectID);
                    int rowsaffected = cmd1.ExecuteNonQuery();
                    if (rowsaffected > 0)
                    {
                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                        MessageBox.Show("تم الحذف بنجاح");

                    }
                    else
                    {
                        MessageBox.Show("please select a row to delete . ");
                    }
                }


                catch { }


            }
        }

        private void butupdate_Click(object sender, EventArgs e)
        {

            if (SelectedRowIndex < 0 || SelectedColumnIndex < 0)
            {
                MessageBox.Show("الرجاء تحديد خلية");
                return;
            }
            string newvalue = texEDIT.Text;
            string columnname = dataGridView1.Columns[SelectedColumnIndex].Name;
            string primarykeycolumn = "IDent_Num";
            object primarykeyvalue = dataGridView1.Rows[SelectedRowIndex].Cells[primarykeycolumn].Value;
            string query2 = $"update CUSTOMERS SET [{columnname}]= @NewValue WHERE [{primarykeycolumn}]=@IDent_Num";
            //constr = ConfigurationManager.ConnectionStrings["appcon"].ConnectionString;
            //conn = new SqlConnection(constr);
            conn = new SqlConnection(ConnectionStringHotel.ConnectionString);
            SqlCommand cmd2 = new SqlCommand(query2, conn);

            cmd2.Parameters.AddWithValue("@NewValue", newvalue);
            cmd2.Parameters.AddWithValue("@IDent_Num", primarykeyvalue);
            conn.Open();

            int result = cmd2.ExecuteNonQuery();
            conn.Close();
            if (result > 0)
            {
                dataGridView1.Rows[SelectedRowIndex].Cells[SelectedColumnIndex].Value = newvalue;
                MessageBox.Show("تم التحديث بنجاح");

            }
            else
            {
                MessageBox.Show("فشل التحديث");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                SelectedRowIndex = e.RowIndex;
                SelectedColumnIndex = e.ColumnIndex;
                object cellValue = dataGridView1.Rows[SelectedRowIndex].Cells[SelectedColumnIndex].Value;
                texEDIT.Text = cellValue != null ? cellValue.ToString() : string.Empty;
            }
        }

        private void texSEARCH_TextChanged(object sender, EventArgs e)
        {

            //constr = ConfigurationManager.ConnectionStrings["appcon"].ConnectionString;
            //conn = new SqlConnection(constr);
            conn = new SqlConnection(ConnectionStringHotel.ConnectionString);
            string query3 = "select * from CUSTOMERS WHERE IDent_Num LIKE @IDent_Num+'%'";

            SqlCommand cmd = new SqlCommand(query3, conn);
            cmd.Parameters.AddWithValue("@IDent_Num", texSEARCH.Text.Trim());
            SqlDataAdapter ad2 = new SqlDataAdapter(cmd);
            DataTable dt3 = new DataTable();
            ad2.Fill(dt3);
            dataGridView1.DataSource = dt3;

            if (dt3.Rows.Count == 0)
            {
                MessageBox.Show("لا توجد بيانات مطابقه");
            }


        }
    }
}


