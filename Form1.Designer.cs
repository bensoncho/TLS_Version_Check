namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblAPIUrl = new System.Windows.Forms.Label();
            this.tbxAPIUrl = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.tbxResult = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.cbxTLSVersion = new System.Windows.Forms.ComboBox();
            this.tbxProtocol = new System.Windows.Forms.Label();
            this.lblTLSVersion = new System.Windows.Forms.Label();
            this.lblNetVersion = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAPIUrl
            // 
            this.lblAPIUrl.AutoSize = true;
            this.lblAPIUrl.Location = new System.Drawing.Point(12, 9);
            this.lblAPIUrl.Name = "lblAPIUrl";
            this.lblAPIUrl.Size = new System.Drawing.Size(47, 12);
            this.lblAPIUrl.TabIndex = 0;
            this.lblAPIUrl.Text = "API位置";
            // 
            // tbxAPIUrl
            // 
            this.tbxAPIUrl.Location = new System.Drawing.Point(65, 6);
            this.tbxAPIUrl.Name = "tbxAPIUrl";
            this.tbxAPIUrl.Size = new System.Drawing.Size(746, 22);
            this.tbxAPIUrl.TabIndex = 1;
            this.tbxAPIUrl.Text = "https://api.telegram.org/";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(817, 6);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // tbxResult
            // 
            this.tbxResult.Location = new System.Drawing.Point(65, 62);
            this.tbxResult.Multiline = true;
            this.tbxResult.Name = "tbxResult";
            this.tbxResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbxResult.Size = new System.Drawing.Size(746, 303);
            this.tbxResult.TabIndex = 3;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(12, 65);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(34, 12);
            this.lblResult.TabIndex = 4;
            this.lblResult.Text = "Result";
            // 
            // cbxTLSVersion
            // 
            this.cbxTLSVersion.FormattingEnabled = true;
            this.cbxTLSVersion.Items.AddRange(new object[] {
            "Default",
            "TLS1.1",
            "TLS1.2",
            "SSL3/TLS1.0/TLS1.1/TLS1.2"});
            this.cbxTLSVersion.Location = new System.Drawing.Point(65, 34);
            this.cbxTLSVersion.Name = "cbxTLSVersion";
            this.cbxTLSVersion.Size = new System.Drawing.Size(278, 20);
            this.cbxTLSVersion.TabIndex = 5;
            this.cbxTLSVersion.Text = "Default";
            // 
            // tbxProtocol
            // 
            this.tbxProtocol.AutoSize = true;
            this.tbxProtocol.Location = new System.Drawing.Point(12, 37);
            this.tbxProtocol.Name = "tbxProtocol";
            this.tbxProtocol.Size = new System.Drawing.Size(44, 12);
            this.tbxProtocol.TabIndex = 6;
            this.tbxProtocol.Text = "Protocol";
            // 
            // lblTLSVersion
            // 
            this.lblTLSVersion.AutoSize = true;
            this.lblTLSVersion.Location = new System.Drawing.Point(63, 378);
            this.lblTLSVersion.Name = "lblTLSVersion";
            this.lblTLSVersion.Size = new System.Drawing.Size(141, 12);
            this.lblTLSVersion.TabIndex = 7;
            this.lblTLSVersion.Text = "Client Support TLS Version: ";
            // 
            // lblNetVersion
            // 
            this.lblNetVersion.AutoSize = true;
            this.lblNetVersion.Location = new System.Drawing.Point(63, 401);
            this.lblNetVersion.Name = "lblNetVersion";
            this.lblNetVersion.Size = new System.Drawing.Size(125, 12);
            this.lblNetVersion.TabIndex = 8;
            this.lblNetVersion.Text = ".Net FrameWork Version:";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(63, 426);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(758, 36);
            this.lblDesc.TabIndex = 9;
            this.lblDesc.Text = resources.GetString("lblDesc.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 475);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblNetVersion);
            this.Controls.Add(this.lblTLSVersion);
            this.Controls.Add(this.tbxProtocol);
            this.Controls.Add(this.cbxTLSVersion);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.tbxResult);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.tbxAPIUrl);
            this.Controls.Add(this.lblAPIUrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "TLS Checker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAPIUrl;
        private System.Windows.Forms.TextBox tbxAPIUrl;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox tbxResult;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ComboBox cbxTLSVersion;
        private System.Windows.Forms.Label tbxProtocol;
        private System.Windows.Forms.Label lblTLSVersion;
        private System.Windows.Forms.Label lblNetVersion;
        private System.Windows.Forms.Label lblDesc;
    }
}

