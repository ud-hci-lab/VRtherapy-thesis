using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    private MenuScript menu;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("<MenuButton><START> " + this.name);
        menu = GameObject.Find("Table").GetComponent<MenuScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("<MenuButton><OnTriggerEnter> Collided with " + other);
        //ensure that the collider is not another part of the model
        if (other.gameObject.tag == "PTAsset")
        {
            //Color currentColor = button.colors.normalColor;
            //this.GetComponent<Button>().colors.normalColor(Color.green);
            menu.ThreeDfishIntialization();
        }
    }
}
