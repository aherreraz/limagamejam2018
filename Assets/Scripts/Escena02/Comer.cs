﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comer : MonoBehaviour
{
    public Stat BarraHambre;
    public GameObject Jhon;

    private void Awake()
    {
        BarraHambre.Initialize();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Mosca>())
        {
            BarraHambre.Value++;
            collision.GetComponent<Animator>().SetTrigger("Die");
            collision.GetComponent<Mosca>().enabled = false;
            Destroy(collision.gameObject, 0.5f);
        }

        else if (collision.GetComponent<Cucaracha>())
        {
            BarraHambre.Value += 2;
            collision.GetComponent<Animator>().SetTrigger("Die");
            collision.GetComponent<Cucaracha>().enabled = false;
            collision.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            Destroy(collision.gameObject, 0.5f);
        }

        else if (collision.GetComponent<Paloma>())
        {
            collision.GetComponent<Animator>().SetTrigger("GetHit");
            collision.GetComponent<Paloma>().enabled = false;
            Destroy(collision.gameObject, 0.5f);
            Jhon.GetComponent<Animator>().SetTrigger("Die");
            StartCoroutine(LevelManager.instance.ReloadLevel(0.7f));
        }

        else if (collision.GetComponent<Gato>())
        {
            collision.GetComponent<Animator>().SetTrigger("GetHit");
            collision.GetComponent<Gato>().enabled = false;
            collision.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            Destroy(collision.gameObject, 0.5f);
            Jhon.GetComponent<Animator>().SetTrigger("Die");
            StartCoroutine(LevelManager.instance.ReloadLevel(0.7f));
        }

        if (BarraHambre.Value >= BarraHambre.MaxVal)
            LevelManager.instance.LoadNextLevel();
    }
}
