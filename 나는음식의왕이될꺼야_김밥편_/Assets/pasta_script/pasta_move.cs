using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pasta_move : MonoBehaviour
{
   public  Transform[] P_position;
    public GameObject panel;
    private bool active = true;



    void Start()
    {
        if (active == true && !panel.activeSelf)
        {
            StartCoroutine(RandomMove());
        }

        if (panel.activeSelf) {
            active = false;
        }
    }





    IEnumerator RandomMove()
    {
        int randomIndex = Random.Range(0, P_position.Length);
        Transform spawnPoint = P_position[randomIndex];

        gameObject.transform.position = spawnPoint.position;



        yield return new WaitForSeconds(2f);

        StartCoroutine(RandomMove());



    }
}
