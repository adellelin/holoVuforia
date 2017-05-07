using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(Vector3.up * Time.deltaTime * 10);
       
        this.transform.Rotate(0, 0, 1f);

        
    }
}
