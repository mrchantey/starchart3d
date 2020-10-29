using UnityEngine;
using NUnit.Framework;
namespace Ahoy
{


    public class TestMechanics
    {

        [Test]
        public void TestHorizontalMotion()
        {
            var x0 = 0f;
            var v0 = 0f;
            var a = 2.5f;
            var t = 10f;

            var vf = Mechanics.FinalVelocity(v0, a, t);
            var xf = Mechanics.FinalPosition(x0, v0, a, t);
            Assert.AreEqual(25, vf);
            Assert.AreEqual(125, xf);

            //time to resting position
            x0 = 0f;
            v0 = 27f;
            a = -8.4f;
            vf = 0;
            t = Mechanics.TimeToVelocity(v0, vf, a);
            xf = Mechanics.FinalPosition(0, v0, a, t);
            Assert.IsTrue(3.214286f.IsAlmostEqual(t));
            Assert.IsTrue(43.39286f.IsAlmostEqual(xf));

            x0 = 0f;
            xf = 50;
            v0 = 15;
            vf = 0;
            t = Mechanics.TimeToPositionByVelocity(x0, xf, v0, vf);
            a = Mechanics.Acceleration(x0, xf, v0, vf, t);
            Assert.AreEqual(a, -2.25f);

            // Debug.Log($"final: t: {t}\txf: {xf}\ta: {a}");
        }


        [Test]
        public void TestVerticleMotion()
        {

            float a = Mechanics.GRAVITY_EARTH;
            float y0 = 100;
            float yf = 0;
            float v0 = 0;
            // float vf = Mechanics.GetFinalVelocity(0,)
            // float t = Mechanics.GetTimeToPosition(y0,yf,0)
            float t = Mechanics.TimeToPositionByAcceleration(y0, yf, v0, a);
            float vf = Mechanics.FinalVelocity(v0, a, t);

            // Debug.Log($"t: {t}\tvf: {vf}");
            Assert.IsTrue(t.IsAlmostEqual(4.516007f));
            Assert.IsTrue(vf.IsAlmostEqual(-44.2869f));

            v0 = 10f;
            t = Mechanics.TimeToPositionByAcceleration(y0, yf, v0, a);
            vf = Mechanics.FinalVelocity(v0, a, t);
            Assert.IsTrue(t.IsAlmostEqual(5.649419f));
            Assert.IsTrue(vf.IsAlmostEqual(-45.40187f));
        }


        [Test]
        public void TestProjectileMotion()
        {
            // var theta = Mathf.PI / 4;
            float theta = Mathf.Deg2Rad * 30;
            float vel = 8.5f;
            var pos0 = new Vector2(0, 100);

            float y2 = 0;
            float x1 = Mechanics.FinalProjectilePosition(theta, vel, pos0, y2);


            // Debug.Log($"t: {t}\tx1: {x1}");

            Assert.IsTrue(x1.IsAlmostEqual(36.58623f));


            vel = 28;
            float y1 = Mechanics.DistanceToZenith(theta, vel, 0);
            Assert.IsTrue(y1.IsAlmostEqual(9.993218f));


            pos0 = new Vector2(0, 0);
            var pos1 = new Vector2(100, 0);
            var velX = 5;
            var (angle, velocity) = Mechanics.ProjectileVelocity(pos0, pos1, velX);
            angle = angle * Mathf.Rad2Deg;

            // Debug.Log($"angle: {angle}, velocity: {velocity}");

        }


    }
}