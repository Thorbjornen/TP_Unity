using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VegetableThrower : MonoBehaviour

{
   
    [Tooltip("Collection of vegetables that can be thrown")] public Rigidbody[] vegetables;
    
    [Header("Throw")]
    [Range(0, 20), Tooltip("Minimum force to apply to a vegetable when throwing")] public float minThrowForce = 2;
    [Range(0, 20), Tooltip("Maximum force to apply to a vegetable when throwing")] public float maxThrowForce = 10;
    [Range(0.5f, 3), Tooltip("Time the player has to hold the button to throw at max strengh")] public float throwForceChargeTime = 1;
    public float throwForce01;
    
    [Range(0,30), Tooltip("Maximum torque to apply to a vegetable when throwing")] public float maxRandomTorque = 10;

    [Header("UI")]
    public Image chargeBarFilling;

    Vector3 lance;
    public Transform throwPoint;
    public Rigidbody InstantiateRandomVegetable()
    {
        int randomIndex = Random.Range(0, 1);
        return Instantiate(vegetables[randomIndex], transform.position, Quaternion.identity, null) ;
    }

    public void ThrowVegetable(Rigidbody vegetable, float throwForce)
    {
        //Viens de la fonction 
        Rigidbody newProjectile = vegetable;
        //Use Impulse as the force on GameObject
        Vector3 direction = throwPoint.forward;
        newProjectile.AddForce(direction * throwForce, ForceMode.Impulse);
    }
    // Update is called once per frame
    void Update()
    {
        //Charger/Langer le légume
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowVegetable( InstantiateRandomVegetable(), 5);
        }

            //Met à jour le remplissage de la barre d'UI
            chargeBarFilling.fillAmount = throwForce01;
    }
}
