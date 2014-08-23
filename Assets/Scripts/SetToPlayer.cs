using UnityEngine;
using System.Collections;

public class SetToPlayer : MonoBehaviour {


	void Start () {
		transform.parent = GameObject.FindGameObjectWithTag("PlayerSprite").transform;
		transform.localPosition = new Vector3(0,0,-10f);
	}

}
