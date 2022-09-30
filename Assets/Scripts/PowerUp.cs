using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUp : MonoBehaviour
{
    //public GameEnding gameEnding;
    public GameObject player;
    public GameObject specialEffect;
    public bool invincible = false;
    public GameObject [] ghosts;
    public TextMeshProUGUI pickupText;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player) //start timer 15 seconds, power-up - get rid of gameobject
        {
            pickupText.SetText("You're Now Invincible For 15 Seconds!");
            invincible = true;
            Power();

        }
    }

    void Power()
    {
        if (invincible)
        {
            StartCoroutine(PowerUpper());
        }
    }

    IEnumerator PowerUpper(){

        Instantiate(specialEffect, transform.position, transform.rotation);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        setInvincible(true);
        pickupText.SetText("You're Now Invincible For 15 Seconds!");
        yield return new WaitForSeconds(2);
        pickupText.SetText("You're Invincible!");
        

        foreach(GameObject ghost in ghosts)
        {
            ghost.GetComponent<Rigidbody>().isKinematic = false;
        }

        yield return new WaitForSeconds(15);
         
        foreach(GameObject ghost in ghosts)
        {
            ghost.GetComponent<Rigidbody>().isKinematic = true;
        }
        setInvincible(false);
        pickupText.SetText("You're No Longer Invincible!");
        Destroy(gameObject);
        yield return new WaitForSeconds(3);
        pickupText.text = "";
    }

    public void setInvincible(bool invinsiblility)
    {
        invincible = invinsiblility;
        
    }
}
