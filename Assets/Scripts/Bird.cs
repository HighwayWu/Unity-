using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    private bool isClick = false;
    public Transform rightPos;
    public Transform leftPos;
    public float maxDis;

    [HideInInspector]
    public SpringJoint2D sp;
    protected Rigidbody2D rg;
    public LineRenderer right;
    public LineRenderer left;
    public GameObject boom;
    protected Tail tail;
    public bool canMove = false;
    public float smooth = 3;//平滑度

    public AudioClip select;
    public AudioClip fly;

    private bool isFly = false;

    public Sprite hurt;
    protected SpriteRenderer render;

    public void Awake()
    {
        sp = GetComponent<SpringJoint2D>();
        rg = GetComponent<Rigidbody2D>();
        tail = GetComponent<Tail>();
        render = GetComponent<SpriteRenderer>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isClick) {
            //鼠标点击小鸟拖动时位置变化
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position += new Vector3(0, 0, -Camera.main.transform.position.z);

            if(Vector3.Distance(transform.position, rightPos.position) > maxDis)
            {
                Vector3 pos = (transform.position - rightPos.position).normalized;
                pos *= maxDis;
                transform.position = pos + rightPos.position;
            }

            Line();
        }

        //相机跟随
        float posX = transform.position.x;
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position,
            new Vector3(Mathf.Clamp(posX, -6.2f, 13), Camera.main.transform.position.y, Camera.main.transform.position.z), smooth * Time.deltaTime);

        if (isFly)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ShowSkill();
            }
        }
    }

    private void OnMouseDown()
    {
        if (canMove)
        {
            AudioPlay(select);
            isClick = true;
            rg.isKinematic = true;
        }
    }

    private void OnMouseUp()
    {
        if (canMove)
        {
            isClick = false;
            rg.isKinematic = false;
            Invoke("Fly", 0.1f);
            //禁用画线组建
            right.enabled = false;
            left.enabled = false;
            canMove = false;
        }
    }

    private void Fly()
    {
        isFly = true;
        AudioPlay(fly);
        tail.StartTrails();
        sp.enabled = false; //小鸟飞行时使SpringJoint失效
        Invoke("Next", 5);
    }

    private void Line()
    {
        right.enabled = true;
        left.enabled = true;
        right.SetPosition(0, rightPos.position);
        right.SetPosition(1, transform.position);
        left.SetPosition(0, leftPos.position);
        left.SetPosition(1, transform.position);
    }

    protected virtual void Next()
    {
        GameManager._instance.birds.Remove(this);
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
        GameManager._instance.NextBird();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isFly = false;
        tail.ClearTrails();
    }

    private void AudioPlay(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip,transform.position);
    }

    //小黄鸟的特殊技能 空中加速
    public virtual void ShowSkill()
    {
        isFly = false;
    }

    public void Hurt()
    {
        render.sprite = hurt;
    }
}
