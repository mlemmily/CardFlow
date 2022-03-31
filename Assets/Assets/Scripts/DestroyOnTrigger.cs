using UnityEngine;

// Destroy owning GameObject if any collider with a specific tag is trespassing
public class DestroyOnTrigger : MonoBehaviour
{

    //this script is used to delete any object on collision with a player, but it's main usage is for working in tangent with secret counter
    public string m_Tag = "Player";

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == m_Tag)
            Destroy(gameObject);
    }
}
