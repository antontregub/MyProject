using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using test.Models;
using PagedList;

namespace test.Controllers
{
    public class HomeController : Controller
    {
        TenderContext db = new TenderContext();
        // private SqlConnection sql;
 
         public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
         {

             ViewBag.CurrentSort = sortOrder;
             // ViewBag.CategorySortParm = String.IsNullOrEmpty(sortOrder) ? "Category" : "";
             ViewBag.CategorySortParm = sortOrder == "Category" ? "Sum" : "Category";
             ViewBag.DateSortParm = sortOrder == "Date" ? "Category" : "Date";
             ViewBag.SumSortPar = sortOrder == "Sum" ? "Category" : "Sum";
             if (searchString != null)
             {
                 page = 1;
             }
             else
             {
                 searchString = currentFilter;
             }

             ViewBag.CurrentFilter = searchString;

             var tend = from s in db.Tenders
                            select s;
            // ViewBag.position = searchString;
             if (!String.IsNullOrEmpty(searchString))
             {
                 tend = tend.Where(s => s.tender.Contains(searchString)
                                        || s.description.Contains(searchString));
             }
             switch (sortOrder)
             {
                   case "Category":
                     tend = tend.OrderByDescending(s => s.category);
                   break;
                 case "Date":
                     tend = tend.OrderBy(s => s.date);
                     break;
                 case "Sum":
                     tend = tend.OrderBy(s => s.initial_rate);
                     break;
                 default:
                     tend = tend.OrderBy(s => s.tender);
                     break;
             }
             int pageSize = 2;
             int pageNumber = (page ?? 1);
             return View(tend.ToPagedList(pageNumber, pageSize));
         }

        public ActionResult TenderPage(int itemId)
        {
            var Item = db.Tenders.FirstOrDefault(x => x.Id == itemId);
            return View(Item);
        }

    }
}