using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class buttonFunctionsScript : MonoBehaviour
{
    //gameobjects for the radio songs
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public Button changeSongButton;
    public Button selectSongButton;
    public GameObject radioBtn;
    public string correctSongName = "Workers Choir  Ilizwe Ngelethu";
    public GameObject radioCorrectPanel;
    public GameObject radioIncorrectPanel;
    public GameObject musicPanel;
    public GameObject imageRotate;
    public GameObject radioAudioSource;

    //panel gameobjects for case switching
    public GameObject radioExhibitPanel;
    public GameObject bikoExhibitPanel;
    public GameObject peterGabrielExhibitPanel;
    public GameObject gunExhibitPanel;
    public GameObject nationalAnthemExhibitPanel;
    public GameObject incorrectExhibitPanel;
    public GameObject gameOverPanel;

    //correct and incorrect panel arrays
    public GameObject[] correctMenuPanels;
    public GameObject[] incorrectMenuPanels;

    //game objects for tracking how many lives user has left over
    private int currentStep = 1;
    private bool isSequenceStarted = false;
    private int livesLeft = 3;
    public GameObject textLives1;
    public GameObject textLives2;
    public GameObject textLives3;
    public GameObject textLives4;
    public GameObject textLives5;
    public GameObject gameOverText;

    //game objects for Vuforia camera
    public Camera arCamera;
    public float maxRaycastDist = 10f;

    //method to make sure gameobjects are set to default when the application starts running
    void Start()
    {
        radioBtn.SetActive(false);

        //listener to the button to check clicks
        changeSongButton.onClick.AddListener(changeSongBtn);
        selectSongButton.onClick.AddListener(changeSongBtn);

        //ensuring arrays are the correct length
        if(correctMenuPanels.Length != 5 || incorrectMenuPanels.Length != 5)
        {
            Debug.LogError("Correct and Incorrect Menu Panels arrays must have exactly 5 elements.");
        }
        //update the text gameobjects for all the different panels
        textLives1.GetComponent<Text>().text = "You have " + livesLeft + " lives left.";
        textLives2.GetComponent<Text>().text = "You have " + livesLeft + " lives left.";
        textLives3.GetComponent<Text>().text = "You have " + livesLeft + " lives left.";
        textLives4.GetComponent<Text>().text = "You have " + livesLeft + " lives left.";
        textLives5.GetComponent<Text>().text = "You have " + livesLeft + " lives left.";
    }

    //update method to constantly check if ray is hitting radio to display button
    void Update()
    {
        //raycast from the center of the cameras viewport
        Ray ray = arCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        //if ray hits a collider within max distance and it's tagged as "radio", activate the button
        if(Physics.Raycast(ray, out hit, maxRaycastDist))
        {
            //ray hits object with radio tag btn will be set active otherwise inactive
            if(hit.collider.CompareTag("radio"))
            {
                radioBtn.SetActive(true);
            }
            else
            {
                radioBtn.SetActive(false);
            }
        }
        else
        {
            radioBtn.SetActive(false);
        }
    }

    //method to set sequence to true to know when to start counting
    public void startBtnClicked()
    {
        isSequenceStarted = true;
        deactivateAllPanels();
        Debug.Log("Sequence started!");
    }

    //method to make btn rotate like radio nob
    public void imageRotateBtn()
    {
        //rotate image 90 degrees
        imageRotate.transform.Rotate(0f, 0f, 90f);
    }

    //method for btn to change songs
    public void changeSongBtn()
    {
        //cycling through audio clips
        if(audioClips.Length > 0)
        {
            int nextAudioIndex = (System.Array.IndexOf(audioClips, audioSource.clip) + 1) % audioClips.Length;
            audioSource.clip = audioClips[nextAudioIndex];
            audioSource.Play();
        }
    }

    //method to manage if the correct song was played or not
    public void selectSongBtn()
    {
        //stop audio playing after song is selected
        audioSource.Stop();
        radioAudioSource.SetActive(false);

        //checking if the correct audio is playing
        if(audioSource.clip.name == correctSongName)
        {
            //changing to correct panel
            musicPanel.SetActive(false);
            radioCorrectPanel.SetActive(true);
            Debug.Log("Correct song! Progress to the next stage.");
            //take to next panel
            radioAudioSource.SetActive(false);
        }
        else
        {
            //changing to incorrect panel
            musicPanel.SetActive(false);
            radioIncorrectPanel.SetActive(true);
            Debug.Log("Incorrect song.");
            radioAudioSource.SetActive(false);
        }
    }

    //close panel btn
    public void closePanelBtn()
    {
        //checking if the correct audio is playing
        if(audioSource.clip.name == correctSongName)
        {
            radioCorrectPanel.SetActive(true);
        }
        else
        {
            radioIncorrectPanel.SetActive(true);
        }
    }

    //scanned image checker method
    public void imageScanned(int panelNumber)
    {
        //checking if sequence started
        if(!isSequenceStarted)
        {
            Debug.Log("Sequence has not started yet.");
            return; 
        }

        //checking if panel number is correct with the step number
        if(panelNumber == currentStep)
        {
            //correct panel scanned for the current step in game
            activatePanel(panelNumber);
            //when object is displayed add to the counter for next panel
            currentStep++; 

            //if counter is greater than 5 then the game is complete
            if(currentStep > 5)
            {
                Debug.Log("Sequence completed!");
                //congratulations panel
            }
        }
        else
        {
            //incorrect image scanned
            incorrectExhibitPanel.SetActive(true);
            Debug.Log("Incorrect panel scanned.");
        }
    }

    //method to active panel corresponding to current step int
    private void activatePanel(int panelNumber)
    {
        //deactivate all panels
        radioExhibitPanel.SetActive(false);
        bikoExhibitPanel.SetActive(false);
        peterGabrielExhibitPanel.SetActive(false);
        gunExhibitPanel.SetActive(false);
        nationalAnthemExhibitPanel.SetActive(false);

        //activate the correct panel based on the step number
        switch(panelNumber)
        {
            case 1:
                radioExhibitPanel.SetActive(true);
                break;
            case 2:
                bikoExhibitPanel.SetActive(true);
                break;
            case 3:
                peterGabrielExhibitPanel.SetActive(true);
                break;
            case 4:
                gunExhibitPanel.SetActive(true);
                break;
            case 5:
                nationalAnthemExhibitPanel.SetActive(true);
                break;
            default:
                radioExhibitPanel.SetActive(false);
                bikoExhibitPanel.SetActive(false);
                peterGabrielExhibitPanel.SetActive(false);
                gunExhibitPanel.SetActive(false);
                nationalAnthemExhibitPanel.SetActive(false);
                incorrectExhibitPanel.SetActive(true);
                //default case results in invalid panel being displayed and all other panels switched off and log error to check
                Debug.LogError("Invalid panel number.");
                break;
        }
    }

    //method to check if question is answered correctly
    private void CheckQuestionResult(int panelNumber)
    {
        //getting correct and incorrect panels for specific panel
        GameObject correctPanel = correctMenuPanels[panelNumber - 1];
        GameObject incorrectPanel = incorrectMenuPanels[panelNumber - 1];

        //checking if the correct panel is active
        if (correctPanel.activeSelf)
        {
            Debug.Log("Question answered correctly!");
        }
        else if (incorrectPanel.activeSelf)
        {
            //if incorrect panel is active a life will automatically be deducted
            deductLife();
        }
    }

    //deduct method to check if user still has any lives left
    public void deductLife()
    {
        livesLeft--;
        Debug.Log($"Incorrect answer. Lives remaining: {livesLeft}");

        //update the text to display how many lives a user has left
        textLives1.GetComponent<Text>().text = "You have " + livesLeft + " lives left.";
        textLives2.GetComponent<Text>().text = "You have " + livesLeft + " lives left.";
        textLives3.GetComponent<Text>().text = "You have " + livesLeft + " lives left.";
        textLives4.GetComponent<Text>().text = "You have " + livesLeft + " lives left.";
        textLives5.GetComponent<Text>().text = "You have " + livesLeft + " lives left.";
        gameOverText.GetComponent<Text>().text = "You have " + livesLeft + " lives left.";

        //if user still has positive amount of lives
        if(livesLeft > 0)
        {
            incorrectExhibitPanel.SetActive(true);
        }
        //checking if lives left = 0 to process game over screen
        else if(livesLeft == 0)
        {
            //display game over panel
            incorrectExhibitPanel.SetActive(false);
            GameOver();
        }
    }

    //setting game over panel active when user lives are = 0
    private void GameOver()
    {
        deactivateAllPanels();
        gameOverPanel.SetActive(true);
        
        Debug.Log("Game over! No lives left.");
    }

    //deactivate all panels
    private void deactivateAllPanels()
    {
        //deactivate all normal gameobjects
        radioExhibitPanel.SetActive(false);
        bikoExhibitPanel.SetActive(false);
        peterGabrielExhibitPanel.SetActive(false);
        gunExhibitPanel.SetActive(false);
        nationalAnthemExhibitPanel.SetActive(false);
        incorrectExhibitPanel.SetActive(false);

        //deactivate all correctMenuPanels array
        foreach (GameObject panel in correctMenuPanels)
        {
            if (panel != null)
            {
                panel.SetActive(false);
            }
        }

        //deactivate all incorrectMenuPanels array
        foreach (GameObject panel in incorrectMenuPanels)
        {
            if (panel != null)
            {
                panel.SetActive(false);
            }
        }
    }

    //button for incorrect menu
    public void quitApp()
    {
        Application.Quit();
    }
}
