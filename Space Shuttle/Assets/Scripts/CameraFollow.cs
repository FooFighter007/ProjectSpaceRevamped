using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform rocketTransform;
    public Transform myTransform;
   

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rocket = new Vector3(rocketTransform.transform.position.x, rocketTransform.transform.position.y + 18, -43);
        myTransform.transform.position = rocket;
        
	}
}
 