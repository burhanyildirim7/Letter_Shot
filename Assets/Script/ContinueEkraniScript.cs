using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueEkraniScript : MonoBehaviour
{
    public static bool continueToStartAktif;
    [SerializeField] GameObject ContinueEkrani;
    [SerializeField] GameObject oyunIciEkrani;

    void Start()
    {
        continueToStartAktif = false;
        ContinueEkrani.SetActive(true);
        oyunIciEkrani.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void TapToStartFonk() 
    {
        FindObjectOfType<LevelController>().KelimeVeHarfCek();
        continueToStartAktif = true;
        ContinueEkrani.SetActive(false);
        oyunIciEkrani.SetActive(true);
    }

    public void levelYenilendi() 
    {
        ContinueEkrani.SetActive(true);
        oyunIciEkrani.SetActive(false);
    }
}
