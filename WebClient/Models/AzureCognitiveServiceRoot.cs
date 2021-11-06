using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class Rectangle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int W { get; set; }
        public int H { get; set; }
    }

    public class Object
    {
        public Rectangle Rectangle { get; set; }
        public string ObjectProperty { get; set; }
        public double Confidence { get; set; }
        public object Parent { get; set; }
    }

    public class Metadata
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public string Format { get; set; }
    }

    public class AzureCognitiveServiceRoot
    {
        public List<Object> Objects { get; set; }
        public string RequestId { get; set; }
        public Metadata Metadata { get; set; }
        public string ModelVersion { get; set; }
    }
}
