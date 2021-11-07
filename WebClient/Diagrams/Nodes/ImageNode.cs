using Blazor.Diagrams.Core.Models;
using Domain.SnorkelAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Diagrams.Nodes
{
    public class ImageNode : NodeModel
    {
        public Snorkel SnorkelInConfiguration { get; set; }
        public ImageNode(Blazor.Diagrams.Core.Geometry.Point position = null) : base(position)
        {
            AddPort(PortAlignment.Top);
            AddPort(PortAlignment.Bottom);
            AddPort(PortAlignment.Right);
            AddPort(PortAlignment.Left);
        }
    }
}
