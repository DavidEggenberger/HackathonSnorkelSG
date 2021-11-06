using System;
using System.Collections.Generic;

namespace Domain.SnorkelAggregate
{
    public class Image
    {
        public Guid Id { get; set; }
        public Guid SnorkelId { get; set; }
        public string Base64Data { get; set; }
        public string ImageAddress { get; set; }
    }
}
