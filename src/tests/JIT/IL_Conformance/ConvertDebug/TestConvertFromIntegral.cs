using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Reflection;
using System.Reflection.Emit;

namespace CheckGenericSbyte
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
            Type returnType = typeof(T);
            Console.WriteLine("Run test from " + typeof(F).FullName + ", value " + from.ToString() + " To " + typeof(T).FullName + "with Op " + convOpcode.Name + " exception expected: " + exceptionExpected);
            string name = "DynamicConvertFrom" + typeof(F).FullName + "To" + typeof(T).FullName + from.ToString() + "Op" + convOpcode.Name;
            DynamicMethod dm = new DynamicMethod(name, returnType, args);

            ILGenerator generator = dm.GetILGenerator();

            if (typeof(F) == typeof(int)) generator.Emit(fromOpcode, (int)(object)from);
            else if (typeof(F) == typeof(long)) generator.Emit(fromOpcode, (long)(object)from);
            else if (typeof(F) == typeof(nint)) generator.Emit(fromOpcode, (nint)(object)from);
            else if (typeof(F) == typeof(float)) generator.Emit(fromOpcode, (float)(object)from);
            else if (typeof(F) == typeof(double)) generator.Emit(fromOpcode, (double)(object)from);
            else
            {
                throw new NotSupportedException();
            }

            generator.Emit(convOpcode);
            generator.Emit(OpCodes.Ret);

            try
            {
                T res = (T)dm.Invoke(null, BindingFlags.Default, null, new object[] { }, null);
                if (exceptionExpected)
                {
                    failedCount++;
                    Console.WriteLine("No exception in " + name);
                }
                if (checkResult && !expectedTo.Equals(res))
                {
                    failedCount++;
                    Console.WriteLine("Wrong result in " + name);
                }
            }
            catch
            {
                if (!exceptionExpected)
                {
                    failedCount++;
                    Console.WriteLine("Not expected exception in " + name);
                }
            }
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
            GenerateTest<float, ulong>(int.MinValue, sourceOp, convOvfUn, ExpectException, 0);
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
            TestConvertFromFloatToU8();
            return 100;
        }
    }
}
