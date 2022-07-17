using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerSystems;

public class HazardZone : MonoBehaviour
{
    // Start is called before the first frame update

    PlayerStats player;

    [SerializeField]
    int damage;

    [SerializeField]
    float damageInterval;

    bool playerInHazard;

    void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerStatsBehaviour>().PlayerStatsInstance;
    }

    // Update is called once per frame
    public void TriggerDamage()
    {
        Debug.Log("Trigger dmg");
        playerInHazard = true;
        player.TakeDamage(damage);
        StartCoroutine(DamageTicks());
    }

    IEnumerator DamageTicks() {

        while (playerInHazard)
        {
            yield return new WaitForSeconds(damageInterval);

            if (!playerInHazard) yield break;
            Debug.Log("tick dmg!");
            player.TakeDamage(damage);
        }
    }

    private void OnTriggerExit(Collider other)
    {

            if (other.gameObject.tag == "Player") {

                playerInHazard = false;
                StopCoroutine(DamageTicks());

            }
    }

}
