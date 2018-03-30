using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

    public bool isSelect = false;
    public Sprite levelBG;
    private Image image;
    public GameObject[] stars;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

	// Use this for initialization
	void Start () {
        if (transform.parent.GetChild(0).name == gameObject.name)
        {
            isSelect = true;
        }
        else
        {
            //前一关通关后开通当前关
            int preNum = int.Parse(gameObject.name) - 1;
            if(PlayerPrefs.GetInt("level" + preNum.ToString()) > 0)
            {
                isSelect = true;
            }

            //由于只做了9关，所以后边的关上锁
            if(int.Parse(gameObject.name) > 9)
            {
                isSelect = false;
            }
        }

        if (isSelect)
        {
            image.overrideSprite = levelBG;
            transform.Find("Text").gameObject.SetActive(true);

            int count = PlayerPrefs.GetInt("level" + gameObject.name);  //获取关卡名字->获取关卡星星数
            if(count > 0)
            {
                for(int i = 0; i < count; i++)
                {
                    stars[i].SetActive(true);
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Selected()
    {
        if (isSelect)
        {
            PlayerPrefs.SetString("nowLevel","level" + gameObject.name);
            SceneManager.LoadScene(2);
        }
    }
}
