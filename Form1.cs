using System;
using System.Windows.Forms;

namespace demo3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView(); // Tạo cấu trúc DataGridView
        }

        // Tạo cấu trúc DataGridView
        private void InitializeDataGridView()
        {
            // Xóa các cột cũ nếu có
            dataGridView1.Columns.Clear();

            // Thêm các cột vào DataGridView
            dataGridView1.Columns.Add("MSNV", "Mã Số Nhân Viên");
            dataGridView1.Columns.Add("TenNV", "Tên Nhân Viên");
            dataGridView1.Columns.Add("LuongCB", "Lương Cơ Bản");

            // Đặt chế độ không cho phép chỉnh sửa trực tiếp
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Chế độ chọn cả dòng
            dataGridView1.MultiSelect = false; // Không cho phép chọn nhiều dòng
        }

        // Nút Thêm
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(); // Mở Form2
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Kiểm tra dữ liệu không trống
                if (string.IsNullOrWhiteSpace(frm.MSNV) || string.IsNullOrWhiteSpace(frm.TenNV) || string.IsNullOrWhiteSpace(frm.LuongCB))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Thêm dữ liệu từ Form2 vào DataGridView
                dataGridView1.Rows.Add(frm.MSNV, frm.TenNV, frm.LuongCB);
            }
        }

        // Nút Xóa
        private void button2_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Duyệt qua tất cả các dòng được chọn
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    // Kiểm tra dòng không phải dòng mới (trống)
                    if (!row.IsNewRow)
                    {
                        // Xóa dòng
                        dataGridView1.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn dòng nào để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Nút Sửa
        private void button3_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow dongChon = dataGridView1.SelectedRows[0];

                // Kiểm tra dòng không phải là dòng mới (trống)
                if (!dongChon.IsNewRow)
                {
                    // Kiểm tra dữ liệu dòng không trống
                    if (dongChon.Cells[0].Value == null || dongChon.Cells[1].Value == null || dongChon.Cells[2].Value == null)
                    {
                        MessageBox.Show("Dòng được chọn không có dữ liệu hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Mở Form2 và truyền dữ liệu hiện tại
                    Form2 frm = new Form2
                    {
                        MSNV = dongChon.Cells[0].Value?.ToString(),
                        TenNV = dongChon.Cells[1].Value?.ToString(),
                        LuongCB = dongChon.Cells[2].Value?.ToString()
                    };

                    // Nếu người dùng xác nhận và đóng Form2
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        dongChon.Cells[0].Value = frm.MSNV;
                        dongChon.Cells[1].Value = frm.TenNV;
                        dongChon.Cells[2].Value = frm.LuongCB;
                    }
                }
                else
                {
                    MessageBox.Show("Không thể sửa dòng trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Chưa chọn dòng nào để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Nút Đóng
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form
        }
    }
}
