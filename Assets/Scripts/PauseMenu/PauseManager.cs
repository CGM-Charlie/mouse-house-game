using System.Collections;
using System.Collections.Generic;
using JoshH.UI;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {
    
    // Pause Screen
    [Header("Pause Menu Components")] 
    [SerializeField] private GameObject pauseScreenObj;
    [SerializeField] private GameObject pauseScreenPosIn;
    [SerializeField] private GameObject pauseScreenPosOut;

    private bool isMenuOpen = false;

    void Start() {
        // Continue Button
        var continueButton = pauseScreenObj.transform.Find("PauseOptions/ResumeButton").GetComponent<Button>();
        var continueButtonEvents = pauseScreenObj.transform.Find("PauseOptions/ResumeButton").GetComponent<ButtonEventHandlers>();
        continueButton.onClick.AddListener(ContinueGame);
        continueButtonEvents.onSelectAction.AddListener(delegate { SelectedTweenAnimation(continueButton.gameObject); });
        continueButtonEvents.onDeselectAction.AddListener(delegate { DeselectedTweenAnimation(continueButton.gameObject); });
        
        // Quit Button
        var quitButton = pauseScreenObj.transform.Find("PauseOptions/QuitGameButton").GetComponent<Button>();
        var quitButtonEvents = pauseScreenObj.transform.Find("PauseOptions/QuitGameButton").GetComponent<ButtonEventHandlers>();
        quitButton.onClick.AddListener(QuitGame);
        quitButtonEvents.onSelectAction.AddListener(delegate { SelectedTweenAnimation(quitButton.gameObject); });
        quitButtonEvents.onDeselectAction.AddListener(delegate { DeselectedTweenAnimation(quitButton.gameObject); });
    }
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            isMenuOpen = !isMenuOpen;
            
            if (isMenuOpen) {
                PauseGame();
            } else {
                ContinueGame();
            }
        }
    }

    private void PauseGame() {
        isMenuOpen = true;
        Pause_InAnimation();
    }

    private void ContinueGame() {
        isMenuOpen = false;
        Pause_OutAnimation();
    }

    private void QuitGame() {
        
    }
    
    private void Pause_InAnimation() {
        LeanTween.cancel(pauseScreenObj);
        LeanTween.move(pauseScreenObj, pauseScreenPosIn.transform.position, 0.5f).setEaseOutExpo();
    }
    
    private void Pause_OutAnimation() {
        LeanTween.cancel(pauseScreenObj);
        LeanTween.move(pauseScreenObj, pauseScreenPosOut.transform.position, 0.5f).setEaseOutExpo();
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
