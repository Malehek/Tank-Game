using UnityEngine;

public class TankAim : MonoBehaviour
{
    public Transform m_Turret; // Reference to the turret transform

    private LayerMask m_LayerMask; // Layer mask to filter raycast hits

    private void Awake()
    { 
        m_LayerMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, m_LayerMask))
        { 
            m_Turret.LookAt(hit.point);
        }
    }
}
