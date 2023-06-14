namespace AppView2
{
	partial class ShowAllVoucher
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
			label1 = new Label();
			voucher_dt_gridview = new DataGridView();
			btn_sudung = new Button();
			((System.ComponentModel.ISupportInitialize)voucher_dt_gridview).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point);
			label1.Location = new Point(12, 31);
			label1.Name = "label1";
			label1.Size = new Size(104, 26);
			label1.TabIndex = 0;
			label1.Text = "VouCher";
			label1.Click += label1_Click;
			// 
			// voucher_dt_gridview
			// 
			voucher_dt_gridview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			voucher_dt_gridview.Location = new Point(12, 77);
			voucher_dt_gridview.Name = "voucher_dt_gridview";
			voucher_dt_gridview.RowTemplate.Height = 25;
			voucher_dt_gridview.Size = new Size(862, 470);
			voucher_dt_gridview.TabIndex = 1;
			// 
			// btn_sudung
			// 
			btn_sudung.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point);
			btn_sudung.Location = new Point(689, 562);
			btn_sudung.Name = "btn_sudung";
			btn_sudung.Size = new Size(161, 55);
			btn_sudung.TabIndex = 2;
			btn_sudung.Text = "Áp dụng";
			btn_sudung.UseVisualStyleBackColor = true;
			btn_sudung.Click += btn_sudung_Click;
			// 
			// ShowAllVoucher
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(881, 667);
			Controls.Add(btn_sudung);
			Controls.Add(voucher_dt_gridview);
			Controls.Add(label1);
			Name = "ShowAllVoucher";
			Text = "ShowAllVoucher";
			((System.ComponentModel.ISupportInitialize)voucher_dt_gridview).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private DataGridView voucher_dt_gridview;
		private Button btn_sudung;
	}
}