using UnityEngine;

public class DustParticleControl : MonoBehaviour
{
    [SerializeField] private bool createDustOnWalk = false;
    [SerializeField] private ParticleSystem dustParticleSystem;

    public void CreateDustParticles()
    {
        if (createDustOnWalk)
        {
            dustParticleSystem.Stop();
            dustParticleSystem.Play();
        }
    }
}