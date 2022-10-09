using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackTrigger : MonoBehaviour
{
    public PlayerAttack myAttack;
    // Start is called before the first frame update
   public void FireReady(){
       myAttack.FireSpell();
   }
}
