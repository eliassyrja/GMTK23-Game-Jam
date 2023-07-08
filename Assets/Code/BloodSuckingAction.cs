using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSuckingAction : MonoBehaviour
{
    private GameObject mosqGameObject;

    private Rigidbody2D playerRigidBody;
    private Rigidbody2D mosqRigidBody;

    [SerializeField] private bool sucking = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("SuccRadius"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                sucking = true;

                mosqGameObject = collision.gameObject.transform.parent.gameObject;

                mosqRigidBody = mosqGameObject.GetComponent<Rigidbody2D>();
                mosqRigidBody.velocity = new Vector2(0f, 0f);

                gameObject.transform.position = mosqGameObject.transform.position;
                playerRigidBody.velocity = new Vector2(0f, 0f);

                Debug.Log("SuccyMODE ACTIVATED");
            }
            else
            {
                sucking = false;
                Debug.Log("SuccyMODE DE ACTIVATED");
                mosqRigidBody = null;
            }
        }
    }

    public bool IsSucking()
    {
        return sucking;
    }
}
