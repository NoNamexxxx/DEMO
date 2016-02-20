using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MessagePanel : MonoBehaviour {
    public static MessagePanel Instance;

    [SerializeField]
    private TweenScale anim;
    [SerializeField]
    private Text message;
    private Button closeButton;
	void Awake () {
        Instance = this;
        closeButton = transform.Find("BgPanel/Button").GetComponent<Button>();
        closeButton.onClick.AddListener(this.Close);
        gameObject.SetActive(false);
    }
    public void Show(string text)
    {
        gameObject.SetActive(true);
        anim.PlayForward();
        message.text = text;
    }
	void Close()
    {
        anim.PlayReverse();
        Invoke("SetActiveFalse", 0.45f);
    }
    /// <summary>
    /// 防止遮罩
    /// </summary>
    void SetActiveFalse()
    {
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
	
	}
}
