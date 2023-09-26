using UnityEngine;

public class SpritePositionOrder : MonoBehaviour {

    // -- Variables --
    [SerializeField] private bool m_runOnce;
    [SerializeField] private float m_offsetY;
    private SpriteRenderer m_sprite;
    
    // -- Built-In Methods --
    private void Awake() {
        m_sprite = GetComponentInChildren<SpriteRenderer>();
    } // Awake ()

    private void LateUpdate() {
        var precisionMultiplier = 5F;
        m_sprite.sortingOrder = (int) (-(transform.position.y + m_offsetY) * precisionMultiplier);
        if(m_runOnce) Destroy(this);
    } // LateUpdate ()

} // Class SpritePositionOrder