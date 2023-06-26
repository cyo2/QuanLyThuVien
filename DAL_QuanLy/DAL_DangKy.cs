using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO_QuanLy;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;

namespace DAL_QuanLy
{
    public class DAL_DangKy : DBConnect
    {

        public bool addNhanVien(DTO_DangKy DTO_Nhanvien)
        { 
            string strSql = "SP_TAOLOGIN";
            DBConnect provider = new DBConnect();
            provider.Connect();
            try
            { 
                SqlParameter p = new SqlParameter("@re", SqlDbType.VarChar, 100);
                p.Direction = ParameterDirection.Output;
                provider.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
                    //new SqlParameter { ParameterName = "@CaTruc", Value = DTO_Nhanvien.NhanVien_ca },
                    new SqlParameter { ParameterName = "@LGNAME", Value = DTO_Nhanvien.NhanVien_loginname },
                    new SqlParameter { ParameterName = "@PASS", Value = DTO_Nhanvien.NhanVien_pass },
                    new SqlParameter { ParameterName = "@USERNAME", Value = DTO_Nhanvien.NhanVien_user},
                    new SqlParameter { ParameterName = "@ROLE", Value = DTO_Nhanvien.NhanVien_loai}, p );
                provider.Disconnect();
                if (p.Value.ToString().Trim() == "0")
                    return false;
                return true;
            }
            catch
            {
                return true;
            }
        }
        public bool addNV1(DTO_DangKy DTO_NhanVien2)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-DDOK4T1;Initial Catalog=Quan_Ly_Thu_Vien;Integrated Security=True;"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SP_TAOLOGIN", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Thêm các tham số đầu vào
                    command.Parameters.AddWithValue("@LGNAME", DTO_NhanVien2.NhanVien_loginname);
                    command.Parameters.AddWithValue("@PASS", DTO_NhanVien2.NhanVien_pass);
                    command.Parameters.AddWithValue("@USERNAME",  DTO_NhanVien2.NhanVien_user);
                    command.Parameters.AddWithValue("@ROLE", DTO_NhanVien2.NhanVien_loai);

                    // Thêm tham số output
                    SqlParameter returnParameter = command.Parameters.Add("@RET", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;

                    // Thực thi stored procedure
                    command.ExecuteNonQuery();

                    // Lấy giá trị trả về từ tham số output
                    int returnValue = (int)returnParameter.Value;
                    if (returnValue == 0) return true;

                    else return false; 
                }
            }
         
        }

        public string TimNhanVienTiepTheo()
        {
            string strSql1 = "usp_TimMaNVTiepTheo";
            DBConnect provider1 = new DBConnect();
            provider1.Connect();

            SqlParameter p = new SqlParameter("@LGNAME", SqlDbType.VarChar, 100);
            p.Direction = ParameterDirection.Output;

            provider1.ExecuteNonQuery(CommandType.StoredProcedure, strSql1, p);

            provider1.Disconnect();
            return p.Value.ToString();
        }
    }
}
