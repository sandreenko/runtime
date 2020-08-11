// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Runtime.Intrinsics;
using System.Security.Cryptography;
using System.Threading;

class Runtime_40440
{

    struct s8
    {
        long f;
    }

    struct s32
    {
        s8 f1;
        s8 f2;
        s8 f3;
        s8 f4;
    }

    struct s128
    {
        s32 f1;
        s32 f2;
        s32 f3;
        s32 f4;
    }

    struct s512
    {
        s128 f1;
        s128 f2;
        s128 f3;
        s128 f4;
    }

    static int StrangeMethod(int length, object a, object b, object c, object d)
    {
        s512 s = new s512();
        string e = new string("abe");
        string f = new string("abf");
        string g = new string("abg");
        string h = new string("abh");

        if (length == 1000)
        {
            return 1000 + e[0] + f[0] + g[0] + h[0];
        }
        Span<int> numbers = stackalloc int[length];
        int sum = 0;

        for (int i = 0; i < length; ++i)
        {
            numbers[i] = i;
        }
        for (int i = 0; i < length; ++i)
        {
            sum += numbers[i];
            if (sum == 4000)
            {
                return 4000;
            }
        }
        return sum;
    }

    static void CallGC()
    {
        while (true)
        {
            System.GC.Collect();
        }
    }

    public static int Main()
    {
        Thread gcThread = new Thread(() => CallGC());
        gcThread.Start();

        const int iterCount = 1000;

        for (int iter = 0; iter < iterCount; ++iter)
        {
            int sum = 0;
            const int threadCount = 128;
            Thread[] threads = new Thread[threadCount];
            int[] results = new int[threadCount];
            for (int i = 0; i < threadCount; ++i)
            {
                int threadId = i;
                int length = threadCount * i + iter + 1;
                threads[threadId] = new Thread(() => { results[threadId] = StrangeMethod(length, null, null, null, null); });
                threads[threadId].Start();
            }


            for (int i = 0; i < threadCount; ++i)
            {

                threads[i].Join();
                sum += results[i];
            }

            Console.WriteLine("Finished an iteration, the sum is: " + sum);
        }
        return 100;
    }
}
