﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingDomain
{
    public class SystemTime : ISystemTime
    {
        public DateTime GetCurrent()
        {
            return DateTime.Now; // THIS IS THE ONLY PLACE YOU CAN USE THIS.
        }
    }
}
