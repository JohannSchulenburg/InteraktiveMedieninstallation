using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleAttraction : MonoBehaviour
{
    public Transform target;
    //public float movementSpeed;
    public float strength;
    private ParticleSystem system;

    public LineManager lm;


    private static ParticleSystem.Particle[] particles = new ParticleSystem.Particle[1000];

    void Update()
    {
        try
        {
            lm = GameObject.Find("LineCreator").GetComponent<LineManager>();
        }
        catch 
        { 
            Debug.Log("LM Missing");
        }
        if (system == null) system = GetComponent<ParticleSystem>();
        if (lm != null)
        {
            bool targetFound = false;
            foreach (Pair pair in lm.pairs)
            {   
                
                //Debug.Log(pair.pairId+", "+gameObject.name+", "+pair.point1.name);

                if (gameObject.name.Equals(pair.point1.name) && (pair.point1.GetComponent<MeshRenderer>().enabled && pair.point2.GetComponent<MeshRenderer>().enabled))
                {
                    target = pair.point2.transform;
                    targetFound = true;
                }
                if(targetFound == false){
                    target = null;
                }
            }
            if (targetFound == true)
            {
                if(system.isPaused) system.Play();
    
                var count = system.GetParticles(particles);

                for (int i = 0; i < count; i++)
                {
                    var particle = particles[i];

                    float distance = Vector3.Distance(target.position, particle.position);

                    if (distance > 0.1f)
                    {
                        particle.position = Vector3.Lerp(particle.position, target.localPosition, Time.deltaTime * strength);
                        //particle.position = Vector3.MoveTowards(particle.position, target.position, strength);
                        particles[i] = particle;
                    }
                }
                system.SetParticles(particles, count);
            }
            else
            {
                if(system.isPlaying){
                    system.Clear();
                    system.Pause();
                }
            }
        }
    }
}