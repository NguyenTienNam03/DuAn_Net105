using AppDaTa.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppView2
{
	public partial class ShowAllVoucher : Form
	{
		public ShowAllVoucher()
		{
			InitializeComponent();
			LoadData();
		}
		public void LoadData()
		{
			
			voucher_dt_gridview.DataSource = listVoucher;
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void btn_sudung_Click(object sender, EventArgs e)
		{

		}
	}
}
