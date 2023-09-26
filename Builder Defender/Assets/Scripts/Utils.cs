using UnityEngine;

public static class Utils {

    // -- Variables --
    private static Camera m_mainCamera;
    
    // -- Customs Methods --
    public static Vector3 GetMouseWorldPosition () {
        if (m_mainCamera == null) m_mainCamera = Camera.main;
        var mouseWorldPosition = m_mainCamera.ScreenToWorldPoint (Input.mousePosition);
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    } // GetMouseWorldPosition

} // Class Utils