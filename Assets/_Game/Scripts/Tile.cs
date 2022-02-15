using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    private static Color selectedColor = new Color(.5f, .5f, .5f, 1.0f);
    private static Tile previousSelected = null;

    private SpriteRenderer spriteRenderer;
    private bool isSelected = false;

    private Vector3[] adjacentDirections = new Vector3[]{Vector3.up, Vector3.down, Vector3.left, Vector3.right};

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
            return;
        }

        if (isSelected) { 
            Deselect();
        } else {
            if (previousSelected == null) {
                Select();
            } else {
                if (GetAllAdjacentTiles().Contains(previousSelected.gameObject)) {
                    SwapSprite(previousSelected.spriteRenderer); 
                    previousSelected.Deselect();
                } else {
                    previousSelected.GetComponent<Tile>().Deselect();
                    Select();
                }
            }
        }
    }

    public void SwapSprite(SpriteRenderer spriteRenderer2) { 
        if (spriteRenderer.sprite == spriteRenderer2.sprite) { 
            return;
        }

        Sprite tempSprite = spriteRenderer2.sprite;
        spriteRenderer2.sprite = spriteRenderer.sprite;
        spriteRenderer.sprite = tempSprite; 
        SFXManager.instance.PlaySFX(Clip.Swap);
    }

    private GameObject GetAdjacent(Vector3 castDir) {
        RaycastHit hit;
        Physics.Raycast(transform.position, castDir, out hit, 1.23f);
        Debug.Log("castDir: " + castDir);
        Debug.Log("transform.position: " + transform.position);
        Debug.Log("hit.collider: " + hit.collider);

        if (hit.collider != null) {
            return hit.collider.gameObject;
        }

        return null;
    }

    private List<GameObject> GetAllAdjacentTiles() {
        List<GameObject> adjacentTiles = new List<GameObject>();

        for (int i = 0; i < adjacentDirections.Length; i++) {
            adjacentTiles.Add(GetAdjacent(adjacentDirections[i]));
        }

        Debug.Log(adjacentTiles);
        return adjacentTiles;
    }
}
