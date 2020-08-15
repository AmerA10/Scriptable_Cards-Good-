using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TroopHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    public Transform healthUI;
    public TextMeshProUGUI healthText;
    public Vector3 healthOffset;

    private bool isDead;
   
    
    public float GetHealth()
    {
        return health;
    }
    public void SetHealth(float health)
    {
        this.health = health;
    }

    public void takeDamage(float amount)
    {
  
        if (health > 0 && !isDead)
        {
            health -= amount;
        }
        else if (health <= 0)
        {
           
            isDead = true;
            this.enabled = false;
            this.gameObject.SetActive(false);
        }
     
    }
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        healthUIPos();
    }
    private void healthUIPos()
    {
        healthText.text = this.health.ToString();
      //  healthUI.transform.position = this.transform.position + healthOffset;

    }
}
