using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSettings : MonoBehaviour
{
    public int xSize;
    public int ySize;
    public List<Sprite> tileSprites;

    public void SetupSettings(int xSize, int ySize, List<Sprite> tileSprites)
    {
        this.xSize = xSize;
        this.ySize = ySize;
        this.tileSprites = tileSprites;
    }
}
