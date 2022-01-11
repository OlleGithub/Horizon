
using UnityEngine;
using UnityEngine.VFX;

public class Gun : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    [SerializeField] float firerate = 15f;
    float nexttimetofire;
        [SerializeField] float range = 100f;
    [SerializeField] Camera fpsCam;
    [SerializeField] VisualEffect muzzleFlash;

   [SerializeField] GameObject impactEffectGO;
   private void Update() 
   {
       if(Input.GetButtonDown("Fire1") && Time.time >= nexttimetofire)
       {
           nexttimetofire = Time.time + 1f/firerate; 
           Shoot();
       }
   }
   void Shoot()
   {
       muzzleFlash.Play();
      
       RaycastHit hit;
      if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward, out hit ,range))
      {
         Health health = hit.transform.GetComponent<Health>();
         if(health!= null)
         {
             health.TakeDamage(damage);
         }
            GameObject ImpactGO = Instantiate(impactEffectGO, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(ImpactGO, 2f);
      }

   }
}
