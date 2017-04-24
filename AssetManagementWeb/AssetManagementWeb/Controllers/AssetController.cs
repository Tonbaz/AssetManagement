using AssetManagementWeb.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using AssetManagementWeb.Models;
using AssetManagementWeb.Database;

namespace AssetManagementWeb.Controllers
{
    public class AssetController : Controller
    {
        // GET: Asset
        public ActionResult Index()
        {
            return View();
        }



        // GET: Asset/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Asset/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AssignLocation()
        {
            string json = Request.InputStream.ReadToEnd();
            AssigntLocationModel inputData =
                JsonConvert.DeserializeObject <AssigntLocationModel> (json);
            ToniDBEntities entities = new ToniDBEntities();


            bool succes = false;
            string error = "";
            

            try
            {
                //Haetaan eka paikan id-numero koodin perusteel
                int locationID = (from l in entities.AssetsLocations
                              where l.Code == inputData.LocationCode
                              select l.Id).FirstOrDefault();

                int assetID = (from a in entities.Assets
                                  where a.Code == inputData.AssetCode
                                  select a.Id).FirstOrDefault();

                if ((locationID > 0) && (assetID > 0))
                {
                    AssetsLocation1 newEntry = new AssetsLocation1();
                    newEntry.LocationId = locationID;
                    newEntry.AssetId = assetID;
                    newEntry.LastSeen = DateTime.Now;

                    entities.AssetsLocations1.Add(newEntry);
                    entities.SaveChanges();
                    succes = true;

                }



            }

            catch (Exception ex)
            {
                error = ex.GetType().Name + ":" + ex.Message;
            }

            finally
            {
                entities.Dispose();
            }

            //Palautetaan Json muotoinen tulos kutsujalle
            var result = new { succes = succes, error = error };
            return Json(result);
        }

        // POST: Asset/Create
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

        // GET: Asset/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Asset/Edit/5
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

        // GET: Asset/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Asset/Delete/5
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
