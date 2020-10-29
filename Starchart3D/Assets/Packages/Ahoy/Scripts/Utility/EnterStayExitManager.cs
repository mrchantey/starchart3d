using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
namespace Ahoy
{

	public class EnterStayExitManager<T> where T : IEquatable<T>
	{

		List<T> current;
		public List<T> next;

		Action<T> onEnter;
		Action<T> onStay;
		Action<T> onExit;


		public EnterStayExitManager(int maxElements, Action<T> onEnter, Action<T> onStay, Action<T> onExit)
		{
			current = new List<T>(maxElements);
			next = new List<T>(maxElements);
			this.onEnter = onEnter;
			this.onStay = onStay;
			this.onExit = onExit;
		}

		public void AddToNext(T val)
		{
			next.Add(val);
		}

		public void Evaluate()
		{
			next.ForEach(n =>
			{
				if (current.Any(c => c.Equals(n)))
					onStay(n);
				else
					onEnter(n);
			});

			current.ForEach(c =>
			{
				if (!next.Any(n => n.Equals(c)))
					onExit.Invoke(c);
			});
			var temp = current;
			current = next;
			next = temp;
			next.Clear();
		}
	}
}