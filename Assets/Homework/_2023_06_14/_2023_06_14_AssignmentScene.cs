using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _2023_06_14_AssignmentScene : _2023_06_14_BaseScene
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Transform spawnPoint;
    protected override IEnumerator LoadingRoutine()
    {
        Instantiate(player, spawnPoint.position, spawnPoint.rotation);
        yield return new WaitForSecondsRealtime(1);
        progress = 1.0f;
    }
}
