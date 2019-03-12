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
        /// Builds Trains and Evaluates UserMaintnenaceHistory and returns an 
        /// </summary>
        /// <returns></returns>
        public static long Run(IEnumerable<UserMaintenanceHistory> incomingData)
        {
            long recommendedInterval = 0;

            MLContext mlContext = new MLContext(seed: 0);

            var model = BuildTrainEvaluate(mlContext, incomingData);

            recommendedInterval = Prediction(mlContext, model);

            return recommendedInterval;
        }

        private static ITransformer BuildTrainEvaluate(MLContext mlContext, IEnumerable<UserMaintenanceHistory> incomingData)
        {

            
        }

        private static long Prediction(MLContext mlContext, ITransformer model)
        {
            long recommendedInterval = 0;

            return recommendedInterval;
        }


    }
}
