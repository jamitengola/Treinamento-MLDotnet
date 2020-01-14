using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MLDotnet
{
    public class DadosSalario
    {
        [LoadColumn(0)]
        public float AnosdeExperiencia;

        [LoadColumn(1), ColumnName("Label")]
        public float Salario;
    }
}
