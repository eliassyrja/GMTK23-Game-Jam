using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosqMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float directionChangeTime = 1f;
    private Rigidbody2D rb;
    private float direction;
    private Vector3 lastVelocity;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(ChangeDirection());
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }
    private IEnumerator ChangeDirection()
	{
        direction = Random.Range(-90, 90);
        StartCoroutine(RotateAndApplyForce(Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + direction)));
        yield return new WaitForSeconds(directionChangeTime);
        StartCoroutine(ChangeDirection());
    }
	private void OnCollisionEnter2D(Collision2D collision)
	{
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
        rb.velocity = direction * Mathf.Max(speed, 0f);
	}
    private IEnumerator RotateAndApplyForce(Quaternion direction)
	{
        float duration = 0.3f;
        var startRot = transform.rotation; // current rotation
        for (float timer = 0; timer < duration; timer += Time.deltaTime)
        {
            transform.rotation = Quaternion.Slerp(startRot, direction, timer / duration);
            yield return 0;
        }
        rb.AddRelativeForce(new Vector2(0, 1 * speed));
    }
}
