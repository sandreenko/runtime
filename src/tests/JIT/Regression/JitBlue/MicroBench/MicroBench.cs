// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace MicroBenchDoubleToUint
{
    class MicroBench
    {

        [MethodImpl(MethodImplOptions.NoInlining)]
        static void TestRandom()
        {
            const int seed = 13;
            var rand = new Random(seed);

            const int N = 100000000;
            List<double> listOfRandomDoubles = new List<double>();

            for (int i = 0; i < N; ++i)
            {
                byte[] buf = new byte[8];
                rand.NextBytes(buf);
                double d  = (ulong)BitConverter.ToDouble(buf, 0);
                listOfRandomDoubles.Add(d);
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();
            uint res = 0;

            for (int i = 0; i < N; ++i)
            {
                double d = listOfRandomDoubles[i];
                uint ui = (uint)d;
                res += ui;
            }

            sw.Stop();
            Console.WriteLine("ElapsedMilliseconds: " +  sw.Elapsed.TotalMilliseconds);
            Console.WriteLine("result: " + res);
        }

        static void Main(string[] args)
        {
            TestRandom();
        }
    }
}
