﻿using System;
using System.Collections.Generic;

namespace Domain.ImageTagAggregate
{
    public class Info
    {
        public Guid Id { get; set; }
        public Guid ImageTagId { get; set; }
        public List<InfoComment> InfoComments { get; set; }
    }
}