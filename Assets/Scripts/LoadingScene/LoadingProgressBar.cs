using UnityEngine;
using UnityEngine.UI;

public class LoadingProgressBar : MonoBehaviour {
    private Image targetImage;
    [SerializeField] 
     private Sprite[] sprites;
    [System.Serializable] private enum Loading_Bar_Type{
        None, Fill, SpriteSwap 
    }
    [SerializeField] private Loading_Bar_Type loadingBarType; 

    private void Awake() {
        targetImage = transform.GetComponent<Image>();
    }
    void Start()
    {
        switch (loadingBarType)
        {
            case Loading_Bar_Type.Fill:
                targetImage.fillAmount = 0;
                break;
            default:
                break;
        }
    }

    private void Update()
    {
        switch (loadingBarType)
        {
            case Loading_Bar_Type.Fill:
                FillerLoadingType();
                break;
            case Loading_Bar_Type.SpriteSwap:
                SpriteSwapLoadingType();
                break;
            default:
                break;
        }

    }

    private void FillerLoadingType()
    {
        targetImage.fillAmount = Loader.GetLoadingProgress();
    }
    private void SpriteSwapLoadingType()
    {
        float breakPoint = (float)1/(sprites.Length - 1);
        int spriteIndex = (int)Mathf.Floor(Loader.GetLoadingProgress() / breakPoint);
        Debug.Log($"index {spriteIndex}");
        Sprite selectedSprite = sprites[spriteIndex];
        targetImage.sprite = selectedSprite;
        targetImage.fillAmount = 1;
    }
}
