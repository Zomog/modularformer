using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Transform target;

	void Start () {

        target = GameObject.Find("Player").transform;
		
	}

	void LateUpdate () {

        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y,-2,2), transform.position.z);
        
	}
}
