using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    private Player player;
    private CameraController camera_;
    private Joystick joystick;
    void Start()
    {
        player = FindObjectOfType<Player>();
        if (player.startPointName != gameObject.name)
            return;

        player.transform.position = transform.position;

        camera_ = FindObjectOfType<CameraController>();
        camera_.transform.position = new Vector3(transform.position.x, transform.position.y, camera_.transform.position.z);

        joystick = FindObjectOfType<Joystick>();
        joystick.SetInitialCoordinates();
    }
}
