using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelect : MonoBehaviour {

    public int startsNum = 0;
    private bool isSelect = false;

    public GameObject locks;
    public GameObject stars;

    public GameObject panel;
    public GameObject map;
    public Text starsText;
    public int startNum = 1;
    public int endNum = 3;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("totalNum", 0) >= startsNum)
        {
            isSelect = true;
        }

        if (isSelect)
        {
            locks.SetActive(false);
            stars.SetActive(true);

            int cnt = 0;
            for (int i = startNum; i <= endNum; i++)
            {
                cnt += PlayerPrefs.GetInt("level" + i.ToString(), 0);
            }
            starsText.text = cnt.ToString() + " / 9";
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Selected()
    {
        if (isSelect)
        {
            panel.SetActive(true);
            map.SetActive(false);
        }
    }

    public void PanelSelected()
    {
        panel.SetActive(false);
        map.SetActive(true);
    }
}
