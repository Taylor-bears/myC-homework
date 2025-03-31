namespace 订单管理
{
    partial class CreateOrderForm
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
            idLabel = new Label();
            idTextBox = new TextBox();
            customerLabel = new Label();
            customerTextBox = new TextBox();
            okButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(71, 52);
            idLabel.Margin = new Padding(7, 0, 7, 0);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(93, 31);
            idLabel.TabIndex = 0;
            idLabel.Text = "订单ID:";
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(221, 52);
            idTextBox.Margin = new Padding(7, 8, 7, 8);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new Size(345, 38);
            idTextBox.TabIndex = 1;
            // 
            // customerLabel
            // 
            customerLabel.AutoSize = true;
            customerLabel.Location = new Point(71, 155);
            customerLabel.Margin = new Padding(7, 0, 7, 0);
            customerLabel.Name = "customerLabel";
            customerLabel.Size = new Size(92, 31);
            customerLabel.TabIndex = 2;
            customerLabel.Text = "客户名:";
            // 
            // customerTextBox
            // 
            customerTextBox.Location = new Point(221, 155);
            customerTextBox.Margin = new Padding(7, 8, 7, 8);
            customerTextBox.Name = "customerTextBox";
            customerTextBox.Size = new Size(345, 38);
            customerTextBox.TabIndex = 3;
            // 
            // okButton
            // 
            okButton.Location = new Point(141, 258);
            okButton.Margin = new Padding(7, 8, 7, 8);
            okButton.Name = "okButton";
            okButton.Size = new Size(163, 59);
            okButton.TabIndex = 4;
            okButton.Text = "确定";
            okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.Location = new Point(372, 258);
            cancelButton.Margin = new Padding(7, 8, 7, 8);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(163, 59);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "取消";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // CreateOrderForm
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(663, 407);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(customerTextBox);
            Controls.Add(customerLabel);
            Controls.Add(idTextBox);
            Controls.Add(idLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(7, 8, 7, 8);
            MaximizeBox = false;
            Name = "CreateOrderForm";
            Text = "创建订单";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label customerLabel;
        private System.Windows.Forms.TextBox customerTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}