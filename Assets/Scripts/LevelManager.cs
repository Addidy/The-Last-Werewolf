using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public bool timed = false;
    public float timeTillNextLevel = 5.0f;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) || (timeTillNextLevel <= 0 && timed))
            LoadNextScene();
        timeTillNextLevel -= Time.deltaTime;
    }

    public void LoadNextScene() {
        // Load Scene
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        // Load currentIndex + 1
        SceneManager.LoadScene(currentIndex + 1);
    }

    public void LoadPreviousScene() {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex - 1);
    }

    public void LoadLevel(int index) {
        SceneManager.LoadScene(index);
    }
}