using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFollow : MonoBehaviour {

    public Transform rocketTransform;
    public Transform myTransform;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rocket = new Vector3(0.09f, rocketTransform.transform.position.y -8, 0.09f);
        myTransform.transform.position = rocket;
    }
}
