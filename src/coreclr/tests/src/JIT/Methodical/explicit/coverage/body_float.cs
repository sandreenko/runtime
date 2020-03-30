// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

internal class TestApp
{
    public static AA[] a_init = new AA[101];

    private static unsafe int Main()
    {
        AA.a_init[99] = new AA(97);
        return 100;
    }
}
