using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapTilesSystem : MonoBehaviour
{
    [SerializeField] private FindMatchSystem findMatchSystem;
    [SerializeField] private ClearBoardSystem clearBoardSystem;
    [SerializeField] private GameManager gameManager;

    private Tile oldSelectedTile;

    private Vector2[] rayDirections = new Vector2[] { Vector2.up,
                                                      Vector2.down,
                                                      Vector2.left,
                                                      Vector2.right };

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D ray = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            if (ray)
                TrySelectTile(ray.collider.gameObject.GetComponent<Tile>());
        }
    }

    private void SelectTile(Tile tile)
    {
        tile.isSelected = true;
        tile.spriteRenderer.color = new Color(0.5f, 0.5f, 0.5f);
        oldSelectedTile = tile;
    }

    private void DeselectTile(Tile tile)
    {
        tile.isSelected = false;
        tile.spriteRenderer.color = new Color(1, 1, 1);
        oldSelectedTile = null;
    }

    private void TrySelectTile(Tile tile)
    {
        if (tile.IsEmpty || clearBoardSystem.IsShifting || gameManager.Moves <= 0) return;

        if (tile.isSelected) DeselectTile(tile);
        else if (oldSelectedTile == null) SelectTile(tile);
        else if (GetNearbyTiles().Contains(tile)) SwapTwoTiles(tile);
        else
        {
            DeselectTile(oldSelectedTile);
            SelectTile(tile);
        }
    }

    private void SwapTwoTiles(Tile tile)
    {
        Sprite cashSprite = oldSelectedTile.spriteRenderer.sprite;
        oldSelectedTile.spriteRenderer.sprite = tile.spriteRenderer.sprite;
        tile.spriteRenderer.sprite = cashSprite;
        findMatchSystem.FindAllMatch(tile);
        findMatchSystem.FindAllMatch(oldSelectedTile);
        DeselectTile(oldSelectedTile);

        gameManager.DecreaseMoves();
    }

    private List<Tile> GetNearbyTiles()
    {
        List<Tile> possibleToSwapTiles = new List<Tile>();
        for (int i = 0; i < rayDirections.Length; i++)
        {
            RaycastHit2D hit = Physics2D.Raycast(oldSelectedTile.transform.position, rayDirections[i]);
            if (hit.collider)
                possibleToSwapTiles.Add(hit.collider.GetComponent<Tile>());
        }
        return possibleToSwapTiles;
    }
}
