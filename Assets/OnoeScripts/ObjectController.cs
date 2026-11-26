using Unity.VisualScripting;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
	[SerializeField] GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

	public void SetPlayer(GameObject player)
	{
		this.player = player;
	}

    // Update is called once per frame
    void Update()
    {
		if (transform.position.z < player.transform.position.z -10) Destroy(this.gameObject);
    }
}
