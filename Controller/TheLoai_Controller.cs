using NSSP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSSP.Controller
{
    class TheLoai_Controller
    {
        TheLoai_Model mainModel = new TheLoai_Model();
        public bool Them(String id, String name)
        {
            return mainModel.Them(id, name);
        }
        public bool Sua(String id, String name)
        {
            return mainModel.Sua(id, name);
        }
        public bool Xoa(String id)
        {
            return mainModel.Xoa(id);
        }
    }
}
