using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HIO.Models
{
     public partial class place
    {

         public IEnumerable<comment> AllComments(int PID)
         {
             return from comment in comments
                    where comment.PlaceID == PID 
                    select (comment);
         }
    
    }
}