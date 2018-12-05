/*
 * NKPrefabMan.cs
 * 
 * Copyright (c) 2016 by nanoka All rights reserved.
 * Created by nanoka on 2016/06/30.
 * 
 * Qiita  ：http://qiita.com/nanokanato
 * Twitter：https://twitter.com/nanokanato
 * 
 */
#pragma warning disable 0219

using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;

/*==============================================================*
 * NKPrefabMan : GameObjectをprefabとして保存
 *==============================================================*/
public class NKPrefabMan : MonoBehaviour
{

    private string prefabDir = "Prefab/"; //「Assets/Resources/」以下のprefabファイルの保存先

    /*----------------------------------------------------------*
     * savePrefab : GameObjectをnameのファイル名でprefabとして保存
     *         in : GameObject gameobject
     *            : string name
     *        out : 
     *----------------------------------------------------------*/
    public void savePrefab(GameObject gameobj, string name)
    {
        //prefabの保存フォルダパス
        string prefabDirPath = Application.dataPath + "/Resources/" + prefabDir;
        if (!Directory.Exists(prefabDirPath))
        {
            //prefab保存用のフォルダがなければ作成する
            Directory.CreateDirectory(prefabDirPath);
        }

        //prefabの保存ファイルパス
        string prefabPath = prefabDirPath + name + ".prefab";
        if (!File.Exists(prefabPath))
        {
            //prefabファイルがなければ作成する
            File.Create(prefabPath);
        }

        //prefabの保存
        UnityEditor.PrefabUtility.CreatePrefab("Assets/Resources/" + prefabDir + name + ".prefab", gameobj);
        UnityEditor.AssetDatabase.SaveAssets();
    }

    /*----------------------------------------------------------*
     * loadPrefab : nameのファイル名で保存してあるprefabを呼び出し
     *         in : string name
     *        out : GameObject gameobject
     *----------------------------------------------------------*/
    public GameObject loadPrefab(string name)
    {
        //prefabファイルの存在確認
        string prefabPath = Application.dataPath + "/Resources/" + prefabDir + name + ".prefab";
        if (File.Exists(prefabPath))
        {
            //prefabファイルの読み込み
            string resourcesPath = prefabDir + name;
            GameObject gameobj = (GameObject)Resources.Load<GameObject>(resourcesPath);
            if (gameobj)
            {
                return gameobj;
            }
        }
        return null;
    }
}