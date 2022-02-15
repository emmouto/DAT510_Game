using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {
    public static GridManager instance;
    public List<Sprite> sprites = new List<Sprite>();
    public GameObject tile; // Prefab
    public int gridX, gridY;
    public float distance = 1.0f;
    private GameObject[,] grid;
    Sprite[] previousLeft = new Sprite[8];
    Sprite previousBelow = null;
    public bool IsShifting {get; set;}

    // Start is called before the first frame update
    void Start() {
        instance = GetComponent<GridManager>(); // Singleton instance of the GridManager

        Vector2 offset = tile.GetComponent<SpriteRenderer>().bounds.size;
        initGrid(offset.x, offset.y);
    }

    // Creates a grid with non-repeating tiles.
    private void initGrid(float offsetX, float offsetY) {
        grid = new GameObject[gridX, gridY]; // Create 8x8 grid

        float startX = transform.position.x;
        float startY = transform.position.y;

        for (int x = 0; x < gridX; x++) {
            for (int y = 0; y < gridY; y++) {
                GameObject newTile = Instantiate(tile, new Vector3(startX + (offsetX * x), startY + (offsetY * y), 0), tile.transform.rotation);
                grid[x, y] = newTile;
                newTile.transform.parent = transform;

                List<Sprite> possibleSprites = new List<Sprite>();
                possibleSprites.AddRange(sprites);
                possibleSprites.Remove(previousLeft[y]); 
                possibleSprites.Remove(previousBelow);

                Sprite newSprite = possibleSprites[Random.Range(0, possibleSprites.Count)];
                newTile.GetComponent<SpriteRenderer>().sprite = newSprite;

                previousLeft[y] = newSprite;
                previousBelow = newSprite;
            }
        }
    }
}
