﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL_QuanLy;
using DTO_QuanLy;

namespace BUS_QuanLy
{
    public class BUS_DangKy
    {
        DAL_DangKy dalDangKy = new DAL_DangKy();
        public int addNhanVien(DTO_DangKy DTO_NhanVien)
        {
            return dalDangKy.addNV1(DTO_NhanVien);
            
        }
        public string TimNhanVienTiepTheo()
        {
            return dalDangKy.TimNhanVienTiepTheo(); 
        }

    }
}
