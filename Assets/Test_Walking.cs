using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Walking : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(0,0,Time.deltaTime);
        if(gameObject.transform.position.z > 4)
        gameObject.GetComponent<Animator>().SetBool("Dead",true);
	}
}
