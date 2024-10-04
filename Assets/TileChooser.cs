using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileChooser : MonoBehaviour
{
    public enum tilesType
    {
        Normal,
        Card
    }
    public SpriteRenderer BoxSprite;
    public tilesType TileType = tilesType.Normal;
    // Start is called before the first frame update
    void Start()
    {
        Color CardColor = new Color(0.9f, 0.08f, 0.08f, 1f);
        Color NormalColor = new Color(0.3f, 0.3f, 0.3f, 1f);

        if (TileType == tilesType.Normal)
        {
            BoxSprite.color = NormalColor;
        }
        if (TileType == tilesType.Card)
        {
            BoxSprite.color = CardColor;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && TileType == tilesType.Card)
        {
            Cards();
        }
    }

    void Cards()
    {
    }
}
