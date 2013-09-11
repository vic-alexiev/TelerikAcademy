using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cars
{
    public class Model
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Extra> Extras { get; set; }
    }
}