using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ripple : MonoBehaviour
{
    [Range(0,1f)]
    public float DrawRadius=0.2f;
    public Camera mainCamera;
    public RenderTexture PrevRT;//上一帧
    public RenderTexture CurrentRT;//最近一帧
    public RenderTexture TempRT;//监控RT
    public Shader RippleShader;//涟漪计算shader
    public Shader DrawShader;//绘制shader
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
    /// 绘制
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="radius">半径</param>
  
    private void DrawAt(float x, float y,float radius)
    {
        //绘制原来的贴图
        DrawMat.SetTexture("_Sourcetex",CurrentRT);
        //获得位置
        DrawMat.SetVector("_Pos",new Vector4(x,y,radius));
        //提交
        Graphics.Blit(null,TempRT, DrawMat);
        //交换到drawrt上
        RenderTexture rt = TempRT;
        TempRT = CurrentRT;
        CurrentRT = rt;
    }
    // Update is called once per frame
    void Update()
    {
        //射线检测
        if(Input.GetMouseButton(0))
       {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;//涉嫌捕捉，cast
            if (Physics.Raycast(ray,out hit))
            {
                DrawAt(hit.textureCoord.x, hit.textureCoord.y, DrawRadius);
                //绘制图案
            }
        }
        //计算涟漪
        RippleMat.SetTexture("_PrevRT", PrevRT);
        RippleMat.SetTexture("_CurrentRT", CurrentRT);
        Graphics.Blit(null, TempRT, RippleMat);
        //交换到currentRT上
        Graphics.Blit( TempRT, PrevRT);
        //交换
        RenderTexture rt = PrevRT;
        PrevRT = CurrentRT;
        CurrentRT = rt;
    }
}
