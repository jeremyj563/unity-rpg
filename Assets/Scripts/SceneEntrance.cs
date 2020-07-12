using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneEntrance : MonoBehaviour {
    public string Transition;

    // Start is called before the first frame update
    void Start() {
        SetPlayerPosition();
    }

    // Update is called once per frame
    void Update() {

    }

    private void SetPlayerPosition() {
        var player = PlayerController.Instance;
        if (this.Transition == player.Transition) {
            player.transform.position = base.transform.position;
        }
    }
}
