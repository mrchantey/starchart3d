using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Ahoy
{

	[Serializable]
	public class Gen010UnityEvent : UnityEvent<gen010> { }
	[Serializable]
	public class Gen010NamedUnityEvent : UnityEvent<string, gen010> { }
	[Serializable]
	public class Gen010DoubleUnityEvent : UnityEvent<gen010, gen010> { }
	[Serializable]
	public class Gen010TripleUnityEvent : UnityEvent<gen010, gen010, gen010> { }
	[Serializable]
	public class Gen010QuadrupleUnityEvent : UnityEvent<gen010, gen010, gen010, gen010> { }
	[Serializable]
	public class Gen010ArrayUnityEvent : UnityEvent<gen010[]> { }
	[Serializable]
	public class Gen010ListUnityEvent : UnityEvent<List<gen010>> { }
	[Serializable]
	public class Gen010ArrayPoolUnityEvent : UnityEvent<Gen010ArrayPool> { }

}