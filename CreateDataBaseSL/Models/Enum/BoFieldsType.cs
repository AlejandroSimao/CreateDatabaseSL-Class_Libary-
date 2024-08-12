using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDataBaseSL.Models.Enum
{
    public enum BoFieldsType
    {
        db_Alpha = 0,       // Texto (Alfabético)
        db_Memo = 1,        // Memo
        db_Numeric = 2,     // Numérico
        db_Date = 3,        // Data
        db_Float = 4,       // Decimal
        db_Amount = 5,      // Valor Monetário
        db_Rate = 6,        // Taxa de Câmbio
        db_Quantity = 7     // Quantidade
    }
}
