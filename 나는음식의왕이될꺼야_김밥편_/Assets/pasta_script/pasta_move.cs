using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pasta_move : MonoBehaviour
{
   public  Transform[] P_position;
    public GameObject panel;
    private bool active = true;
    private int previousIndex = -1;



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
        int randomIndex = GetRandomIndexExcludingPrevious1();
        Transform spawnPoint = P_position[randomIndex];

        gameObject.transform.position = spawnPoint.position;



        yield return new WaitForSeconds(2f);

        StartCoroutine(RandomMove());



    }

    int GetRandomIndexExcludingPrevious1()
    {
        int newIndex;
        do
        {
            newIndex = Random.Range(0, P_position.Length);
        } while (newIndex == previousIndex);
        return newIndex;
    }
}
