﻿using System.Collections.Generic;

namespace Entities
{
    public class Bill
    {
        public int BillId { get; set; }
        public ICollection<WorkLog> WorkLogs { get; set; }
    }
}