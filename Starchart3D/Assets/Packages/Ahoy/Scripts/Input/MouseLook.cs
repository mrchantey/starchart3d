using UnityEngine;

namespace Ahoy
{


	public class MouseLook : MonoBehaviour
	{

		[Range(0, 1000)]
		public float mouseSensitivity = 250f;


		void Update()
		{

			var rotX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
			var rotY = -Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

			var curr = transform.localEulerAngles;
			transform.localRotation = Quaternion.Euler(curr.x + rotY, curr.y + rotX, 0.0f);
		}
	}
}