using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingPositionHolder : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public Transform tower_Left;
    [SerializeField]
    public Transform tower_Right;


    public Transform getLeftTower()
    {
        Debug.Log("returning Left Tower:");
        return tower_Left;
    }
    public Transform getRightTower()
    {
        return tower_Right;
    }

}
