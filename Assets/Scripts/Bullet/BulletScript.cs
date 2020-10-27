using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private BulletAnimManagerScript animManager;
    [SerializeField] private LayerMask groundLayerMask;
    private Bullet bullet = new Bullet();


    //  Start
    void Start()
    {
        animManager.SetAnimation(BulletAnimStateEnum.Bullet_Appear);
    }


    //  Update
    private void Update()
    {
        if (!bullet.GetAnimState().Equals(BulletAnimStateEnum.Bullet_Explode))
        {
            transform.Translate(new Vector3(1, 0, 0) * bullet.GetBulletMovementSpeed() * Time.deltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D arg_collider)
    {
        if (arg_collider != null & ((1 << arg_collider.gameObject.layer) & groundLayerMask) != 0)
        {
            Debug.Log("collision 2");
            //animManager.SetAnimation(BulletAnimStateEnum.Bullet_Explode);
        }
    }


    //
    public Bullet GetBullet()
    {
        return bullet;
    }
}
