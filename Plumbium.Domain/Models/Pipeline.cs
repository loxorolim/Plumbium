﻿using System;

namespace Plumbium.Domain.Models
{
    public class Pipeline
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public int TotalProgress { get; set; }
        public int CurrentProgress { get; set; }

        public int ProgressPercentage => TotalProgress == 0 ? 0 : (CurrentProgress * 100 / TotalProgress);
    }
}
