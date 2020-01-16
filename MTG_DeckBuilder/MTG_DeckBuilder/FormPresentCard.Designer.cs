namespace MTG_DeckBuilder
{
    partial class FormPresentCard
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
            this.labelName = new System.Windows.Forms.Label();
            this.labelMana = new System.Windows.Forms.Label();
            this.labelHealthAndAt = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.labelEdition = new System.Windows.Forms.Label();
            this.labelRare = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(12, 57);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(419, 88);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name";
            // 
            // labelMana
            // 
            this.labelMana.AutoSize = true;
            this.labelMana.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMana.Location = new System.Drawing.Point(13, 155);
            this.labelMana.Name = "labelMana";
            this.labelMana.Size = new System.Drawing.Size(70, 25);
            this.labelMana.TabIndex = 1;
            this.labelMana.Text = "label2";
            // 
            // labelHealthAndAt
            // 
            this.labelHealthAndAt.AutoSize = true;
            this.labelHealthAndAt.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHealthAndAt.Location = new System.Drawing.Point(13, 203);
            this.labelHealthAndAt.Name = "labelHealthAndAt";
            this.labelHealthAndAt.Size = new System.Drawing.Size(70, 25);
            this.labelHealthAndAt.TabIndex = 2;
            this.labelHealthAndAt.Text = "label2";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelType.Location = new System.Drawing.Point(13, 247);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(70, 25);
            this.labelType.TabIndex = 3;
            this.labelType.Text = "label2";
            // 
            // labelEdition
            // 
            this.labelEdition.AutoSize = true;
            this.labelEdition.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelEdition.Location = new System.Drawing.Point(14, 290);
            this.labelEdition.Name = "labelEdition";
            this.labelEdition.Size = new System.Drawing.Size(70, 25);
            this.labelEdition.TabIndex = 4;
            this.labelEdition.Text = "label2";
            // 
            // labelRare
            // 
            this.labelRare.AutoSize = true;
            this.labelRare.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRare.Location = new System.Drawing.Point(14, 330);
            this.labelRare.Name = "labelRare";
            this.labelRare.Size = new System.Drawing.Size(70, 25);
            this.labelRare.TabIndex = 5;
            this.labelRare.Text = "label2";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(437, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(249, 335);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // FormPresentCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 514);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelRare);
            this.Controls.Add(this.labelEdition);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.labelHealthAndAt);
            this.Controls.Add(this.labelMana);
            this.Controls.Add(this.labelName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormPresentCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPresentCard";
            this.Load += new System.EventHandler(this.FormPresentCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelMana;
        private System.Windows.Forms.Label labelHealthAndAt;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelEdition;
        private System.Windows.Forms.Label labelRare;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}