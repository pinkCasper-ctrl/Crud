using MVC_EF_Crud1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_EF_Crud1.Controllers
{
    public class BookController : Controller
    {
        LibraryContext context = new LibraryContext();
        public ActionResult MyLibrary()
        {
            var listofData = context.BookDetails.ToList();
            return View(listofData);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BookDetails book)
        {
            context.BookDetails.Add(book);
            context.SaveChanges();
            ViewBag.Message = "Data inserted successfully";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = context.BookDetails.Where(p => p.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(BookDetails book)
        {
            var data = context.BookDetails.Where(p => p.Id == book.Id).FirstOrDefault();
            if (data != null)
            {
                data.Author = book.Author;
                data.Publisher = book.Publisher;
                data.Page = book.Page;
                context.SaveChanges();
            }
            return RedirectToAction("MyLibrary");
        }

        public ActionResult Details(int id)
        {
            var data = context.BookDetails.Where(p => p.Id == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = context.BookDetails.Where(p => p.Id == id).FirstOrDefault();
            context.BookDetails.Remove(data);
            context.SaveChanges();
            ViewBag.Message = "Record delete successfully";
            return RedirectToAction("MyLibrary");
        }
    }
}