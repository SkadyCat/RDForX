using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OP : MonoBehaviour,IViewer {

    public Image encryptImg;
    public Image implantImg;
    public Image decodeImg;

    public static OP Instance;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// 将等待加密的的图像加密，返回生成图像的路径
    /// 
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public string encrypt(string path) {



        return "";
    }

    /// <summary>
    /// 将path的图像读取出来，然后嵌入数据data，最后生成一张新的图像
    /// </summary>
    /// <param name="path"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public string implant(string path, byte[] data) {


        return "";
    }


    /// <summary>
    /// 将图像解密，返回解密路径，out嵌入数据
    /// </summary>
    /// <param name="path"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public string decode(string path, out string value) {

        value = "";

        return "";
    }

    public List<string> op(string originPath,byte[] insertData,out string info) {

        List<string> pathList = new List<string>();

        string encryptPath = encrypt(originPath);
        string implantPath = implant(encryptPath, insertData);
        string decodePath = decode(implantPath, out info);
        pathList.Add(encryptPath);
        pathList.Add(implantPath);
        pathList.Add(decodePath);

        return pathList;
        




    }

    public void update(ViewInfo info)
    {

        switch (info.code) {

            case OPField.op_load:

                Debug.Log(info.strArg);
                break;
        }
    }
}
