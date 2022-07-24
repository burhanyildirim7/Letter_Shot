using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class boyutAyarla : MonoBehaviour
{
    [SerializeField] GameObject TusTakimiArkaPlani;
    [SerializeField] GameObject referansHarf;
    [SerializeField] Canvas UIEkrani;
    public int genislik;
    int harfGenisligi;
    int ekranGenisligi;
    //float gOrani, hOrani;


    void Start()
    {
        genislik = 1;
    }

    void Update()
    {
        Debug.Log("sizdelta X= " + (int)UIEkrani.GetComponent<RectTransform>().sizeDelta.x);
        Debug.Log("sizdelta Y= " + UIEkrani.GetComponent<RectTransform>().sizeDelta.y);
        ekranGenisligi = (int)UIEkrani.GetComponent<RectTransform>().sizeDelta.x;
        genislik = (int)(ekranGenisligi * 0.725f);
        Debug.Log("hesaplanan genişliği = " + genislik);
        //yukseklik = Screen.height*(600/1792);
        if (genislik >= 1000)
        {
            genislik = 1000;
        }
        else
        {

        }
        TusTakimiArkaPlani.GetComponent<RectTransform>().sizeDelta = new Vector2(genislik, genislik);
        harfGenisligi = (int)(genislik * (0.253f));
        Debug.Log("harf genişliği = " + harfGenisligi);
        referansHarf.GetComponent<RectTransform>().sizeDelta = new Vector2(harfGenisligi, harfGenisligi);
    }
}
