using UnityEngine;
using UnityEngine.UI;

public class Surveillance : MonoBehaviour
{
	[SerializeField] private GameObject Caution; // 注意画面
	[SerializeField] private GameObject Warning; // 警告画面
	
	[SerializeField] private Image ImageRight; // 注意画像右
	[SerializeField] private Image ImageLeft; // 左
	[SerializeField] private Image ImageMiddle; // 真ん中

	[SerializeField] private float interval = 5.0f; // 注視間隔
	[SerializeField] private float warning = 1.0f; // 警告時間
	[SerializeField] private float speed = 0.4f; // alpha値変化の速さ
	[SerializeField] private float alphaMaxRight = 1f; // alpha値のMAX右
	[SerializeField] private float alphaMaxLeft = 1f; // 左
	[SerializeField] private float alphaMaxMiddle = 0.8f; // 真ん中
	[SerializeField] private float faceTime = 120f; // alpha = 1になってから顔が表示されるまでの間隔
	private	bool alMax = false; // alpha = 1になったかどうか
	bool watch = false; // 監視が注視しているかどうか

	private float safeTimer = 0f; // 安全時間用タイマー
	private float warningTimer = 0f; // 警告時間用タイマー
	private float timer = 0f; // alphaがmaxになってからのタイマー
	private float alphaRight = 0f; // 画像のalpha値（透明度）右
	private float alphaLeft = 0f; // 左
	private float alphaMiddle = 0f; // 真ん中


	void Update()
	{
		float rand = Random.Range(0f, 5.0f); // ランダム値

		safeTimer++; // 安全時間カウント
		if (safeTimer >= (interval + rand) * 60)
		{   
			Caution.SetActive(true); // 注意画面表示
			alphaRight += Time.deltaTime * speed; // 右
			if (alphaRight >= alphaMaxRight)
			{ // MAX alphaMax
				alphaRight = alphaMaxRight;
			}
			alphaLeft += Time.deltaTime * speed; // 左
			if (alphaLeft >= alphaMaxLeft) 
			{
				alphaLeft = alphaMaxLeft;
				alMax = true;
			}
			alphaMiddle += Time.deltaTime * speed; // 真ん中
			if (alphaMiddle >= alphaMaxMiddle)
			{
				alphaMiddle = alphaMaxMiddle;
			}
			// 注意画像のalpha値の変化
			Color color = ImageRight.color;
			color.a = alphaRight;
			ImageRight.color = color;

			Color color2 = ImageLeft.color;
			color2.a = alphaLeft;
			ImageLeft.color = color2;
			
			Color color3 = ImageMiddle.color;
			color3.a = alphaMiddle;
			ImageMiddle.color = color3;
		}
		if(alMax == true){ timer++; } // alphaがmaxになってから顔画像が表示されるまでのカウント
		if (timer >= faceTime * 60)
		{ // 点滅後、警告画面
			Warning.SetActive(true); // 警告画面表示
			watch = true; // 注視中
			warningTimer++; // 警告時間カウント
			if (warningTimer >= warning * 60)
			{
				Warning.SetActive(false); // 警告画面非表示
				Caution.SetActive(false); // 注意画面非表示
				// 変数のリセット
				watch = false;
				alMax = false;
				safeTimer = 0f;
				warningTimer = 0f;
				timer = 0f;
				alphaRight = 0f;
				alphaLeft = 0f;
				alphaMiddle = 0f;
			}
		}
	}
}