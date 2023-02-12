using System.Collections;
using System.Collections.Generic;
using JoshH.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    // UI WIN CONDITION
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject posin;
    
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
        // Continue Button
        var button = winScreen.transform.Find("RestartButton").GetComponent<Button>();
        var buttonEvent = winScreen.transform.Find("RestartButton").GetComponent<ButtonEventHandlers>();
        button.onClick.AddListener(RestartGame);
        buttonEvent.onSelectAction.AddListener(delegate { SelectedTweenAnimation(button.gameObject); });
        buttonEvent.onDeselectAction.AddListener(delegate { DeselectedTweenAnimation(button.gameObject); });
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
    
    private void OnTriggerEnter2D (Collider2D other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "Trap")
        { 
            LoseGame();
        }
    }
    
    private void LoseGame() {
        LeanTween.cancel(winScreen);
        LeanTween.move(winScreen, posin.transform.position, 0.5f).setEaseOutExpo();
    }

    private void RestartGame() {
        SceneManager.LoadScene("HouseScene");
    }    
    
    
    private void SelectedTweenAnimation(GameObject obj) {
        // Change Color
        var gradient = obj.transform.Find("ButtonFill").GetComponent<UIGradient>();
        gradient.enabled = true;
        
        // Animate
        obj.transform.localScale = Vector3.one;
        LeanTween.cancel(obj);
        LeanTween.scale(obj, new Vector3(1.15f, 1.15f), 0.15f).setEaseOutExpo();
    }

    private void DeselectedTweenAnimation(GameObject obj) {
        // Change Color
        var gradient = obj.transform.Find("ButtonFill").GetComponent<UIGradient>();
        gradient.enabled = false;
        
        obj.transform.localScale = new Vector3(1.15f, 1.15f);
        LeanTween.cancel(obj);
        LeanTween.scale(obj, new Vector3(1.0f, 1.0f), 0.15f).setEaseOutExpo();
    }
}
