using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour {

    public float maxSpeed = 10;
    public float minSpeed = 5;
    public Sprite hurt;
    private SpriteRenderer render;
    public GameObject boom;
    public GameObject score;
    public bool isPig = true;

    public AudioClip hurtClip;
    public AudioClip death;
    public AudioClip birdCollision;
    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            AudioPlay(birdCollision);
            collision.transform.GetComponent<Bird>().Hurt();
        }

        if(collision.relativeVelocity.magnitude > maxSpeed)
        {
            DeathOfPig();
        }else if(collision.relativeVelocity.magnitude > minSpeed && collision.relativeVelocity.magnitude < maxSpeed){
            render.sprite = hurt;
            AudioPlay(hurtClip);
        }
    }

    public void DeathOfPig()
    {
        if (isPig)
        {
            GameManager._instance.pigs.Remove(this);
        }
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
        GameObject tmp = Instantiate(score, transform.position + new Vector3(0,0.8f,0), Quaternion.identity);
        Destroy(tmp, 1.5f);

        AudioPlay(death);
    }

    private void AudioPlay(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }

}
