using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Surveillance : MonoBehaviour
{
	[SerializeField] private GameObject Caution; // 注意画面
	[SerializeField] private Image CautionImage; // 注意画像
	[SerializeField] private GameObject Warning; // 警告画面

	[SerializeField] private float interval = 5.0f; // 注視間隔
	[SerializeField] private float caution = 10f; // 注意時間
	[SerializeField] private float flashSpeed = 0.4f; // 点滅の速さ
	[SerializeField] private float warning = 1.0f; // 警告時間
	[SerializeField] bool watch = false; // 監視が注視しているかどうか


	private float safeTimer = 0f; // 安全時間用タイマー
	private float cautionTimer = 0f; // 注意時間用タイマー
	private float warningTimer = 0f; // 警告時間用タイマー
	private float colorTimer = 0f;

	void Update()
	{
		colorTimer++;
		//var alpha = Mathf.Cos((float)(2 * Mathf.PI * colorTimer / flashSpeed)) * 0.5f + 0.5f;
		Color color = CautionImage.color; // 注意画像の色
		color.a = Mathf.Abs(Mathf.Sin(Time.time * flashSpeed)) - 0.4f; // alpha値の変化
		float rand = Random.Range(0f, 5.0f); // ランダム値

		safeTimer++; // 安全時間カウント
		if (safeTimer >= (interval + rand) * 60)
		{   // 注意画面の点滅
			Caution.SetActive(true);
		
			//var color = CautionImage.color;
			//color.a = alpha;
			CautionImage.color = color;

		}
			
			cautionTimer++; // 注意時間カウント
			if (cautionTimer >= caution * 60)
			{
				Caution.SetActive(false); // 注意画面非表示
				Warning.SetActive(true); // 警告画面表示
				watch = true; // 注視中
				warningTimer++; // 警告時間カウント
				if (warningTimer >= warning * 60)
				{
					watch = false; // 注視解除
					Warning.SetActive(false); // 警告画面非表示
					safeTimer = 0f; // タイマーのリセット
					//cautionTimer = 0f;
					warningTimer = 0f;
				}
			}
		
	}
}