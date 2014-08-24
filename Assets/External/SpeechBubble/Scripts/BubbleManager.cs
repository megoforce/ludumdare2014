using UnityEngine;
using System.Collections;

public class BubbleManager : MonoBehaviour 
{

    private GameObject playerPrefab;

	void Start () 
    {
        playerPrefab = (GameObject)Resources.Load("Prefab/Player");
        StartCoroutine(instantiatNewPlayers());
	}
	

	void Update () 
    {
        
	}

    IEnumerator instantiatNewPlayers()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject newPlayer = (GameObject)Instantiate(playerPrefab, new Vector3(Random.Range(-20f, 20f), 0.5f, Random.Range(-20f, 20f)), Quaternion.identity);
            newPlayer.AddComponent<PlayerMovement>();
            newPlayer.GetComponent<SpeechBubble>().isBot = true;
        }
        yield return new WaitForSeconds(20);
        StartCoroutine(instantiatNewPlayers());
    }
}
