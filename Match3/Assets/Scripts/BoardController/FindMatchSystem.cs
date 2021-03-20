using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMatchSystem : MonoBehaviour
{
    [SerializeField] private ClearBoardSystem clearBoardSystem;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameUI ui;

    private bool isFoundMatch;

    private Vector2[] horizontalDirections = new Vector2[] {Vector2.left,
                                                            Vector2.right };

    private Vector2[] verticalDirections = new Vector2[] { Vector2.up,
                                                           Vector2.down};

    private void TryFindMatch(Tile tile, Vector2[] directions)
    {
        List<Tile> cashFoundTiles = new List<Tile>();
        cashFoundTiles.Add(tile);
        for (int i = 0; i < directions.Length; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(tile.transform.position, directions[i]);
            while (hit.collider && hit.collider.gameObject.GetComponent<Tile>().spriteRenderer.sprite == tile.spriteRenderer.sprite)
            {
                cashFoundTiles.Add(hit.collider.gameObject.GetComponent<Tile>());
                hit = Physics2D.Raycast(hit.collider.gameObject.transform.position, directions[i]);
            }
        }

        isFoundMatch = TryCollectTiles(tile, cashFoundTiles);
    }

    private bool TryCollectTiles(Tile tile, List<Tile> foundTiles)
    {
        List<Tile> cashFoundTiles = new List<Tile>();
        cashFoundTiles.AddRange(foundTiles);

        if (cashFoundTiles.Count >= 3)
        {
            for (int i = 0; i < cashFoundTiles.Count; i++)
            cashFoundTiles[i].spriteRenderer.sprite = null;
            clearBoardSystem.IsSearchingEmptyTile = true;

            gameManager.AddScore(cashFoundTiles.Count);
        }

        return cashFoundTiles.Count >= 3;
    }

    public void FindAllMatch(Tile tile)
    {
        if (tile.IsEmpty) return;

        TryFindMatch(tile, verticalDirections);
        TryFindMatch(tile, horizontalDirections);

        if (isFoundMatch)
        {
            isFoundMatch = false;
            clearBoardSystem.IsSearchingEmptyTile = true;
        }
    }
}
