using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSSP.Model;

namespace NSSP.Controller
{
    class NXB_Controller
    {
        NXB_Model mainModel = new NXB_Model();
        public bool Them(string id, string name, int sdt, string diachi)
        {
            return mainModel.Them(id, name, sdt, diachi);
        }
        public bool Sua(string id, string name, int sdt, string diachi)
        {
            return mainModel.Sua(id, name, sdt, diachi);
        }
        public bool Xoa(String id)
        {
            return mainModel.Xoa(id);
        }
    }
}
