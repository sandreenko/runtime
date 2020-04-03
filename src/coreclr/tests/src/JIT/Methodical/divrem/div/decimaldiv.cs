// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

/****************************************************************************
op1/op2, op1 is of type decimal, op2 can be i4, u4, i8, u8, r4, r8, decimal
op1 and op2 can be static, local, class/struct member, function retval, 1D/2D/3D array
*****************************************************************************/

using System;
internal class decimaldiv
{
    private static decimal s_m_s_op1 = 50;
    private static int s_i_s_op2 = 2;
    private static uint s_ui_s_op2 = 2;
    private static long s_l_s_op2 = 2;
    private static ulong s_ul_s_op2 = 2;
    private static float s_f_s_op2 = 2;
    private static double s_d_s_op2 = 2;
    private static decimal s_m_s_op2 = 2;

    public static int i_f(String s)
    {
        if (s == "op1")
            return 50;
        else
            return 2;
    }
    public static uint ui_f(String s)
    {
        if (s == "op1")
            return 50;
        else
            return 2;
    }
    public static long l_f(String s)
    {
        if (s == "op1")
            return 50;
        else
            return 2;
    }
    public static ulong ul_f(String s)
    {
        if (s == "op1")
            return 50;
        else
            return 2;
    }
    public static float f_f(String s)
    {
        if (s == "op1")
            return 50;
        else
            return 2;
    }
    public static double d_f(String s)
    {
        if (s == "op1")
            return 50;
        else
            return 2;
    }
    public static decimal m_f(String s)
    {
        if (s == "op1")
            return 50;
        else
            return 2;
    }
    private class CL
    {
        public decimal m_cl_op1 = 50;
        public int i_cl_op2 = 2;
        public uint ui_cl_op2 = 2;
        public long l_cl_op2 = 2;
        public ulong ul_cl_op2 = 2;
        public float f_cl_op2 = 2;
        public double d_cl_op2 = 2;
        public decimal m_cl_op2 = 2;
    }

    private struct VT
    {
        public decimal m_vt_op1;
        public int i_vt_op2;
        public uint ui_vt_op2;
        public long l_vt_op2;
        public ulong ul_vt_op2;
        public float f_vt_op2;
        public double d_vt_op2;
        public decimal m_vt_op2;
    }

    public static int Main()
    {
        bool passed = true;
        //initialize class
        CL cl1 = new CL();
        //initialize struct
        VT vt1;
        vt1.m_vt_op1 = 50;
        vt1.i_vt_op2 = 2;
        vt1.ui_vt_op2 = 2;
        vt1.l_vt_op2 = 2;
        vt1.ul_vt_op2 = 2;
        vt1.f_vt_op2 = 2;
        vt1.d_vt_op2 = 2;
        vt1.m_vt_op2 = 2;

        decimal[] m_arr1d_op1 = { 0, 50 };
        decimal[,] m_arr2d_op1 = { { 0, 50 }, { 1, 1 } };
        decimal[,,] m_arr3d_op1 = { { { 0, 50 }, { 1, 1 } } };

        int[] i_arr1d_op2 = { 2, 0, 1 };
        int[,] i_arr2d_op2 = { { 0, 2 }, { 1, 1 } };
        int[,,] i_arr3d_op2 = { { { 0, 2 }, { 1, 1 } } };
        uint[] ui_arr1d_op2 = { 2, 0, 1 };
        uint[,] ui_arr2d_op2 = { { 0, 2 }, { 1, 1 } };
        uint[,,] ui_arr3d_op2 = { { { 0, 2 }, { 1, 1 } } };
        long[] l_arr1d_op2 = { 2, 0, 1 };
        long[,] l_arr2d_op2 = { { 0, 2 }, { 1, 1 } };
        long[,,] l_arr3d_op2 = { { { 0, 2 }, { 1, 1 } } };
        ulong[] ul_arr1d_op2 = { 2, 0, 1 };
        ulong[,] ul_arr2d_op2 = { { 0, 2 }, { 1, 1 } };
        ulong[,,] ul_arr3d_op2 = { { { 0, 2 }, { 1, 1 } } };
        float[] f_arr1d_op2 = { 2, 0, 1 };
        float[,] f_arr2d_op2 = { { 0, 2 }, { 1, 1 } };
        float[,,] f_arr3d_op2 = { { { 0, 2 }, { 1, 1 } } };
        double[] d_arr1d_op2 = { 2, 0, 1 };
        double[,] d_arr2d_op2 = { { 0, 2 }, { 1, 1 } };
        double[,,] d_arr3d_op2 = { { { 0, 2 }, { 1, 1 } } };
        decimal[] m_arr1d_op2 = { 2, 0, 1 };
        decimal[,] m_arr2d_op2 = { { 0, 2 }, { 1, 1 } };
        decimal[,,] m_arr3d_op2 = { { { 0, 2 }, { 1, 1 } } };

        int[,] index = { { 0, 0 }, { 1, 1 } };

            {
            decimal m_l_op1 = 50;
            int i_l_op2 = 2;
            uint ui_l_op2 = 2;
            long l_l_op2 = 2;
            ulong ul_l_op2 = 2;
            float f_l_op2 = 2;
            double d_l_op2 = 2;
            decimal m_l_op2 = 2;

            if (
                (cl1.m_cl_op1 / i_arr1d_op2[0] != cl1.m_cl_op1 / ui_arr1d_op2[0]) 
            || (cl1.m_cl_op1 / ui_arr1d_op2[0] != cl1.m_cl_op1 / l_arr1d_op2[0]) 
            || (cl1.m_cl_op1 / l_arr1d_op2[0] != cl1.m_cl_op1 / ul_arr1d_op2[0]) 
            || (cl1.m_cl_op1 / ul_arr1d_op2[0] != cl1.m_cl_op1 / (decimal)f_arr1d_op2[0]) 
            || (cl1.m_cl_op1 / (decimal)f_arr1d_op2[0] != cl1.m_cl_op1 / (decimal)d_arr1d_op2[0]) 
            || (cl1.m_cl_op1 / (decimal)d_arr1d_op2[0] != cl1.m_cl_op1 / m_arr1d_op2[0]) 
            || (cl1.m_cl_op1 / m_arr1d_op2[0] != cl1.m_cl_op1 / i_arr1d_op2[0]) 
            || (cl1.m_cl_op1 / i_arr1d_op2[0] != 25)
            )
            {
                passed = false;
            }
            if (
                (cl1.m_cl_op1 / i_arr2d_op2[index[0, 1], index[1, 0]] != cl1.m_cl_op1 / ui_arr2d_op2[index[0, 1], index[1, 0]]) 
            || (cl1.m_cl_op1 / ui_arr2d_op2[index[0, 1], index[1, 0]] != cl1.m_cl_op1 / l_arr2d_op2[index[0, 1], index[1, 0]]) 
            || (cl1.m_cl_op1 / l_arr2d_op2[index[0, 1], index[1, 0]] != cl1.m_cl_op1 / ul_arr2d_op2[index[0, 1], index[1, 0]]) 
            || (cl1.m_cl_op1 / ul_arr2d_op2[index[0, 1], index[1, 0]] != cl1.m_cl_op1 / (decimal)f_arr2d_op2[index[0, 1], index[1, 0]]) 
            || (cl1.m_cl_op1 / (decimal)f_arr2d_op2[index[0, 1], index[1, 0]] != cl1.m_cl_op1 / (decimal)d_arr2d_op2[index[0, 1], index[1, 0]]) 
            || (cl1.m_cl_op1 / (decimal)d_arr2d_op2[index[0, 1], index[1, 0]] != cl1.m_cl_op1 / m_arr2d_op2[index[0, 1], index[1, 0]]) 
            || (cl1.m_cl_op1 / m_arr2d_op2[index[0, 1], index[1, 0]] != cl1.m_cl_op1 / i_arr2d_op2[index[0, 1], index[1, 0]]) 
            || (cl1.m_cl_op1 / i_arr2d_op2[index[0, 1], index[1, 0]] != 25)
            )
            {
                passed = false;
            }
            if (
                (cl1.m_cl_op1 / i_arr3d_op2[index[0, 0], 0, index[1, 1]] != cl1.m_cl_op1 / ui_arr3d_op2[index[0, 0], 0, index[1, 1]]) 
                || (cl1.m_cl_op1 / ui_arr3d_op2[index[0, 0], 0, index[1, 1]] != cl1.m_cl_op1 / l_arr3d_op2[index[0, 0], 0, index[1, 1]]) 
                || (cl1.m_cl_op1 / l_arr3d_op2[index[0, 0], 0, index[1, 1]] != cl1.m_cl_op1 / ul_arr3d_op2[index[0, 0], 0, index[1, 1]]) 
                || (cl1.m_cl_op1 / ul_arr3d_op2[index[0, 0], 0, index[1, 1]] != cl1.m_cl_op1 / (decimal)f_arr3d_op2[index[0, 0], 0, index[1, 1]]) 
                || (cl1.m_cl_op1 / (decimal)f_arr3d_op2[index[0, 0], 0, index[1, 1]] != cl1.m_cl_op1 / (decimal)d_arr3d_op2[index[0, 0], 0, index[1, 1]]) 
                || (cl1.m_cl_op1 / (decimal)d_arr3d_op2[index[0, 0], 0, index[1, 1]] != cl1.m_cl_op1 / m_arr3d_op2[index[0, 0], 0, index[1, 1]]) 
                || (cl1.m_cl_op1 / m_arr3d_op2[index[0, 0], 0, index[1, 1]] != cl1.m_cl_op1 / i_arr3d_op2[index[0, 0], 0, index[1, 1]]) 
                || (cl1.m_cl_op1 / i_arr3d_op2[index[0, 0], 0, index[1, 1]] != 25)
                )
            {
                passed = false;
            }
            if (
                (vt1.m_vt_op1 / i_l_op2 != vt1.m_vt_op1 / ui_l_op2) 
            || (vt1.m_vt_op1 / ui_l_op2 != vt1.m_vt_op1 / l_l_op2) 
            || (vt1.m_vt_op1 / l_l_op2 != vt1.m_vt_op1 / ul_l_op2) 
            || (vt1.m_vt_op1 / ul_l_op2 != vt1.m_vt_op1 / (decimal)f_l_op2) 
            || (vt1.m_vt_op1 / (decimal)f_l_op2 != vt1.m_vt_op1 / (decimal)d_l_op2) 
            || (vt1.m_vt_op1 / (decimal)d_l_op2 != vt1.m_vt_op1 / m_l_op2) 
            || (vt1.m_vt_op1 / m_l_op2 != vt1.m_vt_op1 / i_l_op2)
            || (vt1.m_vt_op1 / i_l_op2 != 25)
            )
            {
                passed = false;
            }
            if (
                (vt1.m_vt_op1 / s_i_s_op2 != vt1.m_vt_op1 / s_ui_s_op2) 
                || (vt1.m_vt_op1 / s_ui_s_op2 != vt1.m_vt_op1 / s_l_s_op2) 
                || (vt1.m_vt_op1 / s_l_s_op2 != vt1.m_vt_op1 / s_ul_s_op2) 
                || (vt1.m_vt_op1 / s_ul_s_op2 != vt1.m_vt_op1 / (decimal)s_f_s_op2) 
                || (vt1.m_vt_op1 / (decimal)s_f_s_op2 != vt1.m_vt_op1 / (decimal)s_d_s_op2) 
                || (vt1.m_vt_op1 / (decimal)s_d_s_op2 != vt1.m_vt_op1 / s_m_s_op2) 
                || (vt1.m_vt_op1 / s_m_s_op2 != vt1.m_vt_op1 / s_i_s_op2) 
                || (vt1.m_vt_op1 / s_i_s_op2 != 25)
                )
            {
                passed = false;
            }
            if (
                (vt1.m_vt_op1 / m_f("op2") != vt1.m_vt_op1 / m_f("op2")) 
                || (vt1.m_vt_op1 / m_f("op2") != vt1.m_vt_op1 / m_f("op2")) 
                || (vt1.m_vt_op1 / m_f("op2") != vt1.m_vt_op1 / m_f("op2")) 
                || (vt1.m_vt_op1 / m_f("op2") != vt1.m_vt_op1 / (decimal)m_f("op2"))
                || (vt1.m_vt_op1 / (decimal)m_f("op2") != vt1.m_vt_op1 / (decimal)m_f("op2"))
                || (vt1.m_vt_op1 / (decimal)m_f("op2") != vt1.m_vt_op1 / m_f("op2"))
                || (vt1.m_vt_op1 / m_f("op2") != vt1.m_vt_op1 / m_f("op2"))
                || (vt1.m_vt_op1 / m_f("op2") != 25)
                )
            {
                passed = false;
            }
            if (
                (vt1.m_vt_op1 / cl1.i_cl_op2 != vt1.m_vt_op1 / cl1.ui_cl_op2) 
                || (vt1.m_vt_op1 / cl1.ui_cl_op2 != vt1.m_vt_op1 / cl1.l_cl_op2) 
                || (vt1.m_vt_op1 / cl1.l_cl_op2 != vt1.m_vt_op1 / cl1.ul_cl_op2) 
                || (vt1.m_vt_op1 / cl1.ul_cl_op2 != vt1.m_vt_op1 / (decimal)cl1.f_cl_op2) 
                || (vt1.m_vt_op1 / (decimal)cl1.f_cl_op2 != vt1.m_vt_op1 / (decimal)cl1.d_cl_op2) 
                || (vt1.m_vt_op1 / (decimal)cl1.d_cl_op2 != vt1.m_vt_op1 / cl1.m_cl_op2) 
                || (vt1.m_vt_op1 / cl1.m_cl_op2 != vt1.m_vt_op1 / cl1.i_cl_op2)
                || (vt1.m_vt_op1 / cl1.i_cl_op2 != 25)
                )
            {
                passed = false;
            }
            if (
                (vt1.m_vt_op1 / vt1.i_vt_op2 != vt1.m_vt_op1 / vt1.ui_vt_op2) 
            || (vt1.m_vt_op1 / vt1.ui_vt_op2 != vt1.m_vt_op1 / vt1.l_vt_op2) 
            || (vt1.m_vt_op1 / vt1.l_vt_op2 != vt1.m_vt_op1 / vt1.ul_vt_op2) 
            || (vt1.m_vt_op1 / vt1.ul_vt_op2 != vt1.m_vt_op1 / (decimal)vt1.f_vt_op2) 
            || (vt1.m_vt_op1 / (decimal)vt1.f_vt_op2 != vt1.m_vt_op1 / (decimal)vt1.d_vt_op2) 
            || (vt1.m_vt_op1 / (decimal)vt1.d_vt_op2 != vt1.m_vt_op1 / vt1.m_vt_op2) 
            || (vt1.m_vt_op1 / vt1.m_vt_op2 != vt1.m_vt_op1 / vt1.i_vt_op2) 
            || (vt1.m_vt_op1 / vt1.i_vt_op2 != 25)
            )
            {
                passed = false;
            }
            if (
                (vt1.m_vt_op1 / i_arr1d_op2[0] != vt1.m_vt_op1 / ui_arr1d_op2[0]) 
            || (vt1.m_vt_op1 / ui_arr1d_op2[0] != vt1.m_vt_op1 / l_arr1d_op2[0]) 
            || (vt1.m_vt_op1 / l_arr1d_op2[0] != vt1.m_vt_op1 / ul_arr1d_op2[0]) 
            || (vt1.m_vt_op1 / ul_arr1d_op2[0] != vt1.m_vt_op1 / (decimal)f_arr1d_op2[0]) 
            || (vt1.m_vt_op1 / (decimal)f_arr1d_op2[0] != vt1.m_vt_op1 / (decimal)d_arr1d_op2[0]) 
            || (vt1.m_vt_op1 / (decimal)d_arr1d_op2[0] != vt1.m_vt_op1 / m_arr1d_op2[0]) 
            || (vt1.m_vt_op1 / m_arr1d_op2[0] != vt1.m_vt_op1 / i_arr1d_op2[0]) 
            )
            {
                passed = false;
            }
            if (
                (vt1.m_vt_op1 / i_arr2d_op2[index[0, 1], index[1, 0]] != vt1.m_vt_op1 / ui_arr2d_op2[index[0, 1], index[1, 0]]) 
            || (vt1.m_vt_op1 / ui_arr2d_op2[index[0, 1], index[1, 0]] != vt1.m_vt_op1 / l_arr2d_op2[index[0, 1], index[1, 0]]) 
            || (vt1.m_vt_op1 / l_arr2d_op2[index[0, 1], index[1, 0]] != vt1.m_vt_op1 / ul_arr2d_op2[index[0, 1], index[1, 0]]) 
            || (vt1.m_vt_op1 / ul_arr2d_op2[index[0, 1], index[1, 0]] != vt1.m_vt_op1 / (decimal)f_arr2d_op2[index[0, 1], index[1, 0]]) 
            || (vt1.m_vt_op1 / (decimal)f_arr2d_op2[index[0, 1], index[1, 0]] != vt1.m_vt_op1 / (decimal)d_arr2d_op2[index[0, 1], index[1, 0]]) 
            || (vt1.m_vt_op1 / (decimal)d_arr2d_op2[index[0, 1], index[1, 0]] != vt1.m_vt_op1 / m_arr2d_op2[index[0, 1], index[1, 0]]) 
            || (vt1.m_vt_op1 / m_arr2d_op2[index[0, 1], index[1, 0]] != vt1.m_vt_op1 / i_arr2d_op2[index[0, 1], index[1, 0]]) 
            || (vt1.m_vt_op1 / i_arr2d_op2[index[0, 1], index[1, 0]] != 25)
            )
            {
                passed = false;
            }
            if (
                (vt1.m_vt_op1 / i_arr3d_op2[index[0, 0], 0, index[1, 1]] != vt1.m_vt_op1 / ui_arr3d_op2[index[0, 0], 0, index[1, 1]]) 
            || (vt1.m_vt_op1 / ui_arr3d_op2[index[0, 0], 0, index[1, 1]] != vt1.m_vt_op1 / l_arr3d_op2[index[0, 0], 0, index[1, 1]]) 
            || (vt1.m_vt_op1 / l_arr3d_op2[index[0, 0], 0, index[1, 1]] != vt1.m_vt_op1 / ul_arr3d_op2[index[0, 0], 0, index[1, 1]]) 
            || (vt1.m_vt_op1 / ul_arr3d_op2[index[0, 0], 0, index[1, 1]] != vt1.m_vt_op1 / (decimal)f_arr3d_op2[index[0, 0], 0, index[1, 1]]) 
            )
            {
                passed = false;
            }
  

        }

        return 100;
    }
}
