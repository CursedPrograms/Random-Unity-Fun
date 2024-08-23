using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    public Sprite[] animationFrames;
    public float framesPerSecond = 10f;
    private SpriteRenderer spriteRenderer;
    private float timer;
    private int currentFrame;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (animationFrames.Length == 0) return;        

        timer += Time.deltaTime;

        float timePerFrame = 1f / framesPerSecond;

        if (timer >= timePerFrame)
        {
            currentFrame = (currentFrame + 1) % animationFrames.Length;

            spriteRenderer.sprite = animationFrames[currentFrame];

            timer -= timePerFrame;
        }
    }
}
