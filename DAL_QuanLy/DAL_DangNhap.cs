using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DTO_QuanLy;
using System.Security.Policy;

namespace DAL_QuanLy
{
    public class DAL_DangNhap : DBConnect
    {


        public string getNameUser_Login(string username, string password)
        {
            string strSql1 = "usp_LayTenNhanVien";
            DBConnect provider1 = new DBConnect();
            provider1.Connect();

            SqlParameter p1 = new SqlParameter("@USERNAME", SqlDbType.NVarChar, 100);
            p1.Direction = ParameterDirection.Output;

            provider1.ExecuteNonQuery(CommandType.StoredProcedure, strSql1,
             new SqlParameter { ParameterName = "@LGNAME", Value = username },
             new SqlParameter { ParameterName = "@PASS", Value = password }, p1);

            provider1.Disconnect();
            return p1.Value.ToString();
        }
        public string getPermissionUser_Login(string username, string password)
        {
            string strSql2 = "usp_LayQuyenNhanVien";
            DBConnect provider2 = new DBConnect();
            provider2.Connect();

            SqlParameter p2 = new SqlParameter("@ROLE", SqlDbType.NVarChar, 100);
            p2.Direction = ParameterDirection.Output;

            provider2.ExecuteNonQuery(CommandType.StoredProcedure, strSql2,
            new SqlParameter { ParameterName = "@USERNAME", Value = username },
            new SqlParameter { ParameterName = "@PASS", Value = password }, p2);

            provider2.Disconnect();
            return p2.Value.ToString();
        }
        public string _Login(string username, string password)
        {
            string strSql = "usp_Login";
            DBConnect provider = new DBConnect();
            provider.Connect();

            SqlParameter p = new SqlParameter("@result", SqlDbType.Int);
            p.Direction = ParameterDirection.Output;

            provider.ExecuteNonQuery(CommandType.StoredProcedure, strSql,
            new SqlParameter { ParameterName = "@username", Value = username },
            new SqlParameter { ParameterName = "@password", Value = password }, p);

            provider.Disconnect();
            return p.Value.ToString();
        }
        public DTO_LoginInfo _Login2(string username, string password)
        {
            {
                using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-DDOK4T1;Initial Catalog=Quan_Ly_Thu_Vien;Integrated Security=True;"))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_DANGNHAP", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm các tham số đầu vào
                        command.Parameters.AddWithValue("@LGNAME", username);
                        command.Parameters.AddWithValue("@PASS", password);


                        // Thêm tham số output
                        SqlParameter returnParameter = command.Parameters.Add("@RET", SqlDbType.Int);
                        returnParameter.Direction = ParameterDirection.ReturnValue;
                        //SqlParameter tenNVParameter = command.Parameters.Add("@USERNAME", SqlDbType.NVarChar, 50);
                        //tenNVParameter.Direction = ParameterDirection.Output;

                        //SqlParameter roleParameter = command.Parameters.Add("@ROLE", SqlDbType.NVarChar, 50);
                        //roleParameter.Direction = ParameterDirection.Output;

                        // Thực thi stored procedure
                        command.ExecuteNonQuery();
                        // Lấy giá trị trả về từ tham số output

                        int returnValue = (int)returnParameter.Value;
                        //if (returnValue == 1) return 1;
                        //else if (returnValue == 2) return 2;
                        //else return 0;
                     
                        DTO_LoginInfo loginInfo = new DTO_LoginInfo();
                      
                        loginInfo.Status = returnValue.ToString();
                        //loginInfo.TenNV = (string)command.Parameters["@USERNAME"].Value;
                        //loginInfo.TenNV =  (string)tenNVParameter.Value;
                        //loginInfo.Loai  = (string)roleParameter.Value;
                        //string tenNV = (string)command.Parameters["@Username"].Value;
                        //loginInfo.Loai = (string)command.Parameters["@ROLE"].Value;

                        //string role = (string)command.Parameters["@Role"].Value;
                        if (returnValue == 0)
                        {
                            return loginInfo;
                        }
                        else if (returnValue == 1)
                        {
                            return loginInfo;

                        }
                        else return loginInfo;
                    }


                }

            }

        }
    }
}
