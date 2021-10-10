using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFreezeState : MonoBehaviour
{
    [SerializeField] private float freezeBarHealth;
    private float freezeBarHealth_initial;
    public float freezeTimer;

    private bool isFreezed;
    void Start()
    {
        freezeBarHealth_initial = freezeBarHealth;
        freezeTimer = freezeBarHealth;
    }

    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    if(other.gameObject.tag == "BeamHitPoint")
    //    {
    //        freezeTimer -= Time.deltaTime;
    //    }
    //}
    void Update()
    {
        if(freezeTimer <= 0)
        {
            freezeTimer = 0;
        }
        if (freezeTimer <= 0 && !isFreezed) {
            Freeze();
            isFreezed = true;
        }
    }

    void Freeze()
    {
        int seed = Random.Range(0, 2);

        if (gameObject.GetComponent<ObjectID>().ID == 1) // == wall
        {
            if (seed == 0)
                AudioManager.instance.Play(SoundList.PlayerBulletHit1);
            else if (seed == 1)
                AudioManager.instance.Play(SoundList.PlayerBulletHit2);
            
            gameObject.GetComponent<ObjectID>().attractable = true;
            gameObject.tag = "FortressObject";
        }
        if (gameObject.GetComponent<ObjectID>().ID == 2) // == enemy
        {
            if (seed == 0)
                AudioManager.instance.Play(SoundList.PlayerBulletHit1);
            else if (seed == 1)
                AudioManager.instance.Play(SoundList.PlayerBulletHit2);

            gameObject.GetComponent<ObjectID>().attractable = true;
            gameObject.tag = "FortressObject";
            gameObject.GetComponent<EnemyBehaviour>().enabled = false;
            gameObject.GetComponent<EnemyPath>().enabled = false;
        }
    }

    public float GetFreezeBarHealth()
    {
        return freezeBarHealth;
    }
    public float TakeFreezeDamage(float damage)
    {
        freezeTimer -= damage;
        return damage;
    }
}
