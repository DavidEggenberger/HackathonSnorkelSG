using System;

namespace Domain
{
    public class InfoComment
    {
        public Guid Id { get; set; }
        public Guid InfoId { get; set; }
        public Info Info { get; set; }
        public string Comment { get; set; }
    }
}
