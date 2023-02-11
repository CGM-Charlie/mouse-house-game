using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPickupScr : MonoBehaviour
{
    bool canpickup;
    public int foodItems = 0;
    public int maxItems;
    GameObject ObjectIwantToPickUp;
    public bool canLeave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (foodItems > maxItems)
        {
            canLeave = true;
        }
    }

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "Food")
        {
            //Debug.Log("Check");
            canpickup = true;  
            ObjectIwantToPickUp = other.gameObject; 
            foodItems += 1;
            Destroy(other.gameObject);
        }
    }
}
