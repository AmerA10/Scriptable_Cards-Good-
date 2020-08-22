using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MainAttack : MonoBehaviour
{
    // Start is called before the first frame update

    public abstract void Attack();
    public abstract Transform GetAttackTarget();
    public abstract void SetAttackTarget(Transform newTarget); 

    // Update is called once per frame

}
