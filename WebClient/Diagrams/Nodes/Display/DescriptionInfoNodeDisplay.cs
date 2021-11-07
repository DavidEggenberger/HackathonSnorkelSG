using Blazor.Diagrams.Core.Models;
using Domain.SnorkelAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Diagrams.Nodes.Display
{
    public class DescriptionInfoNodeDisplay : NodeModel
    {
        public Snorkel Snorkel { get; set; }
        public DescriptionInfoNodeDisplay(Blazor.Diagrams.Core.Geometry.Point position = null) : base(position)
        {
            
        }
    }
}
