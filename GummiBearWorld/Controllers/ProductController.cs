﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace GummiBearKingdom.Controllers
{
	public class ProductController : Controller
	{
		private GummiBearWorldContext db = new GummiBearWorldContext();
		public IActionResult Index()
		{
			return View(db.Items.Include(items => items.Category).ToList());
		}
		public IActionResult Details(int id)
		{
			var thisItem = db.Items.FirstOrDefault(items => items.id == id);
			return View(thisItem);
		}
		public IActionResult Create()
		{
			ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
			return View();
		}
		[HttpPost]
		public IActionResult Create(Item item)
		{
			db.Items.Add(item);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult Edit(int id)
		{
			var thisItem = db.Items.FirstOrDefault(items => items.id == id);
			ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
			return View(thisItem);
		}
		[HttpPost]
		public IActionResult Edit(Item item)
		{
			db.Entry(item).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult Delete(int id)
		{
			var thisItem = db.Items.FirstOrDefault(items => items.id == id);
			return View(thisItem);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			var thisItem = db.Items.FirstOrDefault(items => items.id == id);
			db.Items.Remove(thisItem);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}