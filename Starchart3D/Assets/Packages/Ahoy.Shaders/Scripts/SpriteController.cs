using UnityEngine;
using Ahoy;

namespace Ahoy.Shaders
{

	public class SpriteController : MonoBehaviour
	{

		public Material spriteMat;
		public MeshRenderer spriteMeshRenderer;

		public float framesPerSecond = 2;

		public int startFrameIndex = 0;
		public int numFrames = 9;

		public bool autoStart;
		public bool loop = true;
		bool isPlaying = false;

		float currentTime;

		public NullUnityEvent onStopPlaying;

		void Start()
		{
			if (autoStart)
				StartPlaying();
		}

		public void StartPlaying()
		{
			currentTime = 0;
			SetFrameIndex(startFrameIndex);
			isPlaying = true;
		}

		public void StopPlaying()
		{
			isPlaying = false;
			onStopPlaying.Invoke();
		}

		void Update()
		{
			if (!isPlaying)
				return;

			float frameDuration = 1 / framesPerSecond;
			currentTime += Time.deltaTime;

			float totalTime = (numFrames) * frameDuration;

			if (currentTime >= totalTime)
			{
				if (loop)
					StartPlaying();
				else
				{
					StopPlaying();
					return;
				}
			}
			int frameIndex = startFrameIndex + Mathf.FloorToInt(currentTime * framesPerSecond);
			SetFrameIndex(frameIndex);
		}
		public void SetFrameIndex(int index)
		{
			if (spriteMat != null)
				spriteMat.SetInt("_FrameIndex", index);
			if (spriteMeshRenderer != null)
				spriteMeshRenderer.material.SetInt("_FrameIndex", index);
		}

	}
}