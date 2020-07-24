using System;
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
        public bool Them_TheLoai(String tenTheLoai)
        {
            String sql = "insert into THELOAI(TENTHELOAI) values('" + tenTheLoai + "')";
            bool res = false;
            
            if (XuLy.ExecuteNonQuery(sql) > 0)
                res = true;
            return res;
            
        }
    }
}
