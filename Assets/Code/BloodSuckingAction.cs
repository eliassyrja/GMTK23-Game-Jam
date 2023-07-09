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
    private AudioSource suckingAudio;
    private bool audioPlaying;

    // Start is called before the first frame update
    void Start()
    {
        targetIsDead = false;
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
        gm = FindAnyObjectByType<GameManager>();
        suckingAudio = gm.GetComponent<AudioManager>().GetSuckingAudio();
    }


    void FixedUpdate()
    {
        if (sucking && !targetIsDead)
        {
            mosqRigidBody = mosqGameObject.GetComponent<Rigidbody2D>();
            mosqRigidBody.velocity = new Vector2(0f, 0f);

            StartCoroutine(SmoothJump(mosqGameObject.transform.position));
            playerRigidBody.velocity = new Vector2(0f, 0f);
            
			if (!audioPlaying)
			{
                suckingAudio.PlayOneShot(suckingAudio.clip);
                audioPlaying = true;
            }

            if (mosqGameObject.GetComponent<MosqHealth>().GetMosquitoHealth() <= 0 && !targetIsDead)
            {
                targetIsDead = true;
                suckingAudio.Stop();
                audioPlaying = false;
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
                mosqGameObject = collision.gameObject.transform.parent.gameObject;
                sucking = true;
            }
            else
            {
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
    private IEnumerator SmoothJump(Vector3 targetPos)
	{
        float duration = 0.1f;
        var startPos = transform.position; // current rotation
        for (float timer = 0; timer < duration; timer += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, timer/duration);
            yield return 0;
        }
    }
}
