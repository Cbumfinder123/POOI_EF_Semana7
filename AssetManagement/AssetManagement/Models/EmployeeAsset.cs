using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssetManagement.Models
{
    public class EmployeeAsset
    {
        public int AssetId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateOut { get; set; }
        public DateTime? DateReturned { get; set; }
        public string ConditionOut { get; set; }
        public string ConditionReturned { get; set; }
        public string OtherDetails { get; set; }

        public virtual ITAsset ITAsset { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
