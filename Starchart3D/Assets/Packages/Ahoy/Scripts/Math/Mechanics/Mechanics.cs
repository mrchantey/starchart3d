


using UnityEngine;

namespace Ahoy
{

    public static class Mechanics
    {

        public static readonly float GRAVITY_EARTH = -9.80665f;
        public static readonly Vector3 GRAVITY_EARTH_FORCE = new Vector3(0, GRAVITY_EARTH, 0);
        // public static readonly float INVERSE_GRAVITY_SQUARED = 0.5f *  GRAVITY_EARTH;

        /* PHYSICS MECHANICS 


formula rearranger: https://www.mymathtutors.com/algebra-tutors/adding-numerators/online-calculator---rearrange.html#c=simplify_algstepssimplify&v217=f%2520%253D%2520i%2520%2B%2520a%2520*%2520t&v218=t








// HORIZONTAL MOTION---------------------------------------------------------------------------

d = displacement
v = velocity
a = acceleration
t = time

v0/vi = initial velocity
vt = velocity at time
vf = final velocity

vt = vi + a * t

xf = xi + vi * t + 1/2 * a * t^2

vf^2 = vi^2 + 2 * a * d 

pos = ((vf + vi) /2) * t

avgVel = (vf + vi) / 2

*/

        //vf = vi + (a * t)
        public static float FinalVelocity(float initialVelocity, float acceleration, float time)
        {
            return initialVelocity + acceleration * time;
        }

        public static float TimeToPositionByVelocity(float initialPosition, float finalPosition, float initialVelocity, float finalVelocity)
        {
            return (2 * (finalPosition - initialPosition)) / (initialVelocity + finalVelocity);
        }


        public static float TimeToVelocity(float initialVelocity, float finalVelocity, float acceleration)
        {
            return (finalVelocity - initialVelocity) / acceleration;
        }

        public static float Acceleration(float initialPosition, float finalPosition, float initialVelocity, float finalVelocity, float time)
        {
            return -(2 * (initialPosition + initialVelocity * time - finalPosition) / (time * time));
        }

        public static float FinalPosition(float initialPosition, float initialVelocity, float acceleration, float time)
        {
            return initialPosition + initialVelocity * time + 0.5f * acceleration * time * time;
        }

        // VERTICAL MOTION---------------------------------------------------------------------------

        public static float TimeToPositionByAcceleration(float initialPosition, float finalPosition, float initialVelocity, float acceleration)
        {

            //plug into quadratic: a = aceleration, b = initialVelocity, c = displacement, x = time

            //positive quadratic because time cannot be negative
            //not sure why only the negative one is true
            //um i think because quadratic negative opens downward
            return Math.QuadraticNegative(0.5f * acceleration, initialVelocity, -(finalPosition - initialPosition));
            // return -((initialVelocity + Mathf.Sqrt(initialVelocity * initialVelocity + 2 * acceleration * finalPosition - 2 * acceleration * initialPosition)) / acceleration);
        }


        // PROJECTILE MOTION-----------------------------------------------------------------------

        public static Vector3 FinalProjectilePosition(Vector3 position, Vector3 velocity, float y1)
        {
            var world2D = To2D(position, position + velocity);
            world2D.pos1 -= world2D.pos0;

            float x = FinalProjectilePosition(world2D.pos1, world2D.pos0, y1);
            var posHoriz = world2D.dirHoriz * x;
            return new Vector3(position.x, 0, position.z) + new Vector3(posHoriz.x, y1, posHoriz.y);
        }



        public static float FinalProjectilePosition(float theta, float velocity, Vector2 pos0, float y1)
        {
            var vel = Math.PolarToCartesian(theta, velocity);
            return FinalProjectilePosition(vel, pos0, y1);
        }

        //time in air depends only on y component
        //displacement = vel.y * t + 0.5 * (-g^2) * t^2
        //0 = vel.y * t + 0.5 * (-g^2) * t^2 - displacement
        //quadratic equation to solve
        public static float FinalProjectilePosition(Vector2 velocity, Vector2 pos0, float y1)
        {
            var aX = 0;//drag
            var aY = GRAVITY_EARTH;

            float t = TimeToPositionByAcceleration(pos0.y, y1, velocity.y, aY);
            float x1 = FinalPosition(pos0.x, velocity.x, aX, t);
            return x1;
        }

        public static float DistanceToZenith(float theta, float velocity, float y0)
        {
            var vel0 = Math.PolarToCartesian(theta, velocity);
            var aY = GRAVITY_EARTH;
            var t = TimeToVelocity(vel0.y, 0, aY);
            return FinalPosition(y0, vel0.y, aY, t);
        }

        public static
        (Vector2 pos0, Vector2 pos1, Vector2 dirHoriz) To2D(Vector3 pos0, Vector3 pos1)
        {
            var dPos = pos1 - pos0;
            var dHoriz = dPos.XZ();
            var magHoriz = dHoriz.magnitude;
            var dirHoriz = dHoriz.normalized;


            var pos0Vec2 = new Vector2(0, pos0.y);
            var pos1Vec2 = new Vector2(magHoriz, pos1.y);

            return (pos0Vec2, pos1Vec2, dirHoriz);
        }

        public static Vector3 ProjectileVelocity(Vector3 pos0, Vector3 pos1, float initialVelocityX)
        {

            var pos2D = To2D(pos0, pos1);

            // var pos0XZ = pos0.XZ();
            // var pos1XZ = pos1.XZ();

            // var mag0X = pos0XZ.magnitude;


            var (theta, velocity) = ProjectileVelocity(pos2D.pos0, pos2D.pos1, initialVelocityX);

            var localVel = Math.PolarToCartesian(theta, velocity);

            var velHoriz = pos2D.dirHoriz * localVel.x;
            var worldVel = new Vector3(velHoriz.x, localVel.y, velHoriz.y);

            return worldVel;
        }

        public static (float theta, float velocity) ProjectileVelocity(Vector2 pos0, Vector2 pos1, float initialVelocityX)
        {
            var dPos = pos1 - pos0;
            float aY = GRAVITY_EARTH;
            float t = TimeToPositionByVelocity(pos0.x, pos1.x, initialVelocityX, initialVelocityX);

            //plug into quadratic: a = aceleration, b = initialVelocity, c = displacement, x = time
            float initialVelocityY = Math.QuadraticB(0.5f * aY, -dPos.y, t);
            var (theta, velocity) = Math.CartesianToPolar(initialVelocityX, initialVelocityY);
            // Debug.Log($"projectile velocity - distX: {pos1.x - pos0.x}\tt: {t}\tvelY: {initialVelocityY}");
            return (theta, velocity);
        }

        /*
        in t time the target travels targetVel * t and the projectile travels xVel * t

        vel2 - vel1 = dist
        t = dist / (vel2-vel1)
        */
        public static Vector3 ProjectileTargetNextPosition(Vector3 position, Vector3 targetPosition, Vector3 targetVelocity, float projectileVelocityX)
        {
            var targetVelMag = targetVelocity.magnitude;
            var targetDir = targetVelocity.normalized;

            var dist = (targetPosition - position).magnitude;
            var t = -(dist / (targetVelMag - projectileVelocityX));
            // targetLastPos = target.position;

            // if (debug)
            //     Debug.Log($"dist: {dist}\tt: {t}\ttarget velocity: {targetVelocity}");

            return targetPosition + targetVelocity * t;

            // return vel;
        }


    }
}