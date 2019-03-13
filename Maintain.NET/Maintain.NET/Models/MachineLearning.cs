using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Microsoft.ML;
using Maintain.NET.Models;
using Microsoft.ML.Data;
using Microsoft.Data.DataView;
using static Microsoft.ML.Transforms.NormalizingEstimator;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maintain.NET.Models
{
    public class IntervalData
    {
        public float Label;
        public float Interval;
    }

    public class IntervalPrediction
    {
        [ColumnName("Score")]
        public float Interval;
    }

    public class MachineLearning
    {
        /// <summary>
        /// Builds Trains and Evaluates UserMaintnenaceHistory and returns a long that represents the recommended interval of MaintenanceTask.
        /// </summary>
        /// <returns>long representing recommended interval of MaintenanceTask</returns>
        public static long Run(IEnumerable<UserMaintenanceHistory> incomingData, long lower, long upper)
        {
            long recommendedInterval = 0;

            MLContext mlContext = new MLContext();

            ITransformer trainedModel = BuildTrainEvaluate(mlContext, incomingData);

            recommendedInterval = Evaluate(mlContext, trainedModel, incomingData, lower, upper);

            return recommendedInterval;
        }

        public static IntervalData[] ParseData(IEnumerable<UserMaintenanceHistory> incomingData)
        {
            IntervalData[] dataArray = new IntervalData[incomingData.Count()];

            int counter = 0;

            foreach (UserMaintenanceHistory userMaintenanceHistory in incomingData)
            {
                IntervalData intervalData = new IntervalData()
                {
                    Label = userMaintenanceHistory.Interval,
                    Interval = userMaintenanceHistory.Interval
                };

                dataArray[counter] = intervalData;
                counter++;
            }
            return dataArray;
        }
        

        /// <summary>
        /// Receives a list of selected UserMaintenanceHistory data and returns a trained regression model.
        /// </summary>
        /// <param name="mlContext">Loads the input machine learning database</param>
        /// <param name="incomingData">Loads the input UserMaintenanceHistory list</param>
        /// <param name="lower">Sets the lower bound of UserMaintenanceHistory.Interval value that will be used in calculation.</param>
        /// <param name="upper">Sets the upper bound of UserMaintenanceHistory.Interval value that will be used in calculation.</param>
        /// <returns>Returns a trained regression model that will be used by Prediction() to return a recommended interval.</returns>
        private static ITransformer BuildTrainEvaluate(MLContext mlContext, IEnumerable<UserMaintenanceHistory> incomingData)
        {
            IntervalData[] dataArray = ParseData(incomingData);

            IDataView baseTrainingDataView = mlContext.Data.LoadFromEnumerable<IntervalData>(dataArray);

            // Tracks the original number of objects within incoming data.
            //int originalCount = baseTrainingDataView.GetColumn<float>(mlContext, columnName: ).Count();

            // Filters interval values being used using input lower and upper values as params.
            //IDataView trainingDataView = mlContext.Data.FilterRowsByColumn(baseTrainingDataView, nameof(IntervalData.Interval), lowerBound: lower, upperBound: upper);

            // Tracks filtered number of objects.
            //int filteredCount = trainingDataView.GetColumn<float>(mlContext, nameof(IntervalData.Interval)).Count();

            //Converts the mlContext DB items into items that can be run in calculations.

            var dataProcessPipeline = mlContext.Transforms.Concatenate("Features", "Interval");

            //var trainer = mlContext.Regression.Trainers.StochasticDualCoordinateAscent(labelColumnName: DefaultColumnNames.Label, featureColumnName: DefaultColumnNames.Features);
            var trainer = mlContext.Regression.Trainers.PoissonRegression();
            var trainingPipeline = dataProcessPipeline.Append(trainer);
            // trainedModel is output.
            var trainedModel = trainingPipeline.Fit(baseTrainingDataView);

            // trainedModel is returned.
            
            return trainedModel;
        }

        private static long Evaluate(MLContext mlContext, ITransformer model, IEnumerable<UserMaintenanceHistory> incomingData, long lower, long upper)
        {
            long recommendedInterval = 0;

            int counter = 0;
            long savedData = 0;

            foreach (UserMaintenanceHistory userMaintenanceHistory in incomingData)
            {
                if (userMaintenanceHistory.Interval > lower && userMaintenanceHistory.Interval < upper)
                {
                    recommendedInterval += userMaintenanceHistory.Interval;
                    savedData = savedData + 1;
                }
                counter++;
            }
            recommendedInterval = recommendedInterval / savedData;

            var predictionFunction = model.CreatePredictionEngine<IntervalData, IntervalPrediction>(mlContext);

            IntervalData interval = new IntervalData()
            {
                Label = recommendedInterval,
                Interval = recommendedInterval
            };

            var prediction = predictionFunction.Predict(interval);

            float predictedValue = prediction.Interval;

            return recommendedInterval;
        }


    }
}
