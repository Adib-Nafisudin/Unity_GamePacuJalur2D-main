using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoImageLoader : MonoBehaviour
{
    [SerializeField] List<Sprite> sprites = new List<Sprite>();
    [SerializeField] Image image => GetComponent<Image>();
    private void Start() {
        // image.sprite = sprites[Random.Range(0, sprites.Count-1)];
    }
    public void SetImage(int index) => image.sprite = sprites[index];
}
