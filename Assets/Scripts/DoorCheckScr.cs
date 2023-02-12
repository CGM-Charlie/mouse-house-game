using System.Collections;
using System.Collections.Generic;
using JoshH.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorCheckScr : MonoBehaviour {
    
    
    // UI WIN CONDITION
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject posin;
    [SerializeField] private GameObject posOut;

    public GameObject player;
    GameObject ObjectIwantToPickUp;
    public bool willLeave;
    // Start is called before the first frame update
    void Start()
    {
        willLeave = false;
        
        // BUTTONS
        // Continue Button
        var button = winScreen.transform.Find("RestartButton").GetComponent<Button>();
        var buttonEvent = winScreen.transform.Find("RestartButton").GetComponent<ButtonEventHandlers>();
        button.onClick.AddListener(QuitGame);
        buttonEvent.onSelectAction.AddListener(delegate { SelectedTweenAnimation(button.gameObject); });
        buttonEvent.onDeselectAction.AddListener(delegate { DeselectedTweenAnimation(button.gameObject); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D (Collider2D other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "Home") 
        {
            checkFood();
            ObjectIwantToPickUp = other.gameObject; 
            
        }
    }

    private void WinGame() {
        LeanTween.cancel(winScreen);
        LeanTween.move(winScreen, posin.transform.position, 0.5f).setEaseOutExpo();
    }

    private void QuitGame() {
        SceneManager.LoadScene("MainMenu");
    }
    
    void checkFood() {
        if (player.GetComponent<FoodPickupScr>().canLeave) {
            willLeave = true; // WIN  THE GAME
            WinGame();
        }
        else {
            willLeave = false;
        }
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
