using System;
using UnityEngine;

namespace Ahoy
{


    //MOSTLY BROKEN
    [System.Serializable]
    public class TransformSetter
    {
        public Transform source;
        public Transform target;
        public Space space;
        public Pose deltaPose;

        public void Initialize()
        {
            deltaPose = new Pose() { position = target.position - source.position, rotation = Quaternion.FromToRotation(source.position, target.position) };
        }

        public void Update()
        {
            var sourcePose = space == Space.World ? source.Pose() : source.LocalPose();
            var pose = new Pose() { position = deltaPose.position + sourcePose.position, rotation = deltaPose.rotation * sourcePose.rotation };
            target.SetPositionAndRotation(pose);
        }

    }

}