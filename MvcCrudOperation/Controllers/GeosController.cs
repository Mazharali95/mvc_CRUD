using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MvcCrudOperation.Models;
using System.Web.Mvc;

namespace MvcCrudOperation.Controllers
{
    public class GeosController : Controller
    {

        GeosDBModel dbHandle = new GeosDBModel();
        // GET: Geos
        public ActionResult Index(int? i, string search)
        {
            GeosDBModel dbhandle = new GeosDBModel();
            string constring = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            SqlConnection MySqlConn = new SqlConnection(constring);
            string MySqlQuery = "select * from tblEmployees  where Name Like '%" + search + "%'";
            SqlCommand cmd = new SqlCommand(MySqlQuery, MySqlConn);
            MySqlConn.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            List<GeosModel> gmodel = new List<GeosModel>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                gmodel.Add(
                    new GeosModel
                    {

                        id = Convert.ToInt32(dr["id"]),
                        Name = Convert.ToString(dr["Name"]),
                        DeptName = Convert.ToString(dr["DeptName"]),




                    });

               }
               if (gmodel.Count() == 0)
               {
                  Response.Write("<script>alert('sorry no data foud')</script>");

              }


                   MySqlConn.Close();
            ModelState.Clear();
            return View(gmodel.ToList());
            
            //return View(dbHandle.GetStudent());
        }

        // GET: Geos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Geos/Create
        public ActionResult Create()    
        {
            return View();
        }

        // POST: Geos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Dailogs");
            }
            catch
            {
                return View();
            }
        }

        //GET: Geos/Edit
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return PartialView("addrecord", dbHandle.GetStudent().Find(model => model.id == id));
            //return View(dbHandle.GetStudent().Find(model => model.id==id));
        }


        // POST: Geos/Dailogs/5
        [HttpPost]
        public ActionResult Edit(int id, GeosModel smodel)
        {
            try
            {
                GeosDBModel sdb = new GeosDBModel();
                sdb.UpdateDetails(smodel);


                return RedirectToAction("Dailogs");
            }
            catch
            {
                return View();
            }
        }

        // GET: Geos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Geos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Dailogs");
            }
            catch
            {
                return View();
            }
        }
    }
}
