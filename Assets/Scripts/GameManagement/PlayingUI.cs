using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingUI : MonoBehaviour
{
    private float health = 0;
    private float attack = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetHealth();
        GetAttack();
    }

    // Update is called once per frame
    void Update()
    {
        GetHealth();
        GetAttack();
    }

    public void GetHealth()
    {
        health = PlayerHealth.health;
        if (health >= 0)
        {
            GameObject.Find("HP").GetComponent<TMPro.TextMeshProUGUI>().text = health.ToString();
        }
    }

    public void GetAttack()
    {
        attack = PlayerAttack.attackPower;
        GameObject.Find("Attk").GetComponent<TMPro.TextMeshProUGUI>().text = attack.ToString();
    }
}
