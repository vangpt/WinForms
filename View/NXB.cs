using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NSSP.Controller;
using NSSP.Model;

namespace NSSP.View
{
    public partial class NXB : Form
    {
        NXB_Model mainModel = new NXB_Model();
        NXB_Controller mainController = new NXB_Controller();
        public NXB()
        {
            InitializeComponent();
        }

        private void NXB_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            dtgNXB.DataSource = mainModel.Load();
        }
        public void SetNull()
        {
            txtTenNXB.Text = "";
            txtMaNXB.Text = "";
            txtDiaChi.Text = "";
            txtSDT.Text = "";            
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            bool isOk = true;
            
            if (txtTenNXB.Text == "" || txtMaNXB.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Không được để trống data","Thông báo");
                isOk = false;
            }
            else
            {
                if (txtMaNXB.Text.Length != 4)
                {
                    MessageBox.Show("Mã phải gồm 4 kí tự", "Thông báo");
                    isOk = false;
                }
                else
                {
                    if (txtSDT.Text.Length != 10)
                    {
                        MessageBox.Show("SDT phải gồm 10 kí tự số", "Thông báo");
                        isOk = false;
                    }
                }
            }
            
            
            if (isOk)
            {
                try
                {
                    string name = txtTenNXB.Text;
                    string id = txtMaNXB.Text;
                    int sdt = int.Parse(txtSDT.Text);
                    string diachi = txtDiaChi.Text;
                    if (mainController.Them(id, name, sdt, diachi))
                    {
                        MessageBox.Show("Thêm mới thành công", "Thông báo"  );
                        LoadData();
                        SetNull();
                    }
                    else
                    {
                        MessageBox.Show("Mã bị trùng", "Thông báo");
                    }
                    
                }
                catch
                {
                    MessageBox.Show("SDT phải nhập số", "Thông báo");
                }
            }
            
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaNXB.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
            SetNull();
        }

        private void dtgNXB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i;
                i = dtgNXB.CurrentRow.Index;
                txtMaNXB.Text = dtgNXB.Rows[i].Cells[0].Value.ToString();
                txtTenNXB.Text = dtgNXB.Rows[i].Cells[1].Value.ToString();
                txtSDT.Text = dtgNXB.Rows[i].Cells[2].Value.ToString();
                txtDiaChi.Text = dtgNXB.Rows[i].Cells[3].Value.ToString();
                txtMaNXB.Enabled = false;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                btnAdd.Enabled = false;
            }
            catch
            {
                e.ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            bool isOk = true;

            if (txtTenNXB.Text == "" || txtMaNXB.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Không được để trống data", "Thông báo");
                isOk = false;
            }
            else
            {
                if (txtSDT.Text.Length != 10)
                {
                    MessageBox.Show("SDT phải gồm 10 kí tự số", "Thông báo");
                    isOk = false;
                }
            }


            if (isOk)
            {
                DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn sửa mã NXB: " + txtMaNXB.Text + " không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        string name = txtTenNXB.Text;
                        string id = txtMaNXB.Text;
                        int sdt = int.Parse(txtSDT.Text);
                        string diachi = txtDiaChi.Text;
                        if (mainController.Sua(id, name, sdt, diachi))
                        {
                            MessageBox.Show("Sửa thành công");
                            LoadData();
                            SetNull();
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi", "Thông báo");
                        }

                    }
                    catch
                    {
                        MessageBox.Show("SDT phải nhập số", "Thông báo");
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtMaNXB.Text;
            DialogResult confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa mã NXB: " + id + " không?", "Xác nhận", MessageBoxButtons.YesNo);
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
