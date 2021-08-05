// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Reflection;
using System.Reflection.Emit;

namespace TestCasts
{
    class Program
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ulong Check(float f)
        {
            ulong s = checked((ulong)f);
            return s;
        }


        [MethodImpl(MethodImplOptions.NoInlining)]
        static void GenerateTest(float from)
        {


            Console.WriteLine("Value before, on entry " + from.ToString());

            try
            {
               Console.WriteLine("Value before, in try " + from.ToString());
               ulong res = Check(from); 
            }
            catch
            {
            }
            Console.WriteLine("Value after " + from.ToString());
        }



        
        [MethodImpl(MethodImplOptions.NoInlining)]
        static void TestConvertFromFloatToU8()
        {
            GenerateTest(long.MinValue);

            GenerateTest(long.MinValue);

            GenerateTest(long.MinValue);


           TestSimple(long.MinValue, (float)long.MinValue);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void TestSimple(float f, object f1)
        {
            Console.WriteLine("Test Simple value is " + f + ", f1 is " + f1.ToString());
            Debug.Assert(f < -1E-9);
        }


        static int Main(string[] args)
        {
            TestConvertFromFloatToU8();
            return 100;

        }
    }
}
