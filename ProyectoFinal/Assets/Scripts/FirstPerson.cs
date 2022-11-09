using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{

	[Range(0.1f, 9f)] [SerializeField]
	private float sensitivity = 2f;

	[Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
	[Range(0f, 90f)] [SerializeField] 
	private float yRotationLimit = 88f;

	[SerializeField] private Vector3 offset;
	[SerializeField] private Transform playerPosition;
	[SerializeField] private Transform cameraPosition;
	Vector2 rotation;

	const int number = 10;
	const string xAxis = "Mouse X"; //Strings in direct code generate garbage, storing and re-using them creates no garbage
	const string yAxis = "Mouse Y";

	
	void Update()
	{
		rotation.x += Input.GetAxis(xAxis) * sensitivity;
		rotation.y += Input.GetAxis(yAxis) * sensitivity;

		//Debug.Log(rotation);

		rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);

		var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
		var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

		transform.localRotation = xQuat * yQuat;

		playerPosition.rotation = Quaternion.Euler(0, rotation.x, 0);
	}
	void LateUpdate()
    {
		transform.position = cameraPosition.position + offset;
    }
}
