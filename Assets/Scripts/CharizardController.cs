using UnityEngine;

public class CharizardController : MonoBehaviour
{
    [SerializeField] private float speed;

    private FixedJoystick fixedJoystick;
    private Rigidbody rigidBody;
    private Animator animationController;
    private bool isFlying = false;

    private void OnEnable()
    {
        fixedJoystick = FindFirstObjectByType<FixedJoystick>();
        rigidBody = gameObject.GetComponent<Rigidbody>();
        animationController = gameObject.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float xVal = fixedJoystick.Horizontal;
        float yval = fixedJoystick.Vertical;
        Vector3 movement = new Vector3(xVal, 0, yval);
        rigidBody.linearVelocity = movement * speed;
        if (xVal != 0 && yval != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xVal, yval) * Mathf.Rad2Deg, transform.eulerAngles.z);
            if (!isFlying)
            {
                animationController.SetBool("flyParam", true);
                isFlying = true;
            }
        }
        else
        {
            if (isFlying)
            {
                animationController.SetBool("flyParam", false);
                isFlying = false;
            }
        }
    }
}