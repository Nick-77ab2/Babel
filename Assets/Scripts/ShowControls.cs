using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowControls : MonoBehaviour
{
    public GameObject Controls;
    public Button controlDisplay;
    // Start is called before the first frame update
    void Start()
    {
        Button myControl = controlDisplay.GetComponent<Button>();
        myControl.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TaskOnClick(){
         GameObject control = Controls;
        control.SetActive(true);
    }
}
