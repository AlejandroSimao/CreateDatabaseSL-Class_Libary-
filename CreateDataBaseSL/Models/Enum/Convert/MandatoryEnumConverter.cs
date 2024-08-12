using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDataBaseSL.Models.Enum.Convert
{
    public class MandatoryEnumConverter: JsonConverter<Mandatory>
    {
        public override void WriteJson(JsonWriter writer, Mandatory value, JsonSerializer serializer)
        {
            // Converte o enum para 'Y' ou 'N'
            writer.WriteValue(value == Mandatory.tYES ? "Y" : "N");
        }

        public override Mandatory ReadJson(JsonReader reader, Type objectType, Mandatory existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            // Lê o valor de volta para enum
            var stringValue = reader.Value.ToString();
            return stringValue == "Y" ? Mandatory.tYES : Mandatory.tNO;
        }
    }
}
