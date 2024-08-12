using CreateDataBaseSL.Models.Enum;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateDataBaseSL.Models.Enum.Convert;

namespace CreateDataBaseSL.Models
{
    public class UserTablesMD
    {
        public string TableDescription { get; set; } 

        public string TableName { get; set; } 

        public TableType TableType { get; set; }

        [JsonConverter(typeof(ArchivableEnumConverter))]
        public Archivable Archivable { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ArchiveDateField { get; set; } = null;


    }

    public class ReturnJsonUserTablesMD
    {
        [JsonProperty("odata.metadata")]
        public string OdataMetadata { get; set; }
        public List<UserTablesMD> value { get; set; }
    }
}
