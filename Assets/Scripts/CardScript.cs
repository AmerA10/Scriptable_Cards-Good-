using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardScript : MonoBehaviour
{
    // Start is called before the first frame update
    public cardTemplate card;
    public TextMeshProUGUI costText;
    public Image cardImage;

    public GameObject troop;

    public Transform spawnPos_Temp;

    void Start()
    {
        costText.text = card.cost.ToString();
        cardImage.sprite = card.artWork;
    }
        
    public void SpawnTroop ()
    {
        Instantiate(troop, spawnPos_Temp.transform.position, Quaternion.identity);
        Debug.Log("Spawning Troop");
    }
   
}
