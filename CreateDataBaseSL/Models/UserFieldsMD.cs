using CreateDataBaseSL.Models.Enum;
using CreateDataBaseSL.Models.Enum.Convert;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDataBaseSL.Models
{
    public class UserFieldsMD
    {
        public string Description { get; set; }

        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public BoFldSubTypes SubType { get; set; }

        public string TableName { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public BoFieldsType Type { get; set; }

        public int Size { get; set; }

        public int EditSize { get; set; }

        public string LinkedTable { get; set; }
        
        public string DefaultValue { get; set; }

        [JsonConverter(typeof(MandatoryEnumConverter))]
        public Mandatory Mandatory { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<ValidValue> ValidValues { get; set; } = null;
    }

    public class ValidValue
    {
        public string Value { get; set; }
        public string Description { get; set; }
    }

    public class ReturnJsonUserFieldMD
    {
        [JsonProperty("odata.metadata")]
        public string OdataMetadata { get; set; }
        public List<UserFieldsMD> value { get; set; }
    }
}
