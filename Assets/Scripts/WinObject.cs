using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinObject : MonoBehaviour
{
    public Canvas scoreCanvas;
    public int multiplier = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Knife"))
        {

            Destroy(this);
            other.GetComponent<Knife>().SetKnifeStatus(false);
            other.GetComponent<Knife>().GetComponent<Rigidbody>().isKinematic = true;
            
            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            int value = gameManager.GetThisGameCoins() * multiplier;
            gameManager.AddScore(value, other.transform.position);
            gameManager.Win();

            Canvas canva = Instantiate(scoreCanvas, other.gameObject.transform.position, LookAtCamera());
            canva.GetComponentInChildren<Text>().text = "+"+value.ToString();
        }
    }
    private Quaternion LookAtCamera()
    {
        return Quaternion.LookRotation(transform.position - Camera.main.transform.position);
    }
}
