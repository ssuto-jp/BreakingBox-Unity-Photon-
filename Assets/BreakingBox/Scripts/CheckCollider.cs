using UnityEngine;

public class CheckCollider : MonoBehaviour
{

    private Animator animator;
    [SerializeField]
    private CapsuleCollider[] colliders = new CapsuleCollider[3];//左手、右手、左足のcollider

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //ステート状態によってcolliderを切り替え
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
            colliders[0].enabled = true;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
        {
            colliders[0].enabled = false;
            colliders[1].enabled = true;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack3"))
        {
            colliders[1].enabled = false;
            colliders[2].enabled = true;
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                colliders[i].enabled = false;
            }
        }
    }
}
