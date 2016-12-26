using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour
{

    private float currentSpeed;
    private GameObject currentTarget;
    private Animator animator;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        // coding the rigidbody on the person
        Rigidbody2D myRigidbody = gameObject.AddComponent<Rigidbody2D>();
        myRigidbody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!currentTarget)
        {
            animator.SetBool("IsAttacking", false);
        }
        // moves object to the left
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    // Called from the animator at the time of actual blow
    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();
            if (health)
            {
                health.DealDamage(damage);
            }
        }
    }

    public void Attack (GameObject obj)
    {
        currentTarget = obj;
    }
}
