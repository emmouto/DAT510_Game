using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {
    public static GridManager gridManagerInstance;
    public List<Sprite> tileSprites = new List<Sprite>();
    public GameObject tile; // Prefab
    public int gridDimensionX = 8;
    public int gridDimensionY = 8;
    public float distance = 1.0f;
    private GameObject[,] grid;

    // Start is called before the first frame update
    void Start() {
        gridManagerInstance = GetComponent<GridManager>(); // Singleton instance of the GridManager

        Vector2 offset = tile.GetComponent<SpriteRenderer>().bounds.size;
        initGrid(offset.x, offset.y);
    }

    // 
    private void initGrid(float offsetX, float offsetY) {
        grid = new GameObject[gridDimensionX, gridDimensionY]; // Create 8x8 grid

        float startX = transform.position.x;
        float startY = transform.position.y;

        for (int x = 0; x < gridDimensionX; x++) {
            for (int y = 0; y < gridDimensionY; y++) {
                GameObject newTile = Instantiate(tile, new Vector3(startX + (offsetX * x), startY + (offsetY * y), 0), tile.transform.rotation);
                grid[x, y] = newTile;
            }
        }
    }
}
