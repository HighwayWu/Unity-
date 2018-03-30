using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 由于此panel全屏覆盖，所以在层级界面中必须位于其他UI上方，否则会屏蔽其余UI
public class PausePanel : MonoBehaviour {

    private Animator anim;
    public GameObject pauseButton;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Resume()
    {
        // 播放继续动画
        Time.timeScale = 1;
        anim.SetBool("isPause", false);
    }

    public void Retry()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void Pause()
    {
        // 播放暂停动画
        pauseButton.SetActive(false);
        anim.SetBool("isPause", true);
    }

    public void PauseAnimEnd()
    {
        Time.timeScale = 0;
    }

    public void ResumeAnimEnd()
    {
        pauseButton.SetActive(true);
    }

    public void Home()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
