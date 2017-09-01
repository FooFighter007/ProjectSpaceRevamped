using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ShipMovement : MonoBehaviour {

    public Rigidbody rb;
    public float waitTime = 5f;
    public float upwardForce = 500f;
    public float sideForce = 300f;
    public ParticleSystem Burner;
    public float x;
    public float y;
    public float z;
    public string device;

	// Use this for initialization
	void Start () {

        Screen.orientation = ScreenOrientation.Portrait;

        device = SystemInfo.deviceName;

        Debug.Log(PlayerPrefs.GetInt("MaxLevel"));

        if (PlayerPrefs.GetInt("MaxLevel") < 1)
        {
            PlayerPrefs.SetInt("MaxLevel", 1);
        }

        Burner.emissionRate = 200f;
        Debug.Log(PlayerPrefs.GetInt("MaxLevel"));
	}
	

	// Update is called once per frame
	void FixedUpdate () {

        x = Input.acceleration.x;
        y = Input.acceleration.y;
        z = Input.acceleration.z;

        if (waitTime <= 0f)
        {
            if(SystemInfo.supportsAccelerometer == true)
            {
                rb.AddForce(Input.acceleration.x * 40f * Time.deltaTime, 0f, 0f, ForceMode.Impulse);
                transform.Rotate(0f, Input.acceleration.x * 100 * Time.deltaTime, 0f);
            }

            //rb.AddForce(Input.acceleration.x * 40f * Time.deltaTime, 0f, 0f, ForceMode.Impulse);
            //transform.Rotate(0f, Input.acceleration.x * 100 * Time.deltaTime, 0f); 

            rb.AddForce(0, upwardForce * Time.deltaTime, 0);

            if (Input.GetKey("a"))
            {
                transform.Rotate(0, -90 * Time.deltaTime, 0);
                rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.Impulse);
            }

            if (Input.GetKey("d"))
            {
                transform.Rotate(0, 90 * Time.deltaTime, 0);
                rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.Impulse);
            }
        }

        if (waitTime <= -1.5f)
        {
            Burner.emissionRate = 15f;
        }

        waitTime -= Time.deltaTime;

    }
}
