using UnityEngine;

public class Surveillance : MonoBehaviour
{
	[SerializeField] private GameObject Face; // 監視の顔の画像
	[SerializeField] private GameObject Yellow; // 黄色の注意画像
	[SerializeField] private GameObject Red; // 赤色の警告画像
	[SerializeField] float interval = 3.0f; // 注視間隔
	[SerializeField] float flash = 0.4f; // 点滅時間（黄）（四回繰り返す、計：1.6f）
	[SerializeField] float warnung = 1.0f; // 警告時間(赤＋顔)
	[SerializeField] bool watch = false; // 監視が注視しているかどうか

	private void Start()
	{
		float rand = Random.Range(0f, 4.0f); // 0～4までのランダム値
	}

	private void Update()
	{
		
	}
}
