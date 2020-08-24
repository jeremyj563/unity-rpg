using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour {
    public Transform Target;
    public Tilemap Map;

    private float HalfHeight;
    private float HalfWidth;
    private Vector3 MinBoundary;
    private Vector3 MaxBoundary;

    // Start is called before the first frame update
    void Start() {
        this.Target = PlayerController.Instance.transform;
        SetBoundaries();
    }

    // Update is called once per frame
    void Update() {
        
    }

    // LateUpdate is called once per frame after Update
    void LateUpdate() {
        //var position = base.transform.position;
        //var x = Mathf.Clamp(position.x, this.MinBoundary.x, this.MaxBoundary.x);
        //var y = Mathf.Clamp(position.y, this.MinBoundary.y, this.MaxBoundary.y);
        //var z = position.z;
        //base.transform.position = new Vector3(x, y, z);
        //SetPosition(this.Target.position);

        base.transform.position = new Vector3(this.Target.position.x, this.Target.position.y, base.transform.position.z);
        base.transform.position = new Vector3(Mathf.Clamp(base.transform.position.x, this.MinBoundary.x, this.MaxBoundary.x), Mathf.Clamp(base.transform.position.y, this.MinBoundary.y, this.MaxBoundary.y), base.transform.position.z);
    }

    private void SetBoundaries() {
        this.HalfHeight = Camera.main.orthographicSize;
        this.HalfWidth = Camera.main.aspect * this.HalfHeight;
        this.MinBoundary = this.Map.localBounds.min;
        this.MinBoundary += new Vector3(this.HalfWidth, this.HalfHeight, 0f);
        this.MaxBoundary = this.Map.localBounds.max;
        this.MaxBoundary -= new Vector3(this.HalfWidth, this.HalfHeight, 0f);
    }

    private void SetPosition(Vector3 target) {

    }
}
