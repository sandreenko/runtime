// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Runtime.InteropServices;
using System;

class ClientPInvokeIntNativeTest
{
    [DllImport("PInvokeIntNative")]
    private static extern int Marshal_In([In]int intValue);

    [DllImport("PInvokeIntNative")]
    private static extern int Marshal_InOut([In, Out]int intValue);

    [DllImport("PInvokeIntNative")]
    private static extern int Marshal_Out([Out]int intValue);

    [DllImport("PInvokeIntNative")]
    private static extern int MarshalPointer_In([In]ref int pintValue);

    [DllImport("PInvokeIntNative")]
    private static extern int MarshalPointer_InOut(ref int pintValue);

    [DllImport("PInvokeIntNative")]
    private static extern int MarshalPointer_Out(out int pintValue);

    [DllImport("PInvokeIntNative")]
    private static extern int Marshal_InMany([In]short i1, [In]short i2, [In]short i3, [In]short i4, [In]short i5, [In]short i6, [In]short i7, [In]short i8, [In]short i9, [In]short i10, [In]short i11, [In]byte i12, [In]byte i13, [In]int i14, [In]short i15);


    public static int Main(string[] args)
    {
        int failures = 0;
        int intManaged = (int)1000;
        int intNative = (int)2000;
        int intReturn = (int)3000;


        if(120 != Marshal_InMany(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15))
        {
            failures++;
            Console.WriteLine("InMany return value is wrong");
        }

        return 100 + failures;
    }
}
