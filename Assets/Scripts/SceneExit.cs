using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour {
    public string Transition;
    public string NextScene;
    public SceneEntrance SceneEntrance;

    // Start is called before the first frame update
    void Start() {
        this.SceneEntrance.Transition = this.Transition;
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player") {
            SceneManager.LoadScene(this.NextScene);
            PlayerController.Instance.Transition = this.Transition;
        }
    }
}
