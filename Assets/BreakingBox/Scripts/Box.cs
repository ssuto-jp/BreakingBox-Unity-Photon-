using UnityEngine;

public class Box : MonoBehaviour
{
    public int Box_Hp { get; private set; } = 30;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Hit")
        {
            Box_Hp -= 10;
            if (Box_Hp == 0)
            {
                BreakBox();
            }
        }
    }

    private void BreakBox()
    {
        Destroy(gameObject);
        GameManagerScript.BoxCount -= 1;
    }
}
