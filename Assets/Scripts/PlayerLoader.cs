using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour {
    public GameObject Player;

    // Start is called before the first frame update
    void Start() {
        if (PlayerController.Instance == null) {
            Instantiate(this.Player);
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
