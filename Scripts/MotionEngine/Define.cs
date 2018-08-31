﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotionEngine
{
	public struct Vector3
	{
		public float X;
		public float Y;
		public float Z;
		public Vector3(float x, float y, float z)
		{
			X = x;
			Y = y;
			Z = z;
		}
	}

	public struct Vector2
	{
		public float X;
		public float Y;
		public Vector2(float x, float y)
		{
			X = x;
			Y = y;
		}
	}
}