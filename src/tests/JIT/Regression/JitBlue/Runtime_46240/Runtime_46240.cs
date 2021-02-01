// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Numerics;

public class TestVector128PassingInRegs
{

    struct S
    {
        public bool b1;
        bool b2;
        bool b3;
        bool b4;
        bool b5;
        bool b6;
        bool b7;
        bool b8;
    }
    
        [MethodImpl(MethodImplOptions.NoInlining)]
        static void Get(S s)
        {
            
        }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static bool Test(int a)
    {

        S s = new S();
        if (a == 0)
        {
            Get(s);
            return false;
        }
        return true;

    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static int Main()
    {
        Test(0);
        return 100;
    }
}