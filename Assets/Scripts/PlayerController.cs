using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public static PlayerController Instance { get; set; }
    public Rigidbody2D Rigidbody;
    public float MoveSpeed;
    public Animator Animator;
    public string Transition;

    private Vector2 _Velocity {
        get {
            return this.Rigidbody.velocity;
        } set {
            this.Rigidbody.velocity = value;
        }
    }
    private float _XInput { get; set; }
    private float _YInput { get; set; }

    // Start is called before the first frame update
    private void Start() {
        SetInstance();
        DontDestroyOnLoad(base.gameObject);
    }

    // Update is called once per frame
    private void Update() {
        GetXYInput();
        SetVelocity();
        Animate();
    }

    private void SetInstance() {
        if (PlayerController.Instance == null) {
            PlayerController.Instance = this;
        } else {
            Destroy(base.gameObject);
        }
    }

    private void GetXYInput() {
        this._XInput = Input.GetAxisRaw("Horizontal");
        this._YInput = Input.GetAxisRaw("Vertical");
    }

    private void SetVelocity() {
        this._Velocity = new Vector2(this._XInput, this._YInput) * MoveSpeed;
    }

    private void SetLastMove(float x, float y) {
        this.Animator.SetFloat("lastMoveX", x);
        this.Animator.SetFloat("lastMoveY", y);
    }

    private void Animate() {
        this.Animator.SetFloat("moveX", this._Velocity.x);
        this.Animator.SetFloat("moveY", this._Velocity.y);
        
        float[] xy = {this._XInput, this._YInput};
        if (xy.Contains(1) || xy.Contains(-1)) {
            SetLastMove(this._XInput, this._YInput);
        }
    }

    private string GetDebuggerDisplay() {
        return ToString();
    }
}
