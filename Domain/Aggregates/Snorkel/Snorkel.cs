using System;
using System.Collections.Generic;

namespace Domain.Aggregates.Snorkel
{
    public class Snorkel
    {
        public Guid Id { get; set; }
        public string ApplicationUserId { get; set; }
        public string Name { get; set; }
        public double Lattitude { get; set; }
        public double Longitude { get; set; }
        public Image Image { get; set; }
        public List<SnorkelSupport> SnorkelSupports { get; set; }
    }
}
