using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    // nowLevel : String, 保存当前关卡名字, 格式: level0
    // level0   : int, 保存此关卡获得星数
    // totalNum : int, 保存总获得星数

    public List<Bird> birds;
    public List<Pig> pigs;
    public static GameManager _instance;
    private Vector3 originPos;
    public GameObject win;
    public GameObject lose;
    public GameObject[] stars;
    public GameObject pauseButton;
    private int startsNum = 0;
    private int totalNum = 6;

    private void Awake()
    {
        _instance = this;
        if(birds.Count > 0)
            originPos = birds[0].transform.position;
    }

	// Use this for initialization
	void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Init()
    {
        for(int i = 0; i < birds.Count; i++)
        {
            if (i == 0)
            {
                birds[i].transform.position = originPos;
                birds[i].canMove = true;
                birds[i].enabled = true;
                birds[i].sp.enabled = true;
            }
            else
            {
                birds[i].canMove = false;
                birds[i].enabled = false;
                birds[i].sp.enabled = false;
            }
        }
    }

    // 游戏逻辑判断
    public void NextBird()
    {
        if(pigs.Count > 0)
        {
            if(birds.Count > 0)
            {
                Init();
            }
            else
            {
                //Lose
                lose.SetActive(true);
                pauseButton.SetActive(false);
            }
        }
        else
        {
            // Win
            win.SetActive(true);
            pauseButton.SetActive(false);
        }
    }

    public void ShowStar()
    {
        StartCoroutine("show");
    }

    IEnumerator show()
    {
        for (; startsNum < birds.Count + 1; startsNum++)
        {
            if (startsNum >= stars.Length)
                break;
            yield return new WaitForSeconds(0.2f);
            stars[startsNum].SetActive(true);
        }
    }

    public void Replay()
    {
        SaveData();
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }

    public void Home()
    {
        SaveData();
        SceneManager.LoadScene(1);
    }

    public void SaveData()
    {
        if (startsNum > PlayerPrefs.GetInt(PlayerPrefs.GetString("nowLevel")))
        {
            PlayerPrefs.SetInt(PlayerPrefs.GetString("nowLevel"), startsNum);
        }

        // 保存所有星星数目
        int sum = 0;
        for(int i = 1; i <= totalNum; i++)
        {
            sum += PlayerPrefs.GetInt("level" + i.ToString());
        }
        PlayerPrefs.SetInt("totalNum", sum);
    }
}
