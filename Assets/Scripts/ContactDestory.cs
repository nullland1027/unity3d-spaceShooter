using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDestory : MonoBehaviour
{
    public GameObject asteroidExplosion;
    public GameObject playerExplosion;
    // Start is called before the first frame update
    private GameController controller;

    private void Start() {
        GameObject tmp = GameObject.FindGameObjectWithTag("GameController");
        controller = tmp.GetComponent<GameController>();
        if (controller == null) {
            Debug.LogError("NOT FIND GAMECONTROLLER SCRIPT");
        }    
    }


    void OnTriggerEnter(Collider other) {

        if (other.tag == "Boundary") {
            return;
        }
        if (other.tag != "Player") {
            controller.AddScore(10);
        }
        Destroy(other.gameObject);
        Destroy(gameObject);

        GameObject tmp =  Instantiate(asteroidExplosion, transform.position, transform.rotation) as GameObject;
        Destroy(tmp, 1);

        if (other.tag == "Player") {
            tmp = Instantiate(playerExplosion, other.transform.position, other.transform.rotation) as GameObject;
            Destroy(tmp, 1);

            controller.EndGame();
        }
    }
}
