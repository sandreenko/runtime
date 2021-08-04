// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// This is conformance test for conv described in ECMA-335 Table III.8: Conversion Operations.
// It tests int32/int64/float/double as the source and sbyte/byte/short/ushort/int/uint/long/ulong
// as the dst.

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
        static void GenerateTest(float from, OpCode fromOpcode, OpCode convOpcode, ulong expectedTo)
        {

            Type[] args = new Type[] { }; // No args.
            Type returnType = typeof(ulong);
            Console.WriteLine("Run test from " + typeof(float).FullName + ", value " + from.ToString() + " To " + typeof(ulong).FullName + "with Op " + convOpcode.Name);
            string name = "DynamicConvertFrom" + typeof(float).FullName + "To" + typeof(ulong).FullName + from.ToString() + "Op" + convOpcode.Name;


            Console.WriteLine("Value before, before new dynamic " + from.ToString());

            DynamicMethod dm = new DynamicMethod(name, returnType, args);

            Console.WriteLine("Value before, after new dynamic " + from.ToString()); 

            ILGenerator generator = dm.GetILGenerator();

            generator.Emit(fromOpcode, from);
            
            Console.WriteLine("Value before, after first emit " + from.ToString());  

            generator.Emit(convOpcode);
            generator.Emit(OpCodes.Ret);

            try
            {
                Console.WriteLine("Value before, in try " + from.ToString());
                ulong res = (ulong)dm.Invoke(null, BindingFlags.Default, null, new object[] { }, null);
            }
            catch
            {
            }
            Console.WriteLine("Value after " + from.ToString());
        }


        [MethodImpl(MethodImplOptions.NoInlining)]
        static void TestConvertFromFloat()
        {
            TestConvertFromFloatToU8();
        }

        
        [MethodImpl(MethodImplOptions.NoInlining)]
        static void TestConvertFromFloatToU8()
        {
            OpCode sourceOp = OpCodes.Ldc_R4;
            OpCode convNoOvf = OpCodes.Conv_U8;
            GenerateTest(long.MinValue, sourceOp, convNoOvf, 0);

            OpCode convOvf = OpCodes.Conv_Ovf_U8;
            GenerateTest(long.MinValue, sourceOp, convOvf, 0);

            OpCode convOvfUn = OpCodes.Conv_Ovf_U8_Un;
            GenerateTest(long.MinValue, sourceOp, convOvfUn, 0);


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
            sbyte Zero = 0;
            Debug.Assert(Zero.Equals(0));
            TestConvertFromFloat();
            return 100;

        }
    }
}
