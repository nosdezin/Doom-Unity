using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField]private float PlayerSpeed = 20f;
    [SerializeField]private float myGravity = -10f;
    [SerializeField]private string nome;
    private CharacterController myCC;
    private Vector3 inputVector;
    private Vector3 movementVector;

    void Start() 
    {
        myCC = GetComponent<CharacterController>();
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    void Update() 
    {
        GetInput();
        MovePlayer(); 
        cameraLook();

        if(Input.GetKeyDown(KeyCode.E))
        {
            Interagir();
        }
        
    }

    private void GetInput()
    {
        // Input.GetAxisRaw("Horizontal")
         inputVector = new Vector3(0f,0f,Input.GetAxisRaw("Vertical"));
         inputVector.Normalize();
         inputVector = transform.TransformDirection(inputVector);
         movementVector = (inputVector * PlayerSpeed) + (Vector3.up * myGravity);
    }

    private void MovePlayer()
    {
        myCC.Move(movementVector * Time.deltaTime);
    }

    private void cameraLook()
    {
        Vector3 mousePos = Input.mousePosition;
        Quaternion target = Quaternion.Euler(0, mousePos.x, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, 1);
    }

    private void Interagir()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position,transform.forward,out hit,2);
        if(hit.transform.tag == nome)
        {
            hit.transform.gameObject.GetComponent<door>().aberto = true;
        } 
    }
}
