﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace ViewModels.Application
{
    public class ApplicationCardViewModel
    {
        public IEnumerable<Core.Entities.Application> Applications { get; set; }
    }
}
