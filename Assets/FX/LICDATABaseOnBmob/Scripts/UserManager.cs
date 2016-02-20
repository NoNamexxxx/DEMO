using UnityEngine;
using System.Collections;
using cn.bmob;
using cn.bmob.Extensions;
using cn.bmob.io;
using cn.bmob.api;
using System.Collections.Generic;
public class UserManager : MonoBehaviour
{
    public static UserManager Instance;
    public delegate void OnLoginFinish(bool isSuccess);
    public delegate void OnRegisiterFinish(bool isSuccess,string message);

    private BmobUnity bmobUnity; //对应要操作的数据表
    public string TABLE_NAME = "EasyUser";
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        bmobUnity = GetComponent<BmobUnity>();
    }

    void Update()
    {
        #region ForTest
        //if (Input.GetMouseButtonDown(0))
        //{
        //    BmobGameObject user = new BmobGameObject();
        //    user.userid = "LIC";
        //    user.password = 212;
        //    AddUser(user);
        //}
        //if (Input.GetMouseButtonDown(1))
        //{
        //    SearchUser();
        //}
        //if (Input.GetMouseButtonDown(2))
        //{
        //    BmobGameObject user = new BmobGameObject();
        //    user.userid = "LIC";
        //    user.password = 212;
        //    Login(user, (isok) =>
        //    {
        //        Debug.Log(isok);
        //    });
        //}
        #endregion
    }
    /// <summary>
    /// 返回全部User
    /// </summary>
    public void SearchUser()
    {
        BmobQuery query = new BmobQuery();

        bmobUnity.Find<BmobGameObject>(TABLE_NAME, query, (resp, exception) =>
        {
            if (exception != null)
            {
                Debug.Log("查询失败, 失败原因为： " + exception.Message);
                return;
            }

            List<BmobGameObject> list = resp.results;
            foreach (var user in list)
            {
                Debug.Log("ID:" + user.userid);
            }
        });
    }

    /// <summary>
    /// 添加用户
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public void AddUser(BmobGameObject user,OnRegisiterFinish FinishBlock)
    {
        bmobUnity.Create("EasyUser", user, (resp, exception) =>
         {
             if (exception != null)
             {
                 print("保存失败, 失败原因为： " + exception.Message);
                 //在此处提示用户登录失败
                 FinishBlock(false, exception.Message);
                 return;
             }
             print("保存成功, @" + resp.createdAt);
             FinishBlock(true, "Success");

         });

    }
    
    /// <summary>
    /// 用户登录
    /// </summary>
    /// <param name="LoginUser"></param>
    /// <param name="finished"></param>
    public void  Login(BmobGameObject LoginUser,OnLoginFinish finished)
    {
        BmobQuery query = new BmobQuery();
        query.WhereEqualTo("userid", LoginUser.userid).WhereEqualTo("password",LoginUser.password);
        
        bmobUnity.Find<BmobGameObject>(TABLE_NAME, query, (resp, exception) =>
        {
            if (exception != null)
            {
                Debug.Log("查询失败, 失败原因为： " + exception.Message);
                return;
            }

            List<BmobGameObject> list = resp.results;
            if (list.Count!=0)
            {
                finished(true);
            }
            else
            {
                finished(false);

            }
            foreach (var user in list)
            {
                //Debug.Log("ID:" + user.userid);
            }

        });
    }

}
