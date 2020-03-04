using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Opt_Error
{    
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
	public class FourByte
	{
		[FieldOffset(0)]
		public int val;
		[FieldOffset(0)]
		public uint uval;
		[FieldOffset(0)]
		public float fval;
		[FieldOffset(0)]
		public byte b0;
		[FieldOffset(1)]
		public byte b1;
		[FieldOffset(2)]
		public byte b2;
		[FieldOffset(3)]
		public byte b3;

		public FourByte()
		{
		}

		public FourByte(int val)
		{
			this.val = val;
		}

		public FourByte(uint uval)
		{
			this.uval = uval;
		}

		public FourByte(float fval)
		{
			this.fval = fval;
		}

		public FourByte(byte[] array)
		{
			if (array.Length != 4)
				return;

			this.b0 = array[0];
			this.b1 = array[1];
			this.b2 = array[2];
			this.b3 = array[3];
		}

		public byte this[int i]
		{
			get
			{
				if (i == 0) return b0;
				else if (i == 1) return b1;
				else if (i == 2) return b2;
				else if (i == 3) return b3;
				else return 0;
			}

			set
			{
				if (i == 0) b0 = value;
				else if (i == 1) b1 = value;
				else if (i == 2) b2 = value;
				else if (i == 3) b3 = value;
			}
		}

		public void Twiddle()
		{
			byte b0 = this.b0;
			byte b1 = this.b1;
			byte b2 = this.b2;
			byte b3 = this.b3;

			this.b0 = b3;
			this.b1 = b2;
			this.b2 = b1;
			this.b3 = b0;
		}

		public byte[] ToByteArray()
		{
			byte[] array = new byte[4];

			array[0] = b0;
			array[1] = b1;
			array[2] = b2;
			array[3] = b3;

			return array;
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("{0:x2}-{1:x2}-{2:x2}-{3:x2}", b0, b1, b2, b3);
			return sb.ToString();
		}
	}

	class Program
	{
		private static uint old = 0;
		static int Main(string[] args)
		{
			FourByte fb = new FourByte(old);
			fb.b3 = 1;
			uint val = fb.uval;
			Console.WriteLine("Val " + val);
            return 100;
        }
	}
}
