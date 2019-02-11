using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class return2menu : MonoBehaviour {
    private Touch oldTouch1;  //上次触摸点1(手指1)    
    private Touch oldTouch2;  //上次触摸点2(手指2)    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))                       //返回登录界面
        {
            SceneManager.LoadScene("menu");
        }       
    }
}
