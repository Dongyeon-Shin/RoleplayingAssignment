using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _2023_06_14_LoadingUI : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    private GraphicRaycaster graphicRaycaster;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        graphicRaycaster = GetComponent<GraphicRaycaster>();
    }

    public void FadeIn()
    {
        anim.SetTrigger("FadeIn");
        graphicRaycaster.enabled = false;
    }

    public void FadeOut()
    {
        anim.SetTrigger("FadeOut");
        graphicRaycaster.enabled = true;
    }

    public void SetProgress(float progress)
    {
        slider.value = progress;
    }
}
