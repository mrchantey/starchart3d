using UnityEngine;

namespace Ahoy
{

	public enum Axis2D
	{
		XZ,
		XY,
		YZ
	}

	public class KeyboardController : MonoBehaviour
	{


		[Range(0, 64)]
		public float speed = 1f;
		[Range(0, 64)]
		public float torque = 1f;
		[Range(0, 64)]
		public float scrollSpeed = 3f;
		public Axis2D axis = Axis2D.XZ;
		private void Update()
		{

			Vector3 dir = Vector3.zero;
			float rotDir = 0;
			Vector3 rotation;
			Vector3 vel;
			switch (axis)
			{
				case Axis2D.XZ:
					if (Input.GetKey(KeyCode.W))
						dir.z += 1;
					if (Input.GetKey(KeyCode.S))
						dir.z -= 1;
					if (Input.GetKey(KeyCode.A))
						dir.x -= 1;
					if (Input.GetKey(KeyCode.D))
						dir.x += 1;
					dir.y = Input.mouseScrollDelta.y * scrollSpeed;
					vel = dir * speed * Time.deltaTime;
					transform.Translate(vel, Space.Self);

					rotDir = 0;
					if (Input.GetKey(KeyCode.Q))
						rotDir -= 1;
					if (Input.GetKey(KeyCode.E))
						rotDir += 1;
					rotation = Vector3.up * rotDir * torque;
					transform.Rotate(rotation, Space.Self);
					break;
				case Axis2D.XY:
					if (Input.GetKey(KeyCode.W))
						dir.y += 1;
					if (Input.GetKey(KeyCode.S))
						dir.y -= 1;
					if (Input.GetKey(KeyCode.A))
						dir.x -= 1;
					if (Input.GetKey(KeyCode.D))
						dir.x += 1;
					dir.z = Input.mouseScrollDelta.y * scrollSpeed;
					vel = dir * speed * Time.deltaTime;
					transform.Translate(vel, Space.Self);

					rotDir = 0;
					if (Input.GetKey(KeyCode.Q))
						rotDir -= 1;
					if (Input.GetKey(KeyCode.E))
						rotDir += 1;
					rotation = Vector3.forward * rotDir * torque;
					transform.Rotate(rotation, Space.Self);
					break;
				case Axis2D.YZ:
					if (Input.GetKey(KeyCode.W))
						dir.z += 1;
					if (Input.GetKey(KeyCode.S))
						dir.z -= 1;
					if (Input.GetKey(KeyCode.A))
						dir.y -= 1;
					if (Input.GetKey(KeyCode.D))
						dir.y += 1;
					dir.x = Input.mouseScrollDelta.y * scrollSpeed;
					vel = dir * speed * Time.deltaTime;
					transform.Translate(vel, Space.Self);

					rotDir = 0;
					if (Input.GetKey(KeyCode.Q))
						rotDir -= 1;
					if (Input.GetKey(KeyCode.E))
						rotDir += 1;
					rotation = Vector3.right * rotDir * torque;
					transform.Rotate(rotation, Space.Self);
					break;
			}
		}
	}

}