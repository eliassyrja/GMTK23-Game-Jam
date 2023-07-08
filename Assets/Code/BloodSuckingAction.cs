using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodSuckingAction : MonoBehaviour
{
    [SerializeField] private float suckingSpeed;
    [SerializeField] private bool sucking = false;
    [SerializeField] private float sizeScale;
    [SerializeField] private GameObject bloodSplatter;

    private GameObject mosqGameObject;
    private Rigidbody2D playerRigidBody;
    private Rigidbody2D mosqRigidBody;
    private GameManager gm;
    private bool targetIsDead;

    // Start is called before the first frame update
    void Start()
    {
        targetIsDead = false;
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
        gm = FindAnyObjectByType<GameManager>();
    }


    void FixedUpdate()
    {
        if (sucking && !targetIsDead)
        {
            mosqRigidBody = mosqGameObject.GetComponent<Rigidbody2D>();
            mosqRigidBody.velocity = new Vector2(0f, 0f);

            gameObject.transform.position = mosqGameObject.transform.position;
            playerRigidBody.velocity = new Vector2(0f, 0f);

            if (mosqGameObject.GetComponent<MosqHealth>().GetMosquitoHealth() <= 0 && !targetIsDead)
            {
                targetIsDead = true;
                sucking = false;
                StartCoroutine(DeathAndDestroy());
                gm.ReduceMosquito();
                gm.GetComponent<AudioManager>().PlayClip("MosqDeath", gameObject.transform);
            } 
            else if (!targetIsDead)
            {
                mosqGameObject.GetComponent<MosqHealth>().SetMosquitoHealth(suckingSpeed);
                gameObject.GetComponent<PlayerHealth>().SetPlayerHealth(suckingSpeed);

                mosqGameObject.transform.localScale -= new Vector3(suckingSpeed / sizeScale, suckingSpeed / sizeScale, suckingSpeed / sizeScale);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("SuccRadius") && mosqGameObject == null)
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

    private IEnumerator DeathAndDestroy()
	{
        mosqGameObject.GetComponent<Animator>().SetTrigger("Death");
        mosqGameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        yield return new WaitForSeconds(0.4f);
        Destroy(mosqGameObject);
        targetIsDead = false;
	}
}
