using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using cn.SMSSDK.Unity;

public class regist : MonoBehaviour,SMSSDKHandler {
    public InputField ifd_username;
    public InputField ifd_password;
    public InputField ifd_confirm;
    public InputField ifd_vericode;
    public Text message;
    public Text t_username;
    public Text t_password;
    public Text t_confirm;
    public Text t_vericode;
    public Button send;
    public Button ok;
    public SMSSDK smssdk;
    public UserInfo userInfo;

    private string username;
    private string password;
    private string confirm;
    private string vericode;
    private string result = null;
    private bool check = false;

    private float timer;
    private float timer2;

	// Use this for initialization
	void Start () {
        timer = 0;
        timer2 = 0;

        t_username.enabled = false;
        ifd_username.image.enabled = false ;
        t_password.enabled = false;
        ifd_password.image.enabled = false;
        t_confirm.enabled = false;
        ifd_confirm.image.enabled = false;
        t_vericode.enabled = false;
        ifd_vericode.image.enabled = false;
        send.image.enabled = false;
        send.GetComponentInChildren<Text>().enabled = false;
        ok.image.enabled = false;
        ok.GetComponentInChildren<Text>().enabled = false;

        smssdk = gameObject.GetComponent<SMSSDK>();
        smssdk.init("276d2303535d5", "df8dcbad0876953ff99fdd70aaa43fb7", false);
        userInfo = new UserInfo();
        smssdk.setHandler(this);
    }
	
	// Update is called once per frame
	void Update () {
        username = ifd_username.text;
        password = ifd_password.text;
        confirm = ifd_confirm.text;
        vericode = ifd_vericode.text;

        timer = timer + Time.deltaTime;                         //计算时间，控制消失
        if (timer - timer2 > 1 && timer2 > 0.0000001)
        {
            timer = 0;
            timer2 = 0;
            message.enabled = false;
        }

        if (Time.timeSinceLevelLoad > 1.4) t_username.enabled = true;                   //逐渐显示界面
        if (Time.timeSinceLevelLoad > 1.6) ifd_username.image.enabled = true;
        if (Time.timeSinceLevelLoad > 1.8) t_password.enabled = true;
        if (Time.timeSinceLevelLoad > 1.9) ifd_password.image.enabled = true;
        if (Time.timeSinceLevelLoad > 2) t_confirm.enabled = true;
        if (Time.timeSinceLevelLoad > 2.1) ifd_confirm.image.enabled = true;
        if (Time.timeSinceLevelLoad > 2.2) t_vericode.enabled = true;
        if (Time.timeSinceLevelLoad > 2.3)
        {
            ifd_vericode.image.enabled = true;
            send.image.enabled = true;
            send.GetComponentInChildren<Text>().enabled = true;
            ok.image.enabled = true;
            ok.GetComponentInChildren<Text>().enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))                       //返回登录界面
        {
            SceneManager.LoadScene(0);
        }
    }

    public void click()
    {
        if (username.Length != 11) 
        {
            message.text = "手机号输入有误";
            message.enabled = true;
            timer2 = timer;
        } else if (password.Length < 6)
        {
            message.text = "密码强度过低";
            message.enabled = true;
            timer2 = timer;
        } else if (!password.Equals(confirm))
        {
            message.text = "确认密码错误";
            message.enabled = true;
            timer2 = timer;
        }  else
        {
            smssdk.commitCode(username, "86", vericode);
            if (check)
            {
                WWWForm form = new WWWForm();
                form.AddField("username", username);
                form.AddField("password", password);
                StartCoroutine(sendmsg("http://118.25.210.13:8080/BoneServlet/regist", form));
            }    
        }
    }

    IEnumerator sendmsg(string url, WWWForm wForm)
    {
        WWW postData = new WWW(url, wForm);

        yield return postData;
        if (postData.error != null)                                //有错误信息
        {
            message.text = "服务器连接失败！";
            Debug.Log(postData.error);
            message.enabled = true;
            timer2 = timer;
        }
        else
        {
            if (postData.text.Equals("success"))                    //登录成功
            {
                PlayerPrefs.SetString("username", username);
                SceneManager.LoadScene("menu");
            }
            else
            {                                                       //登录失败，失败信息
                message.text = postData.text;
                message.enabled = true;
                timer2 = timer;
            }
        }
    }

    public void onComplete(int action, object resp)
    {
        check = true;
    }

    public void onError(int action, object resp)
    {
        throw new System.NotImplementedException();
    }

    public void sendSMS()
    {
        smssdk.getCode(CodeType.TextCode, username, "86", "");
    }
}