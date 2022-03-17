using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    private CharacterController characterController;
    public Joystick joystick;
    private Vector3 startRotation;

    public Animator animator;
    public float moveSpeed;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        startRotation = transform.rotation.eulerAngles;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 joystickDirection = new Vector2(joystick.Horizontal, joystick.Vertical);

        if (joystickDirection.magnitude > 0.1f)
        {
            animator.SetBool("Run", true);

            float angel = Vector2.SignedAngle(Vector2.up, joystickDirection);
            var newRotation = startRotation;
            newRotation.y -= angel;
            transform.localRotation = Quaternion.Euler(newRotation);

            Vector3 moveVector = transform.forward;
            characterController.Move(moveVector * (Time.deltaTime * moveSpeed));
        }
        else animator.SetBool("Run", false);
    }


}
