namespace PROJECT
{
    partial class FormPerson
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.serper_field = new System.Windows.Forms.NumericUpDown();
            this.serial_field = new System.Windows.Forms.NumericUpDown();
            this.Lname_field = new System.Windows.Forms.TextBox();
            this.Fname_field = new System.Windows.Forms.TextBox();
            this.Father_field = new System.Windows.Forms.TextBox();
            this.Mother_field = new System.Windows.Forms.TextBox();
            this.Reg_field = new System.Windows.Forms.TextBox();
            this.PBirth_field = new System.Windows.Forms.ComboBox();
            this.Resid_field = new System.Windows.Forms.ComboBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.Attr_field = new System.Windows.Forms.ComboBox();
            this.DBirth_field = new System.Windows.Forms.TextBox();
            this.Adrs_field = new System.Windows.Forms.CheckBox();
            this.Exst_field = new System.Windows.Forms.CheckBox();
            this.NickName_field = new System.Windows.Forms.TextBox();
            this.Occupation_Field = new System.Windows.Forms.TextBox();
            this.Idnum_field = new System.Windows.Forms.TextBox();
            this.Gender_field = new System.Windows.Forms.ComboBox();
            this.Status_field = new System.Windows.Forms.ComboBox();
            this.Mobileno_field = new System.Windows.Forms.TextBox();
            this.dataGridView_Person = new System.Windows.Forms.DataGridView();
            this.serial_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serpers_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fname_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lname_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Father_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mother_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nation_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reg_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PBirth_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DBirth_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Resid_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adrs_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attr_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Exst_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Arch_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nickname_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Occupation_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Idnum_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobileno_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button10 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.insertbtn = new System.Windows.Forms.Button();
            this.Nation_field = new System.Windows.Forms.ComboBox();
            this.facebtn = new System.Windows.Forms.Button();
            this.fpbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.serper_field)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serial_field)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Person)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = " الرقم المتسلسل الشخصي";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = " الرقم المتسلسل للملف";
            // 
            // serper_field
            // 
            this.serper_field.Enabled = false;
            this.serper_field.Location = new System.Drawing.Point(139, -2);
            this.serper_field.Name = "serper_field";
            this.serper_field.Size = new System.Drawing.Size(42, 23);
            this.serper_field.TabIndex = 2;
            // 
            // serial_field
            // 
            this.serial_field.Enabled = false;
            this.serial_field.Location = new System.Drawing.Point(314, 1);
            this.serial_field.Name = "serial_field";
            this.serial_field.Size = new System.Drawing.Size(39, 23);
            this.serial_field.TabIndex = 3;
            // 
            // Lname_field
            // 
            this.Lname_field.Location = new System.Drawing.Point(12, 30);
            this.Lname_field.Name = "Lname_field";
            this.Lname_field.PlaceholderText = "[الشهرة]";
            this.Lname_field.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Lname_field.Size = new System.Drawing.Size(169, 23);
            this.Lname_field.TabIndex = 4;
            // 
            // Fname_field
            // 
            this.Fname_field.Location = new System.Drawing.Point(187, 30);
            this.Fname_field.Name = "Fname_field";
            this.Fname_field.PlaceholderText = "[الاسم]*";
            this.Fname_field.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Fname_field.Size = new System.Drawing.Size(166, 23);
            this.Fname_field.TabIndex = 5;
            // 
            // Father_field
            // 
            this.Father_field.Location = new System.Drawing.Point(187, 60);
            this.Father_field.Name = "Father_field";
            this.Father_field.PlaceholderText = "[اسم الاب]";
            this.Father_field.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Father_field.Size = new System.Drawing.Size(166, 23);
            this.Father_field.TabIndex = 6;
            // 
            // Mother_field
            // 
            this.Mother_field.Location = new System.Drawing.Point(12, 59);
            this.Mother_field.Name = "Mother_field";
            this.Mother_field.PlaceholderText = "[اسم الام]";
            this.Mother_field.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Mother_field.Size = new System.Drawing.Size(169, 23);
            this.Mother_field.TabIndex = 7;
            // 
            // Reg_field
            // 
            this.Reg_field.Location = new System.Drawing.Point(12, 88);
            this.Reg_field.Name = "Reg_field";
            this.Reg_field.PlaceholderText = "[رقم و مكان السجل]*";
            this.Reg_field.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Reg_field.Size = new System.Drawing.Size(341, 23);
            this.Reg_field.TabIndex = 8;
            // 
            // PBirth_field
            // 
            this.PBirth_field.FormattingEnabled = true;
            this.PBirth_field.Location = new System.Drawing.Point(12, 147);
            this.PBirth_field.Name = "PBirth_field";
            this.PBirth_field.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PBirth_field.Size = new System.Drawing.Size(237, 23);
            this.PBirth_field.TabIndex = 9;
            this.PBirth_field.SelectedIndexChanged += new System.EventHandler(this.PBirth_field_SelectedIndexChanged);
            // 
            // Resid_field
            // 
            this.Resid_field.FormattingEnabled = true;
            this.Resid_field.Location = new System.Drawing.Point(12, 176);
            this.Resid_field.Name = "Resid_field";
            this.Resid_field.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Resid_field.Size = new System.Drawing.Size(237, 23);
            this.Resid_field.TabIndex = 10;
            this.Resid_field.SelectedIndexChanged += new System.EventHandler(this.Resid_field_SelectedIndexChanged);
            // 
            // textBox6
            // 
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(255, 147);
            this.textBox6.Name = "textBox6";
            this.textBox6.PlaceholderText = "[محل الولادة]";
            this.textBox6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox6.Size = new System.Drawing.Size(98, 23);
            this.textBox6.TabIndex = 11;
            // 
            // textBox7
            // 
            this.textBox7.Enabled = false;
            this.textBox7.Location = new System.Drawing.Point(255, 176);
            this.textBox7.Name = "textBox7";
            this.textBox7.PlaceholderText = "[محل الاقامة]";
            this.textBox7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox7.Size = new System.Drawing.Size(98, 23);
            this.textBox7.TabIndex = 12;
            // 
            // Attr_field
            // 
            this.Attr_field.FormattingEnabled = true;
            this.Attr_field.Location = new System.Drawing.Point(12, 205);
            this.Attr_field.Name = "Attr_field";
            this.Attr_field.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Attr_field.Size = new System.Drawing.Size(237, 23);
            this.Attr_field.TabIndex = 13;
            // 
            // DBirth_field
            // 
            this.DBirth_field.Location = new System.Drawing.Point(255, 234);
            this.DBirth_field.Name = "DBirth_field";
            this.DBirth_field.PlaceholderText = "[تاريخ الولادة]*";
            this.DBirth_field.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DBirth_field.Size = new System.Drawing.Size(98, 23);
            this.DBirth_field.TabIndex = 14;
            // 
            // Adrs_field
            // 
            this.Adrs_field.AutoSize = true;
            this.Adrs_field.Location = new System.Drawing.Point(224, 273);
            this.Adrs_field.Name = "Adrs_field";
            this.Adrs_field.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Adrs_field.Size = new System.Drawing.Size(129, 19);
            this.Adrs_field.TabIndex = 16;
            this.Adrs_field.Text = " هل يوجد عنوان سكن";
            this.Adrs_field.UseVisualStyleBackColor = true;
            // 
            // Exst_field
            // 
            this.Exst_field.AutoSize = true;
            this.Exst_field.Location = new System.Drawing.Point(229, 298);
            this.Exst_field.Name = "Exst_field";
            this.Exst_field.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Exst_field.Size = new System.Drawing.Size(124, 19);
            this.Exst_field.TabIndex = 17;
            this.Exst_field.Text = " هل يوجد رقم داخلي";
            this.Exst_field.UseVisualStyleBackColor = true;
            // 
            // NickName_field
            // 
            this.NickName_field.Location = new System.Drawing.Point(12, 294);
            this.NickName_field.Name = "NickName_field";
            this.NickName_field.PlaceholderText = "[اللقب]*";
            this.NickName_field.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.NickName_field.Size = new System.Drawing.Size(206, 23);
            this.NickName_field.TabIndex = 18;
            // 
            // Occupation_Field
            // 
            this.Occupation_Field.Location = new System.Drawing.Point(12, 323);
            this.Occupation_Field.Name = "Occupation_Field";
            this.Occupation_Field.PlaceholderText = "[ المهنة]";
            this.Occupation_Field.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Occupation_Field.Size = new System.Drawing.Size(206, 23);
            this.Occupation_Field.TabIndex = 19;
            // 
            // Idnum_field
            // 
            this.Idnum_field.Location = new System.Drawing.Point(229, 323);
            this.Idnum_field.Name = "Idnum_field";
            this.Idnum_field.PlaceholderText = "0";
            this.Idnum_field.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Idnum_field.Size = new System.Drawing.Size(124, 23);
            this.Idnum_field.TabIndex = 20;
            this.Idnum_field.Text = "*";
            // 
            // Gender_field
            // 
            this.Gender_field.FormattingEnabled = true;
            this.Gender_field.Items.AddRange(new object[] {
            "الجنس",
            "زكر",
            "انثى ",
            "غير محدد"});
            this.Gender_field.Location = new System.Drawing.Point(229, 381);
            this.Gender_field.Name = "Gender_field";
            this.Gender_field.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Gender_field.Size = new System.Drawing.Size(124, 23);
            this.Gender_field.TabIndex = 21;
            // 
            // Status_field
            // 
            this.Status_field.FormattingEnabled = true;
            this.Status_field.Items.AddRange(new object[] {
            "اعزج",
            "متزوج",
            "ارمل ",
            "مطلق"});
            this.Status_field.Location = new System.Drawing.Point(229, 352);
            this.Status_field.Name = "Status_field";
            this.Status_field.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Status_field.Size = new System.Drawing.Size(124, 23);
            this.Status_field.TabIndex = 22;
            // 
            // Mobileno_field
            // 
            this.Mobileno_field.Location = new System.Drawing.Point(15, 352);
            this.Mobileno_field.Name = "Mobileno_field";
            this.Mobileno_field.PlaceholderText = "* +___-__-___-___ ";
            this.Mobileno_field.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Mobileno_field.Size = new System.Drawing.Size(203, 23);
            this.Mobileno_field.TabIndex = 23;
            // 
            // dataGridView_Person
            // 
            this.dataGridView_Person.AccessibleRole = System.Windows.Forms.AccessibleRole.Row;
            this.dataGridView_Person.AllowUserToAddRows = false;
            this.dataGridView_Person.AllowUserToDeleteRows = false;
            this.dataGridView_Person.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Person.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serial_column,
            this.serpers_column,
            this.Fname_column,
            this.Lname_column,
            this.Father_column,
            this.Mother_column,
            this.Nation_column,
            this.Reg_column,
            this.PBirth_column,
            this.DBirth_column,
            this.Resid_column,
            this.Adrs_column,
            this.Attr_column,
            this.Exst_column,
            this.Arch_column,
            this.Nickname_column,
            this.Occupation_column,
            this.Idnum_column,
            this.Mobileno_column,
            this.Status_column,
            this.Gender_column});
            this.dataGridView_Person.Location = new System.Drawing.Point(357, 3);
            this.dataGridView_Person.Name = "dataGridView_Person";
            this.dataGridView_Person.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView_Person.RowTemplate.Height = 25;
            this.dataGridView_Person.Size = new System.Drawing.Size(728, 444);
            this.dataGridView_Person.TabIndex = 24;
            this.dataGridView_Person.SelectionChanged += new System.EventHandler(this.dataGridView_Person_SelectionChanged);
            // 
            // serial_column
            // 
            this.serial_column.HeaderText = "رقم متسلسل الملف";
            this.serial_column.Name = "serial_column";
            // 
            // serpers_column
            // 
            this.serpers_column.HeaderText = "رقم متسلسل الشخص";
            this.serpers_column.Name = "serpers_column";
            // 
            // Fname_column
            // 
            this.Fname_column.HeaderText = "الاسم";
            this.Fname_column.Name = "Fname_column";
            // 
            // Lname_column
            // 
            this.Lname_column.HeaderText = "الشهرة";
            this.Lname_column.Name = "Lname_column";
            // 
            // Father_column
            // 
            this.Father_column.HeaderText = "اسم الاب";
            this.Father_column.Name = "Father_column";
            // 
            // Mother_column
            // 
            this.Mother_column.HeaderText = "اسم الام";
            this.Mother_column.Name = "Mother_column";
            // 
            // Nation_column
            // 
            this.Nation_column.HeaderText = "الجنسية";
            this.Nation_column.Name = "Nation_column";
            // 
            // Reg_column
            // 
            this.Reg_column.HeaderText = "سجل القيد";
            this.Reg_column.Name = "Reg_column";
            // 
            // PBirth_column
            // 
            this.PBirth_column.HeaderText = "محل الولادة";
            this.PBirth_column.Name = "PBirth_column";
            // 
            // DBirth_column
            // 
            this.DBirth_column.HeaderText = "تاريخ الولادة";
            this.DBirth_column.Name = "DBirth_column";
            // 
            // Resid_column
            // 
            this.Resid_column.HeaderText = "الاقامة";
            this.Resid_column.Name = "Resid_column";
            // 
            // Adrs_column
            // 
            this.Adrs_column.HeaderText = "Adrs";
            this.Adrs_column.Name = "Adrs_column";
            // 
            // Attr_column
            // 
            this.Attr_column.HeaderText = "Attr";
            this.Attr_column.Name = "Attr_column";
            // 
            // Exst_column
            // 
            this.Exst_column.HeaderText = "Exst";
            this.Exst_column.Name = "Exst_column";
            // 
            // Arch_column
            // 
            this.Arch_column.HeaderText = "Arch";
            this.Arch_column.Name = "Arch_column";
            // 
            // Nickname_column
            // 
            this.Nickname_column.HeaderText = "اللقب";
            this.Nickname_column.Name = "Nickname_column";
            // 
            // Occupation_column
            // 
            this.Occupation_column.HeaderText = "المهنة";
            this.Occupation_column.Name = "Occupation_column";
            // 
            // Idnum_column
            // 
            this.Idnum_column.HeaderText = "Idnum";
            this.Idnum_column.Name = "Idnum_column";
            // 
            // Mobileno_column
            // 
            this.Mobileno_column.HeaderText = "رقم الهاتف";
            this.Mobileno_column.Name = "Mobileno_column";
            // 
            // Status_column
            // 
            this.Status_column.HeaderText = "الحالة الاجتماعية";
            this.Status_column.Name = "Status_column";
            // 
            // Gender_column
            // 
            this.Gender_column.HeaderText = "الجنس";
            this.Gender_column.Name = "Gender_column";
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.White;
            this.button10.Location = new System.Drawing.Point(652, 495);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(105, 38);
            this.button10.TabIndex = 29;
            this.button10.Text = " الغاء";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.cancel_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(874, 495);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(105, 38);
            this.button8.TabIndex = 27;
            this.button8.Text = " حذف";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.deletebtn_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(763, 495);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(105, 38);
            this.button7.TabIndex = 26;
            this.button7.Text = "تعديل";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.editbtn_Click);
            // 
            // insertbtn
            // 
            this.insertbtn.BackColor = System.Drawing.Color.White;
            this.insertbtn.Location = new System.Drawing.Point(985, 495);
            this.insertbtn.Name = "insertbtn";
            this.insertbtn.Size = new System.Drawing.Size(105, 38);
            this.insertbtn.TabIndex = 25;
            this.insertbtn.Text = "ادخال";
            this.insertbtn.UseVisualStyleBackColor = false;
            this.insertbtn.Click += new System.EventHandler(this.Insertbtn_Click);
            // 
            // Nation_field
            // 
            this.Nation_field.FormattingEnabled = true;
            this.Nation_field.Location = new System.Drawing.Point(12, 118);
            this.Nation_field.Name = "Nation_field";
            this.Nation_field.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Nation_field.Size = new System.Drawing.Size(237, 23);
            this.Nation_field.TabIndex = 30;
            // 
            // facebtn
            // 
            this.facebtn.BackColor = System.Drawing.Color.White;
            this.facebtn.Location = new System.Drawing.Point(483, 495);
            this.facebtn.Name = "facebtn";
            this.facebtn.Size = new System.Drawing.Size(105, 38);
            this.facebtn.TabIndex = 31;
            this.facebtn.Text = "اضافة صورة";
            this.facebtn.UseVisualStyleBackColor = false;
            this.facebtn.Click += new System.EventHandler(this.faceimgbtn_Click);
            // 
            // fpbtn
            // 
            this.fpbtn.BackColor = System.Drawing.Color.White;
            this.fpbtn.Location = new System.Drawing.Point(357, 495);
            this.fpbtn.Name = "fpbtn";
            this.fpbtn.Size = new System.Drawing.Size(105, 38);
            this.fpbtn.TabIndex = 32;
            this.fpbtn.Text = "اضافة بصمة";
            this.fpbtn.UseVisualStyleBackColor = false;
            this.fpbtn.Click += new System.EventHandler(this.fpbtn_Click);
            // 
            // FormPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 545);
            this.Controls.Add(this.fpbtn);
            this.Controls.Add(this.facebtn);
            this.Controls.Add(this.Nation_field);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.insertbtn);
            this.Controls.Add(this.dataGridView_Person);
            this.Controls.Add(this.Mobileno_field);
            this.Controls.Add(this.Status_field);
            this.Controls.Add(this.Gender_field);
            this.Controls.Add(this.Idnum_field);
            this.Controls.Add(this.Occupation_Field);
            this.Controls.Add(this.NickName_field);
            this.Controls.Add(this.Exst_field);
            this.Controls.Add(this.Adrs_field);
            this.Controls.Add(this.DBirth_field);
            this.Controls.Add(this.Attr_field);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.Resid_field);
            this.Controls.Add(this.PBirth_field);
            this.Controls.Add(this.Reg_field);
            this.Controls.Add(this.Mother_field);
            this.Controls.Add(this.Father_field);
            this.Controls.Add(this.Fname_field);
            this.Controls.Add(this.Lname_field);
            this.Controls.Add(this.serial_field);
            this.Controls.Add(this.serper_field);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormPerson";
            this.Text = "FormPerson";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormPerson_FormClosed);
            this.Load += new System.EventHandler(this.FormPerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.serper_field)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serial_field)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Person)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private NumericUpDown serper_field;
        private NumericUpDown serial_field;
        private TextBox Lname_field;
        private TextBox Fname_field;
        private TextBox Father_field;
        private TextBox Mother_field;
        private TextBox Reg_field;
        private ComboBox PBirth_field;
        private ComboBox Resid_field;
        private TextBox textBox6;
        private TextBox textBox7;
        private ComboBox Attr_field;
        private TextBox DBirth_field;
        private CheckBox Adrs_field;
        private CheckBox Exst_field;
        private TextBox NickName_field;
        private TextBox Occupation_Field;
        private TextBox Idnum_field;
        private ComboBox Gender_field;
        private ComboBox Status_field;
        private TextBox Mobileno_field;
        private DataGridView dataGridView_Person;
        private Button button10;
        private Button button8;
        private Button button7;
        private Button insertbtn;
        private ComboBox Nation_field;
        private Button facebtn;
        private DataGridViewTextBoxColumn serial_column;
        private DataGridViewTextBoxColumn serpers_column;
        private DataGridViewTextBoxColumn Fname_column;
        private DataGridViewTextBoxColumn Lname_column;
        private DataGridViewTextBoxColumn Father_column;
        private DataGridViewTextBoxColumn Mother_column;
        private DataGridViewTextBoxColumn Nation_column;
        private DataGridViewTextBoxColumn Reg_column;
        private DataGridViewTextBoxColumn PBirth_column;
        private DataGridViewTextBoxColumn DBirth_column;
        private DataGridViewTextBoxColumn Resid_column;
        private DataGridViewTextBoxColumn Adrs_column;
        private DataGridViewTextBoxColumn Attr_column;
        private DataGridViewTextBoxColumn Exst_column;
        private DataGridViewTextBoxColumn Arch_column;
        private DataGridViewTextBoxColumn Nickname_column;
        private DataGridViewTextBoxColumn Occupation_column;
        private DataGridViewTextBoxColumn Idnum_column;
        private DataGridViewTextBoxColumn Mobileno_column;
        private DataGridViewTextBoxColumn Status_column;
        private DataGridViewTextBoxColumn Gender_column;
        private Button fpbtn;
    }
}