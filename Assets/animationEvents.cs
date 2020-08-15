using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationEvents : MonoBehaviour
{
    // Start is called before the first frame update
    public TroopAttack troopAttack;

    private void Awake()
    {
        troopAttack = GetComponentInParent<TroopAttack>();
    }
    void Start()
    {
        
    }
    public void attackEvent ()
    {
        troopAttack.Attack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
