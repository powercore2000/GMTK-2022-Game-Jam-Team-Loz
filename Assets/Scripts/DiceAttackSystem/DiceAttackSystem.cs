using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DiceThrowing
{
    public class DiceAttackSystem : MonoBehaviour
    {
        [SerializeField]
        Transform spawnPoint;

        [SerializeField]
        GameObject diceTossPrefab;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetButtonDown("Shoot"))
            {
                TossDice();
            }
        }

        public void TossDice() {


            GameObject spawnDice = Instantiate(diceTossPrefab, spawnPoint.position, spawnPoint.rotation);
            //spawnDice.GetComponent<Rigidbody>().ve
        }



    }
}