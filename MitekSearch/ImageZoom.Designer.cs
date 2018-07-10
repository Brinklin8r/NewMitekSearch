namespace MitekSearch {
    partial class ImageZoom {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnRotate90 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRotate90
            // 
            this.btnRotate90.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRotate90.Location = new System.Drawing.Point(1135, 610);
            this.btnRotate90.Name = "btnRotate90";
            this.btnRotate90.Size = new System.Drawing.Size(80, 40);
            this.btnRotate90.TabIndex = 0;
            this.btnRotate90.Text = "Rotate 90*";
            this.btnRotate90.UseVisualStyleBackColor = true;
            this.btnRotate90.Click += new System.EventHandler(this.ImageZoom_DoubleClick);
            // 
            // ImageZoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1224, 661);
            this.Controls.Add(this.btnRotate90);
            this.Name = "ImageZoom";
            this.Text = "ImageZoom";
            this.Load += new System.EventHandler(this.ImageZoom_Load);
            this.DoubleClick += new System.EventHandler(this.ImageZoom_DoubleClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRotate90;
    }
}