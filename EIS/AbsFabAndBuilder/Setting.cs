﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AbsFabAndBuilder
{
    public abstract class Setting
    {
        public bool HaveMagic { get; set; }
        public bool IsToday { get; set; }
        public bool HaveWar { get; set; }
    }
}
