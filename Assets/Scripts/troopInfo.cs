using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class troopInfo : MonoBehaviour
{
    // Start is called before the first frame update


    public LayerMask whatIsEnemy;
   
    public float health;
    public float attack_Damage;
    public float attack_Speed;
    public float attack_Range;
    public float agro_Range;
    public AttackType_Enum.AttackType attackType;
    public cardTemplate cardInfo;

    void Awake()
    {
        attackType = cardInfo.attackType;
        health = cardInfo.health;
        attack_Damage = cardInfo.attack_Damage;
        attack_Range = cardInfo.attack_Range;
        attack_Speed = cardInfo.attack_Speed;
        agro_Range = cardInfo.agro_Range;
          
    }

    public float GetHealth()
    {
        return health;
    }
    public float GetAttackDamage ()
    {
        Debug.Log("Returning attack damage of: " + attack_Damage);
        return attack_Damage;
    }
    public float GetAttackSpeed ()
    {
        return attack_Speed;
    }
    public float GetAttackRange()
    {
        return attack_Range;
    }
    public float GetAgroRange (){
        return agro_Range;
    }
    public AttackType_Enum.AttackType GetAttackType()
    {
        return attackType;
        
    }


    

}
