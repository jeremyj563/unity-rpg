using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform Target;

    // Start is called before the first frame update
    void Start() {
        this.Target = PlayerController.Instance.transform;
    }

    // Update is called once per frame
    void Update() {
        
    }

    // LateUpdate is called once per frame after Update
    void LateUpdate() {
        SetPosition(this.Target.position);
    }

    private void SetPosition(Vector3 target) {
        var currentPosition = base.transform.position;
        var x = target.x;
        var y = target.y;
        var z = currentPosition.z;
        base.transform.position = new Vector3(x, y, z);
    }
}
