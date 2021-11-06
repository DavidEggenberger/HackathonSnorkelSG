using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SnorkelAggregate
{
    public class SnorkelComment
    {
        public Guid Id { get; set; }
        public Guid SnorkelId { get; set; }
        public Snorkel Snorkel { get; set; }
        public string ApplicationUserId { get; set; }
        public string Message { get; set; }
    }
}
