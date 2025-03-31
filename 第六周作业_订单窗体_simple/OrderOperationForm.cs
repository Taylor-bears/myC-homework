using System;
using System.Windows.Forms;

namespace 订单管理
{
    public partial class OrderOperationForm : Form
    {
        private OrderService orderService;

        // 我们的订单操作都是基于Order里的OrderService方法的
        public OrderOperationForm(OrderService service)
        {
            orderService = service;
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            operationComboBox.SelectedIndex = 0; // 默认选择第一个操作
            operationComboBox.SelectedIndexChanged += OperationComboBox_SelectedIndexChanged; // 绑定事件，在下面一个
            okButton.Click += OkButton_Click;
            cancelButton.Click += (s, e) => this.Close();
            UpdateInputFields();
        }

        // 根据选择的操作类型要实时调整输入字段的状态
        private void OperationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateInputFields();
        }

        // 我设计的删除只依靠name，而其他两个操作可以针对三个属性
        private void UpdateInputFields()
        {
            var operation = operationComboBox.SelectedItem.ToString();
            quantityTextBox.Enabled = operation != "删除明细";
            priceTextBox.Enabled = operation != "删除明细";
        }

        // 下面的明细操作都依托于ID
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(idTextBox.Text, out int orderId))
            {
                MessageBox.Show("请输入有效的订单ID！");
                return;
            }

            var order = orderService.GetAllOrders().FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                MessageBox.Show("订单不存在！");
                return;
            }

            try
            {
                switch (operationComboBox.SelectedItem.ToString())
                {
                    case "添加明细":
                        if (string.IsNullOrWhiteSpace(productTextBox.Text) || !int.TryParse(quantityTextBox.Text, out int qty) || !decimal.TryParse(priceTextBox.Text, out decimal price))
                        {
                            MessageBox.Show("请输入有效的产品名、数量和价格！");
                            return;
                        }
                        orderService.AddOrderDetail(orderId, new OrderDetails { ProductName = productTextBox.Text, Quantity = qty, Price = price });
                        break;

                    case "删除明细":
                        if (string.IsNullOrWhiteSpace(productTextBox.Text))
                        {
                            MessageBox.Show("请输入产品名！");
                            return;
                        }
                        orderService.RemoveOrderDetail(orderId, productTextBox.Text);
                        break;

                    case "修改明细":
                        if (string.IsNullOrWhiteSpace(productTextBox.Text) || !int.TryParse(quantityTextBox.Text, out qty) || !decimal.TryParse(priceTextBox.Text, out price))
                        {
                            MessageBox.Show("请输入有效的产品名、数量和价格！");
                            return;
                        }
                        orderService.ModifyOrderDetail(orderId, productTextBox.Text, d => { d.Quantity = qty; d.Price = price; });
                        break;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}