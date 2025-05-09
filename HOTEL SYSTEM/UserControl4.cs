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
    public partial class UserControl4 : UserControl
    {
        //string constr;

        int SelectedRowIndex = -1;
        int SelectedColumnIndex = -1;
        SqlConnection conn;

        public UserControl4()
        {
            InitializeComponent();
            //constr = ConfigurationManager.ConnectionStrings["appcon"].ConnectionString;
            conn = new SqlConnection(ConnectionStringHotel.ConnectionString);

        }
        private void loaddatagridview()
        {

            //constr = ConfigurationManager.ConnectionStrings["appcon"].ConnectionString;
            //conn = new SqlConnection(constr);
            conn = new SqlConnection(ConnectionStringHotel.ConnectionString);
            string rd = "select * from SERVICEES";
            SqlDataAdapter ad3 = new SqlDataAdapter(rd, conn);
            DataTable dt4 = new DataTable();
            ad3.Fill(dt4);
            dataGridView1.DataSource = dt4;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(dateTimePicker3.Text) || string.IsNullOrWhiteSpace(dateTimePicker4.Text ) || string.IsNullOrWhiteSpace(dateTimePicker1.Text) )
              
                {
                    MessageBox.Show("الرجاء تعبية جميع الحقول");
                    return;
                }
                string checkquery1 = "select COUNT(*) from SERVICEES WHERE Servicee_Num =@Servicee_Num AND Start_Time=@Start_Time AND The_End_Time=@The_End_Time AND DATE=@DATE";
                SqlCommand checkcmd1 = new SqlCommand(checkquery1, conn);
                checkcmd1.Parameters.AddWithValue("@Servicee_Num", Convert.ToInt32(textBox3.Text));
                checkcmd1.Parameters.AddWithValue("@Start_Time", dateTimePicker3.Value.TimeOfDay);
                checkcmd1.Parameters.AddWithValue("@The_End_Time", dateTimePicker4.Value.TimeOfDay);
                checkcmd1.Parameters.AddWithValue("@DATE", dateTimePicker1.Value);
                conn.Open();
                int roomexits1 = (int)checkcmd1.ExecuteScalar();
                conn.Close();
                if (roomexits1 > 0)
                {
                    MessageBox.Show("هذه الخدمة محجوزة");

                    return;
                }

            }
            catch { }





            try
            {
                string querye = "INSERT INTO SERVICEES (Servicees_ID,Name_Ser,Servicee_Num,price,Start_Time,The_End_Time,Periode,DATE)values(@Servicees_ID,@Name_Ser,@Servicee_Num,@price,@Start_Time,@The_End_Time,@Periode,@DATE)";


                SqlCommand cmd9 = new SqlCommand(querye, conn);



                conn.Open();

                cmd9.Parameters.AddWithValue("@Servicees_ID", Convert.ToInt32(textBox12.Text));
                cmd9.Parameters.AddWithValue("@Name_Ser", textBox4.Text);
                cmd9.Parameters.AddWithValue("@Servicee_Num", Convert.ToInt32(textBox3.Text));
                cmd9.Parameters.AddWithValue("@price", textBox5.Text);
                cmd9.Parameters.AddWithValue("@Start_Time", dateTimePicker3.Value.TimeOfDay);
                cmd9.Parameters.AddWithValue("@The_End_Time", dateTimePicker4.Value.TimeOfDay);
                cmd9.Parameters.AddWithValue("@Periode", textBox13.Text);
                cmd9.Parameters.AddWithValue("@DATE", dateTimePicker1.Value);

                cmd9.ExecuteNonQuery();


                //conn.Close();
                MessageBox.Show("saved successful");
                loaddatagridview();









                if (textBox12.Text == "")
                {
                    MessageBox.Show("Enter Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else if (textBox4.Text == "")
                {
                    MessageBox.Show("Enter Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("Enter Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (textBox5.Text == "")
                {
                    MessageBox.Show("Enter Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (dateTimePicker3.Text == "")
                {
                    MessageBox.Show("Enter Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (dateTimePicker4.Text == "")
                {
                    MessageBox.Show("Enter Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else if (textBox13.Text == "")
                {
                    MessageBox.Show("Enter Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (dateTimePicker1.Text == "")
                {
                    MessageBox.Show("Enter Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    textBox6.Text = textBox12.Text;
                    textBox7.Text = textBox4.Text;
                    textBox8.Text = textBox3.Text;
                    textBox10.Text = textBox5.Text;
                    textBox9.Text = dateTimePicker3.Text;
                    textBox11.Text = dateTimePicker4.Text;
                    textBox14.Text = textBox13.Text;
                    dateTimePicker2.Text = dateTimePicker1.Text;

                    textBox12.Clear();
                    textBox4.Clear();
                    textBox3.Clear();
                    textBox5.Clear();
                    dateTimePicker3.CustomFormat = "";
                    dateTimePicker3.Format = DateTimePickerFormat.Custom;
                    dateTimePicker4.CustomFormat = "";
                    dateTimePicker4.Format = DateTimePickerFormat.Custom;
                    textBox13.Clear();
                    dateTimePicker1.CustomFormat = "";
                    dateTimePicker1.Format = DateTimePickerFormat.Custom;

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
                int id_servicee = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Servicees_ID"].Value);

                DialogResult dr2 = MessageBox.Show("Are you sure you want to delete this record?");
                try
                {
                    if (dr2 == DialogResult.Yes)



                        //    constr = ConfigurationManager.ConnectionStrings["appcon"].ConnectionString;
                        //SqlConnection conn = new SqlConnection(constr);
                        conn = new SqlConnection(ConnectionStringHotel.ConnectionString);

                    conn.Open();
            
                    string queryf = "DELETE from SERCICEES_Reference WHERE Servicees_ID= @Servicees_ID";

                    SqlCommand cmd11 = new SqlCommand(queryf, conn);
                    cmd11.Parameters.AddWithValue("@Servicees_ID", id_servicee);


                     cmd11.ExecuteNonQuery();

                    string queryc = "DELETE from SERVICEES WHERE Servicees_ID= @Servicees_ID";
                    SqlCommand cmd10 = new SqlCommand(queryc, conn);
                    cmd10.Parameters.AddWithValue("@Servicees_ID", id_servicee);

                    int rowsaffected1 = cmd10.ExecuteNonQuery();


                    if (rowsaffected1 > 0  )
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

            //    try
            //    {

            //        if (SelectedRowIndex < 0 || SelectedColumnIndex < 0)
            //        {
            //            MessageBox.Show("الرجاء تحديد خلية");
            //            return;
            //        }
            //        string newvalue = textedit4.Text;
            //        string columnname1 = dataGridView1.Columns[SelectedColumnIndex].Name;
            //        object primarykeyvalue2 = dataGridView1.Rows[SelectedRowIndex].Cells["Servicees_ID"].Value;
            //        object primarykeyvalue12 = dataGridView1.Rows[SelectedRowIndex].Cells["Servicees_ID"].Value;


            //        string queryr = $"update SERVICEES  SET [{columnname1}]= @NewValue WHERE Servicees_ID=@Servicees_ID";

            //        //constr = ConfigurationManager.ConnectionStrings["appcon"].ConnectionString;
            //        //conn = new SqlConnection(constr);
            //        conn = new SqlConnection(ConnectionStringHotel.ConnectionString);



            //        SqlCommand cmd13 = new SqlCommand(queryr, conn);

            //        cmd13.Parameters.AddWithValue("@NewValue", newvalue);
            //        cmd13.Parameters.AddWithValue("@Servicees_ID", primarykeyvalue12);
            //        conn.Open();
            //       int result1= cmd13.ExecuteNonQuery();


            //        string queryn = $"update SERCICEES_Reference  SET [{columnname1}]= @NewValue WHERE Servicees_ID=@Servicees_ID";
            //        SqlCommand cmd12 = new SqlCommand(queryn, conn);
            //        cmd12.Parameters.AddWithValue("@NewValue", newvalue);
            //        cmd12.Parameters.AddWithValue("@Servicees_ID", primarykeyvalue12);
            //        int result2 = cmd12.ExecuteNonQuery();
            //        conn.Close();

            //        if (result1 > 0 && result2 > 0)
            //        {
            //         dataGridView1.Rows[SelectedRowIndex].Cells[SelectedColumnIndex].Value = newvalue;
            //            MessageBox.Show("تم التحديث بنجاح");

            //        }
            //        else
            //        {
            //            MessageBox.Show("فشل التحديث");
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("ربما البيانات تم ادخالها مسبقا" + ex.Message);
            //    }

            try
            {

                if (SelectedRowIndex< 0 || SelectedColumnIndex< 0)
                {
                    MessageBox.Show("الرجاء تحديد خلية");
                    return;
                }
    string newvalue = textedit4.Text;
    string columnname1 = dataGridView1.Columns[SelectedColumnIndex].Name;
    string primarykeycolumn2 = "Servicees_ID";
    object primarykeyvalue12 = dataGridView1.Rows[SelectedRowIndex].Cells[primarykeycolumn2].Value;
    string queryr = $"update SERVICEES  SET [{columnname1}]= @NewValue WHERE [{primarykeycolumn2}]=@Servicees_ID";
    string queryn = $"update SERCICEES_Reference  SET [{columnname1}]= @NewValue WHERE [{primarykeycolumn2}]=@Servicees_ID";
                conn = new SqlConnection(ConnectionStringHotel.ConnectionString);

                //constr = ConfigurationManager.ConnectionStrings["appcon"].ConnectionString;
                //            conn = new SqlConnection(constr);
                conn.Open();
                //SqlCommand cmd12 = new SqlCommand(queryn, conn);

                //cmd12.Parameters.AddWithValue("@NewValue", newvalue);
                //cmd12.Parameters.AddWithValue("@Servicees_ID", primarykeyvalue12);





                SqlCommand cmd13 = new SqlCommand(queryr, conn);
    SqlCommand cmd14 = new SqlCommand(queryn, conn);

    cmd13.Parameters.AddWithValue("@NewValue", newvalue);
                cmd13.Parameters.AddWithValue("@Servicees_ID", primarykeyvalue12);
                //cmd14.Parameters.AddWithValue("@NewValue", newvalue);
                //cmd14.Parameters.AddWithValue("@Servicees_ID", primarykeyvalue12);

                //int result = cmd12.ExecuteNonQuery();
                int result2 = cmd13.ExecuteNonQuery();

    conn.Close();

                if (result2 > 0)
                { 
                    dataGridView1.Rows[SelectedRowIndex].Cells[SelectedColumnIndex].Value = newvalue;
                    MessageBox.Show("تم التحديث بنجاح");

                }
                else
{
    MessageBox.Show("فشل التحديث");
}
            }
            catch (Exception ex)
{
    MessageBox.Show("ربما البيانات تم ادخالها مسبقا" + ex.Message);
}
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRowIndex = e.RowIndex;
            SelectedColumnIndex = e.ColumnIndex;

            if (SelectedRowIndex >= 0 && SelectedColumnIndex >= 0)
            {
                string cellvalue = dataGridView1.Rows[SelectedRowIndex].Cells[SelectedColumnIndex].Value.ToString();
                textedit4.Text = cellvalue;

            }

        }

        private void textsearch4_TextChanged(object sender, EventArgs e)
        {
            //constr = ConfigurationManager.ConnectionStrings["appcon"].ConnectionString;
            //conn = new SqlConnection(constr);
            conn = new SqlConnection(ConnectionStringHotel.ConnectionString);
            string querya = "select * from SERVICEES WHERE Servicees_ID  LIKE @Servicees_ID +'%'";

            SqlCommand cmda = new SqlCommand(querya, conn);
            cmda.Parameters.AddWithValue("@Servicees_ID ", textsearch4.Text.Trim());
            SqlDataAdapter ad4 = new SqlDataAdapter(cmda);
            DataTable dt5 = new DataTable();
            ad4.Fill(dt5);
            dataGridView1.DataSource = dt5;

            if (dt5.Rows.Count == 0)
            {
                MessageBox.Show("لا توجد بيانات مطابقه");
            }
        }
    }
}
