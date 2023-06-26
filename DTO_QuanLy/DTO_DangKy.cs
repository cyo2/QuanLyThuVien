using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO_QuanLy
{
    public class DTO_DangKy
    {
        private string _loginname;
        private string _pass;
        private string _user;
        private string _loai;
      

        /* ======== GETTER/SETTER ======== */
        public string NhanVien_user
        {
            get
            {
                return _user;
            }

            set
            {
                _user = value;
            }
        }
        public string NhanVien_loginname
        {
            get
            {
                return _loginname;
            }

            set
            {
                _loginname = value;
            }
        }

        public string NhanVien_pass
        {
            get
            {
                return _pass;
            }

            set
            {
                _pass = value;
            }
        }
        public string NhanVien_loai
        {
            get
            {
                return _loai;
            }

            set
            {
                _loai = value;
            }
        }
      

        /* === Constructor === */
        public DTO_DangKy()
        {
        }
        public DTO_DangKy(string loginname, string pass, string user, string loai)
        {
            this.NhanVien_loginname = loginname;
            this.NhanVien_pass = pass;
            this.NhanVien_user = user;
            this.NhanVien_loai = loai;
        }

 

     
    }
}
