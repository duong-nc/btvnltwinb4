using System;
using System.Windows.Forms;

namespace demo3
{
    public partial class Form2 : Form
    {
        public string MSNV { get; set; }
        public string TenNV { get; set; }
        public string LuongCB { get; set; }

        public Form2()
        {
            InitializeComponent();
        }

        // Nút Đồng ý (Thêm hoặc Cập nhật)
        private void btn_DongY_Click(object sender, EventArgs e)
        {
            // Kiểm tra giá trị không được để trống
            if (string.IsNullOrWhiteSpace(txtMSNV.Text) ||
                string.IsNullOrWhiteSpace(txtTenNV.Text) ||
                string.IsNullOrWhiteSpace(txtLuongCB.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra Lương cơ bản là số
            if (!decimal.TryParse(txtLuongCB.Text, out _))
            {
                MessageBox.Show("Lương cơ bản phải là một số hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lưu dữ liệu
            MSNV = txtMSNV.Text.Trim();
            TenNV = txtTenNV.Text.Trim();
            LuongCB = txtLuongCB.Text.Trim();

            // Đặt kết quả và đóng form
            this.DialogResult = DialogResult.OK; // Trả về OK
            this.Close();
        }

        // Nút Bỏ qua (Hủy bỏ)
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Trả về Cancel
            this.Close();
        }

        // Khi form được tải
        private void Form2_Load(object sender, EventArgs e)
        {
            // Gán dữ liệu cũ vào các ô nhập liệu (nếu có)
            txtMSNV.Text = MSNV;
            txtTenNV.Text = TenNV;
            txtLuongCB.Text = LuongCB;
        }
    }
}
