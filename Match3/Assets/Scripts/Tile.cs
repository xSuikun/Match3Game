using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [HideInInspector] public bool isSelected;

    public SpriteRenderer spriteRenderer
    {
        get
        {
            return GetComponent<SpriteRenderer>();
        }
    }

    public bool IsEmpty
    {
        get
        {
            return spriteRenderer.sprite == null;
        }
    }
}
