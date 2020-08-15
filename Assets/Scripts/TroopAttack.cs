using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TroopAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public troopInfo troop_Info;
    public TroopPathFinding troopPathFinding;
    private AttackType_Enum.AttackType attackType;  
    private float attack_Range;
    public Transform attackTarget;
    private float attack_Damage;
    public float health;

    public TroopHealth troopHealth;



    private void Awake()
    {


  
      
    }
    void Start()
    {
    
        troopHealth = GetComponent<TroopHealth>();
        troopPathFinding = GetComponent<TroopPathFinding>();
        attackTarget = troopPathFinding.GetAttackTarget();
        troop_Info = GetComponent<troopInfo>();
        attackType = troop_Info.GetAttackType();
        attack_Range = troop_Info.GetAttackRange();
        attack_Damage = troop_Info.GetAttackDamage();
        health = troop_Info.GetHealth();
    }
    public void Attack()
    {
        
        Debug.Log("Attacking target: " + attackTarget.name);
        if (attackTarget.GetComponent<TroopHealth>().GetHealth() >= 0)
        {
            attackTarget.GetComponent<TroopHealth>().takeDamage(attack_Damage);
        }
    }
    public void setAttackTarget(Transform attack_Target)
    {
        attackTarget = attack_Target;
    }
    public Transform GetAttackTarget()
    {
        return attackTarget;
    }
    

    // Update is called once per frame
    void Update()
    {
        setAttackTarget(troopPathFinding.GetAttackTarget());
    }

}
