using System;

namespace Domain.SnorkelAggregate
{
    public class SnorkelSupport
    {
        public Guid Id { get; set; }
        public SnorkelSupportType Type { get; set; }
        public string ApplicationUserId { get; set; }
        public Guid SnorkelId { get; set; }
    }
}
