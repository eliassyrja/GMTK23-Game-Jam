using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float rotationSpeed = 5f;

    private GameManager gm;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(movement.x < 0)
		{
            if (movement.y < 0)
            {
                transform.eulerAngles = Vector3.forward * 135;
            }
            else if (movement.y > 0)
			{
                transform.eulerAngles = Vector3.forward * 45;
            }
            else
                transform.eulerAngles = Vector3.forward * 90;
        }
        else if (movement.x > 0)
        {
            if (movement.y < 0)
            {
                transform.eulerAngles = Vector3.forward * -135;
            }
            else if (movement.y > 0)
            {
                transform.eulerAngles = Vector3.forward * -45;
            }
            else
                transform.eulerAngles = Vector3.forward * -90;
        }
        else if (movement.y < 0)
        {
            transform.eulerAngles = Vector3.forward * 180;
        }
        else if (movement.y > 0)
        {
            transform.eulerAngles = Vector3.forward;
        }
    }

    void FixedUpdate()
    {
        if (gm.IsRunning())
        {
            movement.Normalize();
            rb.MovePosition(rb.position + movementSpeed * Time.fixedDeltaTime * movement);
            RotateInDirectionOfInput();
        }
    }

    private void RotateInDirectionOfInput()
	{
        if (movement.x == 0 && movement.y == 0)
		{
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            rb.MoveRotation(rotation);
		}
	}
}
