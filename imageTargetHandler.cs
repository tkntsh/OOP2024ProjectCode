using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class imageTargetHandler : MonoBehaviour
{
    //objects needed to track which image has been scanned
    public GameObject correctPanel;
    public GameObject incorrectPanel;
    public string targetSceneName;
    private ObserverBehaviour observerBehaviour;
    public sequenceManager sequenceManager;
    public int panelNumber;

    void Start()
    {
        //checking which image is scanned and/or changed
        observerBehaviour = GetComponent<ObserverBehaviour>();
        if(observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }
    }

    //if image is not longer scanned
    private void OnDestroy()
    {
        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }

    //method to check if image has been detected 
    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        if(targetStatus.Status == Status.TRACKED || targetStatus.Status == Status.EXTENDED_TRACKED)
        {
            //image has been detected
            sequenceManager.imageScanned(panelNumber);
        }
    }

    //method to check what scene the user is currently on 
    private void sceneChecker()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if(currentScene.name == targetSceneName)
        {
            if(sequenceManager.isCorrectPanel(panelNumber))
            {
                correctPanel.SetActive(true);
                incorrectPanel.SetActive(false);
            }
            else
            {
                correctPanel.SetActive(false);
                incorrectPanel.SetActive(true);
            }
        }
        else
        {
            Debug.Log("This scene does not require a specific qr code");
        }
    }
}
