using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BetterJumping : MonoBehaviour {
    #region Variables jump
    private Rigidbody2D rb;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    #endregion

    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update () {
        #region Fall and low jump
        if (rb.velocity.y < 0) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        #endregion
    }
}