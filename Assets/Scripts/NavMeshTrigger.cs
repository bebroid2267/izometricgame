using UnityEngine;
using UnityEngine.AI;

public class NavMeshTrigger : MonoBehaviour
{
    // Публичная переменная для хранения ссылки на NavMeshAgent персонажа.
    // Если у вас несколько персонажей, можно сделать эту переменную списком.
    public NavMeshAgent playerAgent;

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, является ли объект, вошедший в триггер, персонажем.
        if (other.GetComponent<NavMeshAgent>() == playerAgent)
        {
            // Отключаем NavMeshAgent, чтобы остановить движение.
            playerAgent.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Проверяем, является ли объект, вышедший из триггера, персонажем.
        if (other.GetComponent<NavMeshAgent>() == playerAgent)
        {
            // Включаем NavMeshAgent, чтобы персонаж мог снова двигаться.
            playerAgent.enabled = true;
        }
    }
}
