using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankView : MonoBehaviour
{
    public PlayerState playerState;
    private TankController tankController;
    [SerializeField] private Slider healthSlider;
    private float movement;
    private float rotation;
    public MeshRenderer[] childs;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private ParticleSystem tankExplosion;
    void Start()
    {
        GameObject cam = GameObject.Find("Main Camera");
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f, 9f, -9f);
        playerState = PlayerState.ALIVE;

    }
    void Update()
    {

        if (playerState == PlayerState.ALIVE)
        {
            Movement();

            if (movement != 0)
                tankController.Move(movement, tankController.GetTankModel().movementSpeed);

            if (rotation != 0)
                tankController.Rotate(rotation, tankController.GetTankModel().rotationSpeed);
        }
        if (tankController.GetHealth() <= 0 && playerState == PlayerState.ALIVE)
        {
            playerState = PlayerState.DEAD;
            tankController.SetPlayerState(playerState);
            tankController.SetGameState(GameState.Credits);
            tankExplosion.Play();
        }

    }
    void Movement()
    {
        movement = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Horizontal");
    }

    public void SetTrankController(TankController tankController)
    {
        this.tankController = tankController;
    }

    public Rigidbody GetRigidBody()
    {
        return rb;
    }

    public void changeColor(Material color)
    {
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].material = color;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<BulletView>() != null)
        {
            tankController.TakeDamage(10);
            healthSlider.value = tankController.GetHealth();
        }
    }
}
