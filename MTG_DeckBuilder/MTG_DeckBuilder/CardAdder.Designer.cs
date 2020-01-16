namespace MTG_DeckBuilder
{
    partial class CardAdder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardAdder));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownMana = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAttack = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownHealth = new System.Windows.Forms.NumericUpDown();
            this.comboBoxEdition = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBoxEditImage = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonAddImage = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxRare = new System.Windows.Forms.ComboBox();
            this.buttonCreateCard = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAttack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHealth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEditImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Добавление карт в базу";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(19, 74);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(140, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(16, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Название";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(16, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Манакост (Общая стоимость)";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // numericUpDownMana
            // 
            this.numericUpDownMana.Location = new System.Drawing.Point(19, 118);
            this.numericUpDownMana.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownMana.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMana.Name = "numericUpDownMana";
            this.numericUpDownMana.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownMana.TabIndex = 5;
            this.numericUpDownMana.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownAttack
            // 
            this.numericUpDownAttack.Location = new System.Drawing.Point(9, 39);
            this.numericUpDownAttack.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownAttack.Name = "numericUpDownAttack";
            this.numericUpDownAttack.Size = new System.Drawing.Size(36, 20);
            this.numericUpDownAttack.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Урон / Здоровье\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(51, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "/\r\n";
            // 
            // numericUpDownHealth
            // 
            this.numericUpDownHealth.Location = new System.Drawing.Point(69, 39);
            this.numericUpDownHealth.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownHealth.Name = "numericUpDownHealth";
            this.numericUpDownHealth.Size = new System.Drawing.Size(36, 20);
            this.numericUpDownHealth.TabIndex = 9;
            // 
            // comboBoxEdition
            // 
            this.comboBoxEdition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEdition.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxEdition.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxEdition.FormattingEnabled = true;
            this.comboBoxEdition.Items.AddRange(new object[] {
            "Гильдии Равники",
            "Базовый выпуск М19",
            "Доминария",
            "Борьба за иксалан",
            "Иксалан",
            "Час Разрушения",
            "Амонхет"});
            this.comboBoxEdition.Location = new System.Drawing.Point(21, 224);
            this.comboBoxEdition.Name = "comboBoxEdition";
            this.comboBoxEdition.Size = new System.Drawing.Size(184, 26);
            this.comboBoxEdition.TabIndex = 10;
            this.comboBoxEdition.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(18, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Выпуск\n";
            // 
            // pictureBoxEditImage
            // 
            this.pictureBoxEditImage.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxEditImage.Image")));
            this.pictureBoxEditImage.Location = new System.Drawing.Point(211, 205);
            this.pictureBoxEditImage.Name = "pictureBoxEditImage";
            this.pictureBoxEditImage.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxEditImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxEditImage.TabIndex = 12;
            this.pictureBoxEditImage.TabStop = false;
            this.pictureBoxEditImage.Click += new System.EventHandler(this.pictureBoxEditImage_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(18, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Тип карты";
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Items.AddRange(new object[] {
            "Волшебство",
            "Мгновенное заклинание",
            "Существо",
            "Чары"});
            this.comboBoxType.Location = new System.Drawing.Point(21, 167);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(184, 26);
            this.comboBoxType.Sorted = true;
            this.comboBoxType.TabIndex = 13;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(431, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(249, 335);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // buttonAddImage
            // 
            this.buttonAddImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAddImage.Location = new System.Drawing.Point(19, 373);
            this.buttonAddImage.Name = "buttonAddImage";
            this.buttonAddImage.Size = new System.Drawing.Size(184, 39);
            this.buttonAddImage.TabIndex = 16;
            this.buttonAddImage.Text = "Добавить изображение (не обязательно)";
            this.buttonAddImage.UseVisualStyleBackColor = true;
            this.buttonAddImage.Click += new System.EventHandler(this.buttonAddImage_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(18, 268);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 16);
            this.label8.TabIndex = 18;
            this.label8.Text = "Редкость карты";
            // 
            // comboBoxRare
            // 
            this.comboBoxRare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRare.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxRare.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxRare.FormattingEnabled = true;
            this.comboBoxRare.Items.AddRange(new object[] {
            "Common",
            "Uncommon",
            "Rare",
            "Mythic"});
            this.comboBoxRare.Location = new System.Drawing.Point(21, 287);
            this.comboBoxRare.Name = "comboBoxRare";
            this.comboBoxRare.Size = new System.Drawing.Size(184, 26);
            this.comboBoxRare.TabIndex = 17;
            // 
            // buttonCreateCard
            // 
            this.buttonCreateCard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCreateCard.Location = new System.Drawing.Point(19, 444);
            this.buttonCreateCard.Name = "buttonCreateCard";
            this.buttonCreateCard.Size = new System.Drawing.Size(184, 45);
            this.buttonCreateCard.TabIndex = 19;
            this.buttonCreateCard.Text = "Создать";
            this.buttonCreateCard.UseVisualStyleBackColor = true;
            this.buttonCreateCard.Click += new System.EventHandler(this.buttonCreateCard_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownHealth);
            this.groupBox1.Controls.Add(this.numericUpDownAttack);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(241, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(129, 65);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // CardAdder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 525);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonCreateCard);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxRare);
            this.Controls.Add(this.buttonAddImage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.pictureBoxEditImage);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxEdition);
            this.Controls.Add(this.numericUpDownMana);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.Name = "CardAdder";
            this.Text = "CardAdder";
            this.Load += new System.EventHandler(this.CardAdder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAttack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHealth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEditImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownMana;
        private System.Windows.Forms.NumericUpDown numericUpDownAttack;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownHealth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBoxEditImage;
        public System.Windows.Forms.ComboBox comboBoxEdition;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonAddImage;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox comboBoxRare;
        private System.Windows.Forms.Button buttonCreateCard;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}