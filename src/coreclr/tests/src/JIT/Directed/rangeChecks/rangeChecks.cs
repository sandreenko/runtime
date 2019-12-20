// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
//

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

class RangeChecks
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    static int TestIncreasing()
    {
        int[] arr = new int[10];
        int i = 0;
        int sum = 0;
        while (i < 10)
        {
            sum += arr[i];
            ++i;
        }
        return sum;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static int TestDecreasing()
    {
        int[] arr = new int[10];
        int i = 9;
        int sum = 0;
        while (i >= 0)
        {
            sum += arr[i];
            --i;
        }
        return sum;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static int TestNonIncreasing()
    {
        int[] arr = new int[10];
        int sum = 0;

        {
            int i = 9;
            while (i >= 0)
            {
                sum += arr[i];
                if (sum != 100)
                {
                    --i;
                }
            }
        }

        {
            int i = 9;
            int j = 9;
            while (i >= 0)
            {
                sum += arr[j];
                --i;
                if (i % 2 == 0)
                {
                    --j;
                }
                else
                {
                    j = j;
                }
            }
        }

        return sum;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static int TestNonDecreasing()
    {
        int[] arr = new int[10];
        int sum = 0;

        {
            int i = 0;
            while (i < 10)
            {
                sum += arr[i];
                if (sum != 100)
                {
                    ++i;
                }
            }
        }

        {
            int i = 0;
            int j = 0;
            while (i < 10)
            {
                sum += arr[j];
                ++i;
                if (i % 2 == 0)
                {
                    ++j;
                }
                else
                {
                    j = j;
                }
            }
        }

        return sum;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static int TestConst()
    {
        int[] arr = new int[10];
        int sum = 0;
        int i = 0;
        int j = 0;
        while (i < 10)
        {
            sum += arr[j];
            ++i;
        }
        return sum;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static int TestNotMonotonic()
    {
        int[] arr = new int[10];
        int i = 0;
        int sum = 0;
        while (i < 10)
        {
            sum += arr[i];
            if (i % 2 == 0)
            {
                i += 3;
            }
            else
            {
                i -= 1;
            }
        }
        return sum;
    }

    static int TestOutOfBoundProxy(Func<int> actualTest)
    {
        try
        {
            actualTest();
        }
        catch (IndexOutOfRangeException)
        {
            return 100;
        }
        Debug.Fail("unreached");
        return 101;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static int TestOutOfBoundLowerDecreasing()
    {
        int[] arr = new int[10];
        int i = 9;
        int j = 15;
        int sum = 0;
        while (j >= 0 && i < 10)
        {
            --j;
            --i;
            sum += arr[i];
        }
        return sum;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static int TestOutOfBoundLowerDecreasing2()
    {
        int[] arr = new int[10];
        int i = 9;
        int sum = 0;
        while (i >= 0)
        {
            --i;
            sum += arr[i];
        }
        return sum;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static int TestOutOfBoundLowerIncreasing()
    {
        int[] arr = new int[10];
        int i = -1;
        int sum = 0;
        while (i < 10)
        {
            sum += arr[i];
            ++i;
        }
        return sum;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static int TestOutOfBoundUpperDecreasing()
    {
        int[] arr = new int[10];
        int i = 10;
        int sum = 0;
        while (i >= 0)
        {
            --i;
            sum += arr[i];
        }
        return sum;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static int TestOutOfBoundUpperIncreasing()
    {
        int[] arr = new int[10];
        int i = -1;
        int sum = 0;
        while (i < 10)
        {
            ++i;
            sum += arr[i];
        }
        return sum;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    static int TestOutOfBoundLowerNotMonotonic()
    {
        int[] arr = new int[10];
        int i = 0;
        int sum = 0;
        while (i < 10)
        {
            sum += arr[i];
            if (i % 2 == 0)
            {
                i += 1;
            }
            else
            {
                i -= 3;
            }
        }
        return sum;
    }


    [MethodImpl(MethodImplOptions.NoInlining)]
    static int TestOutOfBoundUpperNotMonotonic()
    {
        int[] arr = new int[10];
        int i = 9;
        int sum = 0;
        while (i >= 0)
        {
            sum += arr[i];
            if (i % 2 == 0)
            {
                i -= 1;
            }
            else
            {
                i += 3;
            }
        }
        return sum;
    }


    public static int Main()
    {
        try
        {
            TestIncreasing();
            TestDecreasing();
            TestNonIncreasing();
            TestNonDecreasing();
            TestConst();
            TestNotMonotonic();

            TestOutOfBoundProxy(TestOutOfBoundLowerDecreasing);
            TestOutOfBoundProxy(TestOutOfBoundLowerIncreasing);
            TestOutOfBoundProxy(TestOutOfBoundUpperDecreasing);
            TestOutOfBoundProxy(TestOutOfBoundUpperIncreasing);
            TestOutOfBoundProxy(TestOutOfBoundUpperDecreasing);
            TestOutOfBoundProxy(TestOutOfBoundLowerNotMonotonic);
            TestOutOfBoundProxy(TestOutOfBoundLowerNotMonotonic);
        }
        catch (Exception)
        {
            return 101;
        }

        return 100;
    }
}
