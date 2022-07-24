﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanMermiScript : MonoBehaviour
{
    [SerializeField] float speed;
    private Vector3 Enemym_lastKnownPosition;
    public static bool EnemyVuruldu;
    GameObject Trail;
    GameObject Trailobj;
    GameObject Dust;
    GameObject Dustobj;
    GameObject HitEffect;
    GameObject HitEffectobj;

    void Start()
    {
        Enemym_lastKnownPosition = NewDusman.EnemyateslenecekHarf.position;
        speed = 70f;
        StartCoroutine(Wait(0.8f));
        Trail = FindObjectOfType<LevelKelimeVeHarfleri>().BulletTrail;
        Trailobj = Instantiate(Trail, transform.position, Quaternion.identity);
        Trailobj.SetActive(true);
        Dust = FindObjectOfType<LevelKelimeVeHarfleri>().BulletDust;
        Dustobj = Instantiate(Dust, transform.position, Quaternion.identity);
        Dustobj.transform.eulerAngles = new Vector3(90, 0, 0);
        Dustobj.SetActive(true);
        EnemyVuruldu = false;
    }

    void Update()
    {
        Trailobj.transform.position = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, Enemym_lastKnownPosition, speed * Time.deltaTime);//bu satır üstekinin yerine eklendi.
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == NewDusman.EnemyateslenecekHarf.tag)
        {
            EnemyVuruldu = true;
            Destroy(Trailobj);
            Destroy(Dustobj);
            HitEffect = FindObjectOfType<LevelKelimeVeHarfleri>().HitEfect;
            HitEffectobj = Instantiate(HitEffect, transform.position, Quaternion.identity);
            HitEffectobj.SetActive(true);
            HitEffectobj.AddComponent<HitEfectDestroy>();
            Destroy(gameObject);


        }

    }
    IEnumerator Wait(float sure)
    {
        yield return new WaitForSecondsRealtime(sure);
        EnemyVuruldu = true;
        Destroy(gameObject);
        Destroy(Trailobj);
        Destroy(Dustobj);
    }
}
