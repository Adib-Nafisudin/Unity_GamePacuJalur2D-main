using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites = new List<Sprite>();

    SpriteRenderer spriteRenderer => GetComponent<SpriteRenderer>();

    private void Start()
    {
        Init();
    }

    void Init()
    {
        var randomIndex = Random.Range(0, sprites.Count);

        spriteRenderer.sprite = sprites[randomIndex];
    }
}
