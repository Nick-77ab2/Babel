using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttackTrigger : MonoBehaviour
{
    public SkeletonMovement myAttack;

    public void attacker(){
        myAttack.DoAttack();
    }
}
