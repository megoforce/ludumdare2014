using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    private Vector3 dir;
    public bool disableAutoDestroy;

    void Start()
    {
        dir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        if (!disableAutoDestroy)
            Destroy(this.gameObject, 30f);
        StartCoroutine(changeDirection());
    }


    void Update()
    {
        transform.Translate(dir.normalized * Time.deltaTime * 2f);
    }

    IEnumerator changeDirection()
    {
        yield return new WaitForSeconds(Random.Range(3f, 10f));
        dir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        StartCoroutine(changeDirection());
    }
}
