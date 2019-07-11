using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Configuration;
using System.Web.UI;
using Calibration.Models;
using System.Data.SqlClient;




namespace Calibration.Controllers
{
    public class MasterController : Controller
    {
        
        public ActionResult Index(int? page, int? PageRowNumber, String CName = "")
        {
            try
            {
                              
                StaticPagedList<CustomerList> itemsAsIPagedList;
                itemsAsIPagedList = GridList(page, PageRowNumber, CName);
                return Request.IsAjaxRequest()
                       ? (ActionResult)PartialView("Index", itemsAsIPagedList)
                       : View("Index", itemsAsIPagedList);
            }
            catch (Exception ex)
            {
                var mgs = ex.Message;
                return Json(mgs);
            }
            //return View();

        }


        public ActionResult LoadCustomerMaster(int? page, int? PageRowNumber, String CName = "")
        {
            try
            {                
                StaticPagedList<CustomerList> itemsAsIPagedList;
                itemsAsIPagedList = GridList(page, PageRowNumber, CName);
                return Request.IsAjaxRequest()
                       ? (ActionResult)PartialView("_CustomerMaster", itemsAsIPagedList)
                       : View("_CustomerMaster", itemsAsIPagedList);
            }
            catch (Exception ex)
            {
                var mgs = ex.Message;
                return Json(mgs);
            }
            //return View();

        }

        public StaticPagedList<CustomerList> GridList(int? page, int? PageRowNumber, String CName = "")
        {
            jobDbContext _db = new jobDbContext();
            var pageIndex = (page ?? 1);
            int pageSize = (PageRowNumber ?? 8);
            int totalCount = (PageRowNumber ?? 8);
            CustomerList clist = new CustomerList();

            IEnumerable<CustomerList> result = _db.CList.SqlQuery(@"exec USP_GetCustomerList
              @pPageIndex, @pPageSize,@cName",
                new SqlParameter("@pPageIndex", pageIndex),
                new SqlParameter("@pPageSize", pageSize),
                new SqlParameter("cName", CName == null ? (object)DBNull.Value : CName)
                 ).ToList<CustomerList>();

            totalCount = 0;
            if (result.Count() > 0)
            {
                totalCount = Convert.ToInt32(result.FirstOrDefault().TotalRows);
            }
            var itemsAsIPagedList = new StaticPagedList<CustomerList>(result, pageIndex, pageSize, totalCount);

            return itemsAsIPagedList;
        }

        
        public ActionResult AddCustomer()
        {
            return Request.IsAjaxRequest()
                       ? (ActionResult)PartialView("AddCustomer")
                       : View("AddCustomer");
        }
    }
}