using UnityEngine;

public class Bubbles : MonoBehaviour
{
    [SerializeField] private GameObject starPrefab;
    [SerializeField] private float burstForce;
    private ParticleSystem _particleSystem;
    private ParticleSystem.Particle[] _particles; 
    
    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    public void Burst()
    {
        _particleSystem.GetParticles(_particles);

        foreach (var particle in _particles)
        {
            var star = Instantiate(starPrefab, particle.position, Quaternion.identity);
            star.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f,1f), 1) * burstForce, ForceMode2D.Impulse );
        }
        
        _particleSystem.Stop();
    }
}
