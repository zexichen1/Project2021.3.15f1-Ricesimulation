using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ripple : MonoBehaviour
{
    [Range(0,1f)]
    public float DrawRadius=0.2f;
    public Camera mainCamera;
    public RenderTexture PrevRT;//��һ֡
    public RenderTexture CurrentRT;//���һ֡
    public RenderTexture TempRT;//���RT
    public Shader RippleShader;//��������shader
    public Shader DrawShader;//����shader
    private Material RippleMat;
    private Material DrawMat;
    public int TextureSize=512;
    // Start is called before the first frame update
    void Start()
    {
        //get camera
        mainCamera = Camera.main.GetComponent<Camera>();
        CurrentRT = CreateRT();
        PrevRT = CreateRT();
        TempRT = CreateRT();

        DrawMat = new Material(DrawShader);
        RippleMat = new Material(RippleShader);
        GetComponent<Renderer>().material.mainTexture = CurrentRT;
    }
    public RenderTexture CreateRT()
    {
        RenderTexture rt = new RenderTexture(TextureSize, TextureSize,0,RenderTextureFormat.RFloat);
        rt.Create();
        return rt;

    
    }
    /// <summary>
    /// ����
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="radius">�뾶</param>
  
    private void DrawAt(float x, float y,float radius)
    {
        //����ԭ������ͼ
        DrawMat.SetTexture("_Sourcetex",CurrentRT);
        //���λ��
        DrawMat.SetVector("_Pos",new Vector4(x,y,radius));
        //�ύ
        Graphics.Blit(null,TempRT, DrawMat);
        //������drawrt��
        RenderTexture rt = TempRT;
        TempRT = CurrentRT;
        CurrentRT = rt;
    }
    // Update is called once per frame
    void Update()
    {
        //���߼��
        if(Input.GetMouseButton(0))
       {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;//���Ӳ�׽��cast
            if (Physics.Raycast(ray,out hit))
            {
                DrawAt(hit.textureCoord.x, hit.textureCoord.y, DrawRadius);
                //����ͼ��
            }
        }
        //��������
        RippleMat.SetTexture("_PrevRT", PrevRT);
        RippleMat.SetTexture("_CurrentRT", CurrentRT);
        Graphics.Blit(null, TempRT, RippleMat);
        //������currentRT��
        Graphics.Blit( TempRT, PrevRT);
        //����
        RenderTexture rt = PrevRT;
        PrevRT = CurrentRT;
        CurrentRT = rt;
    }
}
