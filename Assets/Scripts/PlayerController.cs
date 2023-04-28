using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Represents the control of the player
/// </summary>
public class PlayerController : MonoBehaviour
{
	private Rigidbody rb;
	private Transform orientation;
	private Vector3 moveDirection;
	private float horizontalInput;
	private float verticalInput;
	public float speed;
	public float groundDrag;
	private int score;
	public int health = 5;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		orientation = GetComponent<Transform>();
		rb.freezeRotation = true;
	}

	private void Update()
	{
		if (health == 0)
		{
			Debug.Log("Game Over!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
		TakeInput();
		rb.drag = groundDrag;
	}

	private void FixedUpdate()
	{
		MovePlayer();
	}

	private void TakeInput()
	{
		horizontalInput = Input.GetAxisRaw("Horizontal");
		verticalInput = Input.GetAxisRaw("Vertical");
	}

	private void MovePlayer()
	{
		moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
		rb.AddForce(moveDirection.normalized * speed * 10f, ForceMode.Force);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Pickup"))
		{
			score++;
			Debug.Log("Score: " + score);
			Destroy(other.gameObject);
		}
		else if (other.CompareTag("Trap"))
		{
			health--;
			Debug.Log("Health: " + health);
		}
		else if (other.CompareTag("Goal"))
		{
			Debug.Log("You win!");
		}
	}
}
