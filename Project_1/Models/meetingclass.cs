using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace Project_1.Models
{
    public class meetingclass:Proj1_DBEntitiesContext
    {
        public List<UserAdmin> usad { get; set; }
        public List<Meeting_Details> md { get; set; }
        
    }
}