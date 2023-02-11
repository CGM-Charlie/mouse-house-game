using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScr : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    public bool changeLevel;

    private Rigidbody2D rb;
    private BoxCollider2D bc;

    public LayerMask platform;
    
    void Start()
    {
        Debug.Log("HOW");
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f);

        if (IsSidewaysRight() || IsSidewaysLeft())
        {
            transform.Translate(Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f, 0f);
            //transform.Rotate(Input.GetAxis("Vertical") * speed * Time.deltaTime, 0f, 0f);
        }
        else if (IsSidewaysUp() || IsSidewaysDown())
        {
            transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, 0f);
            //transform.Rotate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0f, 0f);
        }
        
    }

    bool IsSidewaysRight()
    {
        RaycastHit2D ray = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.right, 0.1f, platform);
        return ray.collider != null;
    }
    bool IsSidewaysLeft()
    {
        RaycastHit2D ray = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.left, 0.1f, platform);
        return ray.collider != null;
    }
    bool IsSidewaysUp()
    {
        RaycastHit2D ray = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.up, 0.1f, platform);
        return ray.collider != null;
    }
    bool IsSidewaysDown()
    {
        RaycastHit2D ray = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, 0.1f, platform);
        return ray.collider != null;
    }
}
