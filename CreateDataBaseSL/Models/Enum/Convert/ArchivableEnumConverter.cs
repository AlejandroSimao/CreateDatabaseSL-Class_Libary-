using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDataBaseSL.Models.Enum.Convert
{
    public class ArchivableEnumConverter : JsonConverter<Archivable>
    {
        public override void WriteJson(JsonWriter writer, Archivable value, JsonSerializer serializer)
        {
            // Converte o enum para 'Y' ou 'N'
            writer.WriteValue(value == Archivable.tYES ? "Y" : "N");
        }

        public override Archivable ReadJson(JsonReader reader, Type objectType, Archivable existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            // Lê o valor de volta para enum
            var stringValue = reader.Value.ToString();
            return stringValue == "Y" ? Archivable.tYES : Archivable.tNO;
        }
    }
}
