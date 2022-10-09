using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSceneManagement : MonoBehaviour
{
    public PlayerHealth health;
    public PlayerAttack attack;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        PlayerHealth.health = 5;
        PlayerAttack.attackPower = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
