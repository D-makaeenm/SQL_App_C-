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

        private void tabPage1_Enter(object sender, EventArgs e)
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
        //-------------------------------------------------------------------------------   hdnhap

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
            ma = row.Cells[0].Value.ToString();
        }
        bool valid = false;
        private void button8_Click(object sender, EventArgs e)
        {
            string mahdn = textBox12.Text;
            string mahang = textBox11.Text;
            string mancc = textBox10.Text;
            string soluong = textBox7.Text;
            string dvt = textBox9.Text;

            ketnoi.Open();
            sql = @"insert into hdnhap
            values
            (N'" + mahdn + "', N'" + mahang + "', N'" + mancc + "',N'" + soluong + "', N'" + dvt + "')";
            MessageBox.Show("Đã thêm thành công !!");
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();
            ketnoi.Open();
            sql = "select *from hdnhap";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = "select* from hdnhap";
            hienthi();
            dataGridView2.DataSource = dt;
            ketnoi.Close();
        }

        private void sua2_Click(object sender, EventArgs e)
        {
            string mahdn = textBox12.Text;
            string mahang = textBox11.Text;
            string mancc = textBox10.Text;
            string soluong = textBox7.Text;
            string dvt = textBox9.Text;
            string vitri = textBox8.Text;
            ketnoi.Open();
            sql = @"update hdnhap set
            mahdn = N'" + mahdn + "', mahang = N'" + mahang + "', mancc = N'" + mancc + "', soluong = N'" + soluong + "', dvt = N'" + dvt + "'" + $" where mahdn = N'" + vitri + "' ";
            MessageBox.Show("Đã sửa thành công!!!");
            textBox5.Clear();
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            xoa();
            ketnoi.Close();
            ketnoi.Open();
            sql = "select * from hdnhap";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
        }

        private void xoa2_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string lenhxoa = "delete hdnhap where mahdn ='" + ma + "'";
            thuchien = new SqlCommand(lenhxoa, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();

            ketnoi.Open();
            sql = "select* from hdnhap";
            hienthi();
            dataGridView1.DataSource = dt;
            ketnoi.Close();
        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            ma = row.Cells[0].Value.ToString();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string select = comboBox.SelectedItem.ToString();
            ketnoi.Open();
            if (select == "mahdn")
            {
                sql = @"select mahdn from hdnhap";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView2.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "mahang")
            {
                sql = @"select mahang from hdnhap";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView2.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "mancc")
            {
                sql = @"select mancc from hdnhap";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView2.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "soluong")
            {
                sql = @"select soluong from hdnhap";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView2.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "dvt")
            {
                sql = @"select dvt from hdnhap";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView2.DataSource = dt;
                ketnoi.Close();
            }
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                DataGridViewCell selected = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex];
                textBox12.Text = dataGridView2.Rows[e.RowIndex].Cells["mahdn"].Value.ToString();
                textBox11.Text = dataGridView2.Rows[e.RowIndex].Cells["mahang"].Value.ToString();
                textBox10.Text = dataGridView2.Rows[e.RowIndex].Cells["mancc"].Value.ToString();
                textBox7.Text = dataGridView2.Rows[e.RowIndex].Cells["soluong"].Value.ToString();
                textBox9.Text = dataGridView2.Rows[e.RowIndex].Cells["dvt"].Value.ToString();
                textBox8.Text = dataGridView2.Rows[e.RowIndex].Cells["mahdn"].Value.ToString();
            }
        }

        //-------------------------------------------------------------------------------------- hd xuat
        private void button12_Click(object sender, EventArgs e)
        {
            string mahdx = textBox18.Text;
            string mahang = textBox17.Text;
            string makh = textBox16.Text;
            string soluong = textBox13.Text;
            string dvt = textBox15.Text;

            ketnoi.Open();
            sql = @"insert into hdxuat
            values
            (N'" + mahdx + "', N'" + mahang + "', N'" + makh + "',N'" + soluong + "', N'" + dvt + "')";
            MessageBox.Show("Đã thêm thành công !!");
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();

            ketnoi.Close();
            ketnoi.Open();
            sql = "select *from hdxuat";
            hienthi();
            dataGridView3.DataSource = dt;
            ketnoi.Close();
        }

        private void sua3_Click(object sender, EventArgs e)
        {
            string mahdx = textBox18.Text;
            string mahang = textBox17.Text;
            string makh = textBox16.Text;
            string soluong = textBox13.Text;
            string dvt = textBox15.Text;
            string vitri = textBox14.Text;
            ketnoi.Open();
            sql = @"update hdxuat set
            mahdx = N'" + mahdx + "', mahang = N'" + mahang + "', makhachhang = N'" + makh + "', soluong = N'" + soluong + "', dvt = N'" + dvt + "'" + $" where mahdx = N'" + vitri + "' ";
            MessageBox.Show("Đã sửa thành công!!!");
            textBox5.Clear();
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            ketnoi.Open();
            sql = "select * from hdxuat";
            hienthi();
            dataGridView3.DataSource = dt;
            ketnoi.Close();
        }

        private void xoa3_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string lenhxoa = "delete hdxuat where mahdx ='" + ma + "'";
            thuchien = new SqlCommand(lenhxoa, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();

            ketnoi.Open();
            sql = "select* from hdxuat";
            hienthi();
            dataGridView3.DataSource = dt;
            ketnoi.Close();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            DataGridViewRow row = dataGridView3.Rows[e.RowIndex];
            ma = row.Cells[0].Value.ToString();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                DataGridViewCell selected = dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex];
                textBox18.Text = dataGridView3.Rows[e.RowIndex].Cells["mahdx"].Value.ToString();
                textBox17.Text = dataGridView3.Rows[e.RowIndex].Cells["mahang"].Value.ToString();
                textBox16.Text = dataGridView3.Rows[e.RowIndex].Cells["makhachhang"].Value.ToString();
                textBox13.Text = dataGridView3.Rows[e.RowIndex].Cells["soluong"].Value.ToString();
                textBox15.Text = dataGridView3.Rows[e.RowIndex].Cells["dvt"].Value.ToString();
                textBox14.Text = dataGridView3.Rows[e.RowIndex].Cells["mahdx"].Value.ToString();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string select = comboBox.SelectedItem.ToString();
            ketnoi.Open();
            if (select == "mahdx")
            {
                sql = @"select mahdx from hdxuat";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView3.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "mahang")
            {
                sql = @"select mahang from hdxuat";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView3.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "makhachhang")
            {
                sql = @"select makhachhang from hdxuat";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView3.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "soluong")
            {
                sql = @"select soluong from hdxuat";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView3.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "dvt")
            {
                sql = @"select dvt from hdxuat";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView3.DataSource = dt;
                ketnoi.Close();
            }
        }

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = "select* from hdxuat";
            hienthi();
            dataGridView3.DataSource = dt;
            ketnoi.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
        }
        //------------------------------------------------------------------------------------- khach hang
        private void button16_Click(object sender, EventArgs e)
        {
            string makhachhang = textBox24.Text;
            string hoten = textBox23.Text;
            string diachi = textBox22.Text;
            string gioitinh = textBox21.Text;
            string dienthoai = textBox20.Text;

            ketnoi.Open();
            sql = @"insert into khachhang
            values
            (N'" + makhachhang + "', N'" + hoten + "', N'" + diachi + "',N'" + gioitinh + "', N'" + dienthoai + "')";
            MessageBox.Show("Đã thêm thành công !!");
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();

            ketnoi.Close();
            ketnoi.Open();
            sql = "select *from khachhang";
            hienthi();
            dataGridView4.DataSource = dt;
            ketnoi.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            string makhachhang = textBox24.Text;
            string hoten = textBox23.Text;
            string diachi = textBox22.Text;
            string gioitinh = textBox21.Text;
            string dienthoai = textBox20.Text;
            string vitri = textBox19.Text;
            ketnoi.Open();
            sql = @"update khachhang set
            makhachhang = N'" + makhachhang + "', hoten = N'" + hoten + "', diachi = N'" + diachi + "', gioitinh = N'" + gioitinh + "', dienthoai = N'" + dienthoai + "'" + $" where makhachhang = N'" + vitri + "' ";
            MessageBox.Show("Đã sửa thành công!!!");
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            ketnoi.Open();
            sql = "select * from khachhang";
            hienthi();
            dataGridView4.DataSource = dt;
            ketnoi.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string lenhxoa = "delete khachhang where makhachhang ='" + ma + "'";
            thuchien = new SqlCommand(lenhxoa, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();

            ketnoi.Open();
            sql = "select* from khachhang";
            hienthi();
            dataGridView4.DataSource = dt;
            ketnoi.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox19.Clear();
            textBox20.Clear();
            textBox21.Clear();
            textBox22.Clear();
            textBox23.Clear();
            textBox24.Clear();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            DataGridViewRow row = dataGridView4.Rows[e.RowIndex];
            ma = row.Cells[0].Value.ToString();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                DataGridViewCell selected = dataGridView4.Rows[e.RowIndex].Cells[e.ColumnIndex];
                textBox24.Text = dataGridView4.Rows[e.RowIndex].Cells["makhachhang"].Value.ToString();
                textBox23.Text = dataGridView4.Rows[e.RowIndex].Cells["hoten"].Value.ToString();
                textBox22.Text = dataGridView4.Rows[e.RowIndex].Cells["diachi"].Value.ToString();
                textBox21.Text = dataGridView4.Rows[e.RowIndex].Cells["gioitinh"].Value.ToString();
                textBox20.Text = dataGridView4.Rows[e.RowIndex].Cells["dienthoai"].Value.ToString();
                textBox19.Text = dataGridView4.Rows[e.RowIndex].Cells["makhachhang"].Value.ToString();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string select = comboBox.SelectedItem.ToString();
            ketnoi.Open();
            if (select == "makhachhang")
            {
                sql = @"select makhachhang from khachhang";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView4.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "hoten")
            {
                sql = @"select hoten from khachhang";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView4.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "diachi")
            {
                sql = @"select diachi from khachhang";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView4.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "gioitinh")
            {
                sql = @"select gioitinh from khachhang";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView4.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "dienthoai")
            {
                sql = @"select dienthoai from khachhang";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView4.DataSource = dt;
                ketnoi.Close();
            }
        }

        private void tabPage4_Enter(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = "select* from khachhang";
            hienthi();
            dataGridView4.DataSource = dt;
            ketnoi.Close();
        }
        //-------------------------------------------------------------------------------- mathang
        private void them5_Click(object sender, EventArgs e)
        {
            string mahang = textBox31.Text;
            string tenhang = textBox30.Text;
            string loaihang = textBox29.Text;
            string mancc = textBox28.Text;
            string soluong = textBox27.Text;
            string dvt = textBox26.Text;

            ketnoi.Open();
            sql = @"insert into mathang
            values
            (N'" + mahang + "', N'" + tenhang + "', N'" + loaihang + "',N'" + mancc + "', N'" + soluong + "', N'" + dvt + "')";
            MessageBox.Show("Đã thêm thành công !!");
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();

            ketnoi.Close();
            ketnoi.Open();
            sql = "select *from mathang";
            hienthi();
            dataGridView5.DataSource = dt;
            ketnoi.Close();
        }

        private void sua5_Click(object sender, EventArgs e)
        {
            string mahang = textBox31.Text;
            string tenhang = textBox30.Text;
            string loaihang = textBox29.Text;
            string mancc = textBox28.Text;
            string soluong = textBox27.Text;
            string dvt = textBox26.Text;
            string vitri = textBox25.Text;
            ketnoi.Open();
            sql = @"update mathang set
            mahang = N'" + mahang + "', tenhang = N'" + tenhang + "', loaihang = N'" + loaihang + "', mancc = N'" + mancc + "', soluong = N'" + soluong + "', dvt = N'" + dvt + "'" + $" where mahang = N'" + vitri + "' ";
            MessageBox.Show("Đã sửa thành công!!!");
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            ketnoi.Open();
            sql = "select * from mathang";
            hienthi();
            dataGridView5.DataSource = dt;
            ketnoi.Close();
        }

        private void xoa5_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string lenhxoa = "delete mathang where mahang ='" + ma + "'";
            thuchien = new SqlCommand(lenhxoa, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();

            ketnoi.Open();
            sql = "select* from mathang";
            hienthi();
            dataGridView5.DataSource = dt;
            ketnoi.Close();
        }

        private void rfl5_Click(object sender, EventArgs e)
        {
            textBox31.Clear();
            textBox30.Clear();
            textBox29.Clear();
            textBox28.Clear();
            textBox27.Clear();
            textBox26.Clear();
            textBox25.Clear();
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            DataGridViewRow row = dataGridView5.Rows[e.RowIndex];
            ma = row.Cells[0].Value.ToString();
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                DataGridViewCell selected = dataGridView5.Rows[e.RowIndex].Cells[e.ColumnIndex];
                textBox31.Text = dataGridView5.Rows[e.RowIndex].Cells["mahang"].Value.ToString();
                textBox30.Text = dataGridView5.Rows[e.RowIndex].Cells["tenhang"].Value.ToString();
                textBox29.Text = dataGridView5.Rows[e.RowIndex].Cells["loaihang"].Value.ToString();
                textBox28.Text = dataGridView5.Rows[e.RowIndex].Cells["mancc"].Value.ToString();
                textBox27.Text = dataGridView5.Rows[e.RowIndex].Cells["soluong"].Value.ToString();
                textBox26.Text = dataGridView5.Rows[e.RowIndex].Cells["dvt"].Value.ToString();
                textBox25.Text = dataGridView5.Rows[e.RowIndex].Cells["mahang"].Value.ToString();
            }
        }

        private void tabPage5_Enter(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = "select* from mathang";
            hienthi();
            dataGridView5.DataSource = dt;
            ketnoi.Close();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string select = comboBox.SelectedItem.ToString();
            ketnoi.Open();
            if (select == "mahang")
            {
                sql = @"select mahang from mathang";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView5.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "tenhang")
            {
                sql = @"select tenhang from mathang";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView5.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "loaihang")
            {
                sql = @"select loaihang from mathang";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView5.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "mancc")
            {
                sql = @"select mancc from mathang";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView5.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "soluong")
            {
                sql = @"select soluong from mathang";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView5.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "dvt")
            {
                sql = @"select dvt from mathang";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView5.DataSource = dt;
                ketnoi.Close();
            }
        }
        //----------------------------------------------------------------------------------- nha cung cap
        private void them6_Click(object sender, EventArgs e)
        {
            string mancc = textBox36.Text;
            string tenncc = textBox35.Text;
            string diachi = textBox34.Text;
            string email = textBox33.Text;

            ketnoi.Open();
            sql = @"insert into nhacc
            values
            (N'" + mancc + "', N'" + tenncc + "', N'" + diachi + "',N'" + email + "')";
            MessageBox.Show("Đã thêm thành công !!");
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            ketnoi.Open();
            sql = "select *from nhacc";
            hienthi();
            dataGridView6.DataSource = dt;
            ketnoi.Close();
        }

        private void sua6_Click(object sender, EventArgs e)
        {
            string mancc = textBox36.Text;
            string tenncc = textBox35.Text;
            string diachi = textBox34.Text;
            string email = textBox33.Text;
            string vitri = textBox32.Text;
            ketnoi.Open();
            sql = @"update nhacc set
            mancc = N'" + mancc + "', tenncc = N'" + tenncc + "', diachi = N'" + diachi + "', email = N'" + email + "'" + $" where mancc = N'" + vitri + "' ";
            MessageBox.Show("Đã sửa thành công!!!");
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            ketnoi.Open();
            sql = "select * from nhacc";
            hienthi();
            dataGridView6.DataSource = dt;
            ketnoi.Close();
        }

        private void xoa6_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string lenhxoa = "delete nhacc where mancc ='" + ma + "'";
            thuchien = new SqlCommand(lenhxoa, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();

            ketnoi.Open();
            sql = "select* from nhacc";
            hienthi();
            dataGridView6.DataSource = dt;
            ketnoi.Close();
        }

        private void rfl6_Click(object sender, EventArgs e)
        {
            textBox32.Clear();
            textBox33.Clear();
            textBox34.Clear();
            textBox35.Clear();
            textBox36.Clear();
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            DataGridViewRow row = dataGridView6.Rows[e.RowIndex];
            ma = row.Cells[0].Value.ToString();
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                DataGridViewCell selected = dataGridView6.Rows[e.RowIndex].Cells[e.ColumnIndex];
                textBox36.Text = dataGridView6.Rows[e.RowIndex].Cells["mancc"].Value.ToString();
                textBox35.Text = dataGridView6.Rows[e.RowIndex].Cells["tenncc"].Value.ToString();
                textBox34.Text = dataGridView6.Rows[e.RowIndex].Cells["diachi"].Value.ToString();
                textBox33.Text = dataGridView6.Rows[e.RowIndex].Cells["email"].Value.ToString();
                textBox32.Text = dataGridView6.Rows[e.RowIndex].Cells["mancc"].Value.ToString();
            }
        }

        private void tabPage6_Enter(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = "select* from nhacc";
            hienthi();
            dataGridView6.DataSource = dt;
            ketnoi.Close();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string select = comboBox.SelectedItem.ToString();
            ketnoi.Open();
            if (select == "mancc")
            {
                sql = @"select mancc from nhacc";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView6.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "tenncc")
            {
                sql = @"select tenncc from nhacc";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView6.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "diachi")
            {
                sql = @"select diachi from nhacc";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView6.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "email")
            {
                sql = @"select email from nhacc";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView6.DataSource = dt;
                ketnoi.Close();
            }
        }
        //------------------------------------------------------------------------------ nhan vien
        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            DataGridViewRow row = dataGridView7.Rows[e.RowIndex];
            ma = row.Cells[0].Value.ToString();
        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                DataGridViewCell selected = dataGridView7.Rows[e.RowIndex].Cells[e.ColumnIndex];
                textBox48.Text = dataGridView7.Rows[e.RowIndex].Cells["manv"].Value.ToString();
                textBox47.Text = dataGridView7.Rows[e.RowIndex].Cells["tennv"].Value.ToString();
                textBox46.Text = dataGridView7.Rows[e.RowIndex].Cells["gioitinh"].Value.ToString();
                textBox45.Text = dataGridView7.Rows[e.RowIndex].Cells["ngaysinh"].Value.ToString();
                textBox44.Text = dataGridView7.Rows[e.RowIndex].Cells["ngaylamviec"].Value.ToString();
                textBox43.Text = dataGridView7.Rows[e.RowIndex].Cells["diachi"].Value.ToString();
                textBox42.Text = dataGridView7.Rows[e.RowIndex].Cells["dienthoai"].Value.ToString();
                textBox41.Text = dataGridView7.Rows[e.RowIndex].Cells["luongcoban"].Value.ToString();
                textBox40.Text = dataGridView7.Rows[e.RowIndex].Cells["phucap"].Value.ToString();
                textBox39.Text = dataGridView7.Rows[e.RowIndex].Cells["manv"].Value.ToString();
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string select = comboBox.SelectedItem.ToString();
            ketnoi.Open();
            if (select == "manv")
            {
                sql = @"select manv from nhanvien";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView7.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "tennv")
            {
                sql = @"select tennv from nhanvien";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView7.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "gioitinh")
            {
                sql = @"select gioitinh from nhanvien";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView7.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "ngaysinh")
            {
                sql = @"select ngaysinh from nhanvien";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView7.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "ngaylamviec")
            {
                sql = @"select ngaylamviec from nhanvien";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView7.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "diachi")
            {
                sql = @"select diachi from nhanvien";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView7.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "dienthoai")
            {
                sql = @"select dienthoai from nhanvien";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView7.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "luongcoban")
            {
                sql = @"select luongcoban from nhanvien";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView7.DataSource = dt;
                ketnoi.Close();
            }
            else if (select == "phucap")
            {
                sql = @"select phucap from nhanvien";
                thuchien = new SqlCommand(sql, ketnoi);
                thuchien.ExecuteNonQuery();
                hienthi();
                dataGridView7.DataSource = dt;
                ketnoi.Close();
            }
        }

        private void tabPage7_Enter(object sender, EventArgs e)
        {
            ketnoi = new SqlConnection(chuoiketnoi);
            ketnoi.Open();
            sql = "select* from nhanvien";
            hienthi();
            dataGridView7.DataSource = dt;
            ketnoi.Close();
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void them7_Click(object sender, EventArgs e)
        {
            string manv = textBox48.Text;
            string tennv = textBox47.Text;
            string gioitinh = textBox46.Text;
            string ngaysinh = textBox45.Text;
            string ngaylamviec = textBox44.Text;
            string diachi = textBox43.Text;
            string dienthoai = textBox42.Text;
            string luongcoban = textBox41.Text;
            string phucap = textBox40.Text;
            DateOnly date1 = DateOnly.ParseExact(ngaysinh, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateOnly date2 = DateOnly.ParseExact(ngaylamviec, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            string ngsinh = date1.ToString("yyyy-MM-dd");
            string nglv = date2.ToString("yyyy-MM-dd");
            ketnoi.Open();
            sql = @"insert into nhanvien
            values
            (N'" + manv + "', N'" + tennv + "', N'" + gioitinh + "',N'" + ngsinh + "',N'" + nglv + "',N'" + diachi + "',N'" + dienthoai + "',N'" + luongcoban + "',N'" + phucap + "')";
            MessageBox.Show("Đã thêm thành công !!");
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            ketnoi.Open();
            sql = "select *from nhanvien";
            hienthi();
            dataGridView7.DataSource = dt;
            ketnoi.Close();
        }

        private void sua7_Click(object sender, EventArgs e)
        {
            string manv = textBox48.Text;
            string tennv = textBox47.Text;
            string gioitinh = textBox46.Text;
            string ngaysinh = textBox45.Text;
            string ngaylamviec = textBox44.Text;
            string diachi = textBox43.Text;
            string dienthoai = textBox42.Text;
            string luongcoban = textBox41.Text;
            string phucap = textBox40.Text;
            string vitri = textBox39.Text;
            ketnoi.Open();
            sql = @"update nhanvien set
            manv = N'" + manv + "', tennv = N'" + tennv + "', gioitinh = N'" + gioitinh + "', ngaysinh = N'" + ngaysinh + "', ngaylamviec = N'" + ngaylamviec + "', diachi = N'" + diachi + "', dienthoai = N'" + dienthoai + "', luongcoban = N'" + luongcoban + "', phucap = N'" + phucap + "'" + $" where manv = N'" + vitri + "' ";
            MessageBox.Show("Đã sửa thành công!!!");
            thuchien = new SqlCommand(sql, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();
            ketnoi.Open();
            sql = "select * from nhanvien";
            hienthi();
            dataGridView7.DataSource = dt;
            ketnoi.Close();
        }

        private void xoa7_Click(object sender, EventArgs e)
        {
            ketnoi.Open();
            string lenhxoa = "delete nhanvien where manv ='" + ma + "'";
            thuchien = new SqlCommand(lenhxoa, ketnoi);
            thuchien.ExecuteNonQuery();
            ketnoi.Close();

            ketnoi.Open();
            sql = "select* from nhanvien";
            hienthi();
            dataGridView7.DataSource = dt;
            ketnoi.Close();
        }

        private void rfr7_Click(object sender, EventArgs e)
        {
            textBox48.Clear();
            textBox47.Clear();
            textBox46.Clear();
            textBox45.Clear();
            textBox44.Clear();
            textBox43.Clear();
            textBox42.Clear();
            textBox41.Clear();
            textBox40.Clear();
            textBox39.Clear();
        }
    }
}
//Code by Ma Bách Duy - K56KMT - TNUT