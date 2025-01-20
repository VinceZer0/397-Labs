using UnityEngine;

namespace Platformer397
{
    public class PlayerController : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created

        [SerializeField] private InputReader input;

        private void Start ()
        {
            Debug.Log("[Start]");
            input.EnablePlayerActoions();

        }

        private void OnEnable()
        {
            input.Move += GetMovement;
        }

        private void OnDisable()
        {
            input.Move -= GetMovement;
        }

        private void Destroy()
        {
            Debug.Log("[Destroy]");
        }

        private void GetMovement(Vector2 move)
        {
            Debug.Log("Input Working" + move);
        }
    }


}
