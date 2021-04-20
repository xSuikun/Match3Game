using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private BoardSettings boardSettings;

    private void Start()
    {
        boardSettings = GetComponent<BoardSettings>();
    }

    protected int xSize
    {
        get
        {
            return boardSettings.xSize;
        }
    }
    protected int ySize
    {
        get
        {
            return boardSettings.ySize;
        }
    }
    protected List<Sprite> tileSprites
    {
        get
        {
            return boardSettings.tileSprites;
        }
    }
}
