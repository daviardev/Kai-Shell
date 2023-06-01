using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Collision : MonoBehaviour {
    #region Layers and collision of the game
    [Header("Layers")]
    public LayerMask groundLayer;

    [Space]

    [Header("Booleans")]
    public bool onGround;

    [Space]

    [Header("Collision")]
    [SerializeField] private float collRadius = .25f;
    public Vector2 bottomOffset;
    #endregion

    void Update () {
        #region Check collision
        onGround = Physics2D.OverlapCircle((Vector2) transform.position + bottomOffset, collRadius, groundLayer);
        #endregion
    }
    #region Draw gizmos
    void OnDrawGizmos () {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2) transform.position + bottomOffset, collRadius);
    }
    #endregion
}