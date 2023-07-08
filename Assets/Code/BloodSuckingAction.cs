using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSuckingAction : MonoBehaviour
{
    [SerializeField] private float suckingSpeed;
    [SerializeField] private bool sucking = false;
    [SerializeField] private float sizeScale;

    private GameObject mosqGameObject;
    private Rigidbody2D playerRigidBody;
    private Rigidbody2D mosqRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if (sucking)
        {
            mosqRigidBody = mosqGameObject.GetComponent<Rigidbody2D>();
            mosqRigidBody.velocity = new Vector2(0f, 0f);

            gameObject.transform.position = mosqGameObject.transform.position;
            playerRigidBody.velocity = new Vector2(0f, 0f);

            if (mosqGameObject.GetComponent<MosqHealth>().GetMosquitoHealth() <= 0)
            {
                sucking = false;
                Destroy(mosqGameObject);
            } else
            {
                mosqGameObject.GetComponent<MosqHealth>().SetMosquitoHealth(suckingSpeed);
                gameObject.GetComponent<PlayerHealth>().SetPlayerHealth(suckingSpeed);

                mosqGameObject.transform.localScale -= new Vector3(suckingSpeed / sizeScale, suckingSpeed / sizeScale, suckingSpeed / sizeScale);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("SuccRadius"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("SuccyMODE ACTIVATED");
                mosqGameObject = collision.gameObject.transform.parent.gameObject;
                sucking = true;
            }
            else
            {
                Debug.Log("SuccyMODE DE ACTIVATED");
                sucking = false;
                mosqRigidBody = null;
            }
        }
    }

    public bool IsSucking()
    {
        return sucking;
    }
}
