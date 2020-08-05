using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSSP.Model
{
    class NXB_Model
    {
        public DataTable Load()
        {
            DataTable res;
            string sql = " select * from NHAXUATBAN";
            res = XuLy.CreateTable(sql);
            return res;
        }
        public bool Them(string id, string ten, int sdt, string diachi)
        {
            string sql = "insert into NHAXUATBAN(MA_NXB, TEN, SDT, DIACHI) values('" + id + "', N'" + ten + "', '" + sdt + "', N'" + diachi + "')";
            bool res = false;

            if (XuLy.ExecuteNonQuery(sql) > 0)
                res = true;
            return res;

        }
        public bool Sua(string id, string ten, int sdt, string diachi)
        {
            String sql = "update NHAXUATBAN set TEN = N'" + ten + "',SDT = '" + sdt + "',DIACHI = N'" + diachi + "' where MA_NXB='" + id + "'";
            bool res = false;

            if (XuLy.ExecuteNonQuery(sql) > 0)
                res = true;
            return res;

        }
        public bool Xoa(String id)
        {
            String sql = "delete from NHAXUATBAN where MA_NXB='" + id + "'";
            bool res = false;

            if (XuLy.ExecuteNonQuery(sql) > 0)
                res = true;
            return res;

        }
    }
}
