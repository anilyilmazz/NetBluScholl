using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetBluSchool.Models
{
    public class BluethoothSearchView
    {
        public int LessonId { get; set; }
        public List<BluethoothDevice> BluList { get; set; }
    }
}