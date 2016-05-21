namespace Hangman
{
    partial class Options
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
            this.warning_text = new System.Windows.Forms.TextBox();
            this.download_info = new System.Windows.Forms.TextBox();
            this.apply_options = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // warning_text
            // 
            this.warning_text.BackColor = System.Drawing.Color.White;
            this.warning_text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.warning_text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warning_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.warning_text.Location = new System.Drawing.Point(12, 12);
            this.warning_text.Multiline = true;
            this.warning_text.Name = "warning_text";
            this.warning_text.ReadOnly = true;
            this.warning_text.Size = new System.Drawing.Size(260, 33);
            this.warning_text.TabIndex = 0;
            this.warning_text.TabStop = false;
            this.warning_text.Text = "Warning! \r\nDO NOT interrupt the process! \r\n";
            this.warning_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // download_info
            // 
            this.download_info.BackColor = System.Drawing.Color.White;
            this.download_info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.download_info.Location = new System.Drawing.Point(12, 199);
            this.download_info.Multiline = true;
            this.download_info.Name = "download_info";
            this.download_info.Size = new System.Drawing.Size(260, 50);
            this.download_info.TabIndex = 1;
            // 
            // apply_options
            // 
            this.apply_options.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.apply_options.Location = new System.Drawing.Point(197, 226);
            this.apply_options.Name = "apply_options";
            this.apply_options.Size = new System.Drawing.Size(75, 23);
            this.apply_options.TabIndex = 2;
            this.apply_options.Text = "Apply";
            this.apply_options.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.apply_options);
            this.Controls.Add(this.download_info);
            this.Controls.Add(this.warning_text);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Options";
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox warning_text;
        private System.Windows.Forms.TextBox download_info;
        private System.Windows.Forms.Button apply_options;
    }
}