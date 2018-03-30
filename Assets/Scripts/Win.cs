using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Show();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Show()
    {
        GameManager._instance.ShowStar();
    }
}
