﻿/// <summary>
///     Programmer : Jonas Smith
///     Pupose     : Approximate integral using trapezoidal and simpsons rule. 
/// </summary>
using System;

namespace NumericalHW6
{
    class NumericalHW6
    {
        int[]  subIntervals_M = new int[] { 2, 4, 8, 16, 32 };

        public void Main()
        {
            double upperBound     = Math.PI;
            double lowerBound     = 0.0;
            double nodeSpacing_H  = 0.0;

            for (int index = 0; index < subIntervals_M.Length; index++)
            {

                nodeSpacing_H  = ( upperBound - lowerBound ) / subIntervals_M[index];

                TrapezoidalRule(nodeSpacing_H, lowerBound + (index * nodeSpacing_H), index);
            }
        }

        // function for both composite methods bellow. 
        public double function(double x_value)
        {
            return ((Math.Pow(x_value, 2) + x_value + 1 ) * Math.Cos(x_value));
        }




        // Composite Trapezoidal Rule - Page 357 1c
        public double TrapezoidalRule(double nodeSpaceH, double x_value, int index)
        {
            return (nodeSpaceH / 2) *( function(x_value) + function(x_value + nodeSpaceH))
                                    + nodeSpaceH * TrapezoidalError(nodeSpaceH, x_value, index);
        }

        public double TrapezoidalError(double nodeSpaceH, double x_value, int index) {
            double functionSummation = 0.0;

            for(int i = 1; i < subIntervals_M[index] - 1; i++)
            {
                functionSummation += function(x_value + (i * nodeSpaceH) );
            }

            return nodeSpaceH * functionSummation;
        }




        // Composite Simpson's Rule - Page 359 4c
        public double SimpsonsRule(double nodeSpaceH, double x_value)
        {
            return (nodeSpaceH / 3) * (function(x_value) + function(x_value + nodeSpaceH))
                                    + nodeSpaceH * SimpsonsError(nodeSpaceH);
        }

        public double SimpsonsError(double x_value)
        {
            return ((Math.Pow(x_value, 2) + x_value + 1) * Math.Cos(x_value));
        }




        // prints the results for the methods used above and each interval. 
        public void PrintResults()
        {
            // print results in the form of SubInterValM[i], Trapezoidal, Simpson's, Error. 
        }

    }
}
