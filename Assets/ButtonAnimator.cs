using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonAnimator : MonoBehaviour
{
    public Button[] buttons;         
    public float animationDuration = 1f;     
    public float delayBeforeAnimation = 0.5f;      

    void Start()
    {
        foreach (Button button in buttons)
        {
            button.interactable = false;
        }

        StartCoroutine(AnimateButtons());
    }

    private IEnumerator AnimateButtons()
    {
        yield return new WaitForSeconds(delayBeforeAnimation);

        float elapsedTime = 0f;

        Vector3 initialScale = Vector3.zero;       
        Vector3 targetScale = Vector3.one;            

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / animationDuration);

            Vector3 currentScale = Vector3.Lerp(initialScale, targetScale, progress);

            foreach (Button button in buttons)
            {
                button.transform.localScale = currentScale;
            }

            yield return null;
        }

        foreach (Button button in buttons)
        {
            button.transform.localScale = targetScale;
        }

        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
    }
}
