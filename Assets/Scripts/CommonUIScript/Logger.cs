﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class Logger : MonoBehaviour
{
    [SerializeField]
    GameObject textPanel;

    static List<string> mLines = new List<string>();
    static List<string> mWriteTxt = new List<string>();
    private string outpath;

    void Awake()
    {
        DontDestroyOnLoad(this);
        Application.logMessageReceived += HandleLog;
    }
    void OnApplicationQuit()
    {
        Debug.Log("Quit");
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            WriteTextToPanel();
            timer = 0;
        }
    }

    float timer;
    void WriteTextToPanel()
    {
        var textList = textPanel.GetComponent<Text>();
        textList.text = "";
        int length = (mLines.Count < 15) ? mLines.Count : 15;
        for (int i = 0; i < length; i++)
        {
            if (length > 0)
            {
                int index = mLines.Count - length + i;
                textList.text += mLines[index];
                textList.text += "\n";
            }
            else
            {
                textList.text += mLines[i];
                textList.text += "\n";
            }
        }
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        mWriteTxt.Add(logString);
        mWriteTxt.Add(stackTrace);
        if (type == LogType.Log)
        {
            //Log(logString);
            //Log(stackTrace);
            LogText(logString);
        }
    }
    public void LogText(params object[] objs)
    {
        string text = "";
        for (int i = 0; i < objs.Length; ++i)
        {
            if (i == 0)
            {
                text += objs[i].ToString();
            }
            else
            {
                text += ", " + objs[i].ToString();
            }
        }
        if (Application.isPlaying)
        {
            if (mLines.Count > 20)
            {
                mLines.RemoveAt(0);
            }
            mLines.Add(text);

        }
    }

    //这里我把错误的信息保存起来，用来输出在手机屏幕上
    static public void Log(params object[] objs)
    {
        string text = "";
        for (int i = 0; i < objs.Length; ++i)
        {
            if (i == 0)
            {
                text += objs[i].ToString();
            }
            else
            {
                text += ", " + objs[i].ToString();
            }
        }
        if (Application.isPlaying)
        {
            if (mLines.Count > 20)
            {
                mLines.RemoveAt(0);
            }
            mLines.Add(text);

        }
    }

    void OnGUI()
    {
        GUI.color = Color.red;
        for (int i = 0, imax = mLines.Count; i < imax; ++i)
        {
            GUILayout.Label(mLines[i]);
        }
    }
    void OnDestroy()
    {
        Application.logMessageReceived -= HandleLog;
    }

    //   void Awake()
    //   {
    //       DontDestroyOnLoad(this);
    //       //Application.persistentDataPath Unity中只有这个路径是既可以读也可以写的。
    //       var filename = System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
    //       //var filename = "log.txt";
    //       outpath = Path.Combine(Application.persistentDataPath, filename);
    //       //每次启动客户端删除之前保存的Log
    //       if (File.Exists(outpath))
    //       {
    //           File.Delete(outpath);
    //       }
    //       File.Create(outpath);
    //       //在这里做一个Log的监听
    //       //Application.RegisterLogCallback(HandleLog);
    //       Application.logMessageReceived += HandleLog;
    //   }
    //void Start()
    //{
    //	Debug.Log(outpath);
    //}

    //   void OnApplicationQuit()
    //   {
    //       Debug.Log("Quit");
    //   }
    //   void Update()
    //   {
    //       //因为写入文件的操作必须在主线程中完成，所以在Update中给你写入文件。
    //       if (mWriteTxt.Count > 0)
    //       {
    //           string[] temp = mWriteTxt.ToArray();
    //           using (StreamWriter writer = new StreamWriter(outpath, true, Encoding.UTF8))
    //           {
    //               foreach (string t in temp)
    //               {
    //                   writer.WriteLine(t);
    //               }
    //               mWriteTxt.Clear();
    //               writer.Close();
    //           }
    //       }
    //       timer += Time.deltaTime;
    //       if (timer>3)
    //       {
    //           WriteTextToPanel();
    //           timer = 0;
    //       }

    //   }

    //   float timer;
    //   void WriteTextToPanel()
    //   {
    //       var textList = textPanel.GetComponent<Text>();
    //       textList.text = "";
    //       int length = (mLines.Count < 15) ? mLines.Count : 15;
    //       for (int i = 0; i < length; i++)
    //       {
    //           if (length > 0)
    //           {
    //               int index = mLines.Count - length + i;
    //               textList.text += mLines[index];
    //           }
    //           else
    //           {
    //               textList.text += mLines[i];
    //           }
    //       }
    //   }

    //   void HandleLog(string logString, string stackTrace, LogType type)
    //   {
    //       mWriteTxt.Add(logString);
    //       mWriteTxt.Add(stackTrace);
    //       if (type == LogType.Log)
    //       {
    //           Log(logString);
    //           //Log(stackTrace);
    //           LogText(logString);

    //       }
    //   }
    //   public void LogText(params object[] objs)
    //   {
    //       string text = "";
    //       for (int i = 0; i < objs.Length; ++i)
    //       {
    //           if (i == 0)
    //           {
    //               text += objs[i].ToString();
    //           }
    //           else
    //           {
    //               text += ", " + objs[i].ToString();
    //           }
    //       }
    //       if (Application.isPlaying)
    //       {
    //           if (mLines.Count > 20)
    //           {
    //               mLines.RemoveAt(0);
    //           }
    //           mLines.Add(text);

    //       }



    //   }

    //   //这里我把错误的信息保存起来，用来输出在手机屏幕上
    //   static public void Log(params object[] objs)
    //   {
    //       string text = "";
    //       for (int i = 0; i < objs.Length; ++i)
    //       {
    //           if (i == 0)
    //           {
    //               text += objs[i].ToString();
    //           }
    //           else
    //           {
    //               text += ", " + objs[i].ToString();
    //           }
    //       }
    //       if (Application.isPlaying)
    //       {
    //           if (mLines.Count > 20)
    //           {
    //               mLines.RemoveAt(0);
    //           }
    //           mLines.Add(text);

    //       }
    //   }

    //   void OnGUI()
    //   {
    //       GUI.color = Color.red;
    //       for (int i = 0, imax = mLines.Count; i < imax; ++i)
    //       {
    //           GUILayout.Label(mLines[i]);
    //       }
    //   }
    //   void OnDestroy()
    //   {
    //       Application.logMessageReceived -= HandleLog;
    //   }
}