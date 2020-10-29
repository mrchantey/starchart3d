using UnityEngine;
using System;
using System.Collections.Generic;
namespace Ahoy
{

    public class ConsumableAhoyEvent<T>
    {

        List<Func<T, bool>> consumingListeners;
        List<Action<T>> nonConsumingListeners;

        // List<Func<T, bool>>consumingListenersOneShot;

        public ConsumableAhoyEvent()
        {
            consumingListeners = new List<Func<T, bool>>();
            nonConsumingListeners = new List<Action<T>>();
            //consumingListenersOneShot = new List<Func<T,bool>>();
        }

        public bool Invoke(T val)
        {
            var cl = consumingListeners.ToArray();
            for (int i = 0; i < cl.Length; i++)
            {
                if (cl[i](val))
                    return true;
            }
            nonConsumingListeners.ToArray().ForEach(l => l(val));
            return false;
        }


        public void AddListener(Func<T, bool> listener)
        {
            consumingListeners.TryAdd(listener);
        }

        public void RemoveListener(Func<T, bool> listener)
        {
            consumingListeners.TryRemove(listener);
        }
        public void AddListener(Action<T> listener)
        {
            nonConsumingListeners.TryAdd(listener);
        }

        public void RemoveListener(Action<T> listener)
        {
            nonConsumingListeners.TryRemove(listener);
        }



        // public void AddListenerOneShot(Func<T,bool> listener)
        // {
        //     listenersOneShot.TryAdd(listener);
        // }
        // public void RemoveListenerOneShot(Func<T,bool> listener)
        // {
        //     listenersOneShot.TryRemove(listener);
        // }
    }
    public class ConsumableAhoyEvent
    {

        List<Func<bool>> consumingListeners;
        List<Action> nonConsumingListeners;

        // List<Func<T, bool>>consumingListenersOneShot;

        public ConsumableAhoyEvent()
        {
            consumingListeners = new List<Func<bool>>();
            nonConsumingListeners = new List<Action>();
            //consumingListenersOneShot = new List<Func<T,bool>>();
        }

        public bool Invoke()
        {
            var cl = consumingListeners.ToArray();
            for (int i = 0; i < cl.Length; i++)
            {
                if (cl[i]())
                    return true;
            }
            nonConsumingListeners.ToArray().ForEach(l => l());
            return false;
        }

        public void AddListener(Func<bool> listener)
        {
            consumingListeners.TryAdd(listener);
        }

        public void RemoveListener(Func<bool> listener)
        {
            consumingListeners.TryRemove(listener);
        }
        public void AddListener(Action listener)
        {
            nonConsumingListeners.TryAdd(listener);
        }

        public void RemoveListener(Action listener)
        {
            nonConsumingListeners.TryRemove(listener);
        }



        // public void AddListenerOneShot(Func<T,bool> listener)
        // {
        //     listenersOneShot.TryAdd(listener);
        // }
        // public void RemoveListenerOneShot(Func<T,bool> listener)
        // {
        //     listenersOneShot.TryRemove(listener);
        // }
    }

}