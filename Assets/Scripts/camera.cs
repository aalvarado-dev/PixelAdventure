using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform player; //variable que guarda el transform del jugador a seguir por la camara

    private void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z); //asigno a la posicion de la camara la posicion del jugador
    }

}
