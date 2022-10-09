using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackListener : MonoBehaviour
{
    // Start is called before the first frame update
   public BossController myBoss;

   public void myAttack(){
       Debug.Log(myBoss.attackType);
        if (myBoss.attackType < 5 && myBoss.attackType >= 0)
        {
            myBoss.DoAttack1();
        }
        else if (myBoss.attackType >= 5 && myBoss.attackType < 10)
        {
            myBoss.DoAttack2();
        }
   }
}
