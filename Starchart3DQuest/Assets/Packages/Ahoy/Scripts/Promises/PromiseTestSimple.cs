using UnityEngine;

namespace Ahoy
{

    public class PromiseTestSimple : MonoBehaviour
    {

        Promise promise;
        private void Start()
        {
            CountToTen()
            .Then(() => Debug.Log($"reached ten on frame ${Time.frameCount}"));
            // .Catch(() => Debug.Log("rejected"));
        }

        private void Update()
        {
            if (Time.frameCount == 10)
                promise.Resolve();
        }

        Promise CountToTen()
        {

            promise = new Promise();
            return promise;
        }

    }

}