
namespace Chessv3._0
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnl_upper = new System.Windows.Forms.Panel();
            this.bt_hide = new System.Windows.Forms.PictureBox();
            this.bt_close = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_main = new System.Windows.Forms.Panel();
            this.restart = new System.Windows.Forms.Button();
            this.pnl_map = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pnl_upper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bt_hide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_close)).BeginInit();
            this.pnl_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_upper
            // 
            this.pnl_upper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(65)))));
            this.pnl_upper.Controls.Add(this.bt_hide);
            this.pnl_upper.Controls.Add(this.bt_close);
            this.pnl_upper.Controls.Add(this.label1);
            this.pnl_upper.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_upper.Location = new System.Drawing.Point(0, 0);
            this.pnl_upper.Name = "pnl_upper";
            this.pnl_upper.Size = new System.Drawing.Size(627, 33);
            this.pnl_upper.TabIndex = 0;
            this.pnl_upper.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnl_upper_MouseDown_1);
            this.pnl_upper.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_upper_MouseMove_1);
            // 
            // bt_hide
            // 
            this.bt_hide.Image = global::Chessv3._0.Properties.Resources.hide;
            this.bt_hide.Location = new System.Drawing.Point(573, 7);
            this.bt_hide.Name = "bt_hide";
            this.bt_hide.Size = new System.Drawing.Size(20, 20);
            this.bt_hide.TabIndex = 2;
            this.bt_hide.TabStop = false;
            this.bt_hide.Click += new System.EventHandler(this.bt_hide_Click);
            // 
            // bt_close
            // 
            this.bt_close.Image = global::Chessv3._0.Properties.Resources.close;
            this.bt_close.Location = new System.Drawing.Point(599, 7);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(20, 20);
            this.bt_close.TabIndex = 1;
            this.bt_close.TabStop = false;
            this.bt_close.Click += new System.EventHandler(this.bt_close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chess";
            // 
            // pnl_main
            // 
            this.pnl_main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(56)))), ((int)(((byte)(65)))));
            this.pnl_main.Controls.Add(this.restart);
            this.pnl_main.Controls.Add(this.pnl_map);
            this.pnl_main.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_main.Location = new System.Drawing.Point(0, 39);
            this.pnl_main.Name = "pnl_main";
            this.pnl_main.Size = new System.Drawing.Size(627, 480);
            this.pnl_main.TabIndex = 1;
            // 
            // restart
            // 
            this.restart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restart.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restart.Location = new System.Drawing.Point(521, 427);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(98, 41);
            this.restart.TabIndex = 1;
            this.restart.Text = "RESTART";
            this.restart.UseVisualStyleBackColor = true;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // pnl_map
            // 
            this.pnl_map.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(46)))), ((int)(((byte)(53)))));
            this.pnl_map.Location = new System.Drawing.Point(0, 0);
            this.pnl_map.Name = "pnl_map";
            this.pnl_map.Size = new System.Drawing.Size(480, 480);
            this.pnl_map.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(627, 519);
            this.Controls.Add(this.pnl_main);
            this.Controls.Add(this.pnl_upper);
            this.Font = new System.Drawing.Font("Nirmala UI", 8.25F);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chess";
            this.pnl_upper.ResumeLayout(false);
            this.pnl_upper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bt_hide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_close)).EndInit();
            this.pnl_main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_upper;
        private System.Windows.Forms.Panel pnl_main;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox bt_hide;
        private System.Windows.Forms.PictureBox bt_close;
        private System.Windows.Forms.Panel pnl_map;
        private System.Windows.Forms.Button restart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}

