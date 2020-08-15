using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackType_Enum : MonoBehaviour
{
    // Start is called before the first frame update
    //there are basically different types of troop targetting. Melee single target, melee aoe, ranged single target and ranged AOE
    public enum AttackType {MELEE_TARGET, MELEE_AOE, RANGED_TARGET, RANGED_AOE }
    public enum TargetType { DEFAULT, BUILDING,  }
    //essentially there are 2 types of targetting, buildings only and regular

}
