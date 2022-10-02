using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromotedNotificationController : EventListener<ELevelChanged>
{
    [SerializeField] private GameObject promotedNotification;


    private void Awake()
    {
        promotedNotification.SetActive(false);
    }

    public override void OnEvent(ELevelChanged e)
    {
        promotedNotification.SetActive(true);
    }
}
