using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    //gameobjects to manage how the game is played
    public int livesLeft = 2;
    public GameObject[] textLives;
    public GameObject gameOverPanel;
    public GameObject incorrectExhibitPanel;

    private int currentStep = 1;
    public int totalSteps = 5;

    private UIManager uiMan;

    // Start is called before the first frame update
    void Start()
    {
        //setting the default number of lives to three
        if(!PlayerPrefs.HasKey("lives"))
        {
            PlayerPrefs.SetInt("lives", livesLeft);
        }
        //getting the correct ui to be displayed when starting
        uiMan = GetComponent<UIManager>();

        //method to update the lives
        updateLivesUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //method to get updated amount of lives
    public int getLives()
    {
        return PlayerPrefs.GetInt("lives", livesLeft);
    }

    //method to deduct lives after every incorrect answer
    public void deductLife()
    {
        //when lives are depleted game over panel pops up
        if(livesLeft > 0)
        {
            livesLeft--;
            updateLivesUI();
            PlayerPrefs.SetInt("lives", livesLeft);
            
            Debug.Log("Lives deducted. Remaining lives: " + livesLeft);
        }
        else
        {
            updateLivesUI();
            PlayerPrefs.SetInt("lives", 0);
            gameOver();
        }
    }

    //method to update the lives in the game via text
    private void updateLivesUI()
    {
        int lives = PlayerPrefs.GetInt("lives");

        foreach(GameObject lifeText in textLives)
        {
            if(lifeText != null)
            {
                lifeText.GetComponent<Text>().text = "You have " + lives + " life left.";
            }
            else
            {
                Debug.LogError("One of the lifetexts is null!");
            }
        }
    }

    //when user has run out of lives this method will run to display game over panel
    private void gameOver()
    {
        uiMan.deactivateAllPanels();
        gameOverPanel.SetActive(true);
        Debug.Log("Game over! No lives left");
    }

    //method to check on what step the user is on
    public void progressStep()
    {
        currentStep++;
        if(currentStep > 5)
        {
            Debug.Log("Sequence completed!");
            gameOverPanel.SetActive(true);
        }
        else
        {
            loadExhibitScene(currentStep);
        }
    }

    //method that returns the current step the user is on
    public int getStep()
    {
        return currentStep;
    }

    //method to check if the game is completed
    public bool isGameCompleted()
    {
        //return true or false
        return currentStep > totalSteps;
    }

    //method to load specific scene based on current step
    public void loadExhibitScene(int exhibitNum)
    {
        string sceneName = "";

        //switch case to validate which scene to open
        switch(exhibitNum)
        {
            case 1:
                sceneName = "radioExhibitScene";
                break;
            case 2:
                sceneName = "bikoVideoScene";
                break;
            case 3:
                sceneName = "peterSongScene";
                break;
            case 4:
                sceneName = "gunExhibitScene";
                break;
            case 5:
                sceneName = "flagsExhibitScene";
                break;
            default:
                incorrectExhibitPanel.SetActive(true);
                Debug.Log("Invalid exhibit number.");
                return;
        }

        //load specific scene by numbers
        SceneManager.LoadScene(sceneName);
    }

    //button for incorrect menu
    public void quitApp()
    {
        Application.Quit();
    }
}
