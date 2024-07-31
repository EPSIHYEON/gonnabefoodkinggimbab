using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pasta_move : MonoBehaviour
{
   public  Transform[] P_position;



    void Start()
    {
        StartCoroutine(RandomMove());
    }





    IEnumerator RandomMove()
    {
        int randomIndex = Random.Range(0, P_position.Length);
        Transform spawnPoint = P_position[randomIndex];

        gameObject.transform.position = spawnPoint.position;



        yield return new WaitForSeconds(1f);

        StartCoroutine(RandomMove());



    }
}
