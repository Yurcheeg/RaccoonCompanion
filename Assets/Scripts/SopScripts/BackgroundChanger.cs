using UnityEngine;
using UnityEngine.UI;

public class BackgroundChanger : MonoBehaviour
{
    public Image backgroundImage;
    public Sprite[] backgroundSprites;
    private int backgroundIndex = 0;

    void Start()
    {
        if (backgroundSprites.Length > 0)
        {
            backgroundImage.sprite = backgroundSprites[backgroundIndex];
        }
    }

    public void ChangeBackground(int index)
    {
        if (index >= 0 && index < backgroundSprites.Length)
        {
            backgroundIndex = index;
            backgroundImage.sprite = backgroundSprites[backgroundIndex];
        }
        else
        {
            Debug.LogWarning("Invalid background index.");
        }
    }
}
