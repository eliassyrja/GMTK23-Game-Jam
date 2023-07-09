using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Rigidbody2D rb;

    private Camera cam;
    private BloodSuckingAction bsa;
    private GameManager gm;
    private Vector2 movement;
    private Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        bsa = FindAnyObjectByType<BloodSuckingAction>();
        gm = FindAnyObjectByType<GameManager>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        if (gm.IsRunning() && !bsa.IsSucking())
        {
            movement.Normalize();
            rb.MovePosition(rb.position + movementSpeed * Time.fixedDeltaTime * movement);

            mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector2 lookDirection = mousePosition - rb.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        }
    }
}
