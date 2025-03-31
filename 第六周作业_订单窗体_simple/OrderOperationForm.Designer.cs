namespace 订单管理
{
    partial class OrderOperationForm
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
            this.idLabel = new System.Windows.Forms.Label();
            this.idTextBox = new System.Windows.Forms.TextBox();
            this.operationLabel = new System.Windows.Forms.Label();
            this.operationComboBox = new System.Windows.Forms.ComboBox();
            this.productLabel = new System.Windows.Forms.Label();
            this.productTextBox = new System.Windows.Forms.TextBox();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.priceLabel = new System.Windows.Forms.Label();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Location = new System.Drawing.Point(20, 20);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(47, 12);
            this.idLabel.TabIndex = 0;
            this.idLabel.Text = "订单ID:";
            // 
            // idTextBox
            // 
            this.idTextBox.Location = new System.Drawing.Point(100, 20);
            this.idTextBox.Name = "idTextBox";
            this.idTextBox.Size = new System.Drawing.Size(150, 21);
            this.idTextBox.TabIndex = 1;
            // 
            // operationLabel
            // 
            this.operationLabel.AutoSize = true;
            this.operationLabel.Location = new System.Drawing.Point(20, 60);
            this.operationLabel.Name = "operationLabel";
            this.operationLabel.Size = new System.Drawing.Size(59, 12);
            this.operationLabel.TabIndex = 2;
            this.operationLabel.Text = "操作类型:";
            // 
            // operationComboBox
            // 
            this.operationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operationComboBox.FormattingEnabled = true;
            this.operationComboBox.Items.AddRange(new object[] {
            "添加明细",
            "删除明细",
            "修改明细"});
            this.operationComboBox.Location = new System.Drawing.Point(100, 60);
            this.operationComboBox.Name = "operationComboBox";
            this.operationComboBox.Size = new System.Drawing.Size(150, 20);
            this.operationComboBox.TabIndex = 3;
            // 
            // productLabel
            // 
            this.productLabel.AutoSize = true;
            this.productLabel.Location = new System.Drawing.Point(20, 100);
            this.productLabel.Name = "productLabel";
            this.productLabel.Size = new System.Drawing.Size(47, 12);
            this.productLabel.TabIndex = 4;
            this.productLabel.Text = "产品名:";
            // 
            // productTextBox
            // 
            this.productTextBox.Location = new System.Drawing.Point(100, 100);
            this.productTextBox.Name = "productTextBox";
            this.productTextBox.Size = new System.Drawing.Size(150, 21);
            this.productTextBox.TabIndex = 5;
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(20, 140);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(35, 12);
            this.quantityLabel.TabIndex = 6;
            this.quantityLabel.Text = "数量:";
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(100, 140);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(150, 21);
            this.quantityTextBox.TabIndex = 7;
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(20, 180);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(35, 12);
            this.priceLabel.TabIndex = 8;
            this.priceLabel.Text = "价格:";
            // 
            // priceTextBox
            // 
            this.priceTextBox.Location = new System.Drawing.Point(100, 180);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(150, 21);
            this.priceTextBox.TabIndex = 9;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(100, 220);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(70, 23);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(180, 220);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(70, 23);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // OrderOperationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.quantityTextBox);
            this.Controls.Add(this.quantityLabel);
            this.Controls.Add(this.productTextBox);
            this.Controls.Add(this.productLabel);
            this.Controls.Add(this.operationComboBox);
            this.Controls.Add(this.operationLabel);
            this.Controls.Add(this.idTextBox);
            this.Controls.Add(this.idLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "OrderOperationForm";
            this.Text = "订单操作";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.TextBox idTextBox;
        private System.Windows.Forms.Label operationLabel;
        private System.Windows.Forms.ComboBox operationComboBox;
        private System.Windows.Forms.Label productLabel;
        private System.Windows.Forms.TextBox productTextBox;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}