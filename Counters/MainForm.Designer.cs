namespace Counters
{
	partial class MainForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this._lbCounters = new System.Windows.Forms.ListBox();
			this._btnAdd = new System.Windows.Forms.Button();
			this._btnRemove = new System.Windows.Forms.Button();
			this._gpControl = new System.Windows.Forms.GroupBox();
			this._btnLoad = new System.Windows.Forms.Button();
			this._btnEdit = new System.Windows.Forms.Button();
			this._btnSave = new System.Windows.Forms.Button();
			this._gpView = new System.Windows.Forms.GroupBox();
			this._gpControl.SuspendLayout();
			this.SuspendLayout();
			// 
			// _lbCounters
			// 
			this._lbCounters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this._lbCounters.FormattingEnabled = true;
			this._lbCounters.Location = new System.Drawing.Point(12, 12);
			this._lbCounters.Name = "_lbCounters";
			this._lbCounters.Size = new System.Drawing.Size(260, 82);
			this._lbCounters.TabIndex = 0;
			// 
			// _btnAdd
			// 
			this._btnAdd.Location = new System.Drawing.Point(6, 19);
			this._btnAdd.Name = "_btnAdd";
			this._btnAdd.Size = new System.Drawing.Size(84, 24);
			this._btnAdd.TabIndex = 1;
			this._btnAdd.Text = "Добавить";
			this._btnAdd.UseVisualStyleBackColor = true;
			// 
			// _btnRemove
			// 
			this._btnRemove.Location = new System.Drawing.Point(96, 19);
			this._btnRemove.Name = "_btnRemove";
			this._btnRemove.Size = new System.Drawing.Size(84, 24);
			this._btnRemove.TabIndex = 2;
			this._btnRemove.Text = "Удалить";
			this._btnRemove.UseVisualStyleBackColor = true;
			// 
			// _gpControl
			// 
			this._gpControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._gpControl.Controls.Add(this._btnLoad);
			this._gpControl.Controls.Add(this._btnEdit);
			this._gpControl.Controls.Add(this._btnSave);
			this._gpControl.Controls.Add(this._btnRemove);
			this._gpControl.Controls.Add(this._btnAdd);
			this._gpControl.Font = new System.Drawing.Font("Comic Sans MS", 9.75F);
			this._gpControl.ForeColor = System.Drawing.Color.Aqua;
			this._gpControl.Location = new System.Drawing.Point(278, 12);
			this._gpControl.Name = "_gpControl";
			this._gpControl.Size = new System.Drawing.Size(457, 57);
			this._gpControl.TabIndex = 3;
			this._gpControl.TabStop = false;
			this._gpControl.Text = "Управление";
			// 
			// _btnLoad
			// 
			this._btnLoad.Location = new System.Drawing.Point(366, 19);
			this._btnLoad.Name = "_btnLoad";
			this._btnLoad.Size = new System.Drawing.Size(84, 24);
			this._btnLoad.TabIndex = 5;
			this._btnLoad.Text = "Загрузить";
			this._btnLoad.UseVisualStyleBackColor = true;
			this._btnLoad.Click += new System.EventHandler(this._btnLoad_Click);
			// 
			// _btnEdit
			// 
			this._btnEdit.Location = new System.Drawing.Point(186, 19);
			this._btnEdit.Name = "_btnEdit";
			this._btnEdit.Size = new System.Drawing.Size(84, 24);
			this._btnEdit.TabIndex = 4;
			this._btnEdit.Text = "Изменить";
			this._btnEdit.UseVisualStyleBackColor = true;
			// 
			// _btnSave
			// 
			this._btnSave.Location = new System.Drawing.Point(276, 19);
			this._btnSave.Name = "_btnSave";
			this._btnSave.Size = new System.Drawing.Size(84, 24);
			this._btnSave.TabIndex = 3;
			this._btnSave.Text = "Сохранить";
			this._btnSave.UseVisualStyleBackColor = true;
			this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
			// 
			// _gpView
			// 
			this._gpView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._gpView.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this._gpView.ForeColor = System.Drawing.Color.Aqua;
			this._gpView.Location = new System.Drawing.Point(278, 75);
			this._gpView.Name = "_gpView";
			this._gpView.Size = new System.Drawing.Size(457, 307);
			this._gpView.TabIndex = 4;
			this._gpView.TabStop = false;
			this._gpView.Text = "Показания";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(747, 396);
			this.Controls.Add(this._gpView);
			this.Controls.Add(this._gpControl);
			this.Controls.Add(this._lbCounters);
			this.Name = "MainForm";
			this.Text = "Контроль счётчиков";
			this._gpControl.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox _lbCounters;
		private System.Windows.Forms.Button _btnAdd;
		private System.Windows.Forms.Button _btnRemove;
		private System.Windows.Forms.GroupBox _gpControl;
		private System.Windows.Forms.Button _btnSave;
		private System.Windows.Forms.GroupBox _gpView;
		private System.Windows.Forms.Button _btnEdit;
		private System.Windows.Forms.Button _btnLoad;
	}
}

