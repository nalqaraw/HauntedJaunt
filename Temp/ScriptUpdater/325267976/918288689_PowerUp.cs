using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //public GameEnding gameEnding;
    public GameObject player;
    public GameObject specialEffect;
    public bool invisible = false;
    float m_Timer; //render void start showseconds
    public GameObject [] ghosts;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player) //start timer 15 seconds, power-up - get rid of gameobject
        {

            m_Timer = 0f;
            invisible = true;
            Power();

        }
    }

    void Power()
    {
        if (invisible)
        {
            StartCoroutine(PowerUpper());
        }
    }

    IEnumerator PowerUpper(){

        Instantiate(specialEffect, transform.position, transform.rotation);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        setInvisible(true);
        //player.GetComponent<Renderer> ().material.color.a = 0.5f;
        player.GetComponent<Renderer>().material.ChangeAlpha( 0.5f );


        foreach(GameObject ghost in ghosts)
        {
            ghost.GetComponent<Rigidbody>().isKinematic = false;
        }

        yield return new WaitForSeconds(15);

        foreach(GameObject ghost in ghosts)
        {
            ghost.GetComponent<Rigidbody>().isKinematic = true;
        }
        setInvisible(false);
        //player.GetComponent<Renderer> ().material.color.a = 1f;
        Destroy(gameObject);
    
    }

    public void setInvisible(bool invisiblility)
    {
        invisible = invisiblility;
    }
}
