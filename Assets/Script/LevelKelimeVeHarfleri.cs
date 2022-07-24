using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelKelimeVeHarfleri : MonoBehaviour
{
    [SerializeField] public GameObject PlayerAtesEtmeNoktasi;
    [SerializeField] public GameObject EnemyAtesEtmeNoktasi;

    [SerializeField]    public string[] LevelKelimeleri;
    [SerializeField]    public string[] LevelHarfleri;
    [SerializeField]    public GameObject PlayerCastle;
    public  List<string> PlayerCastleHarfleri=new List<string>();
    public List<GameObject> PlayerCastleTuglalari = new List<GameObject>();
    [SerializeField]    public GameObject EnemyCastle;
    public  List<string> EnemyCastleHarfleri = new List<string>();
    public List<GameObject> EnemyCastleTuglalari = new List<GameObject>();
    [SerializeField] public GameObject BulletTrail;
    [SerializeField] public GameObject BulletDust;
    [SerializeField] public GameObject HitEfect;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<UIController>().WinEfect.SetActive(false);
        UIController.TuglaSayisi = PlayerCastle.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (TapToStartScript.tapToStartAktif==true)
        {
            TapToStartScript.tapToStartAktif = false;
            PlayerCastleHarfleri.Clear();
            PlayerCastleTuglalari.Clear();
            EnemyCastleHarfleri.Clear();
            EnemyCastleTuglalari.Clear();
            for (int i = 0; i < PlayerCastle.transform.childCount; i++)
            {
                   PlayerCastleHarfleri.Add(PlayerCastle.transform.GetChild(i).gameObject.tag);
                PlayerCastleTuglalari.Add(PlayerCastle.transform.GetChild(i).gameObject);
            }
            for (int i = 0; i < EnemyCastle.transform.childCount; i++)
            {
                EnemyCastleHarfleri.Add(EnemyCastle.transform.GetChild(i).gameObject.tag);
                EnemyCastleTuglalari.Add(EnemyCastle.transform.GetChild(i).gameObject);
            }
        }
        else
        {

        }

    }
}
