using System;
using System.Windows.Forms;

namespace 订单管理
{
    public partial class CreateOrderForm : Form
    {
        private OrderService orderService;

        public CreateOrderForm(OrderService service)
        {
            orderService = service;
            InitializeComponent(); 
            SetupUI();
        }

        private void SetupUI()
        {
            // 绑定事件
            okButton.Click += (s, e) =>
            {
                if (int.TryParse(idTextBox.Text, out int id) && !string.IsNullOrWhiteSpace(customerTextBox.Text))
                {
                    try
                    {
                        // 根据内容创建，我们在MainForm中绑定了，到时候可以及时的显示
                        orderService.AddOrder(new Order { OrderId = id, Customer = customerTextBox.Text });
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("请输入有效的订单ID和客户名！");
                }
            };
            cancelButton.Click += (s, e) => this.Close();
        }
    }
}