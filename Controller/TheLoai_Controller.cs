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
        public bool Them_TheLoai(String name)
        {
            return mainModel.Them_TheLoai(name);
        }
    }
}
