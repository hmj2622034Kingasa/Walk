using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
	Rigidbody rigid;
	private Animator animator;
	[SerializeField] GameObject mainCamera;

	[SerializeField] float walkSpeed=10;
	[SerializeField] float leftRightS=5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		rigid = GetComponent<Rigidbody>();
		animator =GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		rigid.linearVelocity = Vector2.zero;
		mainCamera.transform.position = new Vector3(0, 5, transform.position.z - 3);
		if (Keyboard.current.wKey.IsPressed())
		{
			rigid.AddForce(Vector3.forward * walkSpeed, ForceMode.Force);
			animator.SetBool("isWalking",true);
		}
		else animator.SetBool("isWalking", false);

		if (Keyboard.current.aKey.IsPressed())
		{
			if (Keyboard.current.wKey.IsPressed()) { rigid.AddForce(Vector3.left * leftRightS, ForceMode.Force); }
			animator.SetBool("isLeft", true);
		}
		else animator.SetBool("isLeft", false);

		if (Keyboard.current.dKey.IsPressed())
		{
			if (Keyboard.current.wKey.IsPressed()) { rigid.AddForce(Vector3.right * leftRightS, ForceMode.Force); }
			animator.SetBool("isRight", true);
		}
		else animator.SetBool("isRight", false);

	}
}
