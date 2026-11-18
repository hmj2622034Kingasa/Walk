using UnityEngine;

public class Surveillance : MonoBehaviour
{
	[SerializeField] private GameObject Face; // 監視の顔の画像
	[SerializeField] private GameObject Yellow; // 黄色の注意画像
	[SerializeField] private GameObject Red; // 赤色の警告画像
	[SerializeField] private float interval = 3.0f; // 注視間隔
	[SerializeField] private float flashSpeed = 0.4f; // 点滅時間（黄）（四回繰り返す、計：1.6f）
	[SerializeField] private float minAlpha = 20.0f; // 最小の透明度
	[SerializeField] private float maxAlpha = 60.0f; // 最大の透明度
	[SerializeField] private float warnung = 1.0f; // 警告時間(赤＋顔)
	[SerializeField] bool watch = false; // 監視が注視しているかどうか

	private float timer1 = 0; // タイマー
	private float timer2 = 0; // タイマー2

	private void Start()
	{
		float rand = Random.Range(0f, 4.0f); // 0～4までのランダム値
	}

	private void Update()
	{
		float wave = (Mathf.Sin(Time.time * flashSpeed) +1.0f);
		//Yellow.alpha = Mathf.Lerp(minAlpha, maxAlpha, wave);

		timer1++; // タイマーの増加
		if (timer1 >= interval * 60)
		{
			Yellow.SetActive(true);
			//timer2++;
			//if (timer2 >= flash)
			//{

			//}
		}

	}
}
