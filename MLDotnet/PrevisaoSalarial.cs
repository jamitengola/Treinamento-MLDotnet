using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLDotnet
{
   public  class PrevisaoSalarial
    {
        [ColumnName("Score")]
        public float SalarioPrevisto { get; set; }
    }
}
