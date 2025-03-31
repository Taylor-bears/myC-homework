using System;
using System.Windows.Forms;
using System.Linq;

namespace 订单管理
{
    public partial class MainForm : Form
    {
        private OrderService orderService = new OrderService();
        private BindingSource orderBindingSource = new BindingSource(); // 订单列表绑定源
        private BindingSource detailsBindingSource = new BindingSource(); // 订单明细绑定源

        public MainForm()
        {
            InitializeComponent();
            SetupDataBinding();
        }

        private void SetupDataBinding()
        {
            // 数据绑定
            orderBindingSource.DataSource = orderService.GetAllOrders();
            orderGrid.DataSource = orderBindingSource; // 订单网格

            detailsBindingSource.DataSource = orderBindingSource;
            detailsBindingSource.DataMember = "Details";
            detailsGrid.DataSource = detailsBindingSource; // 明细网格

            // 这里我设计的是当选择订单网格中的某一行时，明细网格自动显示该订单的明细，刷新逻辑在下面一个
            orderGrid.SelectionChanged += OrderGrid_SelectionChanged;
        }

        private void OrderGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (orderGrid.SelectedRows.Count > 0)
            {
                detailsBindingSource.ResetBindings(false); // 刷新明细显示
            }
        }

        // 创建订单按钮
        private void CreateButton_Click(object sender, EventArgs e)
        {
            // 弹出三弹窗之一的创建弹窗
            using (var form = new CreateOrderForm(orderService))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    orderBindingSource.ResetBindings(false);
                }
            }
        }

        // 删除订单按钮
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // 弹出确认框
            if (int.TryParse(Microsoft.VisualBasic.Interaction.InputBox("请输入订单ID:", "删除订单"), out int orderId))
            {
                try
                {
                    orderService.RemoveOrder(orderId);
                    orderBindingSource.ResetBindings(false);
                    MessageBox.Show("订单删除成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // 订单操作按钮
        private void OperateButton_Click(object sender, EventArgs e)
        {
            // 弹出三弹窗之一的订单操作弹窗
            using (var form = new OrderOperationForm(orderService))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    orderBindingSource.ResetBindings(false);
                }
            }
        }

        // 查询订单按钮
        // 上一章的作业，我设记的查询依托于λ表达式，既可以ID，也可以名字，这里我简化了一下，就ID
        private void QueryButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(Microsoft.VisualBasic.Interaction.InputBox("请输入订单ID:", "查询订单"), out int orderId))
            {
                var order = orderService.QueryOrders(o => o.OrderId == orderId).FirstOrDefault(); // λ
                if (order != null)
                {
                    MessageBox.Show(order.ToString(), "订单详情"); // 直接显示该订单的所有信息
                }
                else
                {
                    MessageBox.Show("未找到该订单！");
                }
            }
        }

        private void orderGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}