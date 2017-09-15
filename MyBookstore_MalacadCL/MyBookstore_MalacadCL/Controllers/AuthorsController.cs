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
    public class AuthorsController : Controller
    {
        [HttpGet]
        // GET: Authors
        public ActionResult Index()
        {
            List<AuthorsModels> list = new List<AuthorsModels>();
            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"SELECT authorID, authorLN, 
                                authorFN, authorPhone, 
                                authorAddress, authorCity, 
                                authorState, authorZip 
                                FROM authors";
                using (SqlCommand cmd = new SqlCommand(query,con))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            foreach (DataRow row in dt.Rows)
                            {
                                var author = new AuthorsModels();
                                author.ID = Convert.ToInt32(row["authorID"].ToString());
                                author.LastName = row["authorLN"].ToString();
                                author.FirstName = row["authorFN"].ToString();
                                author.Phone = row["authorPhone"].ToString();
                                author.Address = row["authorAddress"].ToString();
                                author.City = row["authorCity"].ToString();
                                author.State = row["authorState"].ToString();
                                author.Zip = row["authorZip"].ToString();
                                list.Add(author);
                            }
                        }
                    }
                }

            }
           
                return View(list);
        }

        // GET: Authors/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
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

        // GET: Authors/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Authors/Edit/5
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

        // GET: Authors/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Authors/Delete/5
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
