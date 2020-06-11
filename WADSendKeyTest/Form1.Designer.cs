namespace WADSendKeyTest
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpTestResult = new System.Windows.Forms.GroupBox();
            this.ResultListView = new System.Windows.Forms.ListView();
            this.cmdStart = new System.Windows.Forms.Button();
            this.txtBox_Exception = new System.Windows.Forms.RichTextBox();
            this.grpTestSetting = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNotePad_num = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrint_num = new System.Windows.Forms.TextBox();
            this.grpTestResult.SuspendLayout();
            this.grpTestSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTestResult
            // 
            this.grpTestResult.Controls.Add(this.ResultListView);
            this.grpTestResult.Location = new System.Drawing.Point(38, 105);
            this.grpTestResult.Name = "grpTestResult";
            this.grpTestResult.Size = new System.Drawing.Size(731, 276);
            this.grpTestResult.TabIndex = 0;
            this.grpTestResult.TabStop = false;
            this.grpTestResult.Text = "Test Result";
            // 
            // ResultListView
            // 
            this.ResultListView.HideSelection = false;
            this.ResultListView.Location = new System.Drawing.Point(31, 20);
            this.ResultListView.Name = "ResultListView";
            this.ResultListView.Size = new System.Drawing.Size(666, 238);
            this.ResultListView.TabIndex = 0;
            this.ResultListView.UseCompatibleStateImageBehavior = false;
            // 
            // cmdStart
            // 
            this.cmdStart.Location = new System.Drawing.Point(664, 554);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(71, 31);
            this.cmdStart.TabIndex = 1;
            this.cmdStart.Text = "Start";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // txtBox_Exception
            // 
            this.txtBox_Exception.Location = new System.Drawing.Point(39, 397);
            this.txtBox_Exception.Name = "txtBox_Exception";
            this.txtBox_Exception.Size = new System.Drawing.Size(730, 141);
            this.txtBox_Exception.TabIndex = 2;
            this.txtBox_Exception.Text = "";
            this.txtBox_Exception.TextChanged += new System.EventHandler(this.TxtBox_Exception_TextChanged);
            // 
            // grpTestSetting
            // 
            this.grpTestSetting.Controls.Add(this.txtPrint_num);
            this.grpTestSetting.Controls.Add(this.label2);
            this.grpTestSetting.Controls.Add(this.txtNotePad_num);
            this.grpTestSetting.Controls.Add(this.label1);
            this.grpTestSetting.Location = new System.Drawing.Point(39, 25);
            this.grpTestSetting.Name = "grpTestSetting";
            this.grpTestSetting.Size = new System.Drawing.Size(730, 74);
            this.grpTestSetting.TabIndex = 3;
            this.grpTestSetting.TabStop = false;
            this.grpTestSetting.Text = "Test Setting";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Repeat Number of Notepad Running :";
            // 
            // txtNotePad_num
            // 
            this.txtNotePad_num.Location = new System.Drawing.Point(238, 29);
            this.txtNotePad_num.Name = "txtNotePad_num";
            this.txtNotePad_num.Size = new System.Drawing.Size(122, 21);
            this.txtNotePad_num.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(404, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Repeat Number of Print String :";
            // 
            // txtPrint_num
            // 
            this.txtPrint_num.Location = new System.Drawing.Point(590, 29);
            this.txtPrint_num.Name = "txtPrint_num";
            this.txtPrint_num.Size = new System.Drawing.Size(122, 21);
            this.txtPrint_num.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 609);
            this.Controls.Add(this.grpTestSetting);
            this.Controls.Add(this.txtBox_Exception);
            this.Controls.Add(this.cmdStart);
            this.Controls.Add(this.grpTestResult);
            this.Name = "Form1";
            this.Text = "SendKey Verification";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpTestResult.ResumeLayout(false);
            this.grpTestSetting.ResumeLayout(false);
            this.grpTestSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.GroupBox grpTestResult;
        public System.Windows.Forms.ListView ResultListView;
        public System.Windows.Forms.RichTextBox txtBox_Exception;
        public System.Windows.Forms.Button cmdStart;
        private System.Windows.Forms.GroupBox grpTestSetting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPrint_num;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNotePad_num;
    }
}

