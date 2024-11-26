using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sequenceManager : MonoBehaviour
{
    //gameobjects and scripts needed to manage sequence of game
    private gameManager gameM;
    private UIManager uiM;
    public int currentStep = 1;

    // Start is called before the first frame update
    void Start()
    {
        //method to make sure gameobjects get necessary components from different scripts
        gameM = GetComponent<gameManager>();
        uiM = GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //method to handle when an image is scanned
    public void imageScanned(int panelNumber)
    {
        //getting step from gamemanager and checking if corrent image is scanned
        if(panelNumber == gameM.getStep())
        {
            uiM.activatePanel(panelNumber);
            gameM.progressStep();
        }
        else
        {
            Debug.Log("Incorrect image scanned");
            uiM.deactivateAllPanels();
            uiM.incorrectExhibitPanels[panelNumber - 1].SetActive(true);
        }
    }

    //method returns true or false if panel displayed is the correct panel using step
    public bool isCorrectPanel(int panelNumber)
    {
        return panelNumber == currentStep;
    }

    //method to advance the step
    public void advanceStep()
    {
        currentStep++;
    }
}
