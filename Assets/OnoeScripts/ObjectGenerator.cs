using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
	[SerializeField] GameObject player; // ÉvÉåÉCÉÑÅ[

	[SerializeField] GameObject[] wall;
	int cloneInterval=5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(cloneInterval<player.transform.position.z+50)
		{
			GameObject clone = Instantiate(wall[Random.Range(0,wall.Length)],new Vector3(Random.Range(-2.5f,1.5f),0.18f,cloneInterval),Quaternion.Euler(0f, Random.Range(-90,90),0f));
			clone.GetComponent<ObjectController>().SetPlayer(player);
			cloneInterval += Random.Range(5,25);
		}
    }
}
