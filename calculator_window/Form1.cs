using System;
using System.Windows.Forms;

namespace calculator_window
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(new string[] { "+", "-", "*", "/" });
            comboBox1.SelectedIndex = 0;//默认选择第一个运算符
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //第一个数
            if (!float.TryParse(textBox1.Text, out float firstNum))
            {
                MessageBox.Show("输入的第一个数字无效，请重新输入", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //第二个数
            if (!float.TryParse(textBox2.Text, out float doubleNum))
            {
                MessageBox.Show("输入的第二个数字无效，请重新输入", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //运算符
            char operate = comboBox1.SelectedItem.ToString()[0];

            //检查除数
            if (doubleNum == 0 && operate == '/')
            {
                MessageBox.Show("除数不能为0", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //计算
            float result = 0;
            switch (operate)
            {
                case '+':
                    result = firstNum + doubleNum;
                    break;
                case '-':
                    result = firstNum - doubleNum;
                    break;
                case '*':
                    result = firstNum * doubleNum;
                    break;
                case '/':
                    result = firstNum / doubleNum;
                    break;
            }

            label1.Text = $"{result}";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
