// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.


using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

class TestStructs
{
    struct LessNativeInt
    {
        public bool a;
        public bool b;
    }

    struct NativeIntOneField
    {
        public long a;
    }

    struct NativeIntTwoFields
    {
        public int a;
        public int b;
    }

    struct NativeIntFloatField
    {
        public double a;
    }

    struct NativeIntMixedFields
    {
        public int a;
        public float b;
    }




    static LessNativeInt TestLessNativeIntReturnBlockInit()
    {
        LessNativeInt a = new LessNativeInt();
        return a;
    }

    static LessNativeInt TestLessNativeIntReturnFieldInit()
    {
        LessNativeInt a;
        a.a = false;
        a.b = true;
        return a;
    }


    static NativeIntOneField TestNativeIntOneFieldReturnBlockInit()
    {
        NativeIntOneField a = new NativeIntOneField();
        return a;
    }

    static NativeIntOneField TestNativeIntOneFieldReturnFieldInit()
    {
        NativeIntOneField a;
        a.a = 100;
        return a;
    }

    static NativeIntTwoFields TestNativeIntTwoFieldsReturnBlockInit()
    {
        NativeIntTwoFields a = new NativeIntTwoFields();
        return a;
    }

    static NativeIntTwoFields TestNativeIntTwoFieldsReturnFieldInit()
    {
        NativeIntTwoFields a;
        a.a = 100;
        a.b = 10;
        return a;
    }

    static NativeIntFloatField TestNativeIntFloatFieldReturnBlockInit()
    {
        NativeIntFloatField a = new NativeIntFloatField();
        return a;
    }

    static NativeIntFloatField TestNativeIntFloatFieldReturnFieldInit()
    {
        NativeIntFloatField a;
        a.a = 100;
        return a;
    }

    static NativeIntMixedFields TestNativeIntMixedFieldsReturnBlockInit()
    {
        NativeIntMixedFields a = new NativeIntMixedFields();
        return a;
    }

    static NativeIntMixedFields TestNativeIntMixedFieldsReturnFieldInit()
    {
        NativeIntMixedFields a;
        a.a = 100;
        a.b = 10;
        return a;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static int TestLessNativeIntCall1()
    {
        int res = 0;
        var v = TestLessNativeIntReturnBlockInit();
        if (v.a)
        {
            res++;
        }
        if (v.b)
        {
            res++;
        }
        if (v.a && v.b)
        {
            res++;
        }
        if (!v.a && !v.b)
        {
            res--;
        }
        return res;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static int TestLessNativeIntCall2()
    {
        int res = 0;
        var v = TestLessNativeIntReturnFieldInit();
        if (v.a)
        {
            res++;
        }
        if (v.b)
        {
            res++;
        }
        if (v.a && v.b)
        {
            res++;
        }
        if (!v.a && !v.b)
        {
            res--;
        }
        return res;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static int TestNativeIntOneFieldCall1()
    {
        int res = 0;
        var v = TestNativeIntOneFieldReturnBlockInit();
        if (v.a == 0)
        {
            res++;
        }        
        return res;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static int TestNativeIntOneFieldCall2()
    {
        int res = 0;
        var v = TestNativeIntOneFieldReturnFieldInit();
        if (v.a == 0)
        {
            res++;
        }
        return res;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static int TestNativeIntTwoFieldsCall1()
    {
        int res = 0;
        var v = TestNativeIntTwoFieldsReturnBlockInit();
        if (v.a == 0)
        {
            res++;
        }
        if (v.b == 0)
        {
            res++;
        }
        return res;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static int TestNativeIntTwoFieldsCall2()
    {
        int res = 0;
        var v = TestNativeIntTwoFieldsReturnFieldInit();
        if (v.a == 0)
        {
            res++;
        }
        if (v.b == 0)
        {
            res++;
        }
        return res;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static int TestNativeIntFloatFieldCall1()
    {
        int res = 0;
        var v = TestNativeIntFloatFieldReturnBlockInit();
        if (v.a >= 0)
        {
            res++;
        }
        return res;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static int TestNativeIntFloatFieldCall2()
    {
        int res = 0;
        var v = TestNativeIntFloatFieldReturnFieldInit();
        if (v.a >= 0)
        {
            res++;
        }
        return res;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static int TestNativeIntMixedFieldsCall1()
    {
        int res = 0;
        var v = TestNativeIntMixedFieldsReturnBlockInit();
        if (v.a == 0)
        {
            res++;
        }
        if (v.b == 0)
        {
            res++;
        }
        return res;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static int TestNativeIntMixedFieldsCall2()
    {
        int res = 0;
        var v = TestNativeIntMixedFieldsReturnFieldInit();
        if (v.a == 0)
        {
            res++;
        }
        if (v.b == 0)
        {
            res++;
        }
        return res;
    }


    public static int Main()
    {
        TestLessNativeIntCall1();
        TestLessNativeIntCall2();
        TestNativeIntOneFieldCall1();
        TestNativeIntOneFieldCall2();
        TestNativeIntTwoFieldsCall1();
        TestNativeIntTwoFieldsCall2();
        TestNativeIntFloatFieldCall1();
        TestNativeIntFloatFieldCall2();
        TestNativeIntMixedFieldsCall1();
        TestNativeIntMixedFieldsCall2();
        return 100;
    }
}
