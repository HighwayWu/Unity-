﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBlack : Bird {
    private List<Pig> blocks = new List<Pig>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            blocks.Add(collision.gameObject.GetComponent<Pig>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            blocks.Remove(collision.gameObject.GetComponent<Pig>());
        }
    }

    public override void ShowSkill()
    {
        base.ShowSkill();
        if(blocks != null && blocks.Count > 0)
        {
            for(int i=0;i<blocks.Count;i++)
            {
                blocks[i].DeathOfPig();
            }
        }
        Clear();
    }

    private void Clear()
    {
        rg.velocity = Vector3.zero;
        Instantiate(boom, transform.position, Quaternion.identity);
        render.enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        tail.ClearTrails();
    }

    protected override void Next()
    {
        GameManager._instance.birds.Remove(this);
        Destroy(gameObject);
        GameManager._instance.NextBird();
    }
}
