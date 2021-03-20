using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardGenerator : BoardSettings
{
    [SerializeField] private Tile tilePrefab;

    public Tile[,] tileGrid { get; private set; }

    public void GenerateBoard()
    {
        tileGrid = new Tile[xSize, ySize];
        Vector2 boardPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 tileSize = tilePrefab.spriteRenderer.bounds.size;

        Sprite lastSprite = null;

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                Vector2 newTilePosition = new Vector2(boardPosition.x + (tileSize.x * x), boardPosition.y + (tileSize.y * y));
                Tile newTile = Instantiate(tilePrefab, newTilePosition, Quaternion.identity);
                newTile.transform.parent = transform;

                tileGrid[x, y] = newTile;

                List<Sprite> tempSprites = new List<Sprite>();
                tempSprites.AddRange(tileSprites);
                tempSprites.Remove(lastSprite);
                if (x > 0)
                    tempSprites.Remove(tileGrid[x - 1, y].spriteRenderer.sprite);

                newTile.spriteRenderer.sprite = lastSprite = tempSprites[Random.Range(0, tempSprites.Count)];
            }
        }
    }
}
