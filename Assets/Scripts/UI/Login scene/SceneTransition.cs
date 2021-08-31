using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SceneTransition :MonoBehaviour
{
    public void LoadStartScene()
    {
        Debug.Log("sign btn");
        SceneManager.LoadScene(1);
    }


    public static bool IsFileReady(string filename)
    {
        // If the file can be opened for exclusive access it means that the file
        // is no longer locked by another process.
        try
        {
            using (FileStream inputStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                return inputStream.Length > 0;
        }
        catch (IOException)
        {
            return false;
        }
    }


    public static void WaitForFile(string filename)
    {
        //This will lock the execution until the file is ready
        //TODO: Add some logic to make it async and cancelable
        while (IsFileReady(filename)) {

            

        }
    }

    public void LoadStartScene2()  {

        /*
        Debug.Log(IsFileReady(Application.dataPath + "/Resources/XML/log.xml"));
       WaitForFile(Application.dataPath + "/Resources/XML/log.xml");

        Debug.Log("list btn");
        SceneManager.LoadScene(1);
        */


        
       


        if ((File.Exists(Application.dataPath + "/Resources/XML/log.xml")))
        {
            Debug.Log("list btn");
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.LogError("file doesnt found");
        }
        


    }
}
