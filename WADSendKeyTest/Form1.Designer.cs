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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.grpTestResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpTestResult
            // 
            this.grpTestResult.Controls.Add(this.ResultListView);
            this.grpTestResult.Location = new System.Drawing.Point(37, 36);
            this.grpTestResult.Name = "grpTestResult";
            this.grpTestResult.Size = new System.Drawing.Size(707, 289);
            this.grpTestResult.TabIndex = 0;
            this.grpTestResult.TabStop = false;
            this.grpTestResult.Text = "Test Result";
            // 
            // ResultListView
            // 
            this.ResultListView.HideSelection = false;
            this.ResultListView.Location = new System.Drawing.Point(21, 33);
            this.ResultListView.Name = "ResultListView";
            this.ResultListView.Size = new System.Drawing.Size(666, 238);
            this.ResultListView.TabIndex = 0;
            this.ResultListView.UseCompatibleStateImageBehavior = false;
            // 
            // cmdStart
            // 
            this.cmdStart.Location = new System.Drawing.Point(673, 487);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(71, 31);
            this.cmdStart.TabIndex = 1;
            this.cmdStart.Text = "Start";
            this.cmdStart.UseVisualStyleBackColor = true;
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(38, 341);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(706, 140);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 530);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.cmdStart);
            this.Controls.Add(this.grpTestResult);
            this.Name = "Form1";
            this.Text = "SendKey Verification";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpTestResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.GroupBox grpTestResult;
        public System.Windows.Forms.ListView ResultListView;
        public System.Windows.Forms.RichTextBox richTextBox1;
        public System.Windows.Forms.Button cmdStart;
    }
}

