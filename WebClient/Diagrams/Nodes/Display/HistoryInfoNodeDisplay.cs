using Blazor.Diagrams.Core.Models;
using Domain.SnorkelAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Diagrams.Nodes.Display
{
    public class HistoryInfoNodeDisplay : NodeModel
    {
        public Snorkel SnorkelInConfiguration { get; set; }

        public HistoryInfoNodeDisplay(Blazor.Diagrams.Core.Geometry.Point position = null) : base(position)
        {
            
        }
    }
}
