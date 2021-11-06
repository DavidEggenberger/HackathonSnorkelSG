using Domain.SnorkelAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ImageTagAggregate.InfoTypes
{
    public class HistoryInfo : Info
    {
        public int Year { get; set; }
        public string Event { get; set; }
    }
}
