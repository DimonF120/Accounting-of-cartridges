namespace Bank
{
    partial class FormEditZayavki
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownZayavki = new System.Windows.Forms.NumericUpDown();
            this.labelDataPostypleniya = new System.Windows.Forms.Label();
            this.labelDataPodachi = new System.Windows.Forms.Label();
            this.labelCHBU = new System.Windows.Forms.Label();
            this.labelZayavka = new System.Windows.Forms.Label();
            this.dateTimePickerPost = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerPodach = new System.Windows.Forms.DateTimePicker();
            this.comboBoxCHBU = new System.Windows.Forms.ComboBox();
            this.buttonDobav = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownKolvo = new System.Windows.Forms.NumericUpDown();
            this.labelKatridj = new System.Windows.Forms.Label();
            this.comboBoxKartridj = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonPhoto = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZayavki)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKolvo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownZayavki);
            this.groupBox1.Controls.Add(this.labelDataPostypleniya);
            this.groupBox1.Controls.Add(this.labelDataPodachi);
            this.groupBox1.Controls.Add(this.labelCHBU);
            this.groupBox1.Controls.Add(this.labelZayavka);
            this.groupBox1.Controls.Add(this.dateTimePickerPost);
            this.groupBox1.Controls.Add(this.dateTimePickerPodach);
            this.groupBox1.Controls.Add(this.comboBoxCHBU);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 249);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // numericUpDownZayavki
            // 
            this.numericUpDownZayavki.Location = new System.Drawing.Point(117, 45);
            this.numericUpDownZayavki.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDownZayavki.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownZayavki.Name = "numericUpDownZayavki";
            this.numericUpDownZayavki.Size = new System.Drawing.Size(200, 20);
            this.numericUpDownZayavki.TabIndex = 7;
            this.numericUpDownZayavki.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelDataPostypleniya
            // 
            this.labelDataPostypleniya.AutoSize = true;
            this.labelDataPostypleniya.Location = new System.Drawing.Point(9, 210);
            this.labelDataPostypleniya.Name = "labelDataPostypleniya";
            this.labelDataPostypleniya.Size = new System.Drawing.Size(100, 13);
            this.labelDataPostypleniya.TabIndex = 7;
            this.labelDataPostypleniya.Text = "Дата поступления";
            // 
            // labelDataPodachi
            // 
            this.labelDataPodachi.AutoSize = true;
            this.labelDataPodachi.Location = new System.Drawing.Point(9, 157);
            this.labelDataPodachi.Name = "labelDataPodachi";
            this.labelDataPodachi.Size = new System.Drawing.Size(71, 13);
            this.labelDataPodachi.TabIndex = 6;
            this.labelDataPodachi.Text = "Дата подачи";
            // 
            // labelCHBU
            // 
            this.labelCHBU.AutoSize = true;
            this.labelCHBU.Location = new System.Drawing.Point(9, 101);
            this.labelCHBU.Name = "labelCHBU";
            this.labelCHBU.Size = new System.Drawing.Size(30, 13);
            this.labelCHBU.TabIndex = 5;
            this.labelCHBU.Text = "ЦБУ";
            // 
            // labelZayavka
            // 
            this.labelZayavka.AutoSize = true;
            this.labelZayavka.Location = new System.Drawing.Point(9, 47);
            this.labelZayavka.Name = "labelZayavka";
            this.labelZayavka.Size = new System.Drawing.Size(58, 13);
            this.labelZayavka.TabIndex = 4;
            this.labelZayavka.Text = "№ Заявки";
            // 
            // dateTimePickerPost
            // 
            this.dateTimePickerPost.Location = new System.Drawing.Point(115, 204);
            this.dateTimePickerPost.Name = "dateTimePickerPost";
            this.dateTimePickerPost.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerPost.TabIndex = 3;
            this.dateTimePickerPost.ValueChanged += new System.EventHandler(this.dateTimePickerPost_ValueChanged);
            // 
            // dateTimePickerPodach
            // 
            this.dateTimePickerPodach.Location = new System.Drawing.Point(115, 151);
            this.dateTimePickerPodach.Name = "dateTimePickerPodach";
            this.dateTimePickerPodach.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerPodach.TabIndex = 2;
            // 
            // comboBoxCHBU
            // 
            this.comboBoxCHBU.FormattingEnabled = true;
            this.comboBoxCHBU.Location = new System.Drawing.Point(115, 93);
            this.comboBoxCHBU.Name = "comboBoxCHBU";
            this.comboBoxCHBU.Size = new System.Drawing.Size(200, 21);
            this.comboBoxCHBU.TabIndex = 1;
            // 
            // buttonDobav
            // 
            this.buttonDobav.Location = new System.Drawing.Point(135, 270);
            this.buttonDobav.Name = "buttonDobav";
            this.buttonDobav.Size = new System.Drawing.Size(75, 23);
            this.buttonDobav.TabIndex = 1;
            this.buttonDobav.Text = "Добавить";
            this.buttonDobav.UseVisualStyleBackColor = true;
            this.buttonDobav.Click += new System.EventHandler(this.buttonDobav_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.numericUpDownKolvo);
            this.groupBox2.Controls.Add(this.labelKatridj);
            this.groupBox2.Controls.Add(this.comboBoxKartridj);
            this.groupBox2.Location = new System.Drawing.Point(3, 309);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 140);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Количество";
            // 
            // numericUpDownKolvo
            // 
            this.numericUpDownKolvo.Location = new System.Drawing.Point(115, 101);
            this.numericUpDownKolvo.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownKolvo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownKolvo.Name = "numericUpDownKolvo";
            this.numericUpDownKolvo.Size = new System.Drawing.Size(200, 20);
            this.numericUpDownKolvo.TabIndex = 8;
            this.numericUpDownKolvo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelKatridj
            // 
            this.labelKatridj.AutoSize = true;
            this.labelKatridj.Location = new System.Drawing.Point(9, 46);
            this.labelKatridj.Name = "labelKatridj";
            this.labelKatridj.Size = new System.Drawing.Size(51, 13);
            this.labelKatridj.TabIndex = 5;
            this.labelKatridj.Text = "Катридж";
            // 
            // comboBoxKartridj
            // 
            this.comboBoxKartridj.FormattingEnabled = true;
            this.comboBoxKartridj.Location = new System.Drawing.Point(115, 43);
            this.comboBoxKartridj.Name = "comboBoxKartridj";
            this.comboBoxKartridj.Size = new System.Drawing.Size(200, 21);
            this.comboBoxKartridj.TabIndex = 4;
            this.comboBoxKartridj.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(245, 455);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Enabled = false;
            this.buttonEdit.Location = new System.Drawing.Point(164, 455);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 8;
            this.buttonEdit.Text = "Добавить";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonPhoto
            // 
            this.buttonPhoto.Enabled = false;
            this.buttonPhoto.Location = new System.Drawing.Point(83, 455);
            this.buttonPhoto.Name = "buttonPhoto";
            this.buttonPhoto.Size = new System.Drawing.Size(75, 23);
            this.buttonPhoto.TabIndex = 9;
            this.buttonPhoto.Text = "Скан-копия";
            this.buttonPhoto.UseVisualStyleBackColor = true;
            this.buttonPhoto.Click += new System.EventHandler(this.buttonPhoto_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormEditZayavki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 491);
            this.Controls.Add(this.buttonPhoto);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonDobav);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditZayavki";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditZayavki_FormClosing);
            this.Load += new System.EventHandler(this.FormEditZayavki_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZayavki)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKolvo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelDataPostypleniya;
        private System.Windows.Forms.Label labelDataPodachi;
        private System.Windows.Forms.Label labelCHBU;
        private System.Windows.Forms.Label labelZayavka;
        private System.Windows.Forms.DateTimePicker dateTimePickerPost;
        private System.Windows.Forms.DateTimePicker dateTimePickerPodach;
        private System.Windows.Forms.ComboBox comboBoxCHBU;
        private System.Windows.Forms.Button buttonDobav;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelKatridj;
        private System.Windows.Forms.ComboBox comboBoxKartridj;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.NumericUpDown numericUpDownZayavki;
        private System.Windows.Forms.NumericUpDown numericUpDownKolvo;
        private System.Windows.Forms.Button buttonPhoto;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}