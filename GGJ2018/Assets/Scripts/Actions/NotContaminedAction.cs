﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotContaminedAction : PlayerActions
{

    public float actionPushRange = 2f;
    public LayerMask collisionMask;
    AudioSource _audioSource;
    Animator _animator;

    override protected void Awake()
    {
        lastAction = Time.time - coolDownTime;
        coolDownTime = .5f;
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponentInChildren<Animator>();
    }

    override protected void DoAction()
    {
        _animator.SetTrigger("Attack");
        RaycastHit hitInfo;
        Physics.Raycast(transform.position, transform.forward, out hitInfo, actionPushRange);
        //push that guy
        if (hitInfo.collider != null && hitInfo.collider.gameObject != gameObject)
        {
            if (hitInfo.collider.CompareTag(Tags._players))
            {
                hitInfo.collider.GetComponent<Pusher>().Push(transform.forward);
            }
            else
            {
                Rigidbody rigidbody = hitInfo.collider.GetComponent<Rigidbody>();
                if (rigidbody != null) { 
				float range = .2f;
                Vector3 randv = new Vector3(
                Random.Range(-range, range),
                Random.Range(-range, range),
                Random.Range(-range, range)
            	);
                rigidbody.AddForce((transform.forward + randv) * 18f, ForceMode.Impulse);
            }
            _animator.SetTrigger("Attack");
        }

        Debug.Log(hitInfo.collider.name);
        }else{
			Debug.Log("Coup dans le vide");
		}

		GetComponent<Player> ().PlaySound (GetComponent<Player> ()._clack);

	}

	override protected void DoReleaseAction()
{

}

override protected void DoBehaviour()
{
}

}
