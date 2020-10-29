using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ahoy
{

    public class Promise<T>
    {


        AhoyEvent<T> onResolve;
        AhoyEvent<Exception> onReject;
        T cache;
        Exception cachedException;
        bool isResolved;
        bool isRejected;


        public Promise()
        {
            onResolve = new AhoyEvent<T>();
            onReject = new AhoyEvent<Exception>();
        }

        public Promise<T> Then(Action<T> action)
        {
            onResolve.AddListenerOneShot(action);
            if (isResolved)
                onResolve.Invoke(cache);
            return this;
        }

        public Promise<T> Catch(Action<Exception> action)
        {
            onReject.AddListenerOneShot(action);
            if (isRejected)
                onReject.Invoke(cachedException);
            return this;
        }

        public void Resolve(T val)
        {
            if (isResolved)
                Debug.LogWarning("promise is already resolved");
            else
            {
                cache = val;
                isResolved = true;
                onResolve.Invoke(val);
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

        public static Promise<T[]> All(Promise<T>[] proms)
        {
            var prom = new Promise<T[]>();
            int resCount = 0;
            T[] vals = new T[proms.Length];
            proms.ForEach((p, i) =>
            p.Then((T val) =>
            {
                resCount++;
                vals[i] = val;
                if (resCount == proms.Length)
                    prom.Resolve(vals);
            }));
            proms.ForEach(p => p.Catch(ex =>
            {
                prom.Reject(ex);
            }));
            return prom;
        }
    }
}