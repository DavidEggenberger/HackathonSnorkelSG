﻿using System;

namespace Domain
{
    public class SnorkelSupport
    {
        public Guid Id { get; set; }
        public SnorkelSupportType Type { get; set; }
        public string ApplicationUserId { get; set; }
        public Guid SnorkelId { get; set; }
        public Snorkel Snorkel { get; set; }
    }
}
