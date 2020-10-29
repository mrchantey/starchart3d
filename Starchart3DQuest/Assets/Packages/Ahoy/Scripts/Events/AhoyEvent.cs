using UnityEngine;
using System;
using System.Collections.Generic;
namespace Ahoy
{

    public class AhoyEvent<T>
    {

        List<Action<T>> listeners;
        List<Action<T>> listenersOneShot;

        public AhoyEvent()
        {
            listeners = new List<Action<T>>();
            listenersOneShot = new List<Action<T>>();
        }

        public void Invoke(T val)
        {
            //need to convert to array in case one is removed
            listeners.ToArray().ForEach(l => l(val));
            listenersOneShot.ToArray().ForEach(l => l(val));
            // listeners.ToArray().ForEach(l => l.Invoke(val));
            // listenersOneShot.ToArray().ForEach(l => l.Invoke(val));
            listenersOneShot.Clear();
        }

        public void AddListener(Action<T> listener)
        {
            listeners.TryAdd(listener);
        }

        public void RemoveListener(Action<T> listener)
        {
            listeners.TryRemove(listener);
        }

        public void AddListenerOneShot(Action<T> listener)
        {
            listenersOneShot.TryAdd(listener);
        }
        public void RemoveListenerOneShot(Action<T> listener)
        {
            listenersOneShot.TryRemove(listener);
        }

        public void Clear() { listeners.Clear(); }
        public void ClearOneShot() { listenersOneShot.Clear(); }

    }

    public class AhoyEvent
    {


        List<Action> listeners;
        List<Action> listenersOneShot;

        public AhoyEvent()
        {
            listeners = new List<Action>();
            listenersOneShot = new List<Action>();
        }

        public void Invoke()
        {
            //need to convert to array in case one is removed
            listeners.ToArray().ForEach(l => l());
            listenersOneShot.ToArray().ForEach(l => l());
            // listeners.ToArray().ForEach(l => l.Invoke());
            // listenersOneShot.ToArray().ForEach(l => l.Invoke());
            listenersOneShot.Clear();
        }

        public void AddListener(Action listener)
        {
            if (!listeners.Contains(listener))
                listeners.Add(listener);
        }
        public void RemoveListener(Action listener)
        {
            if (listeners.Contains(listener))
                listeners.Remove(listener);
        }
        public void AddListenerOneShot(Action listener)
        {
            if (!listenersOneShot.Contains(listener))
                listenersOneShot.Add(listener);
        }
        public void RemoveListenerOneShot(Action listener)
        {
            if (listenersOneShot.Contains(listener))
                listenersOneShot.Remove(listener);
        }
        public void Clear() { listeners.Clear(); }
        public void ClearOneShot() { listenersOneShot.Clear(); }

    }
}