using UnityEngine;
using Cinemachine;

public class Teleport : MonoBehaviour
{
    public Transform Capsule, cam, player;
    Vector3 _CapsulePos, _PlayerPos;
    void Awake()
    {
        Lvl2.SetActive(false);
        _CapsulePos = Capsule.position;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        col.transform.SetPositionAndRotation(_CapsulePos, Quaternion.identity);
        AdvanceLevel();
        _PlayerPos = player.position;
        cam.transform.SetPositionAndRotation(_PlayerPos, Quaternion.identity);

    }

    public GameObject Lvl1, Lvl2;
    void AdvanceLevel()
    {
        Lvl1.SetActive(false);
        Lvl2.SetActive(true);  
    }
}
