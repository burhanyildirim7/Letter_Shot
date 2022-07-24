using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIParticalController : MonoBehaviour
{
    [SerializeField] public List<GameObject> UIComplimentText = new List<GameObject>();
    [SerializeField] public List<GameObject> UIEmojiList = new List<GameObject>();
    int im = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UIMetinImageHazirla() 
    {
        int rand = Random.Range(0, UIEmojiList.Count);
        for (int i = 0; i < UIEmojiList.Count; i++)
        {
            if (i == rand)
            {
                UIEmojiList[i].SetActive(true);
                UIComplimentText[i].SetActive(true);
            }
            else
            {
                UIEmojiList[i].SetActive(false);
                UIComplimentText[i].SetActive(false);
            }
        }
    }
}
