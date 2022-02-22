
using System;

namespace Server
{
    partial class MAIN
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
            this.textBox_ip = new System.Windows.Forms.TextBox();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_status = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.button_end = new System.Windows.Forms.Button();
            this.richTextBox_recv = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textBox_ip
            // 
            this.textBox_ip.Location = new System.Drawing.Point(129, 80);
            this.textBox_ip.Name = "textBox_ip";
            this.textBox_ip.Size = new System.Drawing.Size(147, 25);
            this.textBox_ip.TabIndex = 0;
            this.textBox_ip.TextChanged += new System.EventHandler(this.textBox_ip_TextChanged);
            // 
            // textBox_port
            // 
            this.textBox_port.Location = new System.Drawing.Point(129, 139);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(147, 25);
            this.textBox_port.TabIndex = 1;
            this.textBox_port.TextChanged += new System.EventHandler(this.textBox_port_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(35, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "服务器IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(35, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "监听端口";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(36, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "基本配置";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(333, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "服务器状态";
            // 
            // textBox_status
            // 
            this.textBox_status.Cursor = System.Windows.Forms.Cursors.No;
            this.textBox_status.Location = new System.Drawing.Point(337, 72);
            this.textBox_status.Multiline = true;
            this.textBox_status.Name = "textBox_status";
            this.textBox_status.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_status.Size = new System.Drawing.Size(407, 132);
            this.textBox_status.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(36, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "服务器操作信息";
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(148, 519);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(140, 48);
            this.button_start.TabIndex = 12;
            this.button_start.Text = "开始监听";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_end
            // 
            this.button_end.Location = new System.Drawing.Point(482, 519);
            this.button_end.Name = "button_end";
            this.button_end.Size = new System.Drawing.Size(140, 48);
            this.button_end.TabIndex = 13;
            this.button_end.Text = "结束监听";
            this.button_end.UseVisualStyleBackColor = true;
            this.button_end.Click += new System.EventHandler(this.button_end_Click);
            // 
            // richTextBox_recv
            // 
            this.richTextBox_recv.Location = new System.Drawing.Point(39, 232);
            this.richTextBox_recv.Name = "richTextBox_recv";
            this.richTextBox_recv.Size = new System.Drawing.Size(705, 249);
            this.richTextBox_recv.TabIndex = 14;
            this.richTextBox_recv.Text = "";
            this.richTextBox_recv.TextChanged += new System.EventHandler(this.richTextBox_recv_TextChanged);
            // 
            // MAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 590);
            this.Controls.Add(this.richTextBox_recv);
            this.Controls.Add(this.button_end);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_status);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.textBox_ip);
            this.Name = "MAIN";
            this.Text = "TCP Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void richTextBox_send_TextChanged(object sender, EventArgs e)
        {
        }

        private void richTextBox_recv_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox_port_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox_ip_TextChanged(object sender, EventArgs e)
        {
        }

        #endregion

        private System.Windows.Forms.TextBox textBox_ip;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_status;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_end;
        private System.Windows.Forms.RichTextBox richTextBox_recv;
    }
}

