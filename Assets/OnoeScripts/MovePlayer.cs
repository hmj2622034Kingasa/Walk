using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
	Rigidbody rigid;
	private Animator animator;
	[SerializeField] GameObject mainCamera;	// カメラ
	[SerializeField] GameObject mainFloor;	// 床

	[SerializeField] float walkSpeed=10;
	[SerializeField] float leftRightS=5;
	[SerializeField] int rotateS=2;
	[SerializeField] float backPct = 80;
	[SerializeField] float altitude;

	int playerR = 0;

	int speedLv;
	int HpLv;

	bool walk;
	bool left;
	bool right;
	bool back;

	[SerializeField]bool hide = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		Application.targetFrameRate = 60;
		rigid = GetComponent<Rigidbody>();
		animator =GetComponent<Animator>();
    }

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("wall"))
		{
			hide = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("wall"))
		{
			hide = false;
		}
	}

	public float GetAltitude()
	{
		return altitude;
	}



	// Update is called once per frame
	void Update()
    {
		rigid.linearVelocity = Vector2.zero;
		mainCamera.transform.position = new Vector3(0, 5+ altitude, transform.position.z - 3);	// カメラをプレイヤーに追従させる
		mainFloor.transform.position = new Vector3(0, altitude, transform.position.z);	// 床のz座標をプレイヤーと同じように動かす

		if (walk==true&&playerR==0)	// 通常歩き
		{
			if(left||right)rigid.AddForce(Vector3.forward * walkSpeed/1.5f, ForceMode.Force);
			else if(transform.position.x>0)rigid.AddForce(Vector3.forward * (walkSpeed*(1.5f-(transform.position.x/5))), ForceMode.Force);
			else rigid.AddForce(Vector3.forward * (walkSpeed * 1.5f), ForceMode.Force);
			animator.SetBool("isWalking", true);
		}
		else if(!left&&!right)animator.SetBool("isWalking", false);

		if (back==true&&walk==false&&left==false&&right==false)	// 後ろ歩き
		{
			rigid.AddForce(-Vector3.forward * backPct*(walkSpeed/100), ForceMode.Force);
			animator.SetBool("isBack",true);
		}
		else animator.SetBool("isBack", false);

		transform.rotation = Quaternion.Euler(0, playerR, 0);

		if (left)   // 左
		{
			if (walk)
			{
				rigid.AddForce(Vector3.left * leftRightS, ForceMode.Force);
				animator.SetBool("isLeft", true);
				animator.SetBool("isWalking", true);
				playerR = 0;
			}
			else
			{	animator.SetBool("isWalking", true);
				if (right) animator.SetBool("isWalking", false);
				if (right && playerR < 0) playerR += rotateS;
				else if (playerR > -90) playerR -= rotateS;
				else rigid.AddForce(Vector3.left * walkSpeed, ForceMode.Force);
				animator.SetBool("isLeft", false);
			}
		}
		else 
		{
			animator.SetBool("isLeft", false);
			
		}

		if (right)  // 右
		{
			if (walk)
			{
				rigid.AddForce(Vector3.right * leftRightS, ForceMode.Force);
				animator.SetBool("isRight", true);
				animator.SetBool("isWalking", true);
				playerR = 0;
			}
			else
			{ 
				animator.SetBool("isWalking", true);
				if (left) animator.SetBool("isWalking", false);
				if (left && playerR > 0)playerR -= rotateS;
				else if (playerR < 90) playerR += rotateS;
				else rigid.AddForce(Vector3.right * walkSpeed, ForceMode.Force);
				animator.SetBool("isRight", false);
			}
		}
		else 
		{
			animator.SetBool("isRight", false);
			
		}

		if (!left && !right)
		{
			if (playerR > 0) playerR-=rotateS;
			if (playerR < 0) playerR+=rotateS;
		}

		if (transform.position.x > 3) transform.position=new Vector3(3,0.18f + altitude, transform.position.z);
		if (transform.position.x < -3) transform.position=new Vector3(-3,0.18f + altitude, transform.position.z);

		// キー入力確認
		if (Keyboard.current.wKey.IsPressed()) walk = true;
		else walk = false;

		if (Keyboard.current.aKey.IsPressed()) left = true;
		else left = false;

		if (Keyboard.current.dKey.IsPressed()) right = true;
		else right = false;

		if (Keyboard.current.sKey.IsPressed()) back = true;
		else back = false;
	}
}
