using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 1f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0, 0.2f, 0);
	}
}
