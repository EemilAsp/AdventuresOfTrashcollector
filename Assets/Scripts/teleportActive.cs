using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportActive : MonoBehaviour
{
    void Update()
    {
        GameObject[] npcMonsters = GameObject.FindGameObjectsWithTag("npc_monster");
        Debug.Log(npcMonsters.Length);
        if (npcMonsters.Length == 0)
        {
            gameObject.SetActive(true);
        }
    }
}
