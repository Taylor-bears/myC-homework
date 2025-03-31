namespace 订单管理
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            orderGrid = new DataGridView();
            detailsGrid = new DataGridView();
            buttonPanel = new FlowLayoutPanel();
            createButton = new Button();
            deleteButton = new Button();
            operateButton = new Button();
            queryButton = new Button();
            ((System.ComponentModel.ISupportInitialize)orderGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)detailsGrid).BeginInit();
            buttonPanel.SuspendLayout();
            SuspendLayout();
            // 
            // orderGrid
            // 
            orderGrid.ColumnHeadersHeight = 46;
            orderGrid.Dock = DockStyle.Top;
            orderGrid.Location = new Point(0, 0);
            orderGrid.Margin = new Padding(7, 8, 7, 8);
            orderGrid.Name = "orderGrid";
            orderGrid.ReadOnly = true;
            orderGrid.RowHeadersWidth = 82;
            orderGrid.Size = new Size(1829, 752);
            orderGrid.TabIndex = 0;
            orderGrid.CellContentClick += orderGrid_CellContentClick;
            // 
            // detailsGrid
            // 
            detailsGrid.ColumnHeadersHeight = 46;
            detailsGrid.Dock = DockStyle.Fill;
            detailsGrid.Location = new Point(0, 752);
            detailsGrid.Margin = new Padding(7, 8, 7, 8);
            detailsGrid.Name = "detailsGrid";
            detailsGrid.ReadOnly = true;
            detailsGrid.RowHeadersWidth = 82;
            detailsGrid.Size = new Size(1479, 697);
            detailsGrid.TabIndex = 1;
            // 
            // buttonPanel
            // 
            buttonPanel.Controls.Add(createButton);
            buttonPanel.Controls.Add(deleteButton);
            buttonPanel.Controls.Add(operateButton);
            buttonPanel.Controls.Add(queryButton);
            buttonPanel.Dock = DockStyle.Right;
            buttonPanel.FlowDirection = FlowDirection.TopDown;
            buttonPanel.Location = new Point(1479, 752);
            buttonPanel.Margin = new Padding(7, 8, 7, 8);
            buttonPanel.Name = "buttonPanel";
            buttonPanel.Padding = new Padding(12, 13, 12, 13);
            buttonPanel.Size = new Size(350, 697);
            buttonPanel.TabIndex = 2;
            // 
            // createButton
            // 
            createButton.Location = new Point(19, 21);
            createButton.Margin = new Padding(7, 8, 7, 8);
            createButton.Name = "createButton";
            createButton.Size = new Size(280, 59);
            createButton.TabIndex = 0;
            createButton.Text = "创建订单";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += CreateButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(19, 96);
            deleteButton.Margin = new Padding(7, 8, 7, 8);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(280, 59);
            deleteButton.TabIndex = 1;
            deleteButton.Text = "删除订单";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += DeleteButton_Click;
            // 
            // operateButton
            // 
            operateButton.Location = new Point(19, 171);
            operateButton.Margin = new Padding(7, 8, 7, 8);
            operateButton.Name = "operateButton";
            operateButton.Size = new Size(280, 59);
            operateButton.TabIndex = 2;
            operateButton.Text = "订单操作";
            operateButton.UseVisualStyleBackColor = true;
            operateButton.Click += OperateButton_Click;
            // 
            // queryButton
            // 
            queryButton.Location = new Point(19, 246);
            queryButton.Margin = new Padding(7, 8, 7, 8);
            queryButton.Name = "queryButton";
            queryButton.Size = new Size(280, 59);
            queryButton.TabIndex = 3;
            queryButton.Text = "查询订单";
            queryButton.UseVisualStyleBackColor = true;
            queryButton.Click += QueryButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1829, 1449);
            Controls.Add(detailsGrid);
            Controls.Add(buttonPanel);
            Controls.Add(orderGrid);
            Margin = new Padding(7, 8, 7, 8);
            Name = "MainForm";
            Text = "订单管理系统";
            ((System.ComponentModel.ISupportInitialize)orderGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)detailsGrid).EndInit();
            buttonPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView orderGrid;
        private System.Windows.Forms.DataGridView detailsGrid;
        private System.Windows.Forms.FlowLayoutPanel buttonPanel;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button operateButton;
        private System.Windows.Forms.Button queryButton;
    }
}