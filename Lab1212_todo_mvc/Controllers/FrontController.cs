﻿using Lab1212_todo_mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Lab1212_todo_mvc.Controllers
{
    public class FrontController : Controller
    {
        private MusFitContext _context2;
        private todoItemDbContext _context;


        public FrontController(todoItemDbContext _db)
        {
            this._context = _db;
        }
        //public TodoController(MusFitContext _db)
        //{
        //    this._context = _db;
        //}

        public IActionResult Index()
        {
            var query = from o in this._context.Employees
                        select o;
            List<Employee> dataList = query.ToList();
            return View("Index", dataList);

        }

        public IActionResult Test()
        {
            var query =
            (from cs in this._context.CoachSpecials
             join e in this._context.Employees
             on cs.EId equals e.EId
             join lc in this._context.LessionCategories
             on cs.LcId equals lc.LcId
             select new //Employee
             {
                 EId = e.EId,
                 EName = e.EName,
                 EEngName = e.EEngName,
                 EPhoto = e.EPhoto,
                 LcTyle = lc.LcType,
                 EExplain = e.EExplain,
                 LcName = lc.LcName
             }).ToList();

            ViewBag.Mytest = query;



            //var query =
            //from  e in this._context.Employees
            //where e.EIsCoach==true
            // select new Employee
            // {
            //     EId = e.EId,
            //     EName = e.EName,
            //     EEngName = e.EEngName,
            //     EPhoto = e.EPhoto,
            //     EExplain = e.EExplain,
            // };

            //ViewBag.Mytest = query.ToList();
            return View();
        }

        public IActionResult Classroom()
        {
            return View();
        }
        public IActionResult Coach()
        {
            var query2 =
            from e in this._context.Employees
            where e.EIsCoach == true
            select new Employee
            {
                EId = e.EId,
                EName = e.EName,
                EEngName = e.EEngName,
                EPhoto = e.EPhoto,
                EExplain = e.EExplain,
            };
            ViewBag.Coach = query2.ToList();
            return View();


        }
        public IActionResult Knowledge()
        {
            return View();
        }
        public IActionResult News()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Reserve()
        {
            return View();
        }



        //[HttpPost]
        //public ActionResult Edit(long id, TodoItem itemForm)
        //{
        //    TodoItem itemDb = this._context.TodoItems.Find(id);
        //    itemDb.Name = itemForm.Name;
        //    itemDb.IsComplete = itemForm.IsComplete ?? false;
        //    this._context.SaveChanges();
        //    return Redirect("/todo/index");
        //    // return Content("OK");
        //    // return Content("OK: name: " + item.TodoItemId);
        //}

        //public ActionResult Edit(long id)
        //{
        //    var query = from o in this._context.TodoItems
        //               where o.TodoItemId == id
        //               select o;
        //    TodoItem item = query.FirstOrDefault();
        //    if (item == null) {
        //        return Content("Not found");
        //    }
        //    return View("Edit", item);
        //    // TodoItem item = this._context.TodoItems.Find(id);
        //    // return Content(item.Name);
        //    // return View();
        //    // return Content("OK: " + id.ToString());
        //}


    }
}
