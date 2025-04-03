using UnityEngine;
using UnityEngine.AI;

public class NavMeshTrigger : MonoBehaviour
{
    // ��������� ���������� ��� �������� ������ �� NavMeshAgent ���������.
    // ���� � ��� ��������� ����������, ����� ������� ��� ���������� �������.
    public NavMeshAgent playerAgent;

    private void OnTriggerEnter(Collider other)
    {
        // ���������, �������� �� ������, �������� � �������, ����������.
        if (other.GetComponent<NavMeshAgent>() == playerAgent)
        {
            // ��������� NavMeshAgent, ����� ���������� ��������.
            playerAgent.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // ���������, �������� �� ������, �������� �� ��������, ����������.
        if (other.GetComponent<NavMeshAgent>() == playerAgent)
        {
            // �������� NavMeshAgent, ����� �������� ��� ����� ���������.
            playerAgent.enabled = true;
        }
    }
}
