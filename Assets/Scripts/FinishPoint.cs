using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    private bool isFading;
    private bool isStartupFade = true;
    private bool isReloadFade;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Bear"))
        {
            if (isFading) return; //so if bear and player enter hatch you dont skip a level
            isFading = true;
            GameManager.Instance.currentLevel++;
            GetComponent<Animator>().Play("FadeOut");
            isStartupFade = false;
        }
    }
    public void ReloadLevel()
    {
        isReloadFade = true;
        GetComponent<Animator>().Play("FadeOut");
    }
    private void LoadNextLevel()
    {
        if (isReloadFade)
        {
            GameManager.Instance.LoadNextLevel();
        }
        if (isStartupFade)
        {
            return;
        }
        GameManager.Instance.LoadNextLevel();
    }
}
