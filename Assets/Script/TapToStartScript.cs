using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStartScript : MonoBehaviour
{
    public static bool tapToStartAktif;
    [SerializeField] GameObject TapToStartEkrani;
    [SerializeField] GameObject oyunIciEkrani;

    void Start()
    {
        tapToStartAktif = false;
        TapToStartEkrani.SetActive(true);
        oyunIciEkrani.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void TapToStartFonk() 
    {
        FindObjectOfType<LevelController>().KelimeVeHarfCek();
        tapToStartAktif = true;
        TapToStartEkrani.SetActive(false);
        oyunIciEkrani.SetActive(true);
    }

    public void levelYenilendi() 
    {
        TapToStartEkrani.SetActive(true);
        oyunIciEkrani.SetActive(false);
    }
}
