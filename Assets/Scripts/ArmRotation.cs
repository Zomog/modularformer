using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour {

	void Update () {

        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        point.Normalize();

        float rotZ = Mathf.Atan2(point.y, point.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

	}
}
