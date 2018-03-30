using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Screen.SetResolution(1280, 720, false);
        Invoke("Load", 2);
	}
	
    private void Load()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
