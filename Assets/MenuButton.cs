﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour
{
    private MenuScript menu;
    private bool hover;
    private Image buttonImage;
    private int hoverTime;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("<MenuButton><START> " + this.name);
        menu = GameObject.Find("Table").GetComponent<MenuScript>();
        buttonImage = this.GetComponent<Image>();
        hover = false;
        hoverTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("<MenuButton><Update> ");
        if (hover) {
            hoverTime += 1;

            if (hoverTime > 200) {
                buttonImage.color = Color.green;

                if (hoverTime > 300) {
                    if (this.name == "ThreeDfishButton") {
                        menu.ThreeDfishIntialization();
                    } else if (this.name == "TwoDfishButton") {
                        menu.FishIntialization();
                    } else if (this.name == "TwoDchickenButton") {
                        menu.ChickenIntialization();
                    } else if (this.name == "TwoDsquareButton") {
                        menu.SquareIntialization();
                    } else if (this.name == "ReturnButton") {
                        Debug.Log("<MenuButton><Update> return button hit");
                        menu.Start();
                    } else if (this.name == "QuitButton") {
                        Debug.Log("Application Quit");
                        Application.Quit(); //only works when you build the project (doesn't work when you play in edit mode)
                    }

                }
            }
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("<MenuButton><OnTriggerEnter> " + this.name);

        //ensure that the collider is not another part of the model
        if (other.gameObject.tag == "PTAsset")
        {
            buttonImage.color = Color.yellow;
            hover = true;
            hoverTime = 0;
        }
    }

    // Update is called once per frame
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("<MenuButton><OnTriggerExit> " + this.name);
        //ensure that the collider is not another part of the model
        if (other.gameObject.tag == "PTAsset")
        {
            buttonImage.color = Color.white;
            hover = false;
            hoverTime = 0;
        }
    }

}
