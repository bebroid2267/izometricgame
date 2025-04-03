using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{
    public Dictionary<string, int> resources = new Dictionary<string, int>();
    public event Action OnResourceUpdated;

    public PlayerMoveController player;
    private bool methodCalled = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IndustryBuild>() && !methodCalled)
        {
            var industry = collision.gameObject.GetComponent<IndustryBuild>();

            if (!resources.ContainsKey(industry.TypeResource))
            {
                resources.Add(industry.TypeResource, industry.CurrentResources);
            }

            if (industry.GiveResource())
            {
                resources[industry.TypeResource] += 1;
                OnResourceUpdated?.Invoke();
            }
            methodCalled = true;
            GameManager.Instance.PopupController.ShowPopup();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        methodCalled = false;
    }

}
