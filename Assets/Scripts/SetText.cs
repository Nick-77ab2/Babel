using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour
{
    public Text myText;
    public GameObject Player;

    private bool hasJumped=false;
    private bool hasMoved = false;
    private bool hasAttacked=false;

    // Start is called before the first frame update
    void Start()
    {
        myText.text = "Use Arrows to move";
    }

    // Update is called once per frame
    void Update()
    {
        TextUpdate();
    }

    void TextUpdate ()
    {
        if (hasMoved==false)
        {
            myText.text = "Use Arrows to move";
            if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
                hasMoved=true;
            }
        }
        if ((hasMoved==true && hasJumped==false)) 
        {
            myText.text = "Use Spacebar to Jump, Again to Double Jump";
            if(Input.GetKeyDown(KeyCode.Space)){
                hasJumped=true;
            }
        }
        if ((hasJumped==true && hasAttacked==false))
        {
            myText.text = "Use Z to Attack";
            if(Input.GetKeyDown(KeyCode.Z)){
                hasAttacked=true;
            }
        }
        if (hasAttacked)
        {
            myText.text = "Get to Door. Press Enter.";
        }
    }
}
