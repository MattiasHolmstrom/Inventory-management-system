namespace OOP2projekt
{
    partial class Form3
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ViewPendingBTN = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.ViewDispatchedBTN = new System.Windows.Forms.Button();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 35);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(683, 251);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(12, 300);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(683, 264);
            this.listBox2.TabIndex = 1;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pending orders";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Dispatched orders";
            // 
            // ViewPendingBTN
            // 
            this.ViewPendingBTN.Location = new System.Drawing.Point(701, 51);
            this.ViewPendingBTN.Name = "ViewPendingBTN";
            this.ViewPendingBTN.Size = new System.Drawing.Size(176, 53);
            this.ViewPendingBTN.TabIndex = 4;
            this.ViewPendingBTN.Text = "View products/customer";
            this.ViewPendingBTN.UseVisualStyleBackColor = true;
            this.ViewPendingBTN.Click += new System.EventHandler(this.ViewPendingBTN_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(698, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Select order to view products and customer info\r\n";
            // 
            // ViewDispatchedBTN
            // 
            this.ViewDispatchedBTN.Location = new System.Drawing.Point(701, 314);
            this.ViewDispatchedBTN.Name = "ViewDispatchedBTN";
            this.ViewDispatchedBTN.Size = new System.Drawing.Size(176, 51);
            this.ViewDispatchedBTN.TabIndex = 6;
            this.ViewDispatchedBTN.Text = "View dispatched products";
            this.ViewDispatchedBTN.UseVisualStyleBackColor = true;
            this.ViewDispatchedBTN.Click += new System.EventHandler(this.ViewDispatchedBTN_Click);
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(701, 110);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(358, 82);
            this.listBox3.TabIndex = 7;
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            this.listBox4.Location = new System.Drawing.Point(701, 371);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(274, 186);
            this.listBox4.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(701, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 88);
            this.button1.TabIndex = 9;
            this.button1.Text = "Dispatch order";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 580);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox4);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.ViewDispatchedBTN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ViewPendingBTN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ViewPendingBTN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ViewDispatchedBTN;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.Button button1;
    }
}