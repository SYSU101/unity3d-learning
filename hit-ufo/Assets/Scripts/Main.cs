using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private MainSceneController controller;

	void Start ()
    {
        this.controller = new MainSceneController();
	}

    private void OnGUI()
    {
        this.controller.OnGameFrame();
    }
}
