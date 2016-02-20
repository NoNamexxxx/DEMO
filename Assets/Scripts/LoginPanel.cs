using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LoginPanel : MonoBehaviour {
    [SerializeField]
    private InputField _passWordField;
    [SerializeField]
    private InputField _nameField;

    private string _name;
    private string _password;
	void Start () {
	
	}
	
	void Update () {
	
	}
    public void OnLoginClick()
    {
        if (_passWordField.text == null || _nameField.text == null) return;
        _name = _nameField.text;
        _password = _passWordField.text;
        BmobGameObject user = new BmobGameObject();
        int result;
        if(!int.TryParse(_password,out result))
        {
            MessagePanel.Instance.Show("密码需要时数字");
            return;
        }
        user.userid = _name;
        user.password = result;
        WaitingPanel.Instance.ShowWaiting();

        UserManager.Instance.Login(user, (isok) =>
        {
            WaitingPanel.Instance.Hide();
            if (isok)
            {
                MessagePanel.Instance.Show("Login成功");
            }
            else
            {
                MessagePanel.Instance.Show("Login失败 ");
            }
            Debug.Log(isok);
        });
    }
    public void OnRegisiterClick()
    {
        if (_passWordField.text.Length == 0 || _nameField.text.Length == 0) return;
        _name = _nameField.text;
        _password = _passWordField.text;
        int result;
        if (!int.TryParse(_password, out result))
        {
            MessagePanel.Instance.Show("密码需要时数字");
            return;
        }
        BmobGameObject user = new BmobGameObject();
        user.userid = _name;
        user.password = result;

        WaitingPanel.Instance.ShowWaiting();

        UserManager.Instance.AddUser(user,(isOk,exception)=> {
            WaitingPanel.Instance.Hide();
            if (isOk)
            {
                MessagePanel.Instance.Show("注册成功");
            }
            else
            {
                MessagePanel.Instance.Show("注册失败 ");
            }
        });
    }
    public void OnBottomClick(int index)
    {
        Debug.Log("Index:" + index);
        //TODO add Login Logic
        switch (index)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        }
    }
}
