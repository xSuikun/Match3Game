using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearBoardSystem : BoardSettings
{
    public bool IsSearchingEmptyTile { private get; set; }
    public bool IsShifting { get; private set; }

    [SerializeField] private FindMatchSystem findMatchSystem;

    private Tile[,] tileGrid;

    private void Update()
    {
        if (IsSearchingEmptyTile)
            SearchEmptyTile();
    }

    public void SetTileGrid(Tile[,] tileGrid) => this.tileGrid = tileGrid;

    private void SearchEmptyTile()
    {
        for (int x = 0; x < xSize; x++)
            for (int y = ySize - 1; y >= 0; y--)
            {
                if (tileGrid[x, y].IsEmpty)
                    ShiftTileDown(x, y);
            }

        IsSearchingEmptyTile = false;

        for (int x = 0; x < xSize; x++)
            for (int y = 0; y < ySize; y++)
            {
                findMatchSystem.FindAllMatch(tileGrid[x, y]);
            }
    }

    private void ShiftTileDown(int xPosition, int yPosition)
    {
        IsShifting = true;
        for (int y = yPosition; y < ySize - 1; y++)
        {
            if (!tileGrid[xPosition, y + 1].IsEmpty)
            {
                Tile tile = tileGrid[xPosition, y];

                tile.spriteRenderer.sprite = tileGrid[xPosition, y + 1].spriteRenderer.sprite;
            }
        }
        tileGrid[xPosition, ySize - 1].spriteRenderer.sprite = GetRandomSprite(xPosition, yPosition);

        IsShifting = false;
    }

    private Sprite GetRandomSprite(int xPosition, int yPosition)
    {
        List<Sprite> cashSprites = new List<Sprite>();
        cashSprites.AddRange(tileSprites);

        if (xPosition > 0)
            cashSprites.Remove(tileGrid[xPosition - 1, yPosition].spriteRenderer.sprite);

        if (xPosition < xSize - 1)
            cashSprites.Remove(tileGrid[xPosition + 1, yPosition].spriteRenderer.sprite);

        if (yPosition > 0)
            cashSprites.Remove(tileGrid[xPosition, yPosition - 1].spriteRenderer.sprite);

        return cashSprites[Random.Range(0, cashSprites.Count)];
    }
}
