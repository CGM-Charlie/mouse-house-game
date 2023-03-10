using System.Collections;
using System.Collections.Generic;
using JoshH.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour{
    
    // Title 
    [Header("Menu Title")] 
    [SerializeField] private GameObject menuTitleObj;
    [SerializeField] private GameObject menuTitleBackgroundObj;
    [SerializeField] private GameObject menuTitlePosIn;
    [SerializeField] private GameObject menuTitlePosOut;
    
    // Menu Options
    [Header("Menu Options")] 
    [SerializeField] private GameObject menuOptionsObj;
    [SerializeField] private GameObject menuOptionsPosIn;
    [SerializeField] private GameObject menuOptionsPosOut;

    // Menu Buttons
    [Header("Menu Buttons")]
    [SerializeField] private GameObject startGameObj;
    [SerializeField] private GameObject creditsObj;
    [SerializeField] private GameObject quitObj;
    
    // Credits Screen
    [Header("Credits Screen")]
    [SerializeField] private GameObject creditsScreenObj;
    [SerializeField] private GameObject creditsScreenPosIn;
    [SerializeField] private GameObject creditsScreenPosOut;

    // UI Screens
    void Start() {
        // Start Animations
        MenuTitle_InAnimation();

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
        
        // Credits Button
        var creditsReturnButton = creditsScreenObj.transform.Find("ReturnButton").GetComponent<Button>();
        var creditsReturnButtonEvents = creditsScreenObj.transform.Find("ReturnButton").GetComponent<ButtonEventHandlers>();
        creditsReturnButton.onClick.AddListener(ReturnToMenu);
        creditsReturnButtonEvents.onSelectAction.AddListener(delegate { SelectedTweenAnimation(creditsReturnButton.gameObject); });
        creditsReturnButtonEvents.onDeselectAction.AddListener(delegate { DeselectedTweenAnimation(creditsReturnButton.gameObject); });
        
    }
    
    // Start Game Button
    private void StartGame() {
        SceneManager.LoadScene("HouseScene");
    }
    
    // Credits Button
    private void Credits() {
        MenuTitle_OutAnimation();
        Credits_InAnimation();
    }
    
    // Quit Button
    private void QuitGame() {
        Application.Quit();
    }
    
    // Credits Return Button
    private void ReturnToMenu() {
        Credits_OutAnimation();
        MenuTitle_InAnimation();
    }
    

    // Tween Animations
    private void MenuTitle_InAnimation() {
        // Menu Title
        LeanTween.cancel(menuTitleObj);
        LeanTween.move(menuTitleObj, menuTitlePosIn.transform.position, 0.5f).setEaseOutExpo().setDelay(0.5f);
        
        // Menu Title Background
        menuTitleBackgroundObj.transform.localScale = Vector3.zero;
        LeanTween.cancel(menuTitleBackgroundObj);
        LeanTween.scale(menuTitleBackgroundObj, new Vector3(1.3f, 1.0f), 0.3f).setEaseOutExpo().setDelay(0.7f);
        
        // Menu Options
        LeanTween.cancel(menuOptionsObj);
        LeanTween.move(menuOptionsObj, menuOptionsPosIn.transform.position, 0.5f).setEaseOutExpo().setDelay(0.5f);
    }
    
    private void MenuTitle_OutAnimation() {
        // Menu Title
        LeanTween.cancel(menuTitleObj);
        LeanTween.move(menuTitleObj, menuTitlePosOut.transform.position, 0.5f).setEaseOutExpo().setDelay(0.5f);
        
        // Menu Title Background
        menuTitleBackgroundObj.transform.localScale = new Vector3(1.3f, 1.0f);
        LeanTween.cancel(menuTitleBackgroundObj);
        LeanTween.scale(menuTitleBackgroundObj, Vector3.zero, 0.3f).setEaseOutExpo().setDelay(0.7f);
        
        // Menu Options
        LeanTween.cancel(menuOptionsObj);
        LeanTween.move(menuOptionsObj, menuOptionsPosOut.transform.position, 0.5f).setEaseOutExpo().setDelay(0.5f);
    }
    
    // Credits
    private void Credits_InAnimation() {
        LeanTween.cancel(creditsScreenObj);
        LeanTween.move(creditsScreenObj, creditsScreenPosIn.transform.position, 0.5f).setEaseOutExpo().setDelay(0.5f);
    }
    
    private void Credits_OutAnimation() {
        LeanTween.cancel(creditsScreenObj);
        LeanTween.move(creditsScreenObj, creditsScreenPosOut.transform.position, 0.5f).setEaseOutExpo().setDelay(0.5f);
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
