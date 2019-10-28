using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField]
    int blockStartHP = 3;
    
    [SerializeField]
    int blockHP;

    [SerializeField]
    Sprite BlockDamageSpriteOne;

    [SerializeField]
    Sprite BlockDamageSpriteTwo;

    [SerializeField]
    GameObject blockParticleFX;
    
	// Use this for initialization
	void Start () { 
        blockHP = blockStartHP;
        FindObjectOfType<GameStatus>().CountBreakableBlocks();
	}
	
	// Update is called once per frame
	void Update () {
	    if (blockHP <= 0)
        {
            FindObjectOfType<GameStatus>().DestroyBreakableBlock();
            TriggerParticleVFX();
            Destroy(gameObject);
        }
        else if (blockHP == 1)
        {
            if (BlockDamageSpriteOne != null)
            {
                GetComponent<SpriteRenderer>().sprite = BlockDamageSpriteOne;
            }
        }
        else if (blockHP == 2)
        {
            if (BlockDamageSpriteTwo != null)
            {
                GetComponent<SpriteRenderer>().sprite = BlockDamageSpriteTwo;
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            blockHP -= 1;
        }
    }

    private void TriggerParticleVFX()
    {
        GameObject sparkles = Instantiate(blockParticleFX,transform.position,transform.rotation);
        Destroy(sparkles, 1f);
    }
}
