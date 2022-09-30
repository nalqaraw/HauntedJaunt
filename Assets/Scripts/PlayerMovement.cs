using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20f;

    Animator m_Anim;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotatation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
            m_Anim = GetComponent<Animator> ();
            m_Rigidbody = GetComponent<Rigidbody> ();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        
        m_Anim.SetBool("IsWalking", isWalking);

        Vector3 fwd = Vector3.RotateTowards (transform.forward, m_Movement, speed * Time.deltaTime, 0f);
        m_Rotatation = Quaternion.LookRotation (fwd);
    }

    void  OnAnimatorMove ()
    {
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * m_Anim.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation (m_Rotatation);
    }
}
