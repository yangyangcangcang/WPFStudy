﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.wuqiang.courseManagement.Model
{
    public class SeriesModel
    {
        public string SeriesName { get; set; }
        public int CurrentValue { get; set; }
        public bool IsGrowing { get; set; }
        public int ChangeRate { get; set; }
    }
}
