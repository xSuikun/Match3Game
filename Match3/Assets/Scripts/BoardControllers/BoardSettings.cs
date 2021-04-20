using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSettings : MonoBehaviour
{
    public int xSize { get; private set; }
    public int ySize { get; private set; }
    public List<Sprite> tileSprites;

    private void Awake()
    {
        xSize = 5;
        ySize = 9;
    }
}
