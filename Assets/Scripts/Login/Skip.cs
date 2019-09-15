using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ForgetPassword()
    {
        SceneManager.LoadScene("forgetPassword");
    }

    public void Register()
    {
        SceneManager.LoadScene("regist");
    }

    public void Login()
    {
        SceneManager.LoadScene("login");
    }
}