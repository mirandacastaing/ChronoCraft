using UnityEngine;
using UnityEngine.UI;

public class TimeEffectUI : MonoBehaviour
{
    public Image tintImage;
    public float fadeSpeed = 5f;
    public PlayerController player;

    void Update()
    {
        if (player == null || tintImage == null) return;

        // Target alpha based on whether time is slowed
        float targetAlpha = (Time.timeScale < 1f) ? 0.24f : 0f;

        // Smoothly fade to target alpha
        Color color = tintImage.color;
        color.a = Mathf.Lerp(color.a, targetAlpha, Time.unscaledDeltaTime * fadeSpeed);
        tintImage.color = color;
    }
}
