using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TroopPathFinding : MonoBehaviour
{
    public AIPath aiPath;
    public AIDestinationSetter destinationSetter;
    public Seeker seeker;
    public troopInfo troop_Info;
    public TroopAttack troopAttack;
    public MainAttack mainAttack;

    public Animator anim;

    [SerializeField] private bool isTargetingTower;
    [SerializeField] private bool isTargetingEnemy;
    [SerializeField] private bool isInAttackRange;
    [SerializeField] private bool isAttacking;

    public LayerMask whatIsEnemy;
    [SerializeField] private Transform targetPos;
    [SerializeField] private Transform attackTarget;
    [SerializeField] private AttackType_Enum.TargetType targetType;
    
    public buildingPositionHolder positionHolder;

    [SerializeField] private float agroRange;
    [SerializeField] private float attackRange;


    [SerializeField]
    private Collider2D[] agroColliders;
    [SerializeField]
    private Collider2D[] attackColliders;


    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        troop_Info = GetComponent<troopInfo>();
        seeker = GetComponent<Seeker>();
        aiPath = GetComponent<AIPath>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        mainAttack = GetComponent<MainAttack>();

        agroRange = troop_Info.cardInfo.agro_Range;
        attackRange = troop_Info.cardInfo.attack_Range;
        aiPath.maxSpeed = troop_Info.cardInfo.move_Speed;
        aiPath.endReachedDistance = attackRange;
        targetType = troop_Info.cardInfo.targetType;

        isTargetingTower = true;
        isTargetingEnemy = false;
        isAttacking = false;

        calculateTowerTarget();
    }
    private void FixedUpdate()
    {
        findAgro();     
    }
    private void Update()
    {
    
    }
    private void calculateTowerTarget()
    {
        Transform leftTower = positionHolder.getLeftTower();
        Transform rightTower = positionHolder.getRightTower();


        if (Vector2.Distance(leftTower.position, this.transform.position) < (Vector2.Distance(rightTower.position, this.transform.position)))
        {
          
            destinationSetter.target = leftTower;
            attackTarget = destinationSetter.target = leftTower;
       
        }
        else
        {
            
            destinationSetter.target = rightTower;
            attackTarget = destinationSetter.target = rightTower;
        }
        isTargetingTower = true;
        isTargetingEnemy = false;
       
    }

    private void findAgro ()
    {
        agroColliders = Physics2D.OverlapCircleAll(this.transform.position, agroRange, whatIsEnemy);
        findTarget(agroColliders);
    }

    private void startAttack(Transform attackTarget)
    {
        if (!isAttacking &&  inAttackRange(attackTarget))
        {
            //Start Attack On Target
            
            anim.SetBool("isAttacking", true);
            isAttacking = true;
        }
        else if (!inAttackRange(attackTarget)) 
        {
          
            anim.SetBool("isAttacking", false);
            isAttacking = false;

        }
       
    }
    private bool inAttackRange(Transform attackTarget)
    {
        attackColliders = Physics2D.OverlapCircleAll(this.transform.position, attackRange, whatIsEnemy);
        for (int i = 0; i <  attackColliders.Length; i++)
        {
            Transform inAttackReach = attackColliders[i].transform;
            if (inAttackReach = attackTarget)
            {
                return true;
            }
            
        }
        return false;
    }
    private void findTarget(Collider2D[] agroColliders)
    {
        if (isTargetingTower && !isTargetingEnemy && !isAttacking && agroColliders.Length != 0)
        {
            Transform newTarget =  findClosestTarget(agroColliders);
            destinationSetter.target = newTarget;
            attackTarget = newTarget;
            Debug.Log("Troop diverts Target to: " + newTarget.name);

            isTargetingTower = false;
            isTargetingEnemy = true;
        }
     
        else if (agroColliders.Length == 0 || towerInAgroRange(agroColliders)) 
        {
            isTargetingEnemy = false;
            isTargetingTower = true;
            isAttacking = false;
            calculateTowerTarget();
        }

        mainAttack.SetAttackTarget(attackTarget);
        startAttack(attackTarget);
    }
    private bool towerInAgroRange (Collider2D[] agroColliders)
    {
        for (int i = 0; i < agroColliders.Length; i++)
        {
            if (!agroColliders[i].tag.Equals("Tower"))
            {
                return false;
            }
        }
        return true;
    }
    //calculates which target in the attack range is the closest
    private Transform findClosestTarget(Collider2D[] agroColliders)
    {
        Transform newTarget = null;
        float closestTarget = Mathf.Infinity;
        for (int i = 0; i < agroColliders.Length; i++)
        {
            Vector2 directionToTarget = agroColliders[i].transform.position - this.transform.position;
            float distanceSqrToTarget = directionToTarget.sqrMagnitude;
            if (distanceSqrToTarget < closestTarget)
            {
                closestTarget = distanceSqrToTarget;
                newTarget = agroColliders[i].transform;
            }
        }
        return newTarget;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(this.transform.position, agroRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, attackRange);
    }

    public Transform GetAttackTarget()
    {
        return attackTarget;
    }

}
       


