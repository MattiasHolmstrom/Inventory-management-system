namespace OOP2projekt
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.newCustbutton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.orderForm = new System.Windows.Forms.Button();
            this.pendingBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(265, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 84);
            this.button1.TabIndex = 0;
            this.button1.Text = "Edit/Add Products";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // newCustbutton
            // 
            this.newCustbutton.Location = new System.Drawing.Point(265, 26);
            this.newCustbutton.Name = "newCustbutton";
            this.newCustbutton.Size = new System.Drawing.Size(174, 63);
            this.newCustbutton.TabIndex = 2;
            this.newCustbutton.Text = "New customer/Edit customer data";
            this.newCustbutton.UseVisualStyleBackColor = true;
            this.newCustbutton.Click += new System.EventHandler(this.newCustbutton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(25, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(192, 58);
            this.button2.TabIndex = 7;
            this.button2.Text = "Submit order file";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // orderForm
            // 
            this.orderForm.Location = new System.Drawing.Point(25, 92);
            this.orderForm.Name = "orderForm";
            this.orderForm.Size = new System.Drawing.Size(192, 87);
            this.orderForm.TabIndex = 13;
            this.orderForm.Text = "Create order";
            this.orderForm.UseVisualStyleBackColor = true;
            this.orderForm.Click += new System.EventHandler(this.orderForm_Click);
            // 
            // pendingBTN
            // 
            this.pendingBTN.Location = new System.Drawing.Point(468, 26);
            this.pendingBTN.Name = "pendingBTN";
            this.pendingBTN.Size = new System.Drawing.Size(162, 63);
            this.pendingBTN.TabIndex = 14;
            this.pendingBTN.Text = "Pending/Dispatched Orders";
            this.pendingBTN.UseVisualStyleBackColor = true;
            this.pendingBTN.Click += new System.EventHandler(this.pendingBTN_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 250);
            this.Controls.Add(this.pendingBTN);
            this.Controls.Add(this.orderForm);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.newCustbutton);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button newCustbutton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button orderForm;
        private System.Windows.Forms.Button pendingBTN;
    }
}

