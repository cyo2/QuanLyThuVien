using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_LoginInf
    {
        private string _status;
        private string _username;
        private string _role;

        public string Status { get => _status; set => _status = value; }
        public string Username { get => _username; set => _username = value; }
        public string Role { get => _role; set => _role = value; }

        public DTO_LoginInf() { }
        public DTO_LoginInf(string status, string username, string role)
        {
            Status = status;
            Username = username;
            Role = role;
        }
    }
   
}
