// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
using System;
using System.Numerics;

// The test was showing type mistmatch in CSE for a SIMD intrinsic that was used in return expr
// and a normal one.

class Runtime_35724
{

    static Vector2 Test()
    {
        Vector2 a = new Vector2(1);
        Vector2 b = new Vector2(2);
        Vector2 c = a / b;
        Vector2 d = a / b;
        Console.WriteLine(c.X + d.Y);
        return a / b;
    }

    static int Main(string[] args)
    {
        Test();
        return 100;
    }
}
