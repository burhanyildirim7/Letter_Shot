using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DusmanAtesEtme : MonoBehaviour
{
    [SerializeField]
    Animator CannonAnim;

    public static int DusmanAtisSayac;
    public static int SavunmaAtisSayac;
    public static int KacKelimeSecildi;

    public Transform firePoint;
    // public GameObject bulletPrefab;
    [SerializeField] private GameObject[] _wordsBulletLetterPrefabs;
   // [SerializeField] private GameObject[] _word2BulletLetterPrefabs;
   // [SerializeField] private GameObject[] _word3BulletLetterPrefabs;
    [SerializeField] List<GameObject> HedefObj = new List<GameObject>();
    private int _bulletSayisi;
    private int _hangiWord;
    public char[] _ToCharArray_CurrentWordBullet;
   // public int[] _bullets;

    List<GameObject> SecilenHarfler = new List<GameObject>();
    public List<Transform> m_target = new List<Transform>();
    public static List<int> _bulletString = new List<int>();

    public static Vector3 hedefKoordinant;

    int sayacHarf;
    float sayacDelay;

    [SerializeField] private int _blokSayisi;
    // Start is called before the first frame update
    void Start()
    {
        sayacDelay = 0;
        SavunmaAtisSayac = 0;
        DusmanAtisSayac = 0;
        _bulletSayisi = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (sayacHarf > 0 && sayacDelay > 0.5f && _blokSayisi > 0)
        {
            ShootHarf();
            CannonAnim.SetBool("Ates", true);
        }
        if (sayacHarf <= 0 || _blokSayisi <= 0)
        {
            sayacDelay = 0;
            sayacHarf = 0;
            _bulletSayisi = 0;
            // _bulletString.Clear();
            

            CannonAnim.SetBool("Ates", false);
        }
        sayacDelay = sayacDelay + Time.deltaTime;
    }

    public void Shoot(int kelimeUzunlugu, string atilacakHarfler)
    {
        sayacHarf = kelimeUzunlugu;
        _ToCharArray_CurrentWordBullet = atilacakHarfler.ToCharArray();
       // int[] _bullets = atilacakHarfler.Split(int.Parse(","));
        // _hangiWord = hangiword;
        sayacDelay = 0;
    }
    private void ShootHarf()
    {
        //_bullets[_bulletSayisi] = (int)_ToCharArray_CurrentWordBullet[_bulletSayisi];
       // int.TryParse(_ToCharArray_CurrentWordBullet[_bulletSayisi], out _bullets[_bulletSayisi]); Convert.ToInt32(yourString);
        
        GameObject bullet = Instantiate(_wordsBulletLetterPrefabs[_bulletString[_bulletSayisi]], firePoint.position, firePoint.rotation);
        hedefKoordinant = m_target[SavunmaAtisSayac].position;
        SavunmaAtisSayac++;
        sayacHarf--;
        _bulletSayisi += 1;
        sayacDelay = 0;
        _blokSayisi--;

        /*
        if (_hangiWord == 1)
        {

            GameObject bullet = Instantiate(_word1BulletLetterPrefabs[_bulletSayisi], firePoint.position, firePoint.rotation);
            hedefKoordinant = m_target[SavunmaAtisSayac].position;
            SavunmaAtisSayac++;
            sayacHarf--;
            _bulletSayisi += 1;
            sayacDelay = 0;

        }
        else if (_hangiWord == 2)
        {
            GameObject bullet = Instantiate(_word2BulletLetterPrefabs[_bulletSayisi], firePoint.position, firePoint.rotation);
            hedefKoordinant = m_target[SavunmaAtisSayac].position;
            SavunmaAtisSayac++;
            sayacHarf--;
            _bulletSayisi += 1;
            sayacDelay = 0;

        }
        else if (_hangiWord == 3)
        {
            GameObject bullet = Instantiate(_word3BulletLetterPrefabs[_bulletSayisi], firePoint.position, firePoint.rotation);
            hedefKoordinant = m_target[SavunmaAtisSayac].position;
            SavunmaAtisSayac++;
            sayacHarf--;
            _bulletSayisi += 1;
            sayacDelay = 0;

        }
        */


    }
}
