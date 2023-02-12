using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public GameObject room1;
    public GameObject room2;
    public GameObject room3;
    public GameObject room4;
    public GameObject room5;
    public float speed;
    public float distanceBetween;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed = Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

        else
        {
            int roomNum = Random.Range(1,6);
            if(roomNum == 1)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, room1.transform.position, speed = Time.deltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
            if(roomNum == 2)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, room2.transform.position, speed = Time.deltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
            if(roomNum == 3)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, room3.transform.position, speed = Time.deltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
            if(roomNum == 4)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, room4.transform.position, speed = Time.deltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
            else
            {
                transform.position = Vector2.MoveTowards(this.transform.position, room5.transform.position, speed = Time.deltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
        }
    }
}
