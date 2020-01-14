using System;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace MLDotnet
{
    class Program
    {
        //public class HouseData
        //{
        //    public float Size { get; set; }
        //    public float Price { get; set; }
        //}

        //public class Prediction
        //{
        //    [ColumnName("Score")]
        //    public float Price { get; set; }
        //}

        static void Main(string[] args)
        {
            var context = new MLContext();

            // Load data
            var trainData = context.Data.LoadFromTextFile<DadosSalario>("./Dados.csv", hasHeader: true, separatorChar: ',');

            // Build model
            var pipeline = context.Transforms.Concatenate("Features", "AnosdeExperiencia")
                .Append(context.Regression.Trainers.LbfgsPoissonRegression());

            var model = pipeline.Fit(trainData);

            // Evaluate
            var predictions = model.Transform(trainData);

            var metrics = context.Regression.Evaluate(predictions);

            Console.WriteLine($"R^2 - {metrics.RSquared}");

            // Predict
            var newData = new DadosSalario
            {
                AnosdeExperiencia = 0.5f
            };

            var predictionFunc = context.Model.CreatePredictionEngine<DadosSalario, PrevisaoSalarial>(model);

            var prediction = predictionFunc.Predict(newData);

            Console.WriteLine($"Previsão - {prediction.SalarioPrevisto} Kzs");

            Console.ReadLine();
        }
    }
}
