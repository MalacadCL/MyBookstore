using MyBookstore_MalacadCL.App_Code;
using MyBookstore_MalacadCL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace MyBookstore_MalacadCL.Controllers
{
    public class PublishersController : Controller
    {
        [HttpGet]
        // GET: Publishers
        public ActionResult Index()
            {
                List<PublishersModels> list = new List<PublishersModels>();
                using (SqlConnection con = new SqlConnection(Helper.GetCon()))
                {
                    con.Open();
                    string query = @"SELECT pubID, pubName 
                                FROM publishers";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dt = new DataTable())
                            {
                                da.Fill(dt);
                                foreach (DataRow row in dt.Rows)
                                {
                                var publisher = new PublishersModels();
                                publisher.ID = Convert.ToInt32(row["pubID"].ToString());
                                publisher.Name = row["pubName"].ToString();
                                list.Add(publisher);
                                }
                            }
                        }
                    }
                }

            return View(list);
            }
        

        // GET: Publishers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Publishers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Publishers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Publishers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Publishers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Publishers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Publishers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
