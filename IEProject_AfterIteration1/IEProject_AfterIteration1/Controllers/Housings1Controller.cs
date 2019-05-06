using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IEProject_AfterIteration1.Models;

namespace IEProject_AfterIteration1.Controllers
{
    public class Housings1Controller : Controller
    {
        private HousingNorm db = new HousingNorm();

        // GET: Housings1
        public ActionResult Index()
        {
            return View(db.Housings.ToList());
        }

        // GET: Housings1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Housing housing = db.Housings.Find(id);
            if (housing == null)
            {
                return HttpNotFound();
            }
            return View(housing);
        }

        // GET: Housings1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Housings1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Suburb,Rent,Distance,SchoolNo,CrimeNo,Buy_Price,HospitalNo,SupermarketNo,StationNo,NormRent,NormDistance,NormSchools,NormCrime,NormHospital,NormSupermarket,NormStation")] Housing housing)
        {
            if (ModelState.IsValid)
            {
                db.Housings.Add(housing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(housing);
        }

        // GET: Housings1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Housing housing = db.Housings.Find(id);
            if (housing == null)
            {
                return HttpNotFound();
            }
            return View(housing);
        }

        // POST: Housings1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Suburb,Rent,Distance,SchoolNo,CrimeNo,Buy_Price,HospitalNo,SupermarketNo,StationNo,NormRent,NormDistance,NormSchools,NormCrime,NormHospital,NormSupermarket,NormStation")] Housing housing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(housing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(housing);
        }

        // GET: Housings1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Housing housing = db.Housings.Find(id);
            if (housing == null)
            {
                return HttpNotFound();
            }
            return View(housing);
        }

        // POST: Housings1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Housing housing = db.Housings.Find(id);
            db.Housings.Remove(housing);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult Results(List<int> valuesa)
        {
            IQueryable<Housing> test1 = from p in db.Housings select p;
            /*var test1 = db.Housings.AsQueryable();
            var test1 = test1.Where(t => t.NormSchools >= values[0]);
            var test1 = test1.Where(t => t.NormCrime >= values[1]);*/
            /* var test2 = test1
                 .Select(s => new { s.Suburb, s.NormRent, s.NormDistance, s.NormHospital,s. })
                 .Where(c => c.NormRent >= values[1] && c.NormHospital >= values[2] && c.NormDistance >= values[2]);
             */
            int[] values = valuesa.ToArray();
            var temp = 0;
            var max = 0;
             for (int i=0;i<values.Length;i++)
            {
                if (max < values[i])
                {
                    max = values[i];
                    temp = i;
                }
            }
            int School = values[0];
            int Crime = values[1];
            int Rent = values[2];
            int Hospital = values[3];
            int Distance = values[4];
            int Station = values[5];
            int Supermarket = values[6];
            //var test2 = test1.Where(c => c.NormCrime >= Crime && c.NormSchools >= School && c.NormRent >= Rent && c.NormHospital >= Hospital && c.NormDistance >= Distance && c.NormStation >= Station && c.NormSupermarket >= Supermarket);
            //IEnumerable<Housing_Results> test3 = test2.Select(s => new { Suburb = s.Suburb, Rent = s.Rent, SchoolNo = s.SchoolNo, StationNo = s.StationNo, SupermarketNo = s.SupermarketNo, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo }).ToList();
            //Debug.WriteLine(test3.ToList());
            /*IEnumerable<Housing> query = (from res in db.Housings
                                          select
                                               {Suburb = res.Suburb,SchoolNo = res.SchoolNo,Rent = res.Rent,StationNo = res.StationNo,SupermarketNo = res.SupermarketNo,NormSupermarket = res.NormSupermarket, NormStation = res.NormStation, NormSchools = res.NormSchools, NormRent = res.NormRent, NormHospital = res.NormHospital, NormDistance = res.NormDistance, NormCrime = res.NormCrime, HospitalNo = res.HospitalNo, Distance = res.Distance, CrimeNo = res.CrimeNo, Buy_Price = res.Buy_Price })
                                               .Where(c => c.NormCrime >= Crime && c.NormSchools >= School && c.NormRent >= Rent && c.NormHospital >= Hospital && c.NormDistance >= Distance && c.NormStation >= Station && c.NormSupermarket >= Supermarket).ToList();
            */
            /*IEnumerable<Housing> query = from res in db.Housings
                                          .Select(res => res.Suburb,res.SchoolNo,res.Rent,res.StationNo, res.SupermarketNo, res.NormSupermarket,  res.NormStation,  res.NormSchools,  res.NormRent,  res.NormHospital,  res.NormDistance,  res.NormCrime,  res.HospitalNo,  res.Distance,  res.CrimeNo, res.Buy_Price )
                                               .where(c => c.NormCrime >= Crime && c.NormSchools >= School && c.NormRent >= Rent && c.NormHospital >= Hospital && c.NormDistance >= Distance && c.NormStation >= Station && c.NormSupermarket >= Supermarket).ToList();

            IEnumerable<Housing_Results> test3 = query.Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.Rent, SchoolNo = s.SchoolNo, StationNo = s.StationNo, SupermarketNo = s.SupermarketNo, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo });
            */
            var query = from c in db.Housings
                        where (c.NormCrime >= Crime && c.NormSchools >= School && c.NormRent >= Rent && c.NormHospital >= Hospital && c.NormDistance >= Distance && c.NormStation >= Station && c.NormSupermarket >= Supermarket)
                        select c;
            var test3 = query.Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.Rent, SchoolNo = s.SchoolNo, StationNo = s.StationNo, SupermarketNo = s.SupermarketNo, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo }).ToList().Take(5);
            switch (temp)
            {
                case 0:
                    test3 = query.Select(s => new Housing_Results{ Suburb = s.Suburb, Rent = s.Rent, SchoolNo = s.SchoolNo, StationNo = s.StationNo, SupermarketNo = s.SupermarketNo, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo }).ToList().OrderByDescending(t => t.SchoolNo).Take(5);
                    break;
                case 1:
                    test3 = query.Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.Rent, SchoolNo = s.SchoolNo, StationNo = s.StationNo, SupermarketNo = s.SupermarketNo, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo }).ToList().OrderBy(s => s.CrimeNo).Take(5);
                    break;
                case 2:
                    test3 = query.Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.Rent, SchoolNo = s.SchoolNo, StationNo = s.StationNo, SupermarketNo = s.SupermarketNo, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo }).ToList().OrderBy(t => t.Rent).Take(5);
                    break;
                case 3:
                    test3 = query.Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.Rent, SchoolNo = s.SchoolNo, StationNo = s.StationNo, SupermarketNo = s.SupermarketNo, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo }).ToList().OrderByDescending(t => t.HospitalNo).Take(5);
                    break;
                case 4:
                    test3 = query.Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.Rent, SchoolNo = s.SchoolNo, StationNo = s.StationNo, SupermarketNo = s.SupermarketNo, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo }).ToList().OrderBy(t => t.Distance).Take(5);
                    break;
                case 5:
                    test3 = query.Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.Rent, SchoolNo = s.SchoolNo, StationNo = s.StationNo, SupermarketNo = s.SupermarketNo, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo }).ToList().OrderByDescending(t => t.StationNo).Take(5);
                    break;
                case 6:
                    test3 = query.Select(s => new Housing_Results { Suburb = s.Suburb, Rent = s.Rent, SchoolNo = s.SchoolNo, StationNo = s.StationNo, SupermarketNo = s.SupermarketNo, HospitalNo = s.HospitalNo, Distance = s.Distance, CrimeNo = s.CrimeNo }).ToList().OrderByDescending(t => t.SupermarketNo).Take(5);
                    break;
            }
            Session["Suburbs"] = test3.Select(t => t.Suburb).ToList();
            return View(test3);
        }

        [HttpPost]
        public ActionResult Results(String SchoolType)
        {
            Debug.WriteLine(SchoolType);
            return RedirectToAction("UpdateResults", "Housings1", new { @schooltype = SchoolType});
        }

        public ActionResult UpdateResults(String schooltype/*, bool bool0, bool bool1, bool bool2, bool bool3, bool bool4, bool bool5*/)
        {

            var temp_subs = (List<String>)Session["Suburbs"];
            List<bool> blanks = new List<bool>();
            if (int.Parse(schooltype) == 1)
            {
                ViewBag.SchoolType = "Primary";
            }
            else if (int.Parse(schooltype) == 2)
            {
                ViewBag.SchoolType = "Secondary";
            }
            else
            {
                ViewBag.SchoolType = "Special";
            }
            /*blanks.Add(bool0);
            blanks.Add(bool1);
            blanks.Add(bool2);
            //List<int> price = new List<int>();
            int price = 0;
            if(bool0)
            {
                price = 250;
            }
            if(bool1)
            {
                price = 500;
            }
            if (bool2)
            {
                price = 2000;
            }*/
            var test1 = Update(schooltype/*, price, blanks*/);
            return View(test1.OrderByDescending(t => t.SchoolNo));
            //return View();
        }

        internal IEnumerable<Updated_Results> Update(String schooltype)
        {
            var temp_subs = (List<String>)Session["Suburbs"];
            /*var a = variable[0];
            var b = variable[1];
            var c = variable[2];*/
            /*IEnumerable<Updated_Result> query = (from res in db.Schools
                                                 where temp_subs.Contains(res.Suburb)
                                                 orderby res.PrimaryNo,res.SecondaryNo
                                                 select new
                                                 {
                                                     Suburb = res.Suburb,
                                                 }).ToList().Select(x => new Updated_Result { Suburb = x.Suburb });
            */
            IEnumerable<Updated_Results> query;
            if (schooltype.Equals("1"))
            {
                query = (from res in db.Schools
                         where temp_subs.Contains(res.Suburb)
                         orderby (res.PrimaryNo)
                         select new
                         {
                             Suburb = res.Suburb,
                             SchoolNo = res.PrimaryNo
                         }).ToList().Select(x => new Updated_Results { Suburb = x.Suburb, SchoolNo = x.SchoolNo });
            }
            else if (schooltype.Equals("2"))
            {
                query = (from res in db.Schools
                         where temp_subs.Contains(res.Suburb)
                         orderby (res.SecondaryNo)
                         select new
                         {
                             Suburb = res.Suburb,
                             SchoolNo = res.SecondaryNo
                         }).ToList().Select(x => new Updated_Results { Suburb = x.Suburb, SchoolNo = x.SchoolNo });

            }
            else
            {
                query = (from res in db.Schools
                         where temp_subs.Contains(res.Suburb)
                         orderby (res.SpecialNo)
                         select new
                         {
                             Suburb = res.Suburb,
                             SchoolNo = res.SecondaryNo
                         }).ToList().Select(x => new Updated_Results { Suburb = x.Suburb, SchoolNo = x.SchoolNo });


            }
            return query;
        }

        public PartialViewResult MapView(String Suburb)
        {
            IEnumerable<Suburb_Map> query1;
            query1 = (from res in db.Stations
                      where res.Suburb == Suburb
                      select new
                      {
                          Suburb = res.Suburb,
                          Name = res.Name,
                          Longitude = res.Longitude,
                          Latitude = res.Latitude,
                      }).ToList().Select(x => new Suburb_Map { Name = x.Name, Latitude = x.Latitude, Longitude = x.Longitude });

            IEnumerable<Suburb_Map> query2;
            query2 = (from res in db.SuperMarkets
                      where res.Suburb == Suburb
                      select new
                      {
                          Suburb = res.Suburb,
                          Name = res.Name,
                          Longitude = res.Longitude,
                          Latitude = res.Latitude,
                      }).ToList().Select(x => new Suburb_Map { Name = x.Name, Latitude = x.Latitude, Longitude = x.Longitude });

            List<Suburb_Map> final = new List<Suburb_Map>();
            foreach(var test in query1)
            {
                final.Add(test);
            }
            foreach (var test in query2)
            {
                final.Add(test);
            }
            ViewBag.SuburbMap = Suburb;
            return PartialView(final);
        }
    }
}
