using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using TMPro;
using UnityEngine.SceneManagement;

public class ScenarioCouloirManager : MonoBehaviour
{
    public TextMeshProUGUI Commentaire;
    public GameObject ColliderGo;
    [SerializeField] [TextArea]
    private string _interractionText;

    public Volume v = null  ;
    public AudioSource accouphene;
    private Bloom b;
    private Vignette vg;
    private LensDistortion ld;
    private ChromaticAberration ca;
    private MotionBlur mb;
    private DepthOfField dof;

    // Start is called before the first frame update
    void Start()
    {
        if(v)
        {
            v.profile.TryGet(out b);
            v.profile.TryGet(out vg);
            v.profile.TryGet(out ld);
            v.profile.TryGet(out ca);
            v.profile.TryGet(out mb);
            v.profile.TryGet(out dof);
        }
       
        StarterAssets.FirstPersonController.setValue(4);

        Commentaire.GetComponent<TextMeshProUGUI>().text = _interractionText.ToString();
        Commentaire.enabled = false;
        StartCoroutine(FirstCommentaire());
    }

    private IEnumerator FirstCommentaire()
    {
        yield return new WaitForSeconds(3f);
        Commentaire.enabled = true;
        
        Debug.Log(Commentaire.GetComponent<TextMeshProUGUI>().text);
        yield return new WaitForSeconds(5f);
        Commentaire.enabled = false;

    }

    private IEnumerator SecondCommentaire()
    {
        Commentaire.enabled = true;
        yield return new WaitForSeconds(2);
        Debug.Log("Start Voies");
        yield return new WaitForSeconds(2);
        Commentaire.enabled = false;
        ColliderGo.SetActive(false);
    }

    private IEnumerator ChangementScene()
    {
        yield return new WaitForSeconds(3);
        accouphene.Stop();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Level1");
        StarterAssets.FirstPersonController.setValue(4);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ColliderGo.name == "SecondCommentaireCollider")
        {
            Commentaire.GetComponent<TextMeshProUGUI>().text = _interractionText.ToString();
            StartCoroutine(SecondCommentaire());
        } else if (ColliderGo.name == "SphereEffectCollider")
        {
            accouphene.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (ColliderGo.name == "SphereEffectCollider")
        {
            var distanceVector = (float)(-(other.transform.position.x - transform.position.x) / 14.5);
            ld.intensity.value = (float)(-(1 - distanceVector) / 2 + 0.3);
            vg.intensity.value = (float)((1 - distanceVector) / 2 + 0.25);
            ca.intensity.value = (float)((1-distanceVector)/5 + 0.8);
            b.intensity.value = (float)((1-distanceVector)*100);
            mb.intensity.value = 1;
            dof.active = true;
            dof.gaussianStart.value = distanceVector*5;
            accouphene.volume = (1 - distanceVector)* 2;
            StarterAssets.FirstPersonController.setValue(distanceVector*4);



            //Fin des effets et changement de scene
            if (distanceVector < 0.3 && distanceVector > 0.01)
            {
                Fade.setFadeOut(true);
                StartCoroutine(ChangementScene());
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(ColliderGo.name == "SphereEffectCollider")
        {
            dof.active = false;
            ld.intensity.value = 0;
            vg.intensity.value = 0;
            ca.intensity.value = 0;
            mb.intensity.value = 0;
            b.intensity.value = 1;

        }
    }
}
