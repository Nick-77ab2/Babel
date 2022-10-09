using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToBoss : MonoBehaviour
{
    private bool hasPlayer;
    // Start is called before the first frame update
    void Start()
    {
        hasPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasPlayer && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("BossLevel");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            hasPlayer = true;
        }
    }
}
