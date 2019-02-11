using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_action : MonoBehaviour {
    private float timer_1;
    private float timer_2;
    private int key_num;

	// Use this for initialization
	void Start () {
        key_num = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (key_num != 2 )
            {
                key_num++;
            } else
            {
                Application.Quit();
            }
        }
	}
}
