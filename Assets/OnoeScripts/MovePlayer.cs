using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{

	private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Keyboard.current.wKey.IsPressed())
		{
			//transform.eulerAngles = new Vector3(0, 0, 0);
			animator.SetBool("isWalking",true);
		}
		else animator.SetBool("isWalking", false);

		if (Keyboard.current.aKey.IsPressed())
		{
			//if(!Keyboard.current.wKey.IsPressed()) transform.eulerAngles = new Vector3(0, -45, 0);
			animator.SetBool("isLeft", true);
		}
		else animator.SetBool("isLeft", false);

		if (Keyboard.current.dKey.IsPressed())
		{
			//if (!Keyboard.current.wKey.IsPressed()) transform.eulerAngles = new Vector3(0,45,0);
			animator.SetBool("isRight", true);
		}
		else animator.SetBool("isRight", false);

	}
}
