using UnityEngine;

public class CameraControl: MonoBehaviour
{
    public float m_DampTime = 0.2f;         // Approximate time for the camera to refocus.

    public Transform m_target;          // The target that the camera follows.

    private Vector3 m_MoveVelocity;     // The velocity of the camera movement.
    private Vector3 m_DesiredPosition;  // The position the camera is moving towards.

    private void Awake()
    { 
        // Remove to manually add a target to follow instead.
        m_target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    { 
        m_DesiredPosition = m_target.position;
        transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity,
            m_DampTime);
    }
}
