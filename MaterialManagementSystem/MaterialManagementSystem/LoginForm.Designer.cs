namespace MaterialManagementSystem
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LoginEmpPassword_txt = new System.Windows.Forms.TextBox();
            this.LoginEmpID_txt = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.loginidword_lab = new System.Windows.Forms.Label();
            this.loginpwword_lab = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(95, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(242, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // LoginEmpPassword_txt
            // 
            this.LoginEmpPassword_txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LoginEmpPassword_txt.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LoginEmpPassword_txt.ForeColor = System.Drawing.Color.Gray;
            this.LoginEmpPassword_txt.Location = new System.Drawing.Point(95, 247);
            this.LoginEmpPassword_txt.MaxLength = 10;
            this.LoginEmpPassword_txt.Name = "LoginEmpPassword_txt";
            this.LoginEmpPassword_txt.PasswordChar = '●';
            this.LoginEmpPassword_txt.Size = new System.Drawing.Size(242, 26);
            this.LoginEmpPassword_txt.TabIndex = 5;
            this.LoginEmpPassword_txt.TextChanged += new System.EventHandler(this.LoginEmpPassword_txt_TextChanged);
            // 
            // LoginEmpID_txt
            // 
            this.LoginEmpID_txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LoginEmpID_txt.Font = new System.Drawing.Font("Microsoft JhengHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.LoginEmpID_txt.ForeColor = System.Drawing.Color.Gray;
            this.LoginEmpID_txt.Location = new System.Drawing.Point(95, 219);
            this.LoginEmpID_txt.MaxLength = 10;
            this.LoginEmpID_txt.Name = "LoginEmpID_txt";
            this.LoginEmpID_txt.Size = new System.Drawing.Size(242, 26);
            this.LoginEmpID_txt.TabIndex = 4;
            this.LoginEmpID_txt.TextChanged += new System.EventHandler(this.LoginEmpID_txt_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(95, 279);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(242, 35);
            this.button1.TabIndex = 8;
            this.button1.Text = "登入";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // loginidword_lab
            // 
            this.loginidword_lab.AutoSize = true;
            this.loginidword_lab.BackColor = System.Drawing.Color.White;
            this.loginidword_lab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginidword_lab.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.loginidword_lab.ForeColor = System.Drawing.Color.Gray;
            this.loginidword_lab.Location = new System.Drawing.Point(97, 222);
            this.loginidword_lab.Name = "loginidword_lab";
            this.loginidword_lab.Size = new System.Drawing.Size(41, 20);
            this.loginidword_lab.TabIndex = 9;
            this.loginidword_lab.Text = "工號";
            // 
            // loginpwword_lab
            // 
            this.loginpwword_lab.AutoSize = true;
            this.loginpwword_lab.BackColor = System.Drawing.Color.White;
            this.loginpwword_lab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginpwword_lab.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.loginpwword_lab.ForeColor = System.Drawing.Color.Gray;
            this.loginpwword_lab.Location = new System.Drawing.Point(97, 250);
            this.loginpwword_lab.Name = "loginpwword_lab";
            this.loginpwword_lab.Size = new System.Drawing.Size(41, 20);
            this.loginpwword_lab.TabIndex = 10;
            this.loginpwword_lab.Text = "密碼";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.ClientSize = new System.Drawing.Size(418, 477);
            this.Controls.Add(this.loginpwword_lab);
            this.Controls.Add(this.loginidword_lab);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LoginEmpPassword_txt);
            this.Controls.Add(this.LoginEmpID_txt);
            this.Name = "LoginForm";
            this.Text = "PROTEKMMS";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox LoginEmpPassword_txt;
        private System.Windows.Forms.TextBox LoginEmpID_txt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label loginidword_lab;
        private System.Windows.Forms.Label loginpwword_lab;
    }
}