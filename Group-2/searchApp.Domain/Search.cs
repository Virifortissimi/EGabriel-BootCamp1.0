using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace searchApp.Domain
{
    public class Search : BaseEntity
    {
        public List<string>? Answer { get; set; }
    }
}