using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using ElephantSDK;

public class LevelController : MonoBehaviour
{
    public static List<string> Kelimler = new List<string>();
    public static List<string> EnemyKelimler = new List<string>();
    public static List<string> Harfler = new List<string>();

    [SerializeField] TextMeshProUGUI UIHarfObjesi;
    private List<TextMeshProUGUI> UIHarfObjeListesi = new List<TextMeshProUGUI>();
    [SerializeField] GameObject UIHarfMerkezi;
    string alphabetsLetter = "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z";
    string[] alphabetsTemp;
    public static List<string> Alphabets = new List<string>();
    [SerializeField] GameObject BulletsPaketi;
    public List<GameObject> Bullets = new List<GameObject>(); //levelde kullan?lacak olan Playerbullet grubu

    [SerializeField] GameObject EnemyBulletsPaketi;
    public List<GameObject> EnemyBullets = new List<GameObject>(); //levelde kullan?lacak olan Playerbullet grubu

    //#### ?EMBER D?Z?L?M? ???N GEREKL? DE???KENLER

    int n;
    float aciArtisi;
    float AciArtisiTemp;
    List<float> aciDizilimiListesi = new List<float>();
    float harfDizilimiX;
    float harfDizilimiY;

    //####

    public List<GameObject> Leveller = new List<GameObject>();

    int cameraSayac = 0;

    public static int levelSayac = 0;

    public static bool yeniLeveleGecildi = false;
    public static GameObject levelTemp;

    private int _currentLevel;
    int harfKonumFarki;

    void Awake()
    {
        AlfabeOlustur();
        //PlayerPrefs.SetInt("DevamEdenLevel", 0);
        levelSayac = PlayerPrefs.GetInt("DevamEdenLevel");
        levelTemp = Instantiate(Leveller[levelSayac], new Vector3(0, 0, 0), Quaternion.identity);
        _currentLevel = PlayerPrefs.GetInt("MevcutLevel");
        Elephant.LevelStarted(_currentLevel);
    }

    // Update is called once per frame
    void Update()
    {
        levelSayac = PlayerPrefs.GetInt("DevamEdenLevel");
        harfKonumFarki = (int)(FindObjectOfType<boyutAyarla>().genislik * 0.117f);
        Debug.Log("harkonumfarki = " + harfKonumFarki);
    }


    public void KelimeVeHarfCek()
    {
        if (UIHarfObjeListesi.Count > 0)
        {
            for (int i = 0; i < UIHarfObjeListesi.Count; i++)
            {
                Destroy(UIHarfObjeListesi[i].gameObject);
            }
        }
        UIHarfObjeListesi.Clear();
        NewDusman.TapToStartKontrol = true;
        //Kelimler.Clear();
        //EnemyKelimler.Clear();
        Kelimler.AddRange(FindObjectOfType<LevelKelimeVeHarfleri>().LevelKelimeleri); //Debug.Log ile kontrol ettim de?erleri al?p Kelimler listesine i?lemi?.
        EnemyKelimler.AddRange(FindObjectOfType<LevelKelimeVeHarfleri>().LevelKelimeleri);
        Harfler.Clear();
        Harfler.AddRange(FindObjectOfType<LevelKelimeVeHarfleri>().LevelHarfleri);    //Debug.Log ile kontrol ettim de?erleri al?p Harfler listesine i?lemi?.

        aciArtisi = 360 / Harfler.Count;
        AciArtisiTemp = 90;
        for (int i = 0; i < Harfler.Count; i++)
        {
            AciArtisiTemp = (AciArtisiTemp + aciArtisi);
            harfDizilimiX = Mathf.Cos(Mathf.PI * AciArtisiTemp / 180) * ((FindObjectOfType<boyutAyarla>().genislik / 2) - harfKonumFarki);
            harfDizilimiY = (Mathf.Sin(Mathf.PI * AciArtisiTemp / 180) * ((FindObjectOfType<boyutAyarla>().genislik / 2) - harfKonumFarki)) + (FindObjectOfType<boyutAyarla>().genislik / 2);
            UIHarfObjeListesi.Add(Instantiate(UIHarfObjesi, UIHarfMerkezi.transform));
            UIHarfObjeListesi[i].transform.localPosition = new Vector3(harfDizilimiX, harfDizilimiY, 0);
            UIHarfObjeListesi[i].GetComponent<TextMeshProUGUI>().text = Harfler[i];
            UIHarfObjeListesi[i].GetComponent<BoxCollider>().isTrigger = true;
            UIHarfObjeListesi[i].gameObject.AddComponent<UIHarfScript>();
        }

        for (int i = 0; i < BulletsPaketi.transform.childCount; i++)
        {
            Bullets.Add(BulletsPaketi.transform.GetChild(i).gameObject);
            EnemyBullets.Add(EnemyBulletsPaketi.transform.GetChild(i).gameObject);
        }
    }
    private void AlfabeOlustur()
    {
        alphabetsTemp = alphabetsLetter.Split(' ');
        Alphabets.AddRange(alphabetsTemp);
    }
    public void LevelYukle()
    {
        levelTemp = Instantiate(Leveller[levelSayac], new Vector3(0, 0, 0), Quaternion.identity);
        _currentLevel = PlayerPrefs.GetInt("MevcutLevel");
        Elephant.LevelStarted(_currentLevel);
    }

}
