using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _2023_06_14_TitleScene : _2023_06_14_BaseScene
{
    protected override IEnumerator LoadingRoutine()
    {
        yield return null;
    }

    public void OnStartButton()
    {
        GameManager.Scene.LoadScene("AssignmentScene");
    }
}
