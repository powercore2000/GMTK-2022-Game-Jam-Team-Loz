using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTriggerControler : MonoBehaviour
{
    //Not shady collider that gives the player a new respawn position when hit
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            Debug.Log("Hit the respawn colider");
            other.gameObject.SendMessage("setRespawnPoint",this.transform.position);
        }
    }
}
