using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public bool timed = false;
    public float timeTillNextLevel = 5.0f;

    // Update is called once per frame
    void Update() {
        if (timeTillNextLevel <= 0 && timed)    //if the level is timed 
            LoadNextScene();                    //load the next scene
        timeTillNextLevel -= Time.deltaTime;    //decement time till next level by time passed by this frame
    }

    public void LoadNextScene() {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;    //retrieve index of current scene
        SceneManager.LoadScene(currentIndex + 1);                       //load the scene with the next index
    }

    public void LoadPreviousScene() {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;    //retrieve index of current scene
        SceneManager.LoadScene(currentIndex - 1);                       //load the scene with the previous index
    }

    public void LoadLevel(int index) {                                  
        SceneManager.LoadScene(index);  //load scene specified
        ScoreKeeper.score = 0;          //TAKE THIS OUT IF RESUSING THIS CODE FOR AN ALTERNATE PROJECT - this resets the score                                
    }
}