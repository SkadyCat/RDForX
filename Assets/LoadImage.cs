using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadImage : ObViewerTemplates {


    public static LoadImage Instance;

    public void Awake()
    {
        Instance = this;
    }

    public string opstrArg;
    // Use this for initialization
    void Start () {
       // StartCoroutine(loadSprite("C:\\Users\\HP\\Desktop\\相册\\合照\\IMG_7438.jpg"));

        addViewer(FolderReader.Instance);
        addViewer(OP.Instance);
      
	}
    public Image img;
	// Update is called once per frame
	void Update () {
		
	}
   

    public void load(string path)
    {

        StartCoroutine(loadSprite(path));


    }

    public int code = 0;
    public void load(string path,int opCode)
    {
        this.code = opCode;
        StartCoroutine(loadSprite(path));


    }
    public void load(string path, int opCode,string strOpArg)
    {
        this.code = opCode;
        this.opstrArg = strOpArg;
        StartCoroutine(loadSprite(path));


    }

    public Sprite sp;
    public RawImage rg;
    IEnumerator loadSprite(string path)
    {
        string filePath = path;

        
        WWW www = new WWW("file://" + filePath);
        yield return www;

        Texture2D texture =new Texture2D(512,512,TextureFormat.RGB24,true);
        int bindex = 1080;
        byte[] dataBytes = www.bytes;
        bool thoutBreak = false;
       
        for (int i = 0; i < 512; i++) {
            if (thoutBreak == true) {
                break;
            }
            for (int j = 0; j < 512; j++) {


                if (bindex > dataBytes.Length) {
                    thoutBreak = true;
                    break;
                }
                Color co = new Color(dataBytes[bindex]/255f, dataBytes[bindex] / 255f, dataBytes[bindex] / 255f);
                texture.SetPixel(i, j, co);


                bindex++;

                
            }
        }
        texture.Apply();
        
      //  Debug.Log("图片格式= "+texture.format+"<>"+ texture.GetPixel(3,3)+"<>"+ texture.GetPixel(30, 30));
        //因为我们定义的是Image，所以这里需要把Texture2D转化为Sprite
        sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

        
        ViewInfo info = new ViewInfo();
        info.strArg = opstrArg;
        info.code = code;
        info.commonArg = sp;
        broadCast(info);
    }
}
