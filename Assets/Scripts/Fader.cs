using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    CanvasGroup canvasGroup;
    [SerializeField] float fadeTime;
 private void Start() 
{
 canvasGroup = GetComponent<CanvasGroup>(); 
 StartCoroutine(FadeOut(3f));     
}
  IEnumerator FadeOut(float time)
  {
     while (canvasGroup.alpha < time)
      {
            canvasGroup.alpha += Time.deltaTime / time;
        yield return null;
      }
  }
}
