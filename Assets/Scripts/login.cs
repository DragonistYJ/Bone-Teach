using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class login : MonoBehaviour {
    public InputField tusername;
    public InputField tpassword;
    public Text tmessage;
    public Toggle remember_psw;

    private string username;
    private string password;
    private float timer;
    private float timer2;

	// Use this for initialization
	void Start () {
        timer = 0;
        timer2 = 0;

        if (PlayerPrefs.HasKey("username")) tusername.text = PlayerPrefs.GetString("username");
        if (PlayerPrefs.HasKey("password") && PlayerPrefs.GetInt("isremember") == 1) tpassword.text = PlayerPrefs.GetString("password");
        if (PlayerPrefs.HasKey("isremember"))
        {
            if (PlayerPrefs.GetInt("isremember")==1) remember_psw.isOn = true;
            else remember_psw.isOn = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        username = tusername.text;                              //获取帐号密码
        password = tpassword.text;

        timer = timer + Time.deltaTime;                         //计算时间，控制消失
        if (timer-timer2 > 1 && timer2>0.0000001)
        {
            timer = 0;
            timer2 = 0;
            tmessage.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))                   //退出程序
        {
            Application.Quit();
        }
    }

    public void userlogin()
    {
        if (!PlayerPrefs.HasKey("username") || !PlayerPrefs.GetString("username").Equals(username))     //保存帐号
        {
            PlayerPrefs.SetString("username", username);
        } 
        if (!PlayerPrefs.HasKey("password") && remember_psw.isOn == true)                               //保存密码
        {
            PlayerPrefs.SetInt("isremember", 1);
            PlayerPrefs.SetString("password", password);
        }
        if (remember_psw.isOn == true) PlayerPrefs.SetInt("isremember", 1);                             //密码保存状态
        else PlayerPrefs.SetInt("isremember", 0);


        if (username.Equals(""))                                //判断账号是否为空
        {
            tmessage.text = "帐号不能为空！";
            tmessage.enabled = true;
            timer2 = timer;
        } else if (password.Equals(""))                         //判断密码是否为空
        {
            tmessage.text = "密码不能为空！";
            tmessage.enabled = true;
            timer2 = timer;
        } else                                                  //向服务器发送登录请求
        {
            WWWForm form = new WWWForm();
            form.AddField("username", username);
            form.AddField("password", password);
            //StartCoroutine(sendmsg("http://118.25.210.13:8080/BoneServlet/login", form));
            SceneManager.LoadScene("menu");
        }
    }


    IEnumerator sendmsg(string url, WWWForm wForm)
    {

        WWW postData = new WWW(url, wForm);

        yield return postData;
        if (postData.error != null)                                //有错误信息
        {
            tmessage.text = "服务器连接失败！";
            Debug.Log(postData.error);
            tmessage.enabled = true;
            timer2 = timer;
        } else
        {
            if (postData.text.Equals("success"))                    //登录成功
            {
                SceneManager.LoadScene("menu");
            } else
            {                                                       //登录失败，失败信息
                tmessage.text = postData.text;
                tmessage.enabled = true;
                timer2 = timer;
            }
        }
    }
}

