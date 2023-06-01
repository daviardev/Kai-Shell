using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour {
    #region Variables player
    private Collision coll;

    [HideInInspector]
    public Rigidbody2D rb;

    [Space]

    [Header("Stats")]
    public float speed;
    public float jumpForce;

    [Space]

    [Header("Booleans")]
    [SerializeField] private bool groundTouch;

    [Space]

    [Header("Particles")]
    [SerializeField] private ParticleSystem jumpParticle;
    #endregion

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collision>();
    }

    void Update () {
        #region Input movement
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 dir = new Vector2(x, y);

        Walk(dir, x);
        #endregion

        #region Jump and use better jump
        if (coll.onGround) GetComponent<BetterJumping>().enabled = true;

        if (Input.GetButtonDown("Jump")) {
            if (coll.onGround) Jump(Vector2.up);
        }

        if (coll.onGround && !groundTouch) {
            GroundTouch();
            groundTouch = true;
        }

        if (!coll.onGround && groundTouch) groundTouch = false;
        #endregion
    }
    #region Walk method
    private void Walk (Vector2 dir, float x) {
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
        RotatePlayer(x);
    }
    #endregion

    #region Jump method
    private void Jump (Vector2 dir) {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += dir * jumpForce;

        jumpParticle.Play();
    }
    #endregion

    #region Detect ground and play jump particle method
    private void GroundTouch () {
        jumpParticle.Play();
    }
    #endregion

    #region Rotate horizontal character method
    private void RotatePlayer (float x) {
        if (x > 0) {
            transform.localScale = new Vector2(1, 1);
        } else if (x < 0) {
            transform.localScale = new Vector2(-1, 1);
        }
    }
    #endregion
}