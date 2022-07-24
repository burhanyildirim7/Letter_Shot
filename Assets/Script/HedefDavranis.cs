using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedefDavranis : MonoBehaviour
{
    public float F_Katsayisi = 20f;
    public bool vuruldu = false;
    public GameObject suPrefab;
    private Rigidbody rg;

    private Transform baslangicKonumu;
    private float deltaKonum;
    private float deltaAciX;
    private float deltaAciY;
    private float deltaAciZ;


    void Start()
    {
        rg = gameObject.GetComponent<Rigidbody>();
        baslangicKonumu = transform;
    }

    void Update()
    {
        deltaKonum = Vector3.Distance(baslangicKonumu.position, transform.position);
        deltaAciX = baslangicKonumu.rotation.x - transform.rotation.x;
        deltaAciY = baslangicKonumu.rotation.y - transform.rotation.y;
        deltaAciZ = baslangicKonumu.rotation.z - transform.rotation.z;
        if (deltaKonum > 20f|| deltaKonum < -20f)
        {
            gameObject.transform.parent = GameObject.Find("Level" + (LevelController.levelSayac+1) + "(Clone)").transform;
            FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleHarfleri.Clear();
            FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleTuglalari.Clear();
            for (int i = 0; i < FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastle.transform.childCount; i++)
            {
                FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleHarfleri.Add(FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastle.transform.GetChild(i).gameObject.tag);
                FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleTuglalari.Add(FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastle.transform.GetChild(i).gameObject);
            }
            Destroy(gameObject, 1f);
        }
        if ((deltaAciX > 60f && deltaAciX<300f)|| (deltaAciX < -60f && deltaAciX > 300f))
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
        }
        else if ((deltaAciY > 60f && deltaAciY < 300f) || (deltaAciY < -60f && deltaAciY > 300f))
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
        }
        else if ((deltaAciZ > 60f && deltaAciZ < 300f) || (deltaAciZ < -60f && deltaAciZ > 300f))
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
        }
        else
        {

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Top")
        {
            vuruldu = true;
            rg = gameObject.GetComponent<Rigidbody>();
            rg.constraints = RigidbodyConstraints.None;
            rg.AddForce(new Vector3(0,0.5f,1)*F_Katsayisi,ForceMode.Impulse);
            //FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleTuglalari.Remove(FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleTuglalari[touchControl.tuglaKonum]);
            //gameObject.transform.parent = GameObject.Find("Level" + (LevelController.levelSayac + 1) + "(Clone)").transform;
           /* FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleHarfleri.Clear();
            FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleTuglalari.Clear();
            for (int i = 0; i < FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastle.transform.childCount; i++)
            {
                FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleHarfleri.Add(FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastle.transform.GetChild(i).gameObject.tag);
                FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleTuglalari.Add(FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastle.transform.GetChild(i).gameObject);
            }*/
        }
        else if(other.tag == "Deniz")
        {
            GameObject su = Instantiate(suPrefab, transform.position, Quaternion.identity);
            gameObject.transform.parent = GameObject.Find("Level" + (LevelController.levelSayac + 1) + "(Clone)").transform;
            Destroy(su, 2f);

            gameObject.transform.parent = GameObject.Find("Level" + (LevelController.levelSayac + 1) + "(Clone)").transform;
            FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleHarfleri.Clear();
            FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleTuglalari.Clear();
            for (int i = 0; i < FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastle.transform.childCount; i++)
            {
                FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleHarfleri.Add(FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastle.transform.GetChild(i).gameObject.tag);
                FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleTuglalari.Add(FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastle.transform.GetChild(i).gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Zemin")
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
        }
        else if (collision.gameObject.tag == "ArkaDuvar")
        {
            gameObject.transform.parent = GameObject.Find("Level" + (LevelController.levelSayac + 1) + "(Clone)").transform;
            FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleHarfleri.Clear();
            FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleTuglalari.Clear();
            for (int i = 0; i < FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastle.transform.childCount; i++)
            {
                FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleHarfleri.Add(FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastle.transform.GetChild(i).gameObject.tag);
                FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastleTuglalari.Add(FindObjectOfType<LevelKelimeVeHarfleri>().EnemyCastle.transform.GetChild(i).gameObject);
            }
            Destroy(gameObject, 1f);
        }
        else
        {

        }

    }
}
