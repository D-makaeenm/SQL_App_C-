using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Globalization;
using System.Data.Common;

namespace SQL_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string chuoiketnoi = "Data Source=DuyVPro;Initial Catalog = thi; Integrated Security = True; Trust Server Certificate=True";
        string sql;
        SqlConnection ketnoi;
        SqlCommand thuchien;
        SqlDataReader docdulieu;
        int i = 0;
        DataTable dt;
        String ma;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = "select* from dondathang";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            ma = row.Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string madon = textBox1.Text;

            string makh = textBox2.Text;
            string manv = textBox3.Text;
            string ngaydh = textBox6.Text;//dd/mm/yy
            DateOnly date = DateOnly.ParseExact(ngaydh, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string ngaythangSQL = date.ToString("yyyy-MM-dd");
            string diachigh = textBox4.Text;
            ketnoi.Open();
            sql = @"insert into dondathang
            values
            (N'" + madon + "', N'" + makh + "', N'" + manv + "',N'" + ngaythangSQL + "', N'" + diachigh + "')";

            MessageBox.Show("Đã thêm thành công !!");
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();
            ketnoi.Open();
            sql = "select *from dondathang";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
        }
        public void hienthi()
        {
            thuchien = new SqlCommand(sql, ketnoi);
            docdulieu = thuchien.ExecuteReader();
            dt = new DataTable();
            dt.Load(docdulieu);
        }
        public void xoa()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            xoa();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string madon = textBox1.Text;
            string makh = textBox2.Text;
            string manv = textBox3.Text;
            string ngaydh = textBox6.Text;
            DateOnly date = DateOnly.ParseExact(ngaydh, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string ngaythangSQL = date.ToString("yyyy-MM-dd");
            string diachigh = textBox4.Text;
            string vitri = textBox5.Text;
            ketnoi.Open();
            sql = @"update dondathang set
            madon = N'" + madon + "', makhachhang = N'" + makh + "', manv = N'" + manv + "', ngaydh = N'" + ngaythangSQL + "', diachigiao = N'" + diachigh + "'" + $" where madon = N'" + vitri + "' ";
            MessageBox.Show("Đã sửa thành công!!!");
            textBox5.Clear();
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();
            ketnoi.Open();
            sql = "select * from dondathang";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string lenhxoa = "delete dondathang where madon ='" + ma + "'";
            thuchien = new SqlCommand(lenhxoa, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();

            ketnoi.Open();
            sql = "select* from dondathang";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                DataGridViewCell selected = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["madon"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["makhachhang"].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["manv"].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["ngaydh"].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["diachigiao"].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["madon"].Value.ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string select = comboBox.SelectedItem.ToString();
            ketnoi.Open();
            if (select == "madon")
            {
                sql = @"select madon from dondathang";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView1.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "makhachhang")
            {
                sql = @"select makhachhang from dondathang";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView1.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "manv")
            {
                sql = @"select manv from dondathang";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView1.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "diachigiao")
            {
                sql = @"select diachigiao from dondathang";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView1.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "ngaydh")
            {
                sql = @"select ngaydh from dondathang";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView1.DataSource = dt;
                ketnoi.Close();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
