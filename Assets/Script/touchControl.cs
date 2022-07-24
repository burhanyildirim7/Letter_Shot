using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;
using TMPro;

public class touchControl : MonoBehaviour
{
    [SerializeField] Camera UICamerasi;
    int sayac;
    public static bool PlayervurulduMu;
    public static string _currentWord;
    public static Transform ateslenecekHarf;
    private GameObject _currentWordBullet;

    [Header("Cizgi Degiskenleri")]
    [SerializeField] private GameObject CizilecekCizgi;
    GameObject CizilecekCizgiTemp;
    [SerializeField] private GameObject _harfArkaPlani;
    GameObject HarfArkaPlaniTemp;
    [SerializeField] public RectTransform CizimGrubu;
    [SerializeField] public Text YazilanKelimeler;
    [SerializeField] public TextMeshProUGUI YazilanKelime;
    [SerializeField] public GameObject YazilanKelimeObj;
    List<string> kullanilanKelimler = new List<string>();
    [SerializeField] public List<string> CurrentWordHarfleri = new List<string>();
    private bool _harfeDegdi;
    private List<Transform> _harfTransformlari = new List<Transform>();
    [SerializeField] public Transform playerCannonFirePoint;

    public static bool atesEdiliyor;
    public static int PlayerBulletSayac;

    Animator PlayerAnim;
    string harfler;

    private void Start()
    {
        harfler = "";
        PlayerBulletSayac = 0;
        _currentWord = "";
        sayac = -1;
        _harfeDegdi = false;
        atesEdiliyor = false;
        PlayervurulduMu = true;
        YazilanKelimeler.text = "";
    }
    Transform araDeger;

    private void Update()
    {
       /* if (harfler.Length!= FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleHarfleri.Count)
        {
            harfler = "";
            for (int i = 0; i < FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleHarfleri.Count; i++)
            {
                harfler = harfler + FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleHarfleri[i];
            }
            GameObject.Find("KaleninHarfleri").transform.GetComponent<Text>().text = harfler;
        }
        else
        {

        }*/ //Kalenin kalan harlerini ekrana yazdırıyor.

        playerCannonFirePoint = FindObjectOfType<LevelKelimeVeHarfleri>().PlayerAtesEtmeNoktasi.transform;
        PlayerAnim = GameObject.Find("PlayerCannon").GetComponent<Animator>();
        if (FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastle.transform.childCount > 0)
        {
            if (PlayervurulduMu)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _currentWord = "";
                    CurrentWordHarfleri.Clear();
                }
                else
                {

                }
                if (Input.GetMouseButton(0) && atesEdiliyor == false)
                {
                    transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y,0);
                    if (_harfeDegdi == true)
                    {
                        Vector3 dir = new Vector3(_harfTransformlari[sayac].localPosition.x, _harfTransformlari[sayac].localPosition.y, 0) - new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
                        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                        float boyu = Mathf.Sqrt(dir.x * dir.x + dir.y * dir.y);
                        Vector3 konum = new Vector3(((_harfTransformlari[sayac].localPosition.x - transform.localPosition.x) / 2) + transform.localPosition.x, ((_harfTransformlari[sayac].localPosition.y - transform.localPosition.y) / 2) + transform.localPosition.y, 0);
                        CizilecekCizgiTemp.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                        CizilecekCizgiTemp.transform.localPosition = konum;
                        CizilecekCizgiTemp.transform.localScale = new Vector3(boyu * 0.01f, .5f, 1);
                    }
                }
                else
                {

                }
                if (Input.GetMouseButtonUp(0) && _harfeDegdi == true)
                {
                    _harfeDegdi = false;
                    sayac = -1;
                    _harfTransformlari.Clear();
                    transform.localPosition = new Vector3(0, 0, 0);
                    if (LevelController.Kelimler.Contains(_currentWord))
                    {
                        YazilanKelimeObj.SetActive(true);
                        YazilanKelime.text = _currentWord;
                           PlayerBulletSayac = 0;
                        BulletUret();
                        atesEdiliyor = true;
                        kullanilanKelimler.Add(_currentWord);

                        YazilanKelimeler.text = YazilanKelimeler.text+ _currentWord + "\n";
                        
                        
                        LevelController.Kelimler.Remove(_currentWord);
                    }
                    else
                    {
                        CurrentWordHarfleri.Clear();
                        if (kullanilanKelimler.Contains(_currentWord))
                        {
                            Debug.Log("KULLANILMIŞ");
                        }
                        else
                        {
                            Debug.Log("KELİME HATALI");
                        }
                    }
                }
                else
                {

                }
            }
            else
            {
                PlayervurulduMu = AtesAldumGideyrum.Vuruldu;
            }
            if (PlayervurulduMu && atesEdiliyor)
            {
                BulletUret();
            }

        }
        else
        {
            YazilanKelimeler.text = "";
              Debug.Log("KAZANDIN");
            FindObjectOfType<UIController>().WinCoinDegerAtama();
            PlayerAnim.SetBool("Ates", false);
            GameObject.Find("EnemyCannon").GetComponent<Animator>().SetBool("Ates", false);
            NewDusman.TapToStartKontrol = false;
            FindObjectOfType<UIController>().OyunEkrani.SetActive(false);
            FindObjectOfType<UIController>().WinEkrani.SetActive(true);
            FindObjectOfType<UIParticalController>().UIMetinImageHazirla();
            FindObjectOfType<UIController>().WinEfect.SetActive(true);
        }


        Debug.Log("PLAYER HEDEF SAYISI= "+FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastle.transform.childCount);
        Debug.LogWarning("BulletSayac= "+PlayerBulletSayac);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "UIHarf")
        {
            _harfTransformlari.Add(other.transform);
            _harfeDegdi = true;
            _currentWord += other.GetComponent<TextMeshProUGUI>().text;
            CurrentWordHarfleri.Add(other.GetComponent<TextMeshProUGUI>().text);
            HarfArkaPlaniTemp = Instantiate(_harfArkaPlani, CizimGrubu.transform);
            HarfArkaPlaniTemp.transform.localPosition = other.transform.localPosition;
            HarfArkaPlaniTemp.gameObject.GetComponent<RectTransform>().sizeDelta = other.gameObject.GetComponent<RectTransform>().sizeDelta;
            //cizgiyi Sabitleme
            if (_harfTransformlari.Count > 1)
            {
                Vector3 dir = new Vector3(_harfTransformlari[sayac].position.x, _harfTransformlari[sayac].position.y, 0) - new Vector3(_harfTransformlari[sayac + 1].position.x, _harfTransformlari[sayac + 1].position.y, 0);
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                float boyu = Mathf.Sqrt(dir.x * dir.x + dir.y * dir.y);
                Vector3 konum = new Vector3(((_harfTransformlari[sayac].position.x - _harfTransformlari[sayac + 1].position.x) / 2) + _harfTransformlari[sayac + 1].position.x, ((_harfTransformlari[sayac].position.y - _harfTransformlari[sayac + 1].position.y) / 2) + _harfTransformlari[sayac + 1].position.y, 0);

                CizilecekCizgiTemp.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                CizilecekCizgiTemp.transform.position = konum;
                CizilecekCizgiTemp.transform.localScale = new Vector3(boyu * 0.01f, .5f, 1);

            }
            //
            CizilecekCizgiTemp = Instantiate(CizilecekCizgi, CizimGrubu.transform);
            sayac++;
        }
    }

    private void BulletUret()
    {
        
        PlayerAnim.SetBool("Ates", true);
        if (PlayerBulletSayac < CurrentWordHarfleri.Count)
        {
            int UstSinir;
            UstSinir = FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleTuglalari.Count;
            if (UstSinir > 0)
            {
                if (FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleHarfleri.Contains(CurrentWordHarfleri[PlayerBulletSayac]))
                {
                    int rand = Random.Range(0, UstSinir);
                    GameObject hedefObje;
                    hedefObje = FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleTuglalari[rand];
                    if (hedefObje.tag == CurrentWordHarfleri[PlayerBulletSayac])
                    {
                        UIController.CoinSayac++;
                           ateslenecekHarf = hedefObje.transform;
                        _currentWordBullet = Instantiate(FindObjectOfType<LevelController>().Bullets[LevelController.Alphabets.BinarySearch(CurrentWordHarfleri[PlayerBulletSayac])], playerCannonFirePoint.parent);
                        _currentWordBullet.transform.position = playerCannonFirePoint.transform.position;
                        PlayervurulduMu = false;
                        PlayerBulletSayac++;
                    }
                    else
                    {
                        BulletUret();
                    }
                }
                else
                {
                    PlayervurulduMu = true;
                    PlayerBulletSayac++;
                }
            }
            else
            {

            }
        }
        else if (PlayerBulletSayac >= CurrentWordHarfleri.Count)
        {
            atesEdiliyor = false;
            PlayerAnim.SetBool("Ates", false);
        }
        else
        {

        }
    }
    public void LevelDegisti() 
    {
        CurrentWordHarfleri.Clear();
        PlayerBulletSayac = 0;
    }

    public void EkranKelimeTemizleme()
    {
        YazilanKelimeler.text = "";
    }
}
