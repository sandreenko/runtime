// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TestDoubleIntConversion
{
    class TestDoubleToUintConv
    {
        static int Main(string[] args)
        {

            uint zero = (uint)GetDouble(0);
            Print(zero, GetDouble(0), 0);
            Debug.Assert(zero == 0);

            uint one = (uint)1;
            Print(one, GetDouble(1), 1);
            //Debug.Assert(one == 1);

            uint minusOne = (uint)GetDouble(-1);
            Print(minusOne, GetDouble(-1), uint.MaxValue);
            Debug.Assert(minusOne == uint.MaxValue);

            uint maxU = (uint)GetDouble(uint.MaxValue);
            Print(maxU, GetDouble(uint.MaxValue), uint.MaxValue);
            //Debug.Assert(maxU == uint.MaxValue);

            uint maxUPlusOne = (uint)Add(uint.MaxValue, 1);
            Print(maxUPlusOne, Add(uint.MaxValue, 1), 0);
            Debug.Assert(maxUPlusOne == 0);

            uint negMaxU = (uint)GetDouble(-uint.MaxValue);
            Print(negMaxU, GetDouble(-uint.MaxValue), 1);
            //Debug.Assert(negMaxU == 1);

            uint negmaxUMinusOne = (uint)Add(-uint.MaxValue, -1);
             Print(negmaxUMinusOne, Add(-uint.MaxValue, -1), 0);
            //Debug.Assert(negmaxUMinusOne == 0);


            uint negmaxUMinusTwo = (uint)Add(-uint.MaxValue, -2);
            Print(negmaxUMinusTwo, Add(-uint.MaxValue, Add(-uint.MaxValue, -2)), uint.MaxValue);
            Debug.Assert(negmaxUMinusTwo == uint.MaxValue);

            uint maxD = (uint)GetDouble(Double.MaxValue);
            Print(maxD, GetDouble(Double.MaxValue), 0);
            //Debug.Assert(maxD == 0);

            uint minD = (uint)GetDouble(Double.MinValue);
            Print(minD, GetDouble(Double.MinValue), 0);
            //Debug.Assert(minD == 0);


            uint hundred = (uint)GetDouble(100);
            Print(hundred, GetDouble(100), 100);
            // Debug.Assert(hundred == 100);

            // TestRandom();
            return 100;
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        static void TestRandom()
        {
            const int seed = 13;
            var rand = new Random(seed);

            const int N = 100;
            List<double> listOfRandomDoubles = new List<double>();
            List<uint> listOfConvertedUints = new List<uint>();

            for (int i = 0; i < N; ++i)
            {
                listOfRandomDoubles.Add(rand.NextDouble() * uint.MaxValue);
            }

            for (int i = 0; i < N; ++i)
            {
                double d = listOfRandomDoubles[i];
                uint ui = (uint)d;
                Console.WriteLine("double " + d + " becomes " + ui);
                listOfConvertedUints.Add(ui);
            }
        }

        // Prevent Roslyn optimizations.
        [MethodImpl(MethodImplOptions.NoInlining)]
        static double GetDouble(double d)
        {
            return d;
        }

        // Prevent Roslyn optimizations.
        [MethodImpl(MethodImplOptions.NoInlining)]
        static double Add(double a, double b)
        {
            return a + b;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Print(uint u, double d, uint expected)
        {
            Console.WriteLine("double is " + d + ", uint is " + u + " or in hex 0x" + u.ToString("x"));
            if (u != expected)
            {
                Console.WriteLine("failed, " + expected + " was expected");
            }
            else
            {
                Console.WriteLine("passed");
            }
        }
    }
}