using UnityEngine;

/// <summary>
/// Represents the camera following the player.
/// </summary>
public class CameraController : MonoBehaviour
{
	public GameObject player;
	public float timeOffset;
	public Vector3 posOffset;
	private Vector3 velocity;

	private void Start()
	{
		transform.position = player.transform.position;
	}

	private void Update()
	{
		transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
	}
}
