using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public GameObject scopeImage;
    public GameObject gunCamera;
    public Camera mainCamera;
    public float scopeFov = 15f;
    private float normalFov;

    private Animator animator;
    private bool isScoped = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isScoped = !isScoped;
            animator.SetBool("isScoped", isScoped);

            StartCoroutine(OnScoped());
        }
        else if(Input.GetMouseButtonUp(1))
        {
            UnScoped();
        }
    }

    private void UnScoped()
    {
        mainCamera.fieldOfView = normalFov;
        scopeImage.SetActive(false);
        gunCamera.SetActive(false);
        animator.SetBool("isScoped", false);
    }

    private IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(0.3f);

        scopeImage.SetActive(true);
        gunCamera.SetActive(true);

        normalFov = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopeFov;
    }
}
