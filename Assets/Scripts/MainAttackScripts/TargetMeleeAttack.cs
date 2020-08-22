using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMeleeAttack : MainAttack
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

    override
    public void Attack()
    {

        Debug.Log("Attacking target: " + attackTarget.name);
        if (attackTarget.GetComponent<TroopHealth>().GetHealth() >= 0)
        {
            attackTarget.GetComponent<TroopHealth>().takeDamage(attack_Damage);
        }
    }
    override
    public  Transform GetAttackTarget()
    {
        return this.attackTarget;
    }
    override
    public void SetAttackTarget(Transform newTarget)
    {
        this.attackTarget = newTarget;
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
