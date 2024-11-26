using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioManager : MonoBehaviour
{
    //gameobjects for audio clips needed in game
    public AudioSource audioSource;
    public GameObject audioSourceObject;
    public AudioClip[] clips;
    public string correctSongName = "Workers Choir  Ilizwe Ngelethu";

    //game objects for UI panels
    public GameObject radioCorrectPanel;
    public GameObject radioIncorrectPanel;

    //buttons for UI
    public Button radioBtnListener;
    public Button selectSongButton;
    public GameObject radioBtn;
    public GameObject imageRotate;
    public GameObject radioPanel;

    //game manager to get the lives left
    private gameManager gameM;

    //game objects for Vuforia camera
    public Camera arCamera;
    public float maxRaycastDist = 10f;

    // Start is called before the first frame update
    void Start()
    {
        //referring back to original game object in game manager script
        radioBtn.SetActive(false);

        radioBtnListener.onClick.AddListener(changeSong);
        selectSongButton.onClick.AddListener(selectSong);

        //get game manager component to manage game logic
        gameM = FindAnyObjectByType<gameManager>();
    }

    // Update is called once per frame
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

    //method to change the song
    public void changeSong()
    {
        if(clips.Length > 0)
        {
            int nextAudio = (System.Array.IndexOf(clips, audioSource.clip) + 1) % clips.Length;
            audioSource.clip = clips[nextAudio];
            audioSource.Play();
        }
    }

    //method to select a song out of the 3 clips
    public void selectSong()
    {
        //check if audio source isnt null
        if(audioSource.clip != null)
        {
            //checking if song chosen is the correct song
            if(audioSource.clip.name == correctSongName)
            {
                audioSource.Stop();
                audioSourceObject.SetActive(false);
                radioPanel.SetActive(false);
                radioCorrectPanel.SetActive(true);
                Debug.Log("Correct song selected");
            }
            //if song chosen is incorrect incorrect panel should be set active
            else
            {
                audioSource.Stop();
                audioSourceObject.SetActive(false);
                radioPanel.SetActive(false);
                radioIncorrectPanel.SetActive(true);

                gameM.deductLife();
                Debug.Log("Incorrect song selected");

                //if user doesnt have any lives left gameover panel needs to be set active
                if(gameM.getLives() <= 0)
                {
                    audioSource.Stop();
                    audioSourceObject.SetActive(false);
                    radioPanel.SetActive(false);

                    gameM.gameOverPanel.SetActive(true);
                    Debug.Log("User ran out of lives");
                }
            }
        }
        else
        {
            Debug.LogError("No audio clip selected in audiosource");
        }
    }

    //method to make btn rotate like radio nob
    public void imageRotateBtn()
    {
        //rotate image 90 degrees
        imageRotate.transform.Rotate(0f, 0f, 90f);
    }
}
