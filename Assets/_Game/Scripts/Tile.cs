using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    private static Color selectedColor = new Color(.5f, .5f, .5f, 1.0f);
    private static Tile previousSelected = null;

    private SpriteRenderer spriteRenderer;
    private bool isSelected = false;
    private Vector2[] adjacentDirections = new Vector2[]{Vector2.up, Vector2.down, Vector2.left, Vector2.right};

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Select() {
        isSelected = true;
        spriteRenderer.color = selectedColor;
        previousSelected = gameObject.GetComponent<Tile>();
        SFXManager.instance.PlaySFX(Clip.Select);
    }

    private void Deselect() {
        isSelected = false;
        spriteRenderer.color = Color.white;
        previousSelected = null;
    }

    void OnMouseDown() {
        if (spriteRenderer.sprite == null || GridManager.instance.IsShifting) {
            Debug.Log("1");
            return;
        }

        if (isSelected) {
            Debug.Log("2");
            Deselect();
        } else {
            if (previousSelected == null) {
                Debug.Log("3");
                Select();
            } else {
                Debug.Log("4");
                Debug.Log("4");
                if (GetAllAdjacentTiles().Contains(previousSelected.gameObject)) {
                    Debug.Log("5");
                    SwapSprite(previousSelected.spriteRenderer); 
                    previousSelected.Deselect();
                } else {
                    Debug.Log("6");
                    previousSelected.GetComponent<Tile>().Deselect();
                    Select();
                }
            }
        }
    }

    public void SwapSprite(SpriteRenderer spriteRenderer2) {
        Debug.Log("SwapSprite");
        if (spriteRenderer.sprite == spriteRenderer2.sprite) { 
            return;
        }

        Sprite tempSprite = spriteRenderer2.sprite;
        spriteRenderer2.sprite = spriteRenderer.sprite;
        spriteRenderer.sprite = tempSprite; 
        SFXManager.instance.PlaySFX(Clip.Swap);
    }

    private GameObject GetAdjacent(Vector2 castDir) {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, castDir);
        // https://stackoverflow.com/questions/38191659/unity-physics2d-raycast-hits-itself if it still hits itself this is why

        if (hit.collider != null) {
            Debug.Log("hit.collider.gameObject: " + hit.collider.gameObject);
            return hit.collider.gameObject;
        }

        return null;
    }

    private List<GameObject> GetAllAdjacentTiles() {
        Debug.Log("7");
        List<GameObject> adjacentTiles = new List<GameObject>();

        for (int i = 0; i < adjacentDirections.Length; i++) {
            adjacentTiles.Add(GetAdjacent(adjacentDirections[i]));
        }

        return adjacentTiles;
    }
}
