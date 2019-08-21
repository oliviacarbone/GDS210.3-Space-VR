using UnityEngine;

public class HandController : MonoBehaviour
{
    private Animator clawAnim;

    [SerializeField]
    private string animationName;

    private void Awake()
    {
        clawAnim = GetComponent<Animator>();
    }

    /// <summary>
    /// Pass a float between 0 and 0.99 to play the animation from that state, use the axis input from the triggers. MAKE SURE TO CLAMP IT!!;
    /// </summary>
    /// <param name="t"></param>
    public void ScaleClawAnimation(float t)
    {
        clawAnim.speed = 1;
        clawAnim.Play(animationName, -1, t);
        clawAnim.speed = 0;
    }
}
