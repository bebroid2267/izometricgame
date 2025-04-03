using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using static UnityEngine.GraphicsBuffer;

public class IndustryController : MonoBehaviour
{
    public List<IndustryBuild> industrys;
    public Vector3 offset = new Vector3(0, 2, 0);
    public float distanceOffset = 2.0f; // Смещение ближе к камере


    private void Start()
    {
        CreateTextsResources();
    }

    private void Update()
    {
        foreach (var industry in industrys)
        {
            industry.GetComponentInChildren<TextMeshPro>().text = $"{industry.Name} \n Ресурс: {industry.TypeResource}  \n {industry.CurrentResources} / {industry.CountResources}";
        }
    }

    private void CreateTextsResources()
    {
        foreach (var industry in industrys)
        {
            if (industry.transform)
            {
                GameObject objectText = new GameObject();
                objectText.AddComponent<TextMeshPro>();
                objectText.transform.parent = industry.transform;

                var textMeshPro = objectText.GetComponent<TextMeshPro>();

                Vector3 worldPosition = industry.transform.position + offset;

                Vector3 directionToCamera = (Camera.main.transform.position - worldPosition).normalized;
                worldPosition -= directionToCamera * distanceOffset;


                textMeshPro.fontSize = 5;
                textMeshPro.color = Color.black;
                textMeshPro.transform.position = worldPosition;
                textMeshPro.transform.forward = Camera.main.transform.forward;
                textMeshPro.text = $"{industry.Name}  Ресурс: {industry.TypeResource}  || {industry.CurrentResources} / {industry.CountResources}";
            }
        }
    }
}
