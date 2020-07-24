using NSSP.Controller;
using NSSP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NSSP.View
{
    public partial class TheLoai : Form
    {
        public TheLoai()
        {
            InitializeComponent();
        }
        TheLoai_Model mainModel = new TheLoai_Model();
        TheLoai_Controller mainController = new TheLoai_Controller();
        private void TheLoai_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtgTheLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i;
                i = dtgTheLoai.CurrentRow.Index;
                txtTenTheLoai.Text = dtgTheLoai.Rows[i].Cells["TENTHELOAI"].Value.ToString();
            }
            catch
            {
                e.ToString();
            }
        }

        
        public void SetNull()
        {
            txtTenTheLoai.Text = "";
        }

        public void LoadData()
        {
            dtgTheLoai.DataSource = mainModel.Load();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtTenTheLoai.Text == "")
            {
                MessageBox.Show("Nhaap day du ten the loai");
            }
            else
            {
                string name = txtTenTheLoai.Text;
                if (mainController.Them_TheLoai(name))
                {
                    MessageBox.Show("Theem moi thanh cong");
                    LoadData();
                    SetNull();
                }
                else
                {
                    MessageBox.Show("co loi xay ra");
                }
                
            }
        }
    }
}
