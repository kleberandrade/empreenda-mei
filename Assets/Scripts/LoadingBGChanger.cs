using UnityEngine;
using UnityEngine.UI;

public class LoadingBGChanger : MonoBehaviour
{
    public Sprite[] bgImgs;
    public Sprite currentBgImage;
    public int imgToLoad;
    public GameObject thisGO;

    void Start()
    {
        thisGO = gameObject;
        currentBgImage = gameObject.GetComponent<Image>().sprite;
      
        imgToLoad = Random.Range(0, bgImgs.Length);

        thisGO.GetComponent<Image>().sprite = bgImgs[imgToLoad];
    }
}