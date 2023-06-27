using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_LoginInfo
    {
        private string _tenNV;
        private string _loai;
        private string _status;

        public string TenNV { get => _tenNV; set => _tenNV = value; }
        public string Loai { get => _loai; set => _loai = value; }
        public string Status { get => _status; set => _status = value; }
        
        public DTO_LoginInfo() { }
        public DTO_LoginInfo(string tenNV, string loai, string status) { 
            this.TenNV = tenNV;
            this.Loai= loai; 
            this.Status = status;
        }


    }
}
