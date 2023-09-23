namespace CrmWinForm
{
    partial class ModelForm
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
            StartButton = new Button();
            StopButton = new Button();
            process1 = new System.Diagnostics.Process();
            CustomerSpeedValue = new NumericUpDown();
            CashDeskSpeedValue = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)CustomerSpeedValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CashDeskSpeedValue).BeginInit();
            SuspendLayout();
            // 
            // StartButton
            // 
            StartButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            StartButton.Location = new Point(713, 415);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(75, 23);
            StartButton.TabIndex = 0;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // StopButton
            // 
            StopButton.Location = new Point(632, 415);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(75, 23);
            StopButton.TabIndex = 1;
            StopButton.Text = "Stop";
            StopButton.UseVisualStyleBackColor = true;
            StopButton.Click += StopButton_Click;
            // 
            // process1
            // 
            process1.StartInfo.Domain = "";
            process1.StartInfo.LoadUserProfile = false;
            process1.StartInfo.Password = null;
            process1.StartInfo.StandardErrorEncoding = null;
            process1.StartInfo.StandardInputEncoding = null;
            process1.StartInfo.StandardOutputEncoding = null;
            process1.StartInfo.UserName = "";
            process1.SynchronizingObject = this;
            // 
            // CustomerSpeedValue
            // 
            CustomerSpeedValue.Location = new Point(668, 12);
            CustomerSpeedValue.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            CustomerSpeedValue.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            CustomerSpeedValue.Name = "CustomerSpeedValue";
            CustomerSpeedValue.Size = new Size(120, 23);
            CustomerSpeedValue.TabIndex = 2;
            CustomerSpeedValue.Value = new decimal(new int[] { 10, 0, 0, 0 });
            CustomerSpeedValue.ValueChanged += CustomerSpeedValue_ValueChanged;
            // 
            // CashDeskSpeedValue
            // 
            CashDeskSpeedValue.Location = new Point(668, 41);
            CashDeskSpeedValue.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            CashDeskSpeedValue.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            CashDeskSpeedValue.Name = "CashDeskSpeedValue";
            CashDeskSpeedValue.Size = new Size(120, 23);
            CashDeskSpeedValue.TabIndex = 3;
            CashDeskSpeedValue.Value = new decimal(new int[] { 10, 0, 0, 0 });
            CashDeskSpeedValue.ValueChanged += CashDeskSpeedValue_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(571, 14);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 4;
            label1.Text = "CustomerSpeed";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(572, 41);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 5;
            label2.Text = "CashDeskSpeed";
            // 
            // ModelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(CashDeskSpeedValue);
            Controls.Add(CustomerSpeedValue);
            Controls.Add(StopButton);
            Controls.Add(StartButton);
            Name = "ModelForm";
            Text = "ModelForm";
            FormClosing += ModelForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)CustomerSpeedValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)CashDeskSpeedValue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button StartButton;
        private Button StopButton;
        private System.Diagnostics.Process process1;
        private Label label2;
        private Label label1;
        private NumericUpDown CashDeskSpeedValue;
        private NumericUpDown CustomerSpeedValue;
    }
}