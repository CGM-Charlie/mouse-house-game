using System.Collections;
using System.Collections.Generic;
using JoshH.UI;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour{
    // Menu Buttons
    [SerializeField] private GameObject startGameObj;
    [SerializeField] private GameObject creditsObj;
    [SerializeField] private GameObject quitObj;

    // UI Screens
    void Start() {
        // Start Button
        var startGameButton = startGameObj.GetComponent<Button>();
        var startGameButtonEvents = startGameObj.GetComponent<ButtonEventHandlers>();
        startGameButton.onClick.AddListener(StartGame);
        startGameButtonEvents.onSelectAction.AddListener(delegate { SelectedTweenAnimation(startGameObj); });
        startGameButtonEvents.onDeselectAction.AddListener(delegate { DeselectedTweenAnimation(startGameObj); });
        
        // Credits Button
        var creditsButton = creditsObj.GetComponent<Button>();
        var creditsButtonEvents = creditsObj.GetComponent<ButtonEventHandlers>();
        creditsButton.onClick.AddListener(Credits);
        creditsButtonEvents.onSelectAction.AddListener(delegate { SelectedTweenAnimation(creditsObj); });
        creditsButtonEvents.onDeselectAction.AddListener(delegate { DeselectedTweenAnimation(creditsObj); });
        
        // Quit Button
        var quitButton = quitObj.GetComponent<Button>();
        var quitButtonEvents = quitObj.GetComponent<ButtonEventHandlers>();
        quitButton.onClick.AddListener(QuitGame);
        quitButtonEvents.onSelectAction.AddListener(delegate { SelectedTweenAnimation(quitObj); });
        quitButtonEvents.onDeselectAction.AddListener(delegate { DeselectedTweenAnimation(quitObj); });
    }
    
    // Start Game Button
    private void StartGame() {
        
    }
    
    // Credits Button
    private void Credits() {
        
    }
    
    // Quit Button
    private void QuitGame() {
        Application.Quit();
    }

    // General Tween Animations
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
