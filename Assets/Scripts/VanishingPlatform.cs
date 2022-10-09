using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishingPlatform : MonoBehaviour
{
    public float vanishTime = 2f;
    public float currentTime = 0f;
    public bool enabled = true;

    // Start is called before the first frame update
    void Start()
    {
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= vanishTime)
        {
            currentTime = 0f;
            ToggleVanish();
        }
    }

    void ToggleVanish() 
    {
        enabled = !enabled;
        foreach(Transform child in gameObject.transform)
        {
            if (child.tag != "Player")
            {
                child.gameObject.SetActive(enabled);
            }
        }
    }
}
