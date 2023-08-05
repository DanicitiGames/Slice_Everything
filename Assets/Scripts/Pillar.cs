using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Knife"))
        {
            other.GetComponent<Knife>().Lose();
            GameObject.Find("GameManager").GetComponent<GameManager>().Lose();
        }
    }
}
