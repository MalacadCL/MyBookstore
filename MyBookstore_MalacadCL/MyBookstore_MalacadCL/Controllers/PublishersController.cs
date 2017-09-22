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
        public ActionResult Create(PublishersModels publisher)
        {
            //try
            //{
            //    // TODO: Add insert logic here

            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}

            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"INSERT INTO publishers VALUES
                               (@pubName)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@pubName", publisher.Name);
                    cmd.ExecuteNonQuery();
                    return RedirectToAction("Index");

                }

            }
        }

        // GET: Publishers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            PublishersModels publisher = new PublishersModels();
            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"SELECT pubName WHERE pubID=@pubID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@authorID", id);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                publisher.Name = dr["pubName"].ToString();
                            }

                            return View(publisher);
                        }
                        else
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
            }
        }

        // POST: Publishers/Edit/5
        [HttpPost]
        public ActionResult Edit(PublishersModels publisher)
        {
            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"UPDATE publishers SET pubName=@pubName WHERE pubID=@pubID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@pubName", publisher.Name);
                    cmd.ExecuteNonQuery();
                    return RedirectToAction("Index");
                }
            }
        }

        // GET: Publishers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            using (SqlConnection con = new SqlConnection(Helper.GetCon()))
            {
                con.Open();
                string query = @"DELETE FROM publisher WHERE pubID=@pubID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("pubID", id);
                    cmd.ExecuteNonQuery();
                    return RedirectToAction("Index");
                }
            }
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
