using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //gameobjects needed to manage UI elements
    public GameObject[] correctExhibitPanels;
    public GameObject[] incorrectExhibitPanels;
    public GameObject gameOverPanel;
    public GameObject gameCompletePanel;

    //reference to gamemanager script
    private gameManager gameM;

    // Start is called before the first frame update
    void Start()
    {
        gameM.GetComponent<gameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //method to activate required panel based on the current step
    public void activatePanel(int panelNum)
    {
        //deactivating all panels first
        deactivateAllPanels();

        //getting current step from game manager script
        int currentStep = gameM.getStep();

        //checking if the panel number is valid and if it is the correct step
        if(panelNum == currentStep)
        {
            correctExhibitPanels[panelNum - 1].SetActive(true);
            //currentStep++;
        }
        else
        {
            incorrectExhibitPanels[panelNum - 1].SetActive(true);
            Debug.LogError("Invalid panel number");
        }
    }

    //method to deactivate all UI panels
    public void deactivateAllPanels()
    {
        foreach(GameObject panel in incorrectExhibitPanels)
        {
            panel.SetActive(false);
        }
        foreach(GameObject panel in correctExhibitPanels)
        {
            panel.SetActive(false);
        }

        gameOverPanel.SetActive(false);
        gameCompletePanel.SetActive(false);
    }
}
