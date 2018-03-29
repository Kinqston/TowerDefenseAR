using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBAR : MonoBehaviour {
    // Use this for initialization
    public GameObject CameraMain;

    void Start () {
        CameraMain = GameObject.Find("Camera");
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.LookAt(CameraMain.transform);
	}
}
