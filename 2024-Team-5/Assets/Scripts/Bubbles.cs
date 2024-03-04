using UnityEngine;

public class Bubbles : MonoBehaviour
{
    [SerializeField] private GameObject starPrefab;
    [SerializeField] private float burstForce;
    [SerializeField] private ParticleSystem _particleSystem;
    private ParticleSystem.Particle[] _particles;
    public GameObject burst;
    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    public void Burst()
    {
        var particles = new ParticleSystem.Particle[_particleSystem.main.maxParticles];
        var currentAmount = _particleSystem.GetParticles(particles);

        for (int i = 0; i < currentAmount; i++)
        {
            var star = Instantiate(starPrefab, particles[i].position, Quaternion.identity);
            var burst = Instantiate(this.burst, particles[i].position, Quaternion.identity);
            burst.transform.localScale *= (particles[i].startSize / 4);
            star.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f,1f), 1) * burstForce, ForceMode2D.Impulse );
        }
        
        _particleSystem.Clear();
        _particleSystem.Stop();
    }
}
