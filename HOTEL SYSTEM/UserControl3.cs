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
    public partial class UserControl3 : UserControl
    {

        //str
        int SelectedRowIndex = -1;
        int SelectedColumnIndex = -1;
        SqlConnection conn;

        public UserControl3()
        {
            InitializeComponent();
            //constr = ConfigurationManager.ConnectionStrings["appcon"].ConnectionString;
            conn = new SqlConnection(ConnectionStringHotel.ConnectionString);

        }
        private void loaddata3()
        {

            //constr = ConfigurationManager.ConnectionStrings["appcon"].ConnectionString;
            //conn = new SqlConnection(constr);

            conn = new SqlConnection(ConnectionStringHotel.ConnectionString);
            string rcc = "select * from FOODS";
            SqlDataAdapter ad3 = new SqlDataAdapter(rcc, conn);
            DataTable dt3 = new DataTable();
            ad3.Fill(dt3);
            dataGridView1.DataSource = dt3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        
                try
                {

                    if (string.IsNullOrWhiteSpace(textBox11.Text) || string.IsNullOrWhiteSpace(textBox11.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
                    string.IsNullOrWhiteSpace(textBox6.Text) || string.IsNullOrWhiteSpace(textBox7.Text) || string.IsNullOrWhiteSpace(textBox5.Text))
                    {
                        MessageBox.Show("الرجاء تعبية جميع الحقول");
                    return;
                    }
                    string query8 = "INSERT INTO FOODS (Food_ID,NAME_Fo,price,Name_cus,Room_num,Totalprice,Quantity) values(@Food_ID,@NAME_Fo,@price,@Name_cus,@Room_num,@Totalprice,@Quantity)";


                SqlCommand cmd8 = new SqlCommand(query8, conn);



                conn.Open();

                cmd8.Parameters.AddWithValue("Food_ID", Convert.ToInt32(textBox11.Text));
                cmd8.Parameters.AddWithValue("Room_num", Convert.ToInt32(textBox1.Text));
                cmd8.Parameters.AddWithValue("Name_cus", textBox2.Text);
                cmd8.Parameters.AddWithValue("NAME_Fo", textBox4.Text);

                cmd8.Parameters.AddWithValue("price", Convert.ToInt32(textBox6.Text));
                cmd8.Parameters.AddWithValue("Totalprice", Convert.ToInt32(textBox7.Text));

                cmd8.Parameters.AddWithValue("Quantity", Convert.ToInt32(textBox5.Text));


                cmd8.ExecuteNonQuery();


                //conn.Close();
                MessageBox.Show("saved successful");
                loaddata3();


                if (textBox11.Text == "")
                {
                    MessageBox.Show("Enter Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("Enter Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Enter Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("Enter Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (textBox5.Text == "")
                {
                    MessageBox.Show("Enter Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (textBox6.Text == "")
                {
                    MessageBox.Show("Enter Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (textBox7.Text == "")
                {
                    MessageBox.Show("Enter Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    label11.Text = textBox11.Text;
                    label12.Text = textBox1.Text;
                    label13.Text = textBox2.Text;
                    textBox3.Text = textBox4.Text;
                    textBox8.Text = textBox5.Text;
                    textBox9.Text = textBox6.Text;
                    textBox10.Text = textBox7.Text;
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox11.Clear();
                }


            }
            catch
            {
                MessageBox.Show("ربما البيانات تم ادخالها مسبقا");

            }
        }

        private void butdelete_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)//للتحقق من تحديد صف
            {
                MessageBox.Show("please select a row to delete . ");
                return;
            }
            {
                int id_food = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Food_ID"].Value);

                DialogResult dr1 = MessageBox.Show("Are you sure you want to delete this record?");
                try
                {
                    if (dr1 == DialogResult.Yes)



                        //    constr = ConfigurationManager.ConnectionStrings["appcon"].ConnectionString;
                        //SqlConnection conn = new SqlConnection(constr);

                        conn = new SqlConnection(ConnectionStringHotel.ConnectionString);

                    conn.Open();
                    string querya = "DELETE from FOODS WHERE Food_ID= @Food_ID";
                    string queryb = "DELETE from Food_Reference WHERE Food_ID= @Food_ID";

                    SqlCommand cmd10 = new SqlCommand(querya, conn);
                    SqlCommand cmd1 = new SqlCommand(queryb, conn);
                    cmd10.Parameters.AddWithValue("@Food_ID", id_food);
                    cmd1.Parameters.AddWithValue("@Food_ID", id_food);
                    int rowsaffected = cmd10.ExecuteNonQuery();

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


                catch
                {
                    MessageBox.Show("ربما البيانات تم ادخالها مسبقا");
                }

            }

        }

        private void butupdate_Click(object sender, EventArgs e)
        {

            try
            {

                if (SelectedRowIndex < 0 || SelectedColumnIndex < 0)
                {
                    MessageBox.Show("الرجاء تحديد خلية");
                    return;
                }
                string newvalue1 = textupdate.Text;
                string columnname = dataGridView1.Columns[SelectedColumnIndex].Name;
                string primarykeycolumn1 = "Food_ID";
                object primarykeyvalue1 = dataGridView1.Rows[SelectedRowIndex].Cells[primarykeycolumn1].Value;
                string query7 = $"update FOODS SET [{columnname}]= @NewValue WHERE [{primarykeycolumn1}]=@Food_ID";
                string query8 = $"update Food_Reference SET [{columnname}]= @NewValue WHERE [{primarykeycolumn1}]=@Food_ID";
                //constr = ConfigurationManager.ConnectionStrings["appcon"].ConnectionString;
                //conn = new SqlConnection(constr);

                conn = new SqlConnection(ConnectionStringHotel.ConnectionString);
                SqlCommand cmd11 = new SqlCommand(query7, conn);
                SqlCommand cmd12 = new SqlCommand(query8, conn);

                cmd11.Parameters.AddWithValue("@NewValue", newvalue1);
                cmd11.Parameters.AddWithValue("@Food_ID", primarykeyvalue1);
                cmd12.Parameters.AddWithValue("@NewValue", newvalue1);
                cmd12.Parameters.AddWithValue("@Food_ID", primarykeyvalue1);
                conn.Open();

                int result = cmd11.ExecuteNonQuery();
                conn.Close();
                if (result > 0)
                {
                    dataGridView1.Rows[SelectedRowIndex].Cells[SelectedColumnIndex].Value = newvalue1;
                    MessageBox.Show("تم التحديث بنجاح");

                }
                else
                {
                    MessageBox.Show("فشل التحديث");
                }
            }
            catch
            {
                MessageBox.Show("ربما البيانات تم ادخالها مسبقا");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            SelectedRowIndex = e.RowIndex;
            SelectedColumnIndex = e.ColumnIndex;

            if (SelectedRowIndex >= 0 && SelectedColumnIndex >= 0)
            {
                string cellvalue = dataGridView1.Rows[SelectedRowIndex].Cells[SelectedColumnIndex].Value.ToString();
                textupdate.Text = cellvalue;

            }
        }

        private void textSEarch_TextChanged(object sender, EventArgs e)
        {
            //constr = ConfigurationManager.ConnectionStrings["appcon"].ConnectionString;
            //conn = new SqlConnection(constr);
            conn = new SqlConnection(ConnectionStringHotel.ConnectionString);
            string query6 = "select * from FOODS WHERE Food_ID LIKE @Food_ID+'%'";

            SqlCommand cmd = new SqlCommand(query6, conn);
            cmd.Parameters.AddWithValue("@Food_ID", textSEarch.Text.Trim());
            SqlDataAdapter ad3 = new SqlDataAdapter(cmd);
            DataTable dt3 = new DataTable();
            ad3.Fill(dt3);
            dataGridView1.DataSource = dt3;

            if (dt3.Rows.Count == 0)
            {
                MessageBox.Show("لا توجد بيانات مطابقه");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n1;
            int n2;
            int c;

            n1 = Convert.ToInt32(textBox5.Text);
            n2 = Convert.ToInt32(textBox6.Text);

            c = n1 * n2;
            textBox7.Text = c.ToString();
        }
    }
}
