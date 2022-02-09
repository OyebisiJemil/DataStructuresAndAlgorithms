﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
    public class SlidingWindow : ISlidingWindow
    {
        
        public List<double> AverageOfAllSubArray(int[] elements)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// given array a = [1,3,2,6,-1,4,1,8,2] and k = 5
        /// find: average of all sub arrays of k contiguous element in it
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public List<double> AverageOfAllSubArray(int[] elements, int k)
        {
            List<double> averages = new List<double>();
            double sum = 0;
            double average = 0;
            int begining_of_the_window = 0;

            for(int i = 0; i< elements.Length; i++)
            {
                sum = sum + elements[i];
                if(i >= k - 1)
                {
                    average = sum / k;
                    sum = sum - elements[begining_of_the_window];
                    begining_of_the_window++;

                    averages.Add(average);
                }
            }

            return averages;
        }

        /// <summary>
        /// given array a = [1,3,2,6,-1,4,1,8,2] and k = 5
        /// find: average of all sub arrays of k contiguous element in it
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public List<double> AverageOfAllSubArrayBruteForce(int[] elements, int k)
        {
            List<double> averages = new List<double>();

            for(int i = 0; i<= elements.Length - k; i++)
            {
                double sum = 0;
                double average = 0;

                for(int j = i; j <= i+k -1; j++)
                {
                    sum = sum + elements[j];
                }
                average = sum / k;
                averages.Add(average);
            }
            return averages;
        }
    }
}
