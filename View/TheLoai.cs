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
        TheLoai_Model mainModel = new TheLoai_Model();
        TheLoai_Controller mainController = new TheLoai_Controller();
        public TheLoai()
        {
            InitializeComponent();
        }
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
                txtTenTheLoai.Text = dtgTheLoai.Rows[i].Cells[0].Value.ToString();
                txtMaTheLoai.Text = dtgTheLoai.Rows[i].Cells[1].Value.ToString();
                txtMaTheLoai.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnAdd.Enabled = false;
            }
            catch
            {
                e.ToString();
            }
        }

        
        public void SetNull()
        {
            txtTenTheLoai.Text = "";
            txtMaTheLoai.Text = "";
        }

        public void LoadData()
        {
            dtgTheLoai.DataSource = mainModel.Load();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTenTheLoai.Text == "" || txtMaTheLoai.Text == "")
            {
                MessageBox.Show("Không được để trống data");
            }
            else
            {
                if (txtMaTheLoai.Text.Length == 4)
                {
                    string name = txtTenTheLoai.Text;
                    string id = txtMaTheLoai.Text;
                    if (mainController.Them(id, name))
                    {
                        MessageBox.Show("Thêm mới thành công");
                        LoadData();
                        SetNull();
                    }
                    else
                    {
                        MessageBox.Show("Mã Đã Tồn Tại ","Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Mã thể loại phải có 4 ký tự", "Thông báo");
                }
                
                
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaTheLoai.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
            SetNull();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtTenTheLoai.Text == "")
            {
                MessageBox.Show("Không được để trống dữ liệu");
            }
            else
            {
                string name = txtTenTheLoai.Text;
                string id = txtMaTheLoai.Text;
                DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn sửa mã thể loại: " + id + " không?", "Xác nhận", MessageBoxButtons.YesNo);
                if(confirm == DialogResult.Yes)
                {
                    if (mainController.Sua(id, name))
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo");
                        LoadData();
                        SetNull();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi sửa", "Thông báo");
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtMaTheLoai.Text;
            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa mã thể loại: " + id + " không?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                if (mainController.Xoa(id))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    LoadData();
                    SetNull();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa", "Thông báo");
                }
            }
        }
    }
}
