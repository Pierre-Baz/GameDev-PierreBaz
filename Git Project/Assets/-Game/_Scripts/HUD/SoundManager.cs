using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip hurtEnemy,deathEnemy,wandWoosh,chargeUp,enemyHit,magicSmite,slimeDivide,slimeSqueeze,skeletBreak,barbChew,ninjaShoot,batSqueak,playerHit,mushroomHit,mushroomDeath;
    static AudioSource audioSrc;
    
    
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        hurtEnemy = Resources.Load<AudioClip>("hurt-enemy");
        deathEnemy = Resources.Load<AudioClip>("enemy-explode");
        wandWoosh = Resources.Load<AudioClip>("wand-woosh");
        chargeUp = Resources.Load<AudioClip>("charge-up");
        enemyHit = Resources.Load<AudioClip>("enemy-hit");
        playerHit = Resources.Load<AudioClip>("player-hit");
        magicSmite = Resources.Load<AudioClip>("magic-smite");
        slimeDivide = Resources.Load<AudioClip>("slime-divide");
        slimeSqueeze = Resources.Load<AudioClip>("slime-squeeze");
        skeletBreak = Resources.Load<AudioClip>("skelet-break");
        barbChew = Resources.Load<AudioClip>("barb-chew");
        ninjaShoot = Resources.Load<AudioClip>("ninja-shoot");
        batSqueak = Resources.Load<AudioClip>("bat-squeak");
        mushroomHit = Resources.Load<AudioClip>("mushroom-hit");
        mushroomDeath = Resources.Load<AudioClip>("mushroom-death");
    }

    public static void PlaySound (string clip)
    {

        switch (clip)
        {
            case "hurtEnemy":
                audioSrc.PlayOneShot(hurtEnemy);
                break;
            case "deathEnemy":
                audioSrc.PlayOneShot(deathEnemy);
                break;
            case "wandWoosh":
                audioSrc.PlayOneShot(wandWoosh);
                break;
            case "chargeUp":
                audioSrc.PlayOneShot(chargeUp);
                break;
            case "enemyHit":
                audioSrc.PlayOneShot(enemyHit);
                break;
            case "playerHit":
                audioSrc.PlayOneShot(playerHit);
                break;
            case "magicSmite":
                audioSrc.PlayOneShot(magicSmite);
                break;
            case "slimeDivide":
                audioSrc.PlayOneShot(slimeDivide);
                break;
            case "slimeSqueeze":
                audioSrc.PlayOneShot(slimeSqueeze);
                break;
            case "skeletBreak":
                audioSrc.PlayOneShot(skeletBreak);
                break;
             case "barbChew":
                audioSrc.PlayOneShot(barbChew);
                break;
            case "ninjaShoot":
                audioSrc.PlayOneShot(ninjaShoot);
                break;
             case "batSqueak":
                audioSrc.PlayOneShot(batSqueak);
                break;
            case "mushroomHit":
                audioSrc.PlayOneShot(mushroomHit);
                break;
            case "mushroomDeath":
                audioSrc.PlayOneShot(mushroomDeath);
                break;

        }
    }



}