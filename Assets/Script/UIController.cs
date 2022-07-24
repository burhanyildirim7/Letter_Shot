using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using ElephantSDK;

public class UIController : MonoBehaviour
{
    [SerializeField] public GameObject TapToStartEkran;
    [SerializeField] public GameObject OyunEkrani;
    [SerializeField] public GameObject WinEkrani;
    [SerializeField] public GameObject WinEfect;
    [SerializeField] public GameObject LoseEkrani;
    [SerializeField] public Text LevelText;
    [SerializeField] public Text CoinText;
    [SerializeField] public Text CoinText2;
    [SerializeField] public Text CoinText3;
    [SerializeField] public Text CoinText4;
    [SerializeField] public GameObject Player;
    //[SerializeField] public touchControl touchControler;
    public static int CoinSayac;
    int CoinMiktari;
    int LeveldeKazanilanCoinMiktari;
    public int KacinciLevel;
    public static int TuglaSayisi;
    private int randomKontrol;
    void Start()
    {
        //PlayerPrefs.SetInt("DevamEdenLevel", 0);
        //PlayerPrefs.SetInt("MevcutLevel", 1);
        KacinciLevel = 1;
        KacinciLevel = PlayerPrefs.GetInt("MevcutLevel");
        if (KacinciLevel < 1)
        {
            PlayerPrefs.SetInt("MevcutLevel", 1);
            KacinciLevel = 1;
        }
        else
        {

        }
        TapToStartEkran.SetActive(true);
        OyunEkrani.SetActive(false);
        WinEkrani.SetActive(false);
        LoseEkrani.SetActive(false);
        LevelText.text = "LEVEL " + (KacinciLevel);
        CoinSayac = 0;
        CoinMiktari = 0;
        LeveldeKazanilanCoinMiktari = 0;
        CoinMiktari = PlayerPrefs.GetInt("CoinDegeri");
        CoinText.text = CoinMiktari.ToString();
        CoinText2.text = CoinMiktari.ToString();

    }
    void Update()
    {
        Debug.Log(KacinciLevel);
        LevelText.text = "LEVEL " + (KacinciLevel);
    }

    public void NextLevel()
    {

        Elephant.LevelCompleted(KacinciLevel);

        CoinMiktari = CoinMiktari + LeveldeKazanilanCoinMiktari;
        PlayerPrefs.SetInt("CoinDegeri", CoinMiktari);
        CoinText.text = CoinMiktari.ToString();
        CoinText2.text = CoinMiktari.ToString();

        CoinSayac = 0;
        KacinciLevel++;
        PlayerPrefs.SetInt("MevcutLevel", KacinciLevel);



        TapToStartEkran.SetActive(true);

        WinEkrani.SetActive(false);
        Player.SetActive(false);
        Player.SetActive(true);
        touchControl.atesEdiliyor = false;
        touchControl.PlayervurulduMu = true;
        NewDusman.EnemyatesEdiliyor = false;
        NewDusman.EnemyvurulduMu = true;
        Destroy(LevelController.levelTemp);
        if (KacinciLevel < FindObjectOfType<LevelController>().Leveller.Count)
        {
            LevelController.levelSayac++;
            PlayerPrefs.SetInt("DevamEdenLevel", LevelController.levelSayac);
        }
        else
        {
            int a = Random.Range(0, FindObjectOfType<LevelController>().Leveller.Count);

            if (randomKontrol != a)
            {
                randomKontrol = a;
                LevelController.levelSayac = a;
                PlayerPrefs.SetInt("DevamEdenLevel", a);

            }
            else
            {
                if ((a + 1) >= FindObjectOfType<LevelController>().Leveller.Count)
                {
                    LevelController.levelSayac = a - 3;
                    PlayerPrefs.SetInt("DevamEdenLevel", a - 3);

                }
                else
                {
                    LevelController.levelSayac = a + 1;
                    PlayerPrefs.SetInt("DevamEdenLevel", a + 1);

                }
            }
        }



        FindObjectOfType<LevelController>().LevelYukle();

    }
    public void RestartLevel()
    {

        Elephant.LevelFailed(KacinciLevel);

        TapToStartEkran.SetActive(true);

        LoseEkrani.SetActive(false);
        CoinMiktari = CoinMiktari + LeveldeKazanilanCoinMiktari;
        PlayerPrefs.SetInt("CoinDegeri", CoinMiktari);
        CoinText.text = CoinMiktari.ToString();
        CoinText2.text = CoinMiktari.ToString();
        Player.SetActive(false);
        Player.SetActive(true);
        touchControl.atesEdiliyor = false;
        touchControl.PlayervurulduMu = true;
        NewDusman.EnemyatesEdiliyor = false;
        NewDusman.EnemyvurulduMu = true;

        Destroy(LevelController.levelTemp);
        FindObjectOfType<LevelController>().LevelYukle();


    }
    public void WinCoinDegerAtama()
    {
        LeveldeKazanilanCoinMiktari = ((TuglaSayisi * 25));
        if (LeveldeKazanilanCoinMiktari <= 0)
        {
            LeveldeKazanilanCoinMiktari = 0;
        }
        else
        {

        }

        CoinText3.text = LeveldeKazanilanCoinMiktari.ToString();

    }
    public void LoseCoinDegerAtama()
    {
        LeveldeKazanilanCoinMiktari = (FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastle.transform.childCount * 10);
        if (LeveldeKazanilanCoinMiktari <= 0)
        {
            LeveldeKazanilanCoinMiktari = 0;
        }
        else
        {

        }
        CoinText4.text = LeveldeKazanilanCoinMiktari.ToString();
    }


}
