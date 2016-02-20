using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class WaitingPanel : MonoBehaviour {
    [SerializeField]
    private Image loadingImage;
    public static WaitingPanel Instance;

    void Awake()
    {
        Instance = this;
        Debug.Log("HI");

        gameObject.SetActive(false);
    }
    void Start () {
        iTween.RotateBy(loadingImage.gameObject, iTween.Hash("z", 400, "loopType", "loop", "delay", .1, "speed", 100));
    }
    public void ShowWaiting()
    {
        gameObject.SetActive(true);

    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

}


  

