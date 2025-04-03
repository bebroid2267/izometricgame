using UnityEngine;

public class PlayerAnimtaionCon : MonoBehaviour
{
    public Animator anim;
    public float t;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Grounded", true);
    }
    public void Run(float speed, bool status)
    {
        if (status == true)
        {
                t += Time.deltaTime;
                if (t >= 2) { t = 2; }
                anim.SetFloat("MoveSpeed", 10f);
        }
        else
        {
            t = 0;
            anim.SetFloat("MoveSpeed", 0f);
        }
    }

    public void GroundWalk()
    {
        anim.SetFloat("MoveSpeed", 0f);
    }
}
