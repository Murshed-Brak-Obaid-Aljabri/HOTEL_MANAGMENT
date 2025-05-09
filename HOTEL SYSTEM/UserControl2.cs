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
    public partial class UserControl2 : UserControl
    {
        //string constr;
        int SelectedRowIndex = -1;
        int SelectedColumnIndex = -1;
        SqlConnection conn;

        public UserControl2()
        {
            InitializeComponent();
            //constr = ConfigurationManager.ConnectionStrings["appcon"].ConnectionString;
            conn = new SqlConnection(ConnectionStringHotel.ConnectionString);

        }
        private void loaddata2()
        {
            //constr = ConfigurationManager.ConnectionStrings["appcon"].ConnectionString;
            //conn = new SqlConnection(constr);
            conn = new SqlConnection(ConnectionStringHotel.ConnectionString);
            string rc = "select* from RESERVATION";
            SqlDataAdapter ad2 = new SqlDataAdapter(rc, conn);
            DataTable dt2 = new DataTable();
            ad2.Fill(dt2);
            dataGridView1.DataSource = dt2;
        }
        private void busave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(dateTimePicker1.Text) || string.IsNullOrWhiteSpace(dateTimePicker2.Text) )
                    
                {
                    MessageBox.Show("الرجاء تعبية جميع الحقول");
                    return;
                }
                string checkquery = "select COUNT(*) from RESERVATION WHERE Room_Num =@Room_Num AND Date_Of_Reservation =@Date_Of_Reservation AND Departure_Date=@Departure_Date";
                SqlCommand checkcmd = new SqlCommand(checkquery, conn);
                checkcmd.Parameters.AddWithValue("@Room_Num", Convert.ToInt32(textBox3.Text));
                checkcmd.Parameters.AddWithValue("@Date_Of_Reservation", (dateTimePicker1.Value));
                checkcmd.Parameters.AddWithValue("@Departure_Date", (dateTimePicker2.Value));
                conn.Open();

                int roomexits = (int)checkcmd.ExecuteScalar();
                conn.Close();

                if (roomexits > 0)
                {
                    MessageBox.Show("هذه الغرفة محجوزة");

                    return;
                }
            }
            catch { };


            try
            {
                string query4 = "INSERT INTO RESERVATION (Room_Num,Date_Of_Reservation,Departure_Date," +
                    "ROOM_TYPE,price,no_of_people,Floor_num) VALUES(@Room_Num,@Date_Of_Reservation,@Departure_Date," +
                    "@ROOM_TYPE,@price,@no_of_people,@Floor_num)";
                SqlCommand cmd3 = new SqlCommand(query4, conn);


                cmd3.Parameters.AddWithValue("@ROOM_TYPE", (comboBox1.Text));
                cmd3.Parameters.AddWithValue("@Room_Num", Convert.ToInt32(textBox3.Text));
                cmd3.Parameters.AddWithValue("@Floor_num", Convert.ToInt32(textBox4.Text));
                cmd3.Parameters.AddWithValue("@price", Convert.ToDecimal(textBox5.Text));
                cmd3.Parameters.AddWithValue("@no_of_people", Convert.ToInt32(textBox1.Text));
                cmd3.Parameters.AddWithValue("@Date_Of_Reservation", (dateTimePicker1.Value));
                cmd3.Parameters.AddWithValue("@Departure_Date", (dateTimePicker2.Value));

                conn.Open();
                cmd3.ExecuteNonQuery();
                MessageBox.Show("saved successful");
                conn.Close();

                loaddata2();
            }catch { MessageBox.Show("هذه الغرفه محجوزة"); }

        }

        private void budelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)//للتحقق من تحديد صف
            {
                MessageBox.Show("please select a row to delete . ");
                return;
            }
            {
                int roomnum = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Room_Num"].Value);

                DialogResult dr1 = MessageBox.Show("Are you sure you want to delete this record?");
                try
                {
                    if (dr1 == DialogResult.Yes)



                        //    constr = ConfigurationManager.ConnectionStrings["appcon"].ConnectionString;
                        //SqlConnection conn = new SqlConnection(constr);

                        conn = new SqlConnection(ConnectionStringHotel.ConnectionString);

                    conn.Open();
                    string query6 = "DELETE from ROOMS WHERE Room_Num_reserv= @Room_Num";
                    string query5 = "DELETE from RESERVATION WHERE Room_Num= @Room_Num";

                    SqlCommand cmd4 = new SqlCommand(query6, conn);
                    SqlCommand cmd5 = new SqlCommand(query5, conn);
                    cmd4.Parameters.AddWithValue("@Room_Num", roomnum);
                    cmd5.Parameters.AddWithValue("@Room_Num", roomnum);
                    int rowsaffected = cmd4.ExecuteNonQuery();

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

        private void buupdate_Click(object sender, EventArgs e)
        {

            if (SelectedRowIndex < 0 || SelectedColumnIndex < 0)
            {
                MessageBox.Show("الرجاء تحديد خلية");
                return;
            }
            string newvalue1 = texEDIT2.Text;
            string columnname = dataGridView1.Columns[SelectedColumnIndex].Name;
            string primarykeycolumn1 = "Room_Num";
            object primarykeyvalue1 = dataGridView1.Rows[SelectedRowIndex].Cells[primarykeycolumn1].Value;
            string query7 = $"update RESERVATION SET [{columnname}]= @NewValue WHERE [{primarykeycolumn1}]=@Room_Num";
            //constr = ConfigurationManager.ConnectionStrings["appcon"].ConnectionString;
            //conn = new SqlConnection(constr);

            conn = new SqlConnection(ConnectionStringHotel.ConnectionString);
            SqlCommand cmd7 = new SqlCommand(query7, conn);

            cmd7.Parameters.AddWithValue("@NewValue", newvalue1);
            cmd7.Parameters.AddWithValue("@Room_Num", primarykeyvalue1);
            conn.Open();

            int result = cmd7.ExecuteNonQuery();
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

        private void texSEARCH2_TextChanged(object sender, EventArgs e)
        {
            //constr = ConfigurationManager.ConnectionStrings["appcon"].ConnectionString;
            //conn = new SqlConnection(constr);

            conn = new SqlConnection(ConnectionStringHotel.ConnectionString);
            string query6 = "select * from RESERVATION WHERE Room_Num LIKE @Room_Num+'%'";

            SqlCommand cmd6 = new SqlCommand(query6, conn);
            cmd6.Parameters.AddWithValue("@Room_Num", texSEARCH2.Text.Trim());
            SqlDataAdapter ad3 = new SqlDataAdapter(cmd6);
            DataTable dt3 = new DataTable();
            ad3.Fill(dt3);
            dataGridView1.DataSource = dt3;

            if (dt3.Rows.Count == 0)
            {
                MessageBox.Show("لا توجد بيانات مطابقه");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            SelectedRowIndex = e.RowIndex;
            SelectedColumnIndex = e.ColumnIndex;

            if (SelectedRowIndex >= 0 && SelectedColumnIndex >= 0)
            {
                string cellvalue = dataGridView1.Rows[SelectedRowIndex].Cells[SelectedColumnIndex].Value.ToString();
                texEDIT2.Text = cellvalue;


            }
        }
    }
}

