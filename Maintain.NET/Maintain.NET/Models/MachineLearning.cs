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

namespace Maintain.NET.Models
{
    public class MachineLearning
    {
        /// <summary>
        /// Builds Trains and Evaluates UserMaintnenaceHistory and returns a long that represents the recommended interval of MaintenanceTask.
        /// </summary>
        /// <returns>long representing recommended interval of MaintenanceTask</returns>
        public static long Run(List<UserMaintenanceHistory> incomingData, long lower, long upper)
        {
            long recommendedInterval = 0;

            MLContext mlContext = new MLContext();

            ITransformer trainedModel = BuildTrainEvaluate(mlContext, incomingData, lower, upper);

            recommendedInterval = Prediction(mlContext, trainedModel);

            return recommendedInterval;
        }

        /// <summary>
        /// Receives a list of selected UserMaintenanceHistory data and returns a trained regression model.
        /// </summary>
        /// <param name="mlContext">Loads the input machine learning database</param>
        /// <param name="incomingData">Loads the input UserMaintenanceHistory list</param>
        /// <param name="lower">Sets the lower bound of UserMaintenanceHistory.Interval value that will be used in calculation.</param>
        /// <param name="upper">Sets the upper bound of UserMaintenanceHistory.Interval value that will be used in calculation.</param>
        /// <returns>Returns a trained regression model that will be used by Prediction() to return a recommended interval.</returns>
        private static ITransformer BuildTrainEvaluate(MLContext mlContext, List<UserMaintenanceHistory> incomingData, long lower, long upper)
        {
            // Loads the incomingData into the mlContext then sets the stored data as a IDataView
            IEnumerable<UserMaintenanceHistory> data = incomingData;

            IDataView baseTrainingDataView = mlContext.Data.LoadFromEnumerable(data);

            // Tracks the original number of objects within incoming data.
            int originalCount = baseTrainingDataView.GetColumn<float>(mlContext, nameof(UserMaintenanceHistory.Interval)).Count();

            // Filters interval values being used using input lower and upper values as params.
            IDataView trainingDataView = mlContext.Data.FilterRowsByColumn(baseTrainingDataView, nameof(UserMaintenanceHistory.Interval), lowerBound: lower, upperBound: upper);

            // Tracks filtered number of objects.
            int filteredCount = trainingDataView.GetColumn<float>(mlContext, nameof(UserMaintenanceHistory.Interval)).Count();

            //Converts the mlContext DB items into items that can be run in calculations.
            var dataProcessPipeline = mlContext.Transforms.CopyColumns(outputColumnName: DefaultColumnNames.Label, inputColumnName: nameof(UserMaintenanceHistory.Interval))
                .Append(mlContext.Transforms.Normalize(outputColumnName: nameof(UserMaintenanceHistory.Interval), mode: NormalizerMode.MeanVariance))
                .Append(mlContext.Transforms.Concatenate(DefaultColumnNames.Features, nameof(UserMaintenanceHistory.Interval))
                );

            // Builds the training algorithm using the .Features Property
            var trainer = mlContext.Regression.Trainers.StochasticDualCoordinateAscent(labelColumnName: DefaultColumnNames.Label, featureColumnName: DefaultColumnNames.Features);

            // Runs the regression with the declared dataset using the compiled training algorithm.
            var trainingPipeline = dataProcessPipeline.Append(trainer);

            // trainedModel is output.
            var trainedModel = trainingPipeline.Fit(trainingDataView);

            // trainedModel is returned.
            return trainedModel;
        }

        private static long Prediction(MLContext mlContext, ITransformer model)
        {
            long recommendedInterval = 0;



            return recommendedInterval;
        }


    }
}
