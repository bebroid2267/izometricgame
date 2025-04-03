using System.Collections;
using UnityEngine;

public class IndustryBuild : MonoBehaviour, IIndustry
{
    public string Name;
    public int CountResources = 5;
    public int CurrentResources = 0;
    

    public string TypeResource;

    void Start()
    {
        StartCoroutine(CreateResourceCoroutine());
    }

    void Update()
    {
        
    }

    IEnumerator CreateResourceCoroutine()
    {
        while (CurrentResources < CountResources)
        {
            CreateResource();
            yield return new WaitForSeconds(5f);
        }
    }

    public void CreateResource()
    {
        CurrentResources++;
    }

    public bool GiveResource()
    {
        if (CurrentResources != 0)
        {
            CurrentResources--;
            return true;
        }
        return false;
    }

}
