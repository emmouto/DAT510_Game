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
                newTile.name = "Tile " + x + "," + y;
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

    public IEnumerator FindNullTiles() {
        for (int x = 0; x < gridX; x++) {
            for (int y = 0; y < gridY; y++) {
                if (grid[x, y].GetComponent<SpriteRenderer>().sprite == null) {
                    yield return StartCoroutine(ShiftTilesDown(x, y));
                    break;
                }
            }
        }

        for (int x = 0; x < gridX; x++) {
            for (int y = 0; y < gridY; y++) {
                grid[x, y].GetComponent<Tile>().ClearAllMatches();
            }
        }
    }

    // Shifts tiles down and refills the board.
    private IEnumerator ShiftTilesDown(int x, int yStart, float shiftDelay = .03f) {
        IsShifting = true;
        int nullCount = 0;
        List<SpriteRenderer> renderers = new List<SpriteRenderer>();

        for (int y = yStart; y < gridY; y++) {  
            SpriteRenderer spriteRenderer = grid[x, y].GetComponent<SpriteRenderer>();

            if (spriteRenderer.sprite == null) {
                nullCount++;
            }

            renderers.Add(spriteRenderer);
        }

        for (int i = 0; i < nullCount; i++) {
            yield return new WaitForSeconds(shiftDelay);

            for (int k = 0; k < renderers.Count - 1; k++) {
                renderers[k].sprite = renderers[k + 1].sprite;
                renderers[k + 1].sprite = GetNewSprite(x, gridY - 1);
            }
        }

        IsShifting = false;
    }

    private Sprite GetNewSprite(int x, int y) {
        List<Sprite> possibleCharacters = new List<Sprite>();
        possibleCharacters.AddRange(sprites);

        if (x > 0) {
            possibleCharacters.Remove(grid[x - 1, y].GetComponent<SpriteRenderer>().sprite);
        }

        if (x < gridX - 1) {
            possibleCharacters.Remove(grid[x + 1, y].GetComponent<SpriteRenderer>().sprite);
        }

        if (y > 0) {
            possibleCharacters.Remove(grid[x, y - 1].GetComponent<SpriteRenderer>().sprite);
        }

        return possibleCharacters[Random.Range(0, possibleCharacters.Count)];
    }
}
