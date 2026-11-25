using UnityEngine;
using UnityEngine.UI;

public class Surveillance : MonoBehaviour
{
	[SerializeField] private GameObject Caution; // 注意画面
	[SerializeField] private GameObject Warning; // 警告画面
	[SerializeField] private Image CautionImage; // 注意画像
	[SerializeField] private float interval = 5.0f; // 注視間隔
	[SerializeField] private float warning = 1.0f; // 警告時間
	[SerializeField] private int flashCount = 4; // 点滅回数
	[SerializeField] private float flashSpeed = 0.4f; // 点滅の速さ
	[SerializeField] private float alphaMax = 0.8f; // alpha値のMAX
	[SerializeField] bool watch = false; // 監視が注視しているかどうか
	[SerializeField] bool alphaUp = true; // alpha値が増加しているか

	private float safeTimer = 0f; // 安全時間用タイマー
	private float warningTimer = 0f; // 警告時間用タイマー
	private float alpha = 0; // 画像のalpha値（透明度）
	private int count = 0; // 点滅の現在の回数

	void Update()
	{
		float rand = Random.Range(0f, 5.0f); // ランダム値

		safeTimer++; // 安全時間カウント
		if (safeTimer >= (interval + rand) * 60)
		{   // 注意画面の点滅
			Caution.SetActive(true); // 注意画面表示

			if (alphaUp == true)
			{ // alpha値の増加
				alpha += Time.deltaTime * flashSpeed;
				if (alpha >= alphaMax)
				{ // MAX alphaMax
					alpha = alphaMax;
					alphaUp = false;
				}
			}
			else
			{ // alpha値の減少
				alpha -= Time.deltaTime * flashSpeed;
				if (alpha <= 0)
				{ // MIN 0
					alpha = 0;
					alphaUp = true;
					count++; // 点滅のカウント増加
				}
			}
			// 注意画像のalpha値の変化
			Color color = CautionImage.color;
			color.a = alpha;
			CautionImage.color = color;
		}
		if (count >= flashCount)
		{ // 点滅後、警告画面
			Caution.SetActive(false); // 注意画面非表示
			Warning.SetActive(true); // 警告画面表示
			watch = true; // 注視中
			
			warningTimer++; // 警告時間カウント
			if (warningTimer >= warning * 60)
			{
				watch = false; // 注視解除
				Warning.SetActive(false); // 警告画面非表示
				safeTimer = 0f; // 安全タイマーのリセット
				warningTimer = 0f; // 警告タイマーリセット
				count = 0; // 点滅カウントのリセット
				alphaUp = true; // alpha値の変化 bool値
				alpha = 0f;
			}
		}
	}
}