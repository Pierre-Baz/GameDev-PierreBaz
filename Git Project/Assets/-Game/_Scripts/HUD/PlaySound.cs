using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    #region Sound Methods

    public void SlimeDivide()
    {
        SoundManager.PlaySound("slimeDivide");
    }

    public void SlimeSqueeze()
    {
        SoundManager.PlaySound("slimeSqueeze");
    }

    public void SkeletBreak()
    {
        SoundManager.PlaySound("skeletBreak");
    }

    public void BarbChew()
    {
        SoundManager.PlaySound("barbChew");
    }

    public void NinjaShoot()
    {
        SoundManager.PlaySound("ninjaShoot");
    }

    public void BatSqueak()
    {
        SoundManager.PlaySound("batSqueak");
    }

    public void mushroomHit(){
        SoundManager.PlaySound("mushroomHit");
    }

    public void mushroomDeath(){
        SoundManager.PlaySound("mushroomDeath");
    }

    #endregion
}
