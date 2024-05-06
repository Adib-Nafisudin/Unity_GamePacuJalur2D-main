using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SceneTransitioner : MonoBehaviour
{
    public Image img;
    public float speed;
    public AnimationCurve fadeCurve;

    void Start()
    {
        StartCoroutine(FadeIn());
    }
    IEnumerator FadeIn()
    {
        float t = 1f;
        while (t > 0f)
        {
            t -= Time.deltaTime * speed;
            float a = fadeCurve.Evaluate(t);
            img.color = new Color (0f,0f,0f,a);
            yield return 0;
        }
    }
    public void FadeTo(string scene){
        StartCoroutine(FadeOut(scene));
    }
    IEnumerator FadeOut(string scene)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * speed;
            float a = fadeCurve.Evaluate(t);
            img.color = new Color (0f,0f,0f,a);
            yield return 0;
        }
        SceneManager.LoadScene(scene);
    }
    
}
