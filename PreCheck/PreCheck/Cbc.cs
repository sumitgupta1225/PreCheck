using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PreCheck
{
    public class Cbc
    {
        public List<customBenchmarkGroups> customBenchmarkGroups { get; set; }
    }

    public class customBenchmarkGroups
    {
        public string id { get; set; }
    }
}