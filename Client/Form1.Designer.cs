
namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_online = new System.Windows.Forms.Button();
            this.button_send = new System.Windows.Forms.Button();
            this.button_break = new System.Windows.Forms.Button();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.richTextBox_recv = new System.Windows.Forms.RichTextBox();
            this.richTextBox_send = new System.Windows.Forms.RichTextBox();
            this.statusBarPanel = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.status_label = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Person = new System.Windows.Forms.TextBox();
            this.button_connect = new System.Windows.Forms.Button();
            this.statusBarPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_online
            // 
            this.button_online.Location = new System.Drawing.Point(29, 388);
            this.button_online.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_online.Name = "button_online";
            this.button_online.Size = new System.Drawing.Size(84, 42);
            this.button_online.TabIndex = 0;
            this.button_online.Text = "上线";
            this.button_online.UseVisualStyleBackColor = true;
            this.button_online.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_send
            // 
            this.button_send.Location = new System.Drawing.Point(473, 388);
            this.button_send.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_send.Name = "button_send";
            this.button_send.Size = new System.Drawing.Size(140, 42);
            this.button_send.TabIndex = 1;
            this.button_send.Text = "发送消息";
            this.button_send.UseVisualStyleBackColor = true;
            this.button_send.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_break
            // 
            this.button_break.Location = new System.Drawing.Point(210, 388);
            this.button_break.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_break.Name = "button_break";
            this.button_break.Size = new System.Drawing.Size(85, 42);
            this.button_break.TabIndex = 2;
            this.button_break.Text = "断开连接";
            this.button_break.UseVisualStyleBackColor = true;
            this.button_break.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(428, 56);
            this.textBox_port.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(185, 25);
            this.textBox_port.TabIndex = 3;
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(128, 20);
            this.textBox_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(176, 25);
            this.textBox_name.TabIndex = 4;
            // 
            // richTextBox_recv
            // 
            this.richTextBox_recv.Location = new System.Drawing.Point(29, 124);
            this.richTextBox_recv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox_recv.Name = "richTextBox_recv";
            this.richTextBox_recv.Size = new System.Drawing.Size(584, 136);
            this.richTextBox_recv.TabIndex = 5;
            this.richTextBox_recv.Text = "";
            // 
            // richTextBox_send
            // 
            this.richTextBox_send.Location = new System.Drawing.Point(29, 294);
            this.richTextBox_send.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox_send.Name = "richTextBox_send";
            this.richTextBox_send.Size = new System.Drawing.Size(584, 71);
            this.richTextBox_send.TabIndex = 6;
            this.richTextBox_send.Text = "";
            // 
            // statusBarPanel
            // 
            this.statusBarPanel.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusBarPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.status_label});
            this.statusBarPanel.Location = new System.Drawing.Point(0, 451);
            this.statusBarPanel.Name = "statusBarPanel";
            this.statusBarPanel.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusBarPanel.Size = new System.Drawing.Size(648, 26);
            this.statusBarPanel.TabIndex = 7;
            this.statusBarPanel.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 20);
            // 
            // status_label
            // 
            this.status_label.Name = "status_label";
            this.status_label.Size = new System.Drawing.Size(13, 20);
            this.status_label.Text = " ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(333, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "端口 ：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "服务器IP：";
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(428, 20);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(185, 25);
            this.textBox_ip.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "聊天框：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 277);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "发送信息：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "我的昵称：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "联系人昵称：";
            // 
            // textBox_Person
            // 
            this.textBox_Person.Location = new System.Drawing.Point(128, 56);
            this.textBox_Person.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox_Person.Name = "textBox_Person";
            this.textBox_Person.Size = new System.Drawing.Size(176, 25);
            this.textBox_Person.TabIndex = 15;
            // 
            // button_connect
            // 
            this.button_connect.Location = new System.Drawing.Point(119, 388);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(85, 42);
            this.button_connect.TabIndex = 16;
            this.button_connect.Text = "建立连接";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 477);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.textBox_Person);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_ip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusBarPanel);
            this.Controls.Add(this.richTextBox_send);
            this.Controls.Add(this.richTextBox_recv);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.button_break);
            this.Controls.Add(this.button_send);
            this.Controls.Add(this.button_online);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "TcpClient";
            this.statusBarPanel.ResumeLayout(false);
            this.statusBarPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.Button button1;
        //private System.Windows.Forms.Button button2;
        //private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.RichTextBox richTextBox_recv;
        private System.Windows.Forms.RichTextBox richTextBox_send;
        private System.Windows.Forms.StatusStrip statusBarPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel status_label;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Person;
        private System.Windows.Forms.Button button_connect;
    }
}

