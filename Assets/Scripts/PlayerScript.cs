using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public HealthScript health;

    public delegate void AFunc();

    public AFunc OnDed;

    protected void OnEnable()
    {
        health.OnHealthDepleted += OnMyHealthDepleted;    
    }

    protected void OnDisable()
    {
        health.OnHealthDepleted -= OnMyHealthDepleted;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //This listens to health depleted
    protected virtual void OnMyHealthDepleted() 
    {
        //Call on ded event
        OnDed?.Invoke();
    }

}
