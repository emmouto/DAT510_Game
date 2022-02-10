using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    private SpriteRenderer spriteRenderer;

    // 
    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
