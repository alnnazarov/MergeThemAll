using UnityEngine;

[RequireComponent(typeof(CreatureController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool canMoving = false;
    [SerializeField] private float moveSpeed = 2.5f;

    void FixedUpdate()
    {
        if (canMoving)
        {
            HandleMovement();
        }
    }

    public void EnableMoving()
    {
        canMoving = true;
    }
    
    private void OnTriggerEnter2D(Collider2D  other)
    {
        Debug.LogWarning("Test Collision");
    }

    private void HandleMovement()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0.0f);

        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
    }
}