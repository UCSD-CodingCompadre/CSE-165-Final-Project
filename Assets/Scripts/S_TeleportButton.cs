using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TeleportButton : MonoBehaviour
{

    public Vector3 teleportLocation;
    public Transform player;

    public void Awake()
    {
        GameObject foundPlayer = GameObject.FindWithTag("Player");
        player = foundPlayer.transform;
    }

    public void Teleport()
    {
        player.gameObject.transform.position = teleportLocation;
        player.GetComponent<CharacterController>().enabled = true;
    }
}
