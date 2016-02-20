using UnityEngine;
using System.Collections;
#if UNITY_5_3
using UnityEngine.SceneManagement;
#endif
public class LoadSceneManager : MonoBehaviour
{
    private bool isStart = false;
    private UISlider _LoadBar;
    private AsyncOperation op;
    public static LoadSceneManager _instance;
    private float ToProgress;
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        _LoadBar = transform.FindChild("LoadBar").GetComponent<UISlider>();
        _LoadBar.value = 0;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    public IEnumerator LoadScene(string name)
    {
        isStart = true;
#if UNITY_5_3

        op = SceneManager.LoadSceneAsync(name, LoadSceneMode.Single);
#else
        op = Application.LoadLevelAsync(name);
#endif

        op.allowSceneActivation = false;
        while (op.progress < 0.89f)
        {
            ToProgress = op.progress;
            while (_LoadBar.value < ToProgress)
            {
                _LoadBar.value += 0.1f;
                yield return new WaitForEndOfFrame();
            }
        }
        while (_LoadBar.value < 1.0f)
        {
            _LoadBar.value += 0.1f;
            yield return new WaitForEndOfFrame();
        }

        op.allowSceneActivation = true;
    }
}
