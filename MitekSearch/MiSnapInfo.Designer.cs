namespace MitekSearch {
    partial class MiSnapInfo {
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
            this.lblMiSnapFront = new System.Windows.Forms.Label();
            this.lblMiSnapBack = new System.Windows.Forms.Label();
            this.lblFront = new System.Windows.Forms.Label();
            this.lblBack = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMiSnapFront
            // 
            this.lblMiSnapFront.Location = new System.Drawing.Point(10, 26);
            this.lblMiSnapFront.Name = "lblMiSnapFront";
            this.lblMiSnapFront.Size = new System.Drawing.Size(505, 200);
            this.lblMiSnapFront.TabIndex = 0;
            // 
            // lblMiSnapBack
            // 
            this.lblMiSnapBack.Location = new System.Drawing.Point(10, 242);
            this.lblMiSnapBack.Name = "lblMiSnapBack";
            this.lblMiSnapBack.Size = new System.Drawing.Size(505, 200);
            this.lblMiSnapBack.TabIndex = 1;
            // 
            // lblFront
            // 
            this.lblFront.AutoSize = true;
            this.lblFront.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFront.Location = new System.Drawing.Point(25, 10);
            this.lblFront.Name = "lblFront";
            this.lblFront.Size = new System.Drawing.Size(132, 16);
            this.lblFront.TabIndex = 2;
            this.lblFront.Text = "MiSnap Front Info:";
            // 
            // lblBack
            // 
            this.lblBack.AutoSize = true;
            this.lblBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBack.Location = new System.Drawing.Point(25, 226);
            this.lblBack.Name = "lblBack";
            this.lblBack.Size = new System.Drawing.Size(132, 16);
            this.lblBack.TabIndex = 3;
            this.lblBack.Text = "MiSnap Back Info:";
            // 
            // MiSnapInfo
            // 
            this.ClientSize = new System.Drawing.Size(527, 471);
            this.Controls.Add(this.lblBack);
            this.Controls.Add(this.lblFront);
            this.Controls.Add(this.lblMiSnapBack);
            this.Controls.Add(this.lblMiSnapFront);
            this.Name = "MiSnapInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMiSnapFront;
        private System.Windows.Forms.Label lblMiSnapBack;
        private System.Windows.Forms.Label lblFront;
        private System.Windows.Forms.Label lblBack;
    }
}