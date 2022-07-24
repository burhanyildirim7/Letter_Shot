using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class NewDusman : MonoBehaviour
{
    public static bool EnemyvurulduMu;
    public static string EnemycurrentWord;
    public static Transform EnemyateslenecekHarf;
    private GameObject _currentWordBullet;

    List<string> kullanilanKelimler = new List<string>();
    [SerializeField] List<string> EnemyCurrentWordHarfleri = new List<string>();
    string[] EnemyCurrentWordTemp;
    [SerializeField] public Transform enemyCannonFirePoint;

    [SerializeField] public static bool EnemyatesEdiliyor;
    int BulletSayac;
    public static bool TapToStartKontrol;

    float zamanlayaci;
    // Start is called before the first frame update
    void Start()
    {
        TapToStartKontrol = false;
        EnemyvurulduMu = true;
        EnemyatesEdiliyor = false;
        zamanlayaci = 0;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCannonFirePoint =FindObjectOfType<LevelKelimeVeHarfleri>().EnemyAtesEtmeNoktasi.transform ;
        if (TapToStartKontrol)
        {
            zamanlayaci = zamanlayaci + Time.deltaTime * 1f;
            if (zamanlayaci>8)
            {
                zamanlayaci = 0;
            }
            else
            {

            }
            // Debug.Log("zamanlayaci= "+zamanlayaci) ;
            if (FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastle.transform.childCount > 0)
            {
                    Debug.LogWarning("ilk harf ateþlendi");
                    if (EnemyatesEdiliyor == false && zamanlayaci >= 7)
                    {
                    Debug.LogWarning("ilk harf");
                        EnemyvurulduMu = false;
                        EnemyatesEdiliyor = true;
                        zamanlayaci = 0;
                        EnemyCurrentWordHarfleri.Clear();
                        System.Random rnnd = new System.Random();
                        int randKelime = rnnd.Next(0, FindObjectOfType<LevelKelimeVeHarfleri>().LevelKelimeleri.Length);
                        EnemycurrentWord = FindObjectOfType<LevelKelimeVeHarfleri>().LevelKelimeleri[randKelime];
                        for (int i = 0; i < EnemycurrentWord.Length; i++)
                        {
                            EnemyCurrentWordHarfleri.Add(EnemycurrentWord[i].ToString());
                        }
                        BulletSayac = 0;
                        EnemyBulletUret();
                        kullanilanKelimler.Add(EnemycurrentWord);
                        LevelController.EnemyKelimler.Remove(EnemycurrentWord);
                    }
                    else
                    {

                    }
                if (EnemyvurulduMu && EnemyatesEdiliyor)
                {
                    Debug.LogWarning("diðer harf");
                    EnemyBulletUret();
                }
                else
                {
                    EnemyvurulduMu = DusmanMermiScript.EnemyVuruldu;
                }

            }
            else
            {
                FindObjectOfType<touchControl>().YazilanKelimeler.text = "";
                GameObject.Find("EnemyCannon").GetComponent<Animator>().SetBool("Ates", false);
                GameObject.Find("PlayerCannon").GetComponent<Animator>().SetBool("Ates", false);
                Debug.Log("KAYBETTIN");
                FindObjectOfType<UIController>().LoseCoinDegerAtama();
                TapToStartKontrol = false;
                FindObjectOfType<UIController>().OyunEkrani.SetActive(false);
                FindObjectOfType<UIController>().LoseEkrani.SetActive(true);
                FindObjectOfType<UIParticalController>().UIMetinImageHazirla();
            }
        }

        Debug.Log("ENEMY HEDEF SAYISI= "+FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastle.transform.childCount);

    }


    private void EnemyBulletUret()
    {
        GameObject.Find("EnemyCannon").GetComponent<Animator>().SetBool("Ates", true);
        if (BulletSayac < EnemyCurrentWordHarfleri.Count)
        {
            int UstSinir;
            UstSinir = FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastleTuglalari.Count;
            if (UstSinir > 0)
            {
                if (FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastleHarfleri.Contains(EnemyCurrentWordHarfleri[BulletSayac]))
                {
                   //System.Random Rnd = new System.Random();
                   // int rand = Rnd.Next(0, UstSinir);
                    int rand = UnityEngine.Random.Range(0, UstSinir);
                    GameObject hedefObje;
                    hedefObje = FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastleTuglalari[rand];
                    if (hedefObje.tag == EnemyCurrentWordHarfleri[BulletSayac])
                    {
                        EnemyateslenecekHarf = hedefObje.transform;
                        _currentWordBullet = Instantiate(FindObjectOfType<LevelController>().EnemyBullets[LevelController.Alphabets.BinarySearch(EnemyCurrentWordHarfleri[BulletSayac])], enemyCannonFirePoint.parent);
                        _currentWordBullet.transform.position = enemyCannonFirePoint.transform.position;
                        EnemyvurulduMu = false;
                        BulletSayac++;
                    }
                    else
                    {
                        EnemyBulletUret();
                    }
                }
                else
                {
                    EnemyvurulduMu = true;
                    BulletSayac++;
                }

            }
            else
            {
            }

        }
        else
        {

        }
        if (BulletSayac >= EnemyCurrentWordHarfleri.Count)
        {
            EnemyatesEdiliyor = false;
            zamanlayaci = 0;
            GameObject.Find("EnemyCannon").GetComponent<Animator>().SetBool("Ates", false);
        }
        else
        {

        }
    }
}
