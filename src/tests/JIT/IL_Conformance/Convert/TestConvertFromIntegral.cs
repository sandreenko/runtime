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
        static int failedCount = 0;

        static readonly bool ExpectException = true;
        static readonly bool DontExpectException = false;

        static readonly bool UnspecifiedBehaviour = true;

        [MethodImpl(MethodImplOptions.NoInlining)]
        static void GenerateTest<F, T>(F from, OpCode fromOpcode, OpCode convOpcode, bool exceptionExpected, T expectedTo, bool undefined = false) where F : struct where T : struct, IEquatable<T>
        {
            bool checkResult = !exceptionExpected && !undefined;
            Debug.Assert(!exceptionExpected || !checkResult);
            Debug.Assert(checkResult || expectedTo.Equals(default(T)));

            Type[] args = new Type[] { }; // No args.
            Type returnType = typeof(ulong);
            Console.WriteLine("Run test from " + typeof(F).FullName + ", value " + from.ToString() + " To " + typeof(T).FullName + "with Op " + convOpcode.Name + " exception expected: " + exceptionExpected);
            string name = "DynamicConvertFrom" + typeof(F).FullName + "To" + typeof(T).FullName + from.ToString() + "Op" + convOpcode.Name;


            Console.WriteLine("Value before, before new dynamic " + from.ToString());

            DynamicMethod dm = new DynamicMethod(name, returnType, args);

            Console.WriteLine("Value before, after new dynamic " + from.ToString()); 

            ILGenerator generator = dm.GetILGenerator();

            if (typeof(F) == typeof(float)) generator.Emit(fromOpcode, (float)(object)from);
            
            Console.WriteLine("Value before, after first emit " + from.ToString());  

            generator.Emit(convOpcode);
            generator.Emit(OpCodes.Ret);

            try
            {
                Console.WriteLine("Value before, in try " + from.ToString());
                T res = (T)dm.Invoke(null, BindingFlags.Default, null, new object[] { }, null);
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
            GenerateTest<float, ulong>(long.MinValue, sourceOp, convNoOvf, DontExpectException, 0, UnspecifiedBehaviour);

            OpCode convOvf = OpCodes.Conv_Ovf_U8;
            GenerateTest<float, ulong>(long.MinValue, sourceOp, convOvf, ExpectException, 0);

            OpCode convOvfUn = OpCodes.Conv_Ovf_U8_Un;
            GenerateTest<float, ulong>(long.MinValue, sourceOp, convOvfUn, ExpectException, 0);


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
            if (failedCount > 0)
            {
                Console.WriteLine("The number of failed tests: " + failedCount);
                return 101;
            }
            else
            {
                Console.WriteLine("All tests passed");
                return 100;
            }

        }
    }
}
