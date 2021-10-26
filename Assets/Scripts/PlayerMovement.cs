using UnityEngine;

namespace Core.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] PlayerController Player;
        [SerializeField] CharacterController Controller;

        private Vector3 cameraForward;
        private Vector3 cameraRight;

        private void Update()
        {
            Movement();
        }

        private void LateUpdate()
        {
            GetCameraVectors();
        }

        private void Movement()
        {
            Vector3 move = Player.MovementDirection.x * cameraRight + Player.MovementDirection.y * cameraForward;
            move *= Player.Speed;

            Controller.Move(move * Time.deltaTime);
        }

        private void GetCameraVectors()
        {
            cameraForward = Camera.main.transform.forward;
            cameraRight = Camera.main.transform.right;
            cameraForward.y = 0;
            cameraRight.y = 0;
            cameraForward.Normalize();
            cameraRight.Normalize();
        }
    }
}