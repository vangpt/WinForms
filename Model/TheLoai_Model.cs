﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSSP.Model
{
    class TheLoai_Model
    {
        public DataTable Load()
        {
            DataTable res;
            String sql = " select * from THELOAI";
            res = XuLy.CreateTable(sql);
            return res;
        }
        public bool Them(String id, String tenTheLoai)
        {
            String sql = "insert into THELOAI(MATHELOAI, TENTHELOAI) values('" + id +"', N'"+ tenTheLoai + "')";
            bool res = false;
            
            if (XuLy.ExecuteNonQuery(sql) > 0)
                res = true;
            return res;
            
        }
        public bool Sua(String id, String tenTheLoai)
        {
            String sql = "update THELOAI set TENTHELOAI = N'" + tenTheLoai + "' where MATHELOAI='" + id + "'";
            bool res = false;

            if (XuLy.ExecuteNonQuery(sql) > 0)
                res = true;
            return res;

        }
        public bool Xoa(String id)
        {
            String sql = "delete from THELOAI where MATHELOAI='" + id + "'";
            bool res = false;

            if (XuLy.ExecuteNonQuery(sql) > 0)
                res = true;
            return res;

        }
    }
}
