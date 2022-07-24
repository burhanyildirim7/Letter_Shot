using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavunmaDavranis : MonoBehaviour
{
    public float Enemy_F_Katsayisi = 20f;
    public bool Enemyvuruldu = false;
    public GameObject EnemysuPrefab;
    private Rigidbody rg;
    private Vector3 baslangicKonumu;
    private float deltaKonum;

    void Start()
    {
        rg = gameObject.GetComponent<Rigidbody>();
        baslangicKonumu = transform.position;
    }

    void Update()
    {

        deltaKonum = Vector3.Distance(baslangicKonumu, transform.position);

       /* if (deltaKonum > 0.05f)
        {
            gameObject.transform.parent = GameObject.Find("Level" + (LevelController.levelSayac + 1) + "(Clone)").transform;
            FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleHarfleri.Clear();
            FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleTuglalari.Clear();
            for (int i = 0; i < FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastle.transform.childCount; i++)
            {
                FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleHarfleri.Add(FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastle.transform.GetChild(i).gameObject.tag);
                FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleTuglalari.Add(FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastle.transform.GetChild(i).gameObject);
            }
            Destroy(gameObject, 3f);
        }*/

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Top")
        {
            Enemyvuruldu = true;
            rg = gameObject.GetComponent<Rigidbody>();
            rg.constraints = RigidbodyConstraints.None;
            rg.AddForce(new Vector3(0, 0.5f, -1) * Enemy_F_Katsayisi, ForceMode.Impulse);
            //FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleTuglalari.Remove(FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleTuglalari[touchControl.tuglaKonum]);
            //gameObject.transform.parent = GameObject.Find("Level" + (LevelController.levelSayac + 1) + "(Clone)").transform;
            FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastleHarfleri.Clear();
            FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastleTuglalari.Clear();
            for (int i = 0; i < FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastle.transform.childCount; i++)
            {
                FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastleHarfleri.Add(FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastle.transform.GetChild(i).gameObject.tag);
                FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastleTuglalari.Add(FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastle.transform.GetChild(i).gameObject);
            }
        }
        else if (other.tag == "Deniz")
        {
            GameObject su = Instantiate(EnemysuPrefab, transform.position, Quaternion.identity);
            gameObject.transform.parent = GameObject.Find("Level" + (LevelController.levelSayac + 1) + "(Clone)").transform;
            Destroy(su, 2f);

            gameObject.transform.parent = GameObject.Find("Level" + (LevelController.levelSayac + 1) + "(Clone)").transform;
            FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastleHarfleri.Clear();
            FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastleTuglalari.Clear();
            for (int i = 0; i < FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastle.transform.childCount; i++)
            {
                FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastleHarfleri.Add(FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastle.transform.GetChild(i).gameObject.tag);
                FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastleTuglalari.Add(FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastle.transform.GetChild(i).gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zemin")
        {
            gameObject.transform.parent = GameObject.Find("Level" + (LevelController.levelSayac + 1) + "(Clone)").transform;
            FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastleHarfleri.Clear();
            FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastleTuglalari.Clear();
            for (int i = 0; i < FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastle.transform.childCount; i++)
            {
                FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastleHarfleri.Add(FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastle.transform.GetChild(i).gameObject.tag);
                FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastleTuglalari.Add(FindObjectOfType<LevelKelimeVeHarfleri>().PlayerCastle.transform.GetChild(i).gameObject);
            }
            Destroy(gameObject, 4f);
        }

    }
}
