using AppDaTa.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppView.Controllers
{
	public class NguoiDungController : Controller
	{
		// GET: NguoiDungController
		[HttpGet]
		public async Task< ActionResult> GetAllKH()
		{
			string url = "https://localhost:7119/api/NguoiDung/GetAll";
			var client = new HttpClient();
			var respons = await client.GetAsync(url);
			var dataapi = await respons.Content.ReadAsStringAsync();
			var list = JsonConvert.DeserializeObject<List<NguoiDung>>(dataapi);
			return View(list);
		}

		// GET: NguoiDungController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: NguoiDungController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: NguoiDungController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: NguoiDungController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: NguoiDungController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: NguoiDungController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: NguoiDungController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
