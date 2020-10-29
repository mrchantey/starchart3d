using UnityEngine;
using System.Linq;
namespace Ahoy
{

    public class PromiseTest : MonoBehaviour
    {

        Promise promise;
        Promise<int>[] promises;

        private void Start()
        {
            promises = GetAllPromises();
            Promise<int>.All(promises)
            .Then((int[] vals) => Debug.Log($"yep, all promises resolved {vals[0]},{vals[1]},{vals[2]},{vals[3]}"));
        }

        private void Update()
        {
            // int i = Time.frameCount - 1;
            // if (i < promises.Length)
            // {
            //     promises[i].Resolve(i);
            // }
        }

        Promise<int>[] GetAllPromises()
        {
            var proms = new Promise<int>[4] { new Promise<int>(), new Promise<int>(), new Promise<int>(), new Promise<int>() };
            proms.ForEach(p => p.Resolve(Random.Range(0, 10)));
            return proms;
        }

    }

}