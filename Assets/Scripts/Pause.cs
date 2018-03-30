using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    // Use this for initialization

    public void Continue()
    {
        PlayerStats.Pause = false;
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
