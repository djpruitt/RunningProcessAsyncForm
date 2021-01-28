
namespace ProcessBackground
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
            this.buttonRunProcessAsync = new System.Windows.Forms.Button();
            this.textOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonRunProcessAsync
            // 
            this.buttonRunProcessAsync.Location = new System.Drawing.Point(81, 23);
            this.buttonRunProcessAsync.Name = "buttonRunProcessAsync";
            this.buttonRunProcessAsync.Size = new System.Drawing.Size(133, 86);
            this.buttonRunProcessAsync.TabIndex = 0;
            this.buttonRunProcessAsync.Text = "Run Process Async";
            this.buttonRunProcessAsync.UseVisualStyleBackColor = true;
            this.buttonRunProcessAsync.Click += new System.EventHandler(this.RunProcessAsync_Click);
            // 
            // textOutput
            // 
            this.textOutput.Location = new System.Drawing.Point(81, 139);
            this.textOutput.Multiline = true;
            this.textOutput.Name = "textOutput";
            this.textOutput.Size = new System.Drawing.Size(596, 255);
            this.textOutput.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textOutput);
            this.Controls.Add(this.buttonRunProcessAsync);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRunProcessAsync;
        private System.Windows.Forms.TextBox textOutput;
    }
}

