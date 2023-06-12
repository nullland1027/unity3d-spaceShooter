using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public GameObject asteroid;
    public Vector3 spawnValues;
    public int asteroidCount;
    public float spawnWait;
    public float startWait;
    public Text scoreText;
    public int score;

    public Text endText;
    private bool gameEnded;
    void Start()
    {
        gameEnded = false;
        endText.gameObject.SetActive(false);
        scoreText.text = "Score: 0";
        StartCoroutine(SpawnWaves());
    }
    private void Update() {
        if (gameEnded) {
            if (Input.GetKeyDown (KeyCode.R)) {
                Scene level = SceneManager.GetActiveScene();
                SceneManager.LoadScene(level.name);
            }
        }
    }
    public void EndGame() {
        gameEnded = true;
        endText.gameObject.SetActive(true);
    }
    public void AddScore(int points) {
        score += points;
        scoreText.text = "Score: " + score;
    }
    // Update is called once per frame
    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWait);
        while (true) {
            for (int i = 0; i < asteroidCount; i++) {
                Vector3 spawnAt = new Vector3(
                Random.Range(-spawnValues.x, spawnValues.x),
                spawnValues.y,
                spawnValues.z
                );
            
                Instantiate(asteroid, spawnAt, Quaternion.identity);
                yield return new WaitForSeconds(spawnWait);
            }
        }
    }
}
