namespace Counters
{
	partial class CounterEditor
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
			this._tbName = new System.Windows.Forms.TextBox();
			this._dtpDate = new System.Windows.Forms.DateTimePicker();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this._nudFracValue = new System.Windows.Forms.NumericUpDown();
			this._nudIntValue = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this._nudFracPerMonth = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this._nudIntPerMonth = new System.Windows.Forms.NumericUpDown();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this._nudFracCapacity = new System.Windows.Forms.NumericUpDown();
			this._nudIntCapacity = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this._btnOk = new System.Windows.Forms.Button();
			this._btnCancel = new System.Windows.Forms.Button();
			this._chbUseCurrentDate = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._nudFracValue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._nudIntValue)).BeginInit();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._nudFracPerMonth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._nudIntPerMonth)).BeginInit();
			this.groupBox5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this._nudFracCapacity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this._nudIntCapacity)).BeginInit();
			this.SuspendLayout();
			// 
			// _tbName
			// 
			this._tbName.Location = new System.Drawing.Point(6, 19);
			this._tbName.Name = "_tbName";
			this._tbName.Size = new System.Drawing.Size(355, 20);
			this._tbName.TabIndex = 1;
			// 
			// _dtpDate
			// 
			this._dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this._dtpDate.Location = new System.Drawing.Point(6, 19);
			this._dtpDate.Name = "_dtpDate";
			this._dtpDate.Size = new System.Drawing.Size(184, 20);
			this._dtpDate.TabIndex = 4;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this._tbName);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(367, 54);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Название";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this._chbUseCurrentDate);
			this.groupBox2.Controls.Add(this._dtpDate);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox2.Location = new System.Drawing.Point(12, 72);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(367, 54);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Дата фиксации";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this._nudFracValue);
			this.groupBox3.Controls.Add(this._nudIntValue);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox3.Location = new System.Drawing.Point(12, 192);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(367, 54);
			this.groupBox3.TabIndex = 7;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Фиксированные показания";
			// 
			// _nudFracValue
			// 
			this._nudFracValue.Location = new System.Drawing.Point(196, 19);
			this._nudFracValue.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
			this._nudFracValue.Name = "_nudFracValue";
			this._nudFracValue.Size = new System.Drawing.Size(159, 20);
			this._nudFracValue.TabIndex = 5;
			this._nudFracValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// _nudIntValue
			// 
			this._nudIntValue.Location = new System.Drawing.Point(6, 19);
			this._nudIntValue.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
			this._nudIntValue.Name = "_nudIntValue";
			this._nudIntValue.Size = new System.Drawing.Size(159, 20);
			this._nudIntValue.TabIndex = 3;
			this._nudIntValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(171, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(19, 26);
			this.label2.TabIndex = 4;
			this.label2.Text = ",";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this._nudFracPerMonth);
			this.groupBox4.Controls.Add(this.label1);
			this.groupBox4.Controls.Add(this._nudIntPerMonth);
			this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox4.Location = new System.Drawing.Point(11, 252);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(367, 54);
			this.groupBox4.TabIndex = 8;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Изменение за месяц";
			// 
			// _nudFracPerMonth
			// 
			this._nudFracPerMonth.Location = new System.Drawing.Point(196, 19);
			this._nudFracPerMonth.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this._nudFracPerMonth.Name = "_nudFracPerMonth";
			this._nudFracPerMonth.Size = new System.Drawing.Size(159, 20);
			this._nudFracPerMonth.TabIndex = 2;
			this._nudFracPerMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(171, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(19, 26);
			this.label1.TabIndex = 1;
			this.label1.Text = ",";
			// 
			// _nudIntPerMonth
			// 
			this._nudIntPerMonth.Location = new System.Drawing.Point(6, 19);
			this._nudIntPerMonth.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
			this._nudIntPerMonth.Name = "_nudIntPerMonth";
			this._nudIntPerMonth.Size = new System.Drawing.Size(159, 20);
			this._nudIntPerMonth.TabIndex = 0;
			this._nudIntPerMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this._nudFracCapacity);
			this.groupBox5.Controls.Add(this._nudIntCapacity);
			this.groupBox5.Controls.Add(this.label3);
			this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox5.Location = new System.Drawing.Point(12, 132);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(367, 54);
			this.groupBox5.TabIndex = 8;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Разрядность";
			// 
			// _nudFracCapacity
			// 
			this._nudFracCapacity.Location = new System.Drawing.Point(196, 19);
			this._nudFracCapacity.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
			this._nudFracCapacity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this._nudFracCapacity.Name = "_nudFracCapacity";
			this._nudFracCapacity.Size = new System.Drawing.Size(159, 20);
			this._nudFracCapacity.TabIndex = 5;
			this._nudFracCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._nudFracCapacity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// _nudIntCapacity
			// 
			this._nudIntCapacity.Location = new System.Drawing.Point(6, 19);
			this._nudIntCapacity.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
			this._nudIntCapacity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this._nudIntCapacity.Name = "_nudIntCapacity";
			this._nudIntCapacity.Size = new System.Drawing.Size(159, 20);
			this._nudIntCapacity.TabIndex = 3;
			this._nudIntCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this._nudIntCapacity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(171, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(19, 26);
			this.label3.TabIndex = 4;
			this.label3.Text = ",";
			// 
			// _btnOk
			// 
			this._btnOk.Location = new System.Drawing.Point(11, 320);
			this._btnOk.Name = "_btnOk";
			this._btnOk.Size = new System.Drawing.Size(139, 23);
			this._btnOk.TabIndex = 9;
			this._btnOk.Text = "ОК";
			this._btnOk.UseVisualStyleBackColor = true;
			// 
			// _btnCancel
			// 
			this._btnCancel.Location = new System.Drawing.Point(240, 320);
			this._btnCancel.Name = "_btnCancel";
			this._btnCancel.Size = new System.Drawing.Size(139, 23);
			this._btnCancel.TabIndex = 10;
			this._btnCancel.Text = "Отмена";
			this._btnCancel.UseVisualStyleBackColor = true;
			// 
			// _chbUseCurrentDate
			// 
			this._chbUseCurrentDate.AutoSize = true;
			this._chbUseCurrentDate.Location = new System.Drawing.Point(196, 19);
			this._chbUseCurrentDate.Name = "_chbUseCurrentDate";
			this._chbUseCurrentDate.Size = new System.Drawing.Size(113, 17);
			this._chbUseCurrentDate.TabIndex = 5;
			this._chbUseCurrentDate.Text = "Текущий момент";
			this._chbUseCurrentDate.UseVisualStyleBackColor = true;
			// 
			// CounterEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(390, 355);
			this.Controls.Add(this._btnCancel);
			this.Controls.Add(this._btnOk);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "CounterEditor";
			this.Text = "CounterEditor";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this._nudFracValue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._nudIntValue)).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this._nudFracPerMonth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._nudIntPerMonth)).EndInit();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this._nudFracCapacity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this._nudIntCapacity)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.TextBox _tbName;
		private System.Windows.Forms.DateTimePicker _dtpDate;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.NumericUpDown _nudIntPerMonth;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown _nudFracPerMonth;
		private System.Windows.Forms.NumericUpDown _nudFracValue;
		private System.Windows.Forms.NumericUpDown _nudIntValue;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.NumericUpDown _nudFracCapacity;
		private System.Windows.Forms.NumericUpDown _nudIntCapacity;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button _btnOk;
		private System.Windows.Forms.Button _btnCancel;
		private System.Windows.Forms.CheckBox _chbUseCurrentDate;
	}
}