// using UnityEngine;
// using NUnit.Framework;
// namespace Ahoy
// {


// 	public class TestMath
// 	{


// 		[Test]
// 		public void TestCartesianToPolar()
// 		{
// 			var cart = Vector2.right;
// 			var polar = Math.CartesianToPolar(cart);
// 			Assert.AreEqual(polar.theta, 0);
// 			Assert.AreEqual(polar.radius, 1);
// 		}

// 		[Test]
// 		public void TestPolarToCartesian()
// 		{
// 			var cart = Math.PolarToCartesian(0, 1);
// 			Assert.AreEqual(cart.x, 1);
// 			Assert.AreEqual(cart.y, 0);
// 		}

// 		[Test]
// 		public void TestCreateMatrix()
// 		{
// 			var a = Vector3.forward * 10 + Vector3.one * 100;
// 			var b = a + Vector3.up;
// 			var c = a + Vector3.right;
// 			var matrix = Math.PointsToMatrix(a, b, c);
// 			var worldFwd = matrix.LocalToWorld.MultiplyPoint3x4(Vector3.forward);
// 			// Debug.Log($"world forward: {worldFwd}");
// 			Assert.IsTrue(worldFwd.IsAlmostEqual(a + Vector3.forward));
// 			// Assert.IsTrue(matrix == Matrix4x4.identity);
// 		}

// 		[Test]
// 		public void TestQuadratic()
// 		{
// 			var a = 1f;
// 			var b = 4f;
// 			var c = -21f;

// 			var x1 = Math.QuadraticPositive(a, b, c);
// 			var x2 = Math.QuadraticNegative(a, b, c);

// 			Assert.AreEqual(3, x1);
// 			Assert.AreEqual(-7, x2);

// 			a = -4.9f;
// 			b = 4.25f;
// 			c = 100f;
// 			var x3 = Math.QuadraticPositive(a, b, c);
// 			Debug.Log($"x3: {x3}");

// 			// Debug.Log($"x1 :{x1}\tx2: {x2}");


// 		}


// 	}
// }