using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AssetManagement.Models
{
    public class ITAsset
    {
        public int asset_id { get; set; }
        public int asset_type_id { get; set; }
        public string asset_name { get; set; }
        public string description { get; set; }
        public string other_details { get; set; }

        public AssetType AssetType { get; set; }  
    }
}


