using System;
using System.Collections.Generic;

namespace Domain
{
    public class ImageTag
    {
        public Guid Id { get; set; }
        public Guid ImageId { get; set; }
        public string Object { get; set; }
        public double Percentage { get; set; }
        public List<Info> Infos { get; set; }
    }
}
