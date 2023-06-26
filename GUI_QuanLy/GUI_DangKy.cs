using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Data;
using System.Data.SqlClient;
using DTO_QuanLy;
using BUS_QuanLy;
using System.Security.Cryptography;
using System.Diagnostics;

namespace GUI_QuanLy
{
    public partial class GUI_DangKy : Form
    {
        BUS_DangKy busDangKy = new BUS_DangKy();
        public GUI_DangKy()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;           
            this.StartPosition = FormStartPosition.CenterScreen;

        }
        private bool drag = false;
        private Point dragCursor, dragForm;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            dragCursor = Cursor.Position;
            dragForm = this.Location;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int wid = SystemInformation.VirtualScreen.Width;
            int hei = SystemInformation.VirtualScreen.Height;
            if (drag)
            {
                // Phải using System.Drawing;
                Point change = Point.Subtract(Cursor.Position, new Size(dragCursor));
                Point newpos = Point.Add(dragForm, new Size(change));              
                this.Location = newpos;
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        /*
        * Hàm băm SHA để băm mật khẩu user 
        */
        private string EncodeSHA1(string pass)
        {

            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(pass);
            bs = sha1.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x").ToLower());
            }
            pass = s.ToString();
            return pass;
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (txtHoTenNVDangKy.Text != "" && txtRoleNVDangKy.Text != "" && txtPassNVDangKy.Text != "")
            {
                string login = textUserName.Text;
                string hotennv = txtHoTenNVDangKy.Text;
                string user = txtRoleNVDangKy.Text;
                string salt = "QUYETDAICA1997";
                // string pass = EncodeSHA1(txtPassNVDangKy.Text + salt);
                string pass = txtPassNVDangKy.Text;
                string loai = "";
                //string ca = "";
                if (txtRoleNVDangKy.Text == "QUANLY") {
                    loai = "NHANVIEN";
                }
                else if (txtRoleNVDangKy.Text == "NHANVIEN")
                {
                    loai = "NHANVIEN";
                }

                // Tạo DTo
                DTO_DangKy tv = new DTO_DangKy(login.Trim(), pass.Trim(), hotennv.Trim(), loai.Trim()); // Vì ID tự tăng nên để ID số gì cũng dc
                if (!busDangKy.addNhanVien(tv))
                {
                    MessageBox.Show("Nhân Viên Này Đã Tồn Tại");
                    return;
                }
                else
                {
                    MessageBox.Show("Đăng Ký Nhân Viên Thành Công!!!");
                    GUI_DangNhap frmDangNhap = new GUI_DangNhap();
                    this.Hide();
                    frmDangNhap.Show();

                }  

            }
            else
            {
                MessageBox.Show("Xin hãy nhập đầy đủ");
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //lblCaTrucNVDangKy.Hide();
            //txtCaNVDangKy.Hide();
            textUserName.ReadOnly = false;

           // txtMaNVDangKy.Text = busDangKy.TimNhanVienTiepTheo();
        }

        private void rdThuThuDangKy_CheckedChanged(object sender, EventArgs e)
        {
            //lblCaTrucNVDangKy.Show();
            //txtCaNVDangKy.Show();
        }

        private void btnHuyDangKy_Click(object sender, EventArgs e)
        {
            GUI_DangNhap frmDangNhap = new GUI_DangNhap();
            frmDangNhap.Show();
            this.Close();
        }

        private void lblCaTrucNVDangKy_Click(object sender, EventArgs e)
        {

        }

        private void lbPassword_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtUserNVDangKy_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtHoTenNVDangKy_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRoleNVDangKy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMaNVDangKy_TextChanged(object sender, EventArgs e)
        {

        }

        private void rdAdminDangKy_CheckedChanged(object sender, EventArgs e)
        {
            //lblCaTrucNVDangKy.Hide();
            //txtCaNVDangKy.Hide();
        }
    }
}
