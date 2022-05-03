using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AcidSpout : MonoBehaviour
{
    public float spoutTimeStop;
    public float spoutTimeEmit;
    public int damageToGive;
    [HideInInspector] public bool canEmit;
    [HideInInspector] ParticleSystem acidParticles;

    private void Awake()
    {
        acidParticles = GetComponentInChildren<ParticleSystem>();
    }

    private void Start()
    {
        StartCoroutine(SpoutRateBuffer());
    }

    private void Update()
    {
        if (canEmit)
        {
            EmitAcid();
        }
    }

    private IEnumerator SpoutRateBuffer()
    {
        canEmit = false;
        yield return new WaitForSeconds(spoutTimeStop);
        canEmit = true;
        yield return new WaitForSeconds(spoutTimeEmit);
        StartCoroutine(SpoutRateBuffer());
    }

    //emit function
    private void EmitAcid()
    {
        acidParticles.Emit(1);
    }
}
