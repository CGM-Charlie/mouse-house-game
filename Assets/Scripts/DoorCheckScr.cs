using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCheckScr : MonoBehaviour
{

    public GameObject player;
    GameObject ObjectIwantToPickUp;
    public bool willLeave;
    // Start is called before the first frame update
    void Start()
    {
        willLeave = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "Home") 
        {
            checkFood();
            ObjectIwantToPickUp = other.gameObject; 
            
        }
    }

    void checkFood() {
        if (player.GetComponent<FoodPickupScr>().canLeave) {
            willLeave = true;
        }
        else {
            willLeave = false;
        }
    }
}
