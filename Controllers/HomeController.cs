using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc.Ajax;
using HIO.Models;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Xml.Serialization;

namespace HIO.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {

        DataRepository dataRepository = new DataRepository();
        private hioDataContext db = new hioDataContext();


        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

       
        public ActionResult Save(string lat, string lval, string city, string country, string comment)
        {
           

            ViewData["Message"] = lat + "  " + lval;

            dataRepository.savenew(lat, lval, city, country, comment);

            return View();

        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult GetAllUsers()
        {
            var dataContext = new hioDataContext();

            var data = from ev in dataContext.Users
                       orderby ev.UserID descending
                       select new
                       {
                           latitude = ev.Lat,
                           longitude = ev.Long,
                           title = ev.Comment,
                           content = ev.City,
                           timestamp = Convert.ToString(ev.Timestamp)

                       };
            //new { gloss_list = GlossaryList, answer = desc }
            return Json(new { markers = data.Distinct() });
        }
        
        public JsonResult GetAllUsersPlain()
        {
            var dataContext = new hioDataContext();

            var data = from ev in dataContext.Users
                       orderby ev.UserID descending
                       select new
                       {
                           latitude = ev.Lat,
                           longitude = ev.Long,
                           title = ev.Comment,
                           content = ev.City,
                           timestamp = Convert.ToString(ev.Timestamp)

                       };
            //new { gloss_list = GlossaryList, answer = desc }
            return Json(new { markers = data.Distinct() });
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult GetAllUsersPost()
        {
            var dataContext = new hioDataContext();

            var data = from ev in dataContext.Users
                       orderby ev.UserID descending
                       select new
                       {
                           latitude = ev.Lat,
                           longitude = ev.Long,
                           title = ev.Comment,
                           content = ev.City,
                           timestamp = Convert.ToString(ev.Timestamp)

                       };
            //new { gloss_list = GlossaryList, answer = desc }
            return Json(new { markers = data.Distinct() });
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetAllUsersNew()
        {
            var dataContext = new hioDataContext();

            var data = from ev in dataContext.Users
                       orderby ev.UserID descending
                       select new
                       {
                           latitude = ev.Lat,
                           longitude = ev.Long,
                           title = ev.Comment,
                           content = ev.City,
                           timestamp = Convert.ToString(ev.Timestamp)

                       };

         
            //new { gloss_list = GlossaryList, answer = desc }
            return new JsonpResult(data.Distinct());
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ListMySites(int userid)
        {
            var dataContext = new hioDataContext();

            var data = from pl in dataContext.places
                       where pl.UserID == userid
                       where pl.Flag >= 0
                       orderby pl.Name descending
                       select new
                       {
                           latitude = pl.LatVal,
                           longitude = pl.LongVal,
                           name = pl.Name,
                           PID = pl.PID,

                       };
            return new JsonpResult(new { sites = data, ct = data.Count() });
        }

        public ActionResult ListAllSites()
        {
            var dataContext = new hioDataContext();

            var data = from pl in dataContext.places
                       orderby pl.Name descending
                       select pl;

            return View(data);
        }

        public ActionResult CommentsPartial(int PID)
        {
            var dataContext = new hioDataContext();

            var data = from pl in dataContext.comments
                       //orderby pl.Name descending
                       select pl;

            return PartialView("CommentsPartial", data);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetSitesInRange(string bounds)
        {
            var dataContext = new hioDataContext();
            string[] boundsbits = bounds.Split(',');
            var latS = boundsbits[0];
            var longW = boundsbits[1];
            var latN = boundsbits[2];
            var longE = boundsbits[3];

            var data = from pl in dataContext.places
                       where (pl.LatVal >= Convert.ToDecimal(latS) && pl.LatVal <= Convert.ToDecimal(latN))
                       where (pl.LongVal >= Convert.ToDecimal(longW) && pl.LongVal <= Convert.ToDecimal(longE))
                       where pl.Flag >= 0
                       orderby pl.Name descending
                       select new
                       {
                           lat = Convert.ToString(pl.LatVal),
                           longval = Convert.ToString(pl.LongVal),
                           name = pl.Name,
                           PID = pl.PID,
                       };

            int ct = data.Count();

            return new JsonpResult(new {points = data, ct = ct});
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ListComments(int PID)
        {
            var dataContext = new hioDataContext();

            var data = from pl in dataContext.comments
                       where pl.PlaceID == PID
                       orderby pl.Datetime descending
                       select new
                       {
                           datetime = Convert.ToString(pl.Datetime),
                           comment = pl.Comment1,
                           username = pl.User.Comment,
                           CID = pl.CID,

                       };
            return new JsonpResult(new { cmts = data, ct = data.Count() });
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult ListPlaces(string search_str)
        {
              var ipaddr = Request.ServerVariables["REMOTE_ADDR"];
             dataRepository.logIP(ipaddr);
                var ipstatus = dataRepository.checkIP(ipaddr);
                if (ipstatus >= 3)
                {
                    var statusmsg = "No";
                    return new JsonpResult(new { status = "-2", statusmsg = statusmsg });
                }
                else
                {

                    var dataContext = new hioDataContext();

                    var data = from pl in dataContext.places
                               join u in dataContext.Users on pl.UserID equals u.UserID
                               where (pl.Name.Contains(search_str) || pl.Town.Contains(search_str) || u.Comment.Contains(search_str))
                               where pl.Flag >= 0
                               orderby pl.Name ascending
                               select new
                               {
                                   latitude = pl.LatVal,
                                   longitude = pl.LongVal,
                                   name = pl.Name,
                                   PID = pl.PID,
                                   town = pl.Town,
                                   username = u.Comment
                               };
                    return new JsonpResult(new { sites = data, ct = data.Count() });
                }
        }

        public ActionResult SaveBrowser(string username, string password, string newu)
        {
            var dataContext = new hioDataContext();
           

             var ipaddr = Request.ServerVariables["REMOTE_ADDR"];
             dataRepository.logIP(ipaddr);
                var ipstatus = dataRepository.checkIP(ipaddr);
                if (ipstatus >= 3)
                {
                    var statusmsg = "No";
                    //(from u in dataContext.notices
                    //                 where u.NID == 3
                    //               select u).First().Ann_content;
                    return new JsonpResult(new { status = "-2", statusmsg = statusmsg });

                }
                else
                {
                    int APIcallsAllowed = (from u in dataContext.Settings
                                           where u.id == 1
                                           select u).First().APIcalls;
                    var siteCount = "0";
                    int userID;
               
                    int APIcalls_today = (from ev in dataContext.hio_events
                                          where ev.Event == "API"
                                          where ev.Datetime >= DateTime.Now.AddDays(-1)
                                          select ev).Count();

                    var APIcalls = "0";
                    if (APIcallsAllowed - APIcalls_today > 0)
                    {
                        APIcalls = "1";
                    }
                    else
                    {
                        APIcalls = "0";
                    }


                    var total_sites = (from ev in dataContext.places
                                       where ev.Flag >= 0
                                       select ev).Count();

                    var latest_pl = from p in dataContext.places
                                    where p.Flag >= 0
                                    orderby p.PID descending
                                    select p;

                    var latest_nm = latest_pl.First().Username;
                    var latest_town = latest_pl.First().Town;

                    if (newu == "true")
                    {
                        //adduser0
                        var usertype = "New User";
                        User newuser = new User();
                        newuser.PID = "nondroid";
                        newuser.Timestamp = DateTime.Now;
                        newuser.Comment = username;
                        newuser.Password = password;
                        //add user, get ID, write event
                        var newuserID = dataRepository.AddUser(newuser);
                        userID = Convert.ToInt32(newuserID);
                        dataRepository.AddLogin(userID, usertype);

                        return new JsonpResult(new { lat_nm = latest_nm, lat_tn = latest_town, total = total_sites, APIcalls = APIcalls, site_ct = siteCount, userID = newuserID });

                    }
                    else
                    {

                        if (username == "undefined" && password == "undefined")
                        {
                            return new JsonpResult(new { lat_nm = latest_nm, lat_tn = latest_town, total = total_sites, APIcalls = APIcalls, site_ct = siteCount, status = "0" });
                            //not in db

                        }
                        else
                        {
                            //are in db
                            var userchk = (from u in dataContext.Users
                                           where (u.Comment == username && u.Password == password)
                                           select u).Count();
                            if (userchk == 1)
                            {
                                //password ok
                                var usertype = "Existing";
                                var userd = from u in dataContext.Users
                                            where (u.Comment == username && u.Password == password)
                                            select u;

                                userID = userd.First().UserID;

                                dataRepository.AddLogin(Convert.ToInt32(userID), usertype);
                                dataRepository.updateUser(Convert.ToInt32(userID));
                                siteCount = dataRepository.SiteCount(Convert.ToInt32(userID));

                                return new JsonpResult(new { lat_nm = latest_nm, lat_tn = latest_town, total = total_sites, APIcalls = APIcalls, userID = userID, site_ct = siteCount, status = "1" });



                            }
                            else
                            {
                                //incorrect deets
                                return new JsonpResult(new { status = "-1" });
                            }


                        }

                    }
                }
        }


        public ActionResult SaveID(string phoneID)
        {
            var dataContext = new hioDataContext();

            var userchk = (from u in dataContext.Users
                           where u.PID == phoneID
                           select u).Count();

            int APIcallsAllowed = (from u in dataContext.Settings
                                   where u.id == 1
                                   select u).First().APIcalls;

            int userID;
            var siteCount = "0";
            var phonename = "No name";

            if (userchk == 1)
            {
                //update user, write event
                var usertype = "Existing";
                var userd = from u in dataContext.Users
                            where u.PID == phoneID
                            select u;
                userID = userd.First().UserID;
                phonename = userd.First().Comment;
                dataRepository.AddLogin(Convert.ToInt32(userID), usertype);
                //dataRepository.updateUser(Convert.ToInt32(userID));
                siteCount = dataRepository.SiteCount(Convert.ToInt32(userID));

            }
            else
            {
                var usertype = "New User";
                User newuser = new User();
                newuser.PID = phoneID;
                newuser.Timestamp = DateTime.Now;
                //add user, get ID, write event
                var newuserID = dataRepository.AddUser(newuser);
                userID = Convert.ToInt32(newuserID);
                dataRepository.AddLogin(userID, usertype);

            }


            int APIcalls_today = (from ev in dataContext.hio_events
                                  where ev.Event == "API"
                                  where ev.Datetime >= DateTime.Now.AddDays(-1)
                                  select ev).Count();

            var APIcalls = "0";
            if (APIcallsAllowed - APIcalls_today > 0)
            {
                APIcalls = "1";
            }
            else
            {
                APIcalls = "0";
            }


            var total_sites = (from ev in dataContext.places
                               where ev.Flag >= 0
                               select ev).Count();

            var latest_pl = from p in dataContext.places
                            where p.Flag >= 0
                            orderby p.PID descending
                            select p;

            var latest_nm = latest_pl.First().Username;
            var latest_town = latest_pl.First().Town;

            //new { gloss_list = GlossaryList, answer = desc }
            return new JsonpResult(new { lat_nm = latest_nm, lat_tn = latest_town, total = total_sites, APIcalls = APIcalls, userID = userID, Name = phonename, site_ct = siteCount });
        }   

         public ActionResult GetWeather(int userID, string latval, string longval)
        {
            dataRepository.APIcall(userID);
            //dataRepository.UserLoc(userID,latval,longval);

            return new JsonpResult(new { status = "Done" });
        }

         public ActionResult SavePlace(int userID, string latval, string longval, string placename, string comment, string town, string username)
         {


             place newplace = new place();
             newplace.UserID = userID;
             newplace.LatVal = Convert.ToDecimal(latval);
             newplace.LongVal = Convert.ToDecimal(longval);
             newplace.Name = placename;
             newplace.Username = username;
             newplace.Flag = 0;
             newplace.Town = town;

             var newplaceID = dataRepository.AddPlace(newplace);

             comment newcomm = new comment();
             newcomm.Comment1 = comment;
             newcomm.PlaceID = newplaceID;
             newcomm.UserID = userID;
             newcomm.Datetime = DateTime.Now;
 
             dataRepository.AddComment(newcomm);
             db.SubmitChanges();

             return new JsonpResult("Done");
         }

         public ActionResult AddSnowEvent(int UserID, string cm, string location, string name)
         {
             dataRepository.AddSnow(UserID, cm, location, name);
             
             return new JsonpResult("Done");
         }

         public ActionResult AddColdest(int UserID, string temp, string location, string name)
         {
             dataRepository.AddColdest(UserID, temp, location, name);

             return new JsonpResult("Done");
         }

         public ActionResult MovePlace(string latval, string longval, int PID)
         {          
             dataRepository.MovePlace(latval, longval, PID);            
             return new JsonpResult("Done");
         }

         public ActionResult DeletePlace(int PID)
         {
             dataRepository.DeletePlace(PID);
             return new JsonpResult("Done");
         }

         public ActionResult SavePhonename(string phonename, int userid)
         {
             dataRepository.updatePhonename(userid,phonename);
             return new JsonpResult("Done");
         }

         public ActionResult SaveLoginDetails(string phonename, int userid, string password)
         {
             
             
             
             //dataRepository.updateuserpass(userid, phonename, password);
             return new JsonpResult("Done");
         }

         public ActionResult SaveComment(int PID, int userID, string comment, string flag)
         {
             var username = dataRepository.getName(userID);
             comment newcomm = new comment();
             newcomm.Comment1 = comment;
             newcomm.PlaceID = PID;
             newcomm.UserID = userID;
             newcomm.Datetime = DateTime.Now;

             dataRepository.AddComment(newcomm);

             if (flag == "yes")
             {
                 comment newcomm2 = new comment();
                 newcomm2.Comment1 = username + " flagged this site for the Moderator.";
                 newcomm2.PlaceID = PID;
                 newcomm2.UserID = userID;
                 newcomm2.Datetime = DateTime.Now;
                 dataRepository.AddComment(newcomm2);
             }

             var dataContext = new hioDataContext();
             var data = from pl in dataContext.comments
                        where pl.PlaceID == PID
                        orderby pl.Datetime descending
                        select new
                        {
                            datetime = Convert.ToString(pl.Datetime),
                            comment = pl.Comment1,
                            username = pl.User.Comment,
                            CID = pl.CID,

                        };
             return new JsonpResult(new { cmts = data, ct = data.Count() });

         }

         public ActionResult EditPlace(int userID, string latval, string longval, string placename, string comment, int delete)
         {
       

             return new JsonpResult("Done");
         }


 
    }
}
