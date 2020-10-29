using System;
using System.Linq;
using UnityEngine;

namespace Ahoy
{

    public class Promise
    {

        AhoyEvent onResolve;
        AhoyEvent<Exception> onReject;
        bool isResolved;
        bool isRejected;
        Exception cachedException;

        public Promise()
        {
            onResolve = new AhoyEvent();
            onReject = new AhoyEvent<Exception>();
        }

        public Promise Then(Action action)
        {
            onResolve.AddListenerOneShot(action);
            if (isResolved)
                onResolve.Invoke();
            return this;
        }

        public Promise Catch(Action<Exception> action)
        {
            onReject.AddListenerOneShot(action);
            if (isRejected)
                onReject.Invoke(cachedException);
            return this;
        }

        public void Resolve()
        {
            if (isResolved)
                Debug.LogWarning("promise is already resolved");
            else
            {
                isResolved = true;
                onResolve.Invoke();
            }
        }

        public void Reject(Exception ex)
        {
            if (isRejected)
                Debug.LogWarning("promise is already rejected");
            else
            {
                cachedException = ex;
                isRejected = true;
                onReject.Invoke(ex);
            }
        }


        public static Promise All(Promise[] proms)
        {
            var prom = new Promise();
            int resCount = 0;
            proms.ForEach(p => p.Then(() =>
            {
                resCount++;
                if (resCount == proms.Length)
                    prom.Resolve();
            }));
            proms.ForEach(p => p.Catch(ex =>
            {
                prom.Reject(ex);
            }));
            return prom;
        }
    }

}