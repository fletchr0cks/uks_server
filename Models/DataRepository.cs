﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using HIO.Models;
using System.IO;

namespace HIO.Models
{
    public class DataRepository
    {

        private hioDataContext db = new hioDataContext();

        public void savenew(string lat, string lval, string city, string country, string comment)
        {

            User user = new User();
            user.Lat = Convert.ToDecimal(lat);
            user.Long = Convert.ToDecimal(lval);
            user.PID = "222fe9";
            user.City = city;
            user.Country = country;
            user.Comment = comment;
            user.Timestamp = DateTime.Now;
            db.Users.InsertOnSubmit(user);

            db.SubmitChanges();

        }
        
        public void updateUser(int userID)
        {

            var user = db.Users
                .Where(u => u.UserID == userID)
                .First();

            user.Timestamp = DateTime.Now;
            db.SubmitChanges();

        }

        public void MovePlace(string latval, string longval, int PID)
        {
            var place = db.places
                .Where(p => p.PID == PID)
                .First();

            place.LatVal = Convert.ToDecimal(latval);
            place.LongVal = Convert.ToDecimal(longval);
            db.SubmitChanges();

        }

        public void DeletePlace(int PID)
        {
            var place = db.places
                .Where(p => p.PID == PID)
                .First();

            place.Flag = -1;
            db.SubmitChanges();

        }

        public int checkIP(string IPaddr)
        {
            int ipchk = (from u in db.IPaddresses
                                   where (u.IPaddr == IPaddr && u.Timestamp.AddSeconds(20) > DateTime.Now)
                                   select u).Count();

            
            return ipchk;

        }

        public void logIP(string IPaddr)
        {
            IPaddress ip = new IPaddress();
            ip.IPaddr = IPaddr;
            ip.Timestamp = DateTime.Now;
            ip.UserID = 10;
            db.IPaddresses.InsertOnSubmit(ip);

            db.SubmitChanges();

        }

        public void updatePhonename(int userID, string phonename)
        {

            var user = db.Users
                .Where(u => u.UserID == userID)
                .First();

            user.Comment = phonename;
            db.SubmitChanges();

        }

        public void updateuserpass(int userID, string username, string password)
        {

            var user = db.Users
                .Where(u => u.UserID == userID)
                .First();

            user.Comment = username;
            user.Password = password;
            db.SubmitChanges();

        }

        public string SiteCount(int userID)
        {

            int sitecount = db.places
                .Where(u => u.UserID == userID)
                .Where(u => u.Flag >= 0)
                .Count();

            return Convert.ToString(sitecount);
        }

        public void AddLogin(int userID, string type)
        {
            hio_event newevent = new hio_event();
            newevent.UserID = userID;
            newevent.Event = type;
            newevent.Datetime = DateTime.Now;
            db.hio_events.InsertOnSubmit(newevent);

            if (type == "Existing")
            {

                var user = db.Users
                    .Where(u => u.UserID == userID)
                    .First();

                user.Timestamp = DateTime.Now;
            }

            db.SubmitChanges();
        }

        public void AddSnow(int UserID, string cm, string location, string name)
        {
             hio_event newevt = new hio_event();
             newevt.Datetime = DateTime.Now;
             newevt.Event = cm;
             newevt.Type = "Snow";
             newevt.UserID = UserID;
            db.hio_events.InsertOnSubmit(newevt);
            db.SubmitChanges();
        }

        public void AddColdest(int UserID, string temp, string location, string name)
        {
            hio_event newevt = new hio_event();
            newevt.Datetime = DateTime.Now;
            newevt.Event = temp;
            newevt.Type = "Temp";
            newevt.UserID = UserID;
            db.hio_events.InsertOnSubmit(newevt);
            db.SubmitChanges();
        }

        public void APIcall(int userID)
        {
            hio_event newevent = new hio_event();
            newevent.UserID = userID;
            newevent.Event = "API";
            newevent.Datetime = DateTime.Now;
            db.hio_events.InsertOnSubmit(newevent);
            db.SubmitChanges();
        }

        public void UserLoc(int userID, string latval, string longval)
        {
            user_location newloc = new user_location();
            newloc.UserID = userID;
            newloc.LatVal = Convert.ToDecimal(latval);
            newloc.LongVal = Convert.ToDecimal(longval);
            db.user_locations.InsertOnSubmit(newloc);
            db.SubmitChanges();
        }

        public string getName(int UserID)
        {
            var user = db.Users
                .Where(u => u.UserID == UserID)
                .First();

            return user.Comment;

        }


        public int AddUser(User user)
        {
            db.Users.InsertOnSubmit(user);
            db.SubmitChanges();
            return user.UserID;
        }

        public void AddComment(comment comment)
        {
            db.comments.InsertOnSubmit(comment);
            db.SubmitChanges();
        }

        public int AddPlace(place place)
        {
            db.places.InsertOnSubmit(place);
            db.SubmitChanges();
            return place.PID;
        }

        public void Add(hio_event ev)
        {
            db.hio_events.InsertOnSubmit(ev);
        }

        public void Add(IPaddress ip)
        {
            db.IPaddresses.InsertOnSubmit(ip);
        }

        public void Add(user_location loc)
        {
            db.user_locations.InsertOnSubmit(loc);
        }
    }
}
