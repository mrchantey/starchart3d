using UnityEngine;

namespace Ahoy.Compute
{


	public abstract class PositionData : ShaderData
	{
		protected abstract Vector3[] GetPositions();
		public virtual void ApplyToShaders(ComputeInstance computeInstance, MaterialInstance materialInstance) { }

		protected ComputeBuffer positionsBuffer;

		public int GetNumPositions() { Initialize(); return positions.Length; }
		public ComputeBuffer GetPositionsBuffer() { Initialize(); return positionsBuffer; }

		bool isInitialized;
		Vector3[] positions;

		protected virtual void OnInit() { }
		void Initialize()
		{
			if (isInitialized)
				return;
			positions = GetPositions();
			positionsBuffer = new ComputeBuffer(positions.Length, Vector3Extensions.stride);
			positionsBuffer.SetData(positions);
			isInitialized = true;
			OnInit();
		}


		void OnDestroy() { Cleanup(); }
		void OnDisable() { Cleanup(); }

		protected virtual void Cleanup()
		{
			isInitialized = false;
			if (positionsBuffer != null)
				positionsBuffer.Dispose();
		}
	}
}