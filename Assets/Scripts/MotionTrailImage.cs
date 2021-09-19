using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionTrailImage : MonoBehaviour
{
    Material m;
    MeshRenderer mr = null;
    MeshFilter mf = null;
    Coroutine fadeoutCoroutine = null;
    float originAlpha = 1f;

    Shader TransparentShader;
    private string ShaderColorParamName = "_Color";

    public Mesh mesh { get { return mf.mesh; } }
	private void Awake()
	{
        TransparentShader = Shader.Find("Legacy Shaders/Transparent/Diffuse");
    }
	public void InitMotionTrailImage(Material material)
    {
        mr = gameObject.AddComponent<MeshRenderer>();

        m = new Material(material);
        mr.material = m;
        mf = gameObject.AddComponent<MeshFilter>();
        gameObject.SetActive(false);


        mr.material.shader = TransparentShader;
    }

    public void CreateMotionTrailImage(Vector3 position, Quaternion rot, float time)
    {
        if (fadeoutCoroutine == null)
        {
            gameObject.SetActive(true);
            gameObject.transform.position = position;
            gameObject.transform.rotation = rot;

            mf.mesh = mesh;
            fadeoutCoroutine = StartCoroutine(FadeOut(time));
        }
    }

    IEnumerator FadeOut(float time)
    {
        while (time > 0f)
        {
            time -= Time.deltaTime;
            //m.color = new Color(m.color.r, m.color.g, m.color.b, originAlpha * time);
            mr.material.SetColor(ShaderColorParamName, new Color(m.color.r, m.color.g, m.color.b, originAlpha * time));
            yield return null;
        }

        gameObject.SetActive(false);
        fadeoutCoroutine = null;
    }
}