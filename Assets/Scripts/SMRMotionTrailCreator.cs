using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMRMotionTrailCreator : MonoBehaviour
{
    public Material trailImageMaterial;

    SkinnedMeshRenderer smr;
    MotionTrailImage[] motionTrailImage;

    int trailImageCount;
    int currentTrailImageIndex;
    float remainTrailImageTime;
    float createTrailImagedelay;
    Coroutine createTrailImageCoroutine = null;

    bool isCreating = false;

    public void Setup(SkinnedMeshRenderer smr, int maxNumber, float remainTime)
    {
        this.smr = smr;
        trailImageCount = maxNumber;
        remainTrailImageTime = remainTime;
        createTrailImagedelay = remainTrailImageTime / (float)trailImageCount + 0.05f;
        CreateTrailImages();
    }

    void CreateTrailImages()
    {
        motionTrailImage = new MotionTrailImage[trailImageCount];
        for (int i = 0; i < motionTrailImage.Length; ++i)
        {
            GameObject newObj = new GameObject();
            motionTrailImage[i] = newObj.AddComponent<MotionTrailImage>();
            motionTrailImage[i].InitMotionTrailImage(trailImageMaterial);
        }
    }

    public void Create(bool flag)
    {
        this.isCreating = flag;
        if (flag)
        {
            if (createTrailImageCoroutine == null)
                createTrailImageCoroutine = StartCoroutine(CreateTrailImageCoroution());
        }
    }

    IEnumerator CreateTrailImageCoroution()
    {
        float t = 0f;
        while (isCreating)
        {
            t += Time.deltaTime;

            if (t >= createTrailImagedelay)
            {
                smr.BakeMesh(motionTrailImage[currentTrailImageIndex].mesh);
                motionTrailImage[currentTrailImageIndex].CreateMotionTrailImage(transform.position, transform.rotation, remainTrailImageTime);
                currentTrailImageIndex = (currentTrailImageIndex + 1) % trailImageCount;
                t -= createTrailImagedelay;
            }
            yield return null;
        }

        createTrailImageCoroutine = null;
    }
}
