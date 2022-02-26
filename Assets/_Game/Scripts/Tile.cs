using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    private static Color selectedColor = new Color(.5f, .5f, .5f, 1.0f);
    private static Tile previousSelected = null;

    private bool isSelected = false;
    private bool matchFound = false;
    private int elementalScoreMultiplier;

    private SpriteRenderer spriteRenderer;
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
        if (spriteRenderer.sprite == null || GridManager.instance.IsShifting) { return; }

        if (isSelected) {
            Deselect();
        } else {
            if (previousSelected == null) {
                Select();
            } else {
                if (GetAllAdjacentTiles().Contains(previousSelected.gameObject)) {
                    SwapSprite(previousSelected.spriteRenderer);
                    previousSelected.ClearAllMatches();
                    previousSelected.Deselect();
                    ClearAllMatches();
                    StopCoroutine(GridManager.instance.FindNullTiles());
                    StartCoroutine(GridManager.instance.FindNullTiles());
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
        GUIManager.instance.MoveCounter++;
    }

    private GameObject GetAdjacent(Vector2 castDir) {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, castDir);
        // https://stackoverflow.com/questions/38191659/unity-physics2d-raycast-hits-itself if it still hits itself this is why

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

        return adjacentTiles;
    }

    private List<GameObject> FindMatch(Vector2 castDir){
        List<GameObject> matchingTiles = new List<GameObject>();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, castDir);

        while (hit.collider != null && hit.collider.GetComponent<SpriteRenderer>().sprite == spriteRenderer.sprite) {
            matchingTiles.Add(hit.collider.gameObject);
            hit = Physics2D.Raycast(hit.collider.transform.position, castDir);
        }

        return matchingTiles; 
    }

    private void ClearMatch(Vector2[] paths) {
        List<GameObject> matchingTiles = new List<GameObject>(); 

        for (int i = 0; i < paths.Length; i++) {
            matchingTiles.AddRange(FindMatch(paths[i]));
        }

        if (matchingTiles.Count >= 2) {
            for (int i = 0; i < matchingTiles.Count; i++) {
                matchingTiles[i].GetComponent<SpriteRenderer>().sprite = null;
            }

            matchFound = true;
            elementalScoreMultiplier = matchingTiles.Count + 1;
        }
    }

    public void ClearAllMatches() {
        if (spriteRenderer.sprite == null) { return; }

        ClearMatch(new Vector2[2]{Vector2.left, Vector2.right});
        ClearMatch(new Vector2[2]{Vector2.up, Vector2.down});

        if (matchFound) {
            string spriteName = spriteRenderer.sprite.name;
            InfusionBarManager infusionBar = (GameObject.Find(spriteName)).GetComponent<InfusionBarManager>();
            int elementalScore = GUIManager.instance.getElementalScore(spriteName);

            for (int i = 0; i < elementalScoreMultiplier; i++) {
                elementalScore += 50;
                infusionBar.fillBar();
            }

            spriteRenderer.sprite = null;
            matchFound = false;
            SFXManager.instance.PlaySFX(Clip.Clear);
        } 
    }
}
