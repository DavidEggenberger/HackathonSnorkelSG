using System;
using System.Collections.Generic;

namespace Domain.Aggregates.Snorkel
{
    public class Image
    {
        public Guid Id { get; set; }
        public Guid SnorkelId { get; set; }
        public Snorkel Snorkel { get; set; }
        public string Base64Data { get; set; }
    }
}
