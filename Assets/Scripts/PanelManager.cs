/*
 * Copyright (c) All Rights Reserved, VERGOSOFT LLC
 * Title: HypnoRem
 * Author: Scott Zastrow
 * 
 */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelManager : MonoBehaviour {

    public Image logo;
    public GameObject settingsPanel;
    public static bool changeSettings;

    void Start ()
    {
        changeSettings = false;
        settingsPanel.SetActive(false);
    }
	

	void Update ()
    {
        //I found that UI pixel size is 22% of Actual width/height pixels. Below: Setting .15f gives me a border on width.
        //logo.GetComponent<RectTransform>().sizeDelta = new Vector2(.15f * Screen.width, .23f * (.15f * Screen.width)); //height is 23% (.23f*) of width based off of ratio of original image.
        //logo.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -151f);
        //settingsPanel.GetComponent<RectTransform>().sizeDelta = new Vector2(.005f * Screen.width, .005f*(Screen.height));
        //settingsPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }

    public void handleSettings()
    {
        if (changeSettings == false)
        {
            changeSettings = true;
            settingsPanel.SetActive(true);

        }
        else if (changeSettings == true)
        {
            changeSettings = false;
            settingsPanel.SetActive(false);
        }
    }
}
