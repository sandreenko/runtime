// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

// The test showed CSE issues with struct return retyping.

using System;
using System.Runtime.CompilerServices;

struct LongtWrapper
{
    public Object a; // a ref field
}

class TestStructs
{
    static LongtWrapper[] cars;

    public static LongtWrapper GetElement() // 8 byte size return will be retyped as a ref.
    {
        return cars[0];
    }

    public static int Main()
    {
        LongtWrapper a = new LongtWrapper();
        cars = new LongtWrapper[1];
        cars[0] = a;

        LongtWrapper e = GetElement(); // force struct retyping to ref.
        cars[0] = e; // a struct typed copy.
        return 100;
    }
}
