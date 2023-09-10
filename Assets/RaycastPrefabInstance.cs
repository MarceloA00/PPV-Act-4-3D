using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastPrefabInstance : MonoBehaviour
{
    private Controls controls;
    public GameObject sphere;
    public GameObject sphereY;

    private void Awake() {
        controls = new Controls();
    }

    private void OnEnable() {
        controls.Player.MouseRaycast.performed += CastRay;
        controls.Player.MouseRaycastY.performed += CastRayY;
        controls.Player.Enable();
    }

    private void OnDisable() {
        controls.Player.MouseRaycast.performed -= CastRay;
    }

    private void CastRay(InputAction.CallbackContext context) {
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            Instantiate(sphere, hit.point, Quaternion.identity);
        }
    }

    private void CastRayY(InputAction.CallbackContext context) {
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            Instantiate(sphereY, hit.point, Quaternion.identity);
        }
    }
}
