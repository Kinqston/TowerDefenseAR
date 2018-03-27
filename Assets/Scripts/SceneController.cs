using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	// Use this for initialization
	public void Scene_Controller(int level)
    {
        SceneManager.LoadScene(level);
    }
}
