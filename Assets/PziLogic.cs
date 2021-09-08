using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataFromXML;
using DataFromArduino;
using System;

public class PziLogic : MonoBehaviour
{



    private string pziName;
    public int Step;

    private List<string> AllStringToSend = new List<string>();

    private void OnEnable()
    {
        pziName = PracticalLessonNumber.LessonNumber;
        // Debug.Log("pziName on Enable-- " + pziName);

    }

    IEnumerator SendStringsToArduino()
    {
        Debug.Log(AllStringToSend[0]);
        foreach (string Item in AllStringToSend)
        {

            sendToArduino(Item);
            Debug.Log("send --- " + Item);
            yield return new WaitForSeconds(0.02f);
        }
        AllStringToSend.Clear();


    }

    IEnumerator LampWait_4s()
    {
        Debug.Log(AllStringToSend[0]);
        foreach (string Item in AllStringToSend)
        {

            sendToArduino(Item);
            yield return new WaitForSeconds(4.0f);
        }
        AllStringToSend.Clear();


    }

    IEnumerator lamp28_on_off()
    {


        {
            yield return new WaitForSeconds(0.1f);
            sendToArduino("on27");
            yield return new WaitForSeconds(3.0f);
            sendToArduino("off27");
        }



    }

    IEnumerator _3_4_7_1()
    {

        {
            yield return new WaitForSeconds(0.01f);
            sendToArduino("off0");
            yield return new WaitForSeconds(0.01f);
            sendToArduino("on1");
            yield return new WaitForSeconds(0.01f);
            sendToArduino("s1goto150");
            yield return new WaitForSeconds(0.01f);
            sendToArduino("s5goto74");
            yield return new WaitForSeconds(0.01f);
            sendToArduino("s6goto74");
            yield return new WaitForSeconds(2.0f);
            sendToArduino("s1goto84");
            yield return new WaitForSeconds(1.0f);
            sendToArduino("off1");
            yield return new WaitForSeconds(0.01f);
            sendToArduino("on0");
        }

    }

    IEnumerator _3_4_7_2()
    {

        {

            yield return new WaitForSeconds(0.01f);
            sendToArduino("s1goto0");
            yield return new WaitForSeconds(0.01f);
            sendToArduino("s2goto0");
            yield return new WaitForSeconds(0.05f);
            sendToArduino("s1goto84");
            yield return new WaitForSeconds(0.01f);
            sendToArduino("s2goto100");

        }

    }

    IEnumerator _3_4_7_3()
    {
        
        while (true)
        {

            yield return new WaitForSeconds(0.01f);
            sendToArduino("s5goto74");
            yield return new WaitForSeconds(0.01f);
            sendToArduino("s6goto74");
            yield return new WaitForSeconds(0.5f);
            sendToArduino("s5goto100");
            yield return new WaitForSeconds(0.01f);
            sendToArduino("s6goto100");

        }

    }

    private bool _3_4_7_3_bool;

    IEnumerator _3_5_6_1()
    {

        {

            yield return new WaitForSeconds(0.01f);
            sendToArduino("s0goto0");
            yield return new WaitForSeconds(1.0f);
            sendToArduino("s0goto20");
            

        }

    }

    IEnumerator _3_5_1_1sh3()
    {

        {

            yield return new WaitForSeconds(0.1f);
            sendToArduino("s0goto-14400");
            yield return new WaitForSeconds(40.0f);
            sendToArduino("s1goto-14000");

        }

    }

    IEnumerator _3_5_1_1sh5()
    {

        {

            yield return new WaitForSeconds(0.1f);
            sendToArduino("s1goto0");
            yield return new WaitForSeconds(39.3f);
            sendToArduino("s0goto-400");

        }

    }

    IEnumerator _3_5_1_1sh28()
    {

        {
            yield return new WaitForSeconds(0.1f);
            sendToArduino("s1goto0");
            yield return new WaitForSeconds(9.0f);
            sendToArduino("s0goto-14160");

        }

    }

    IEnumerator _3_5_1_1sh18()
    {

        {

            yield return new WaitForSeconds(0.1f);
            sendToArduino("s0goto-14400");
            yield return new WaitForSeconds(1.0f);
            sendToArduino("s1goto-2720");

        }

    }

    IEnumerator _3_5_2_2sh7()
    {

        {

            yield return new WaitForSeconds(0.1f);
            sendToArduino("s0goto-14400");
            yield return new WaitForSeconds(40.0f);
            sendToArduino("s1goto-18080");

        }

    }

    IEnumerator _3_5_3_1sh14()
    {

        {

            yield return new WaitForSeconds(0.1f);
            sendToArduino("s1goto0");
            yield return new WaitForSeconds(18.0f);
            sendToArduino("s0goto-400");

        }

    }

    IEnumerator _3_5_3_1sh7()
    {

        {

            yield return new WaitForSeconds(0.1f);
            sendToArduino("s0goto-14400");
            yield return new WaitForSeconds(40.0f);
            sendToArduino("s1goto-15200");

        }

    }

    IEnumerator _3_5_3_1sh15()
    {

        {

            yield return new WaitForSeconds(0.1f);
            sendToArduino("s0goto-14400");
            yield return new WaitForSeconds(40.0f);
            sendToArduino("s1goto-16000");

        }

    }

    IEnumerator _3_5_3_1sh17()
    {

        {

            yield return new WaitForSeconds(0.1f);
            sendToArduino("s1goto0");
            yield return new WaitForSeconds(46.0f);
            sendToArduino("s0goto-400");

        }

    }

    IEnumerator _3_5_2_2sh9()
    {

        {

            yield return new WaitForSeconds(0.1f);
            sendToArduino("s1goto0");
            yield return new WaitForSeconds(50.2f);
            sendToArduino("s0goto0");

        }

    }

    IEnumerator lamp3473_on_off()
    {


        {
            yield return new WaitForSeconds(0.1f);
            sendToArduino("off0");
            yield return new WaitForSeconds(0.1f);
            sendToArduino("on1");
            yield return new WaitForSeconds(1.0f);
            sendToArduino("off1");
            yield return new WaitForSeconds(0.1f);
            sendToArduino("on0");
        }



    }

    IEnumerator lamp9_10_flashing()
    {

        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            sendToArduino("on8");
            yield return new WaitForSeconds(0.01f);
            sendToArduino("on9");
            yield return new WaitForSeconds(1.0f);
            sendToArduino("off8");
            yield return new WaitForSeconds(0.01f);
            sendToArduino("off9");
            yield return new WaitForSeconds(1.0f);
        }



    }

    private bool lamp9_10_flashing_bool;

    IEnumerator lamp_3_3_3_13()
    {

        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            sendToArduino("on0");
            yield return new WaitForSeconds(0.5f);
            sendToArduino("off0");
        }



    }

    private bool _lamp_3_3_3_13_bool;
    private Coroutine _coroutine;


    IEnumerator Lamp0_flashing_2600()
    {

        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            sendToArduino("off0");
            yield return new WaitForSeconds(1.0f);
            sendToArduino("on0");
            yield return new WaitForSeconds(1.0f);
        }



    }

    private bool Lamp0_flashing_2600_bool;

    IEnumerator Lamp3_flashing_2600()
    {

        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            sendToArduino("on1");
            yield return new WaitForSeconds(1.0f);
            sendToArduino("off1");
            yield return new WaitForSeconds(1.0f);
        }



    }

    private bool Lamp3_flashing_2600_bool;
    

    IEnumerator Lamp4_1_flashing_2600()
    {

        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            sendToArduino("on0");
            yield return new WaitForSeconds(0.01f);
            sendToArduino("on2");
            yield return new WaitForSeconds(1.0f);
            sendToArduino("off0");
            yield return new WaitForSeconds(0.01f);
            sendToArduino("off2");
            yield return new WaitForSeconds(1.0f);
        }



    }

    private bool Lamp4_1_flashing_2600_bool;
    

    IEnumerator YellowLampSAS_flashing()
    {

        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            sendToArduino("on2");
            yield return new WaitForSeconds(0.01f);
            sendToArduino("on3");
            yield return new WaitForSeconds(1.0f);
            sendToArduino("off2");
            yield return new WaitForSeconds(0.01f);
            sendToArduino("off3");
            yield return new WaitForSeconds(1.0f);
        }



    }

    private bool YellowLampSAS_flashing_bool;

    IEnumerator RedLampSAS_flashing()
    {

        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            sendToArduino("on0");
            yield return new WaitForSeconds(0.01f);
            sendToArduino("on1");
            yield return new WaitForSeconds(1.0f);
            sendToArduino("off0");
            yield return new WaitForSeconds(0.01f);
            sendToArduino("off1");
            yield return new WaitForSeconds(1.0f);
        }



    }

    private bool RedLampSAS_flashing_bool;

    public void StartStepFunction(string pziName, int step)
    {

        //Debug.Log(pziName);

        try
        {
            Invoke(pziName, 0.5f);
            Step = step;

        }
        catch
        {

            Debug.Log("NO function at Step " + Step);

        }


    }

    private void sendToArduino(string StringToSend)
    {

        GameObject arduinoMenager = GameObject.FindGameObjectWithTag("Arduino");
        //Debug.Log(arduinoMenager);
        arduinoMenager.GetComponent<DevicesManager>().SendToDevice(StringToSend, 0);
        //

    }

    public void ArduinoAction(string[] StrFromArduino)
    {
        if (StrFromArduino[2].Contains("."))
        {
            StrFromArduino[2] = Convert.ToInt32(StrFromArduino[2].Substring(0, StrFromArduino[2].IndexOf("."))).ToString();
        }

        switch (pziName)
        {
            case "LM2D2T7PZI2":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on31");
                                        break;

                                    default:

                                        sendToArduino("off31");


                                        break;



                                }

                                break;


                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 3)
                                            sendToArduino("on10");

                                        break;






                                }

                                break;

                        }

                        break;


                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "3":
                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 5)
                                        {
                                            AllStringToSend.Add("on11");
                                            AllStringToSend.Add("off10");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;


                                }




                                break;



                        }


                        break;



                }


                break;



            case "LM2D2T6PZI1":

                switch (StrFromArduino[0])
                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 4)
                                        {
                                            sendToArduino("on0");
                                        }
                                        break;



                                }


                                break;
                        }







                        break;

                }


                break;

            case "LM2D2T6PZI2":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "5":
                                switch (StrFromArduino[2])

                                {

                                    case "0":

                                        if (Step == 17)
                                        {
                                            AllStringToSend.Add("off12");
                                            AllStringToSend.Add("off13");
                                            AllStringToSend.Add("off14");
                                            AllStringToSend.Add("off15");
                                            AllStringToSend.Add("off16");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;


                                }




                                break;

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                        }


                        break;



                }


                break;


            case "LM2D2T6PZI3":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                        }


                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 10)
                                        {
                                            AllStringToSend.Add("on11");
                                            AllStringToSend.Add("on12");
                                            StartCoroutine(SendStringsToArduino());
                                        }


                                        break;

                                    case "2":

                                        if (Step == 13)
                                        {
                                            AllStringToSend.Add("off12");
                                            AllStringToSend.Add("on13");
                                            StartCoroutine(SendStringsToArduino());
                                        }




                                        break;

                                    case "7":

                                        if (Step == 19)
                                        {
                                            AllStringToSend.Add("off13");
                                            AllStringToSend.Add("on15");
                                            StartCoroutine(SendStringsToArduino());
                                        }




                                        break;

                                    case "11":

                                        if (Step == 22)
                                        {
                                            AllStringToSend.Add("off15");
                                            AllStringToSend.Add("on17");
                                            AllStringToSend.Add("on22");
                                            StartCoroutine(SendStringsToArduino());
                                        }




                                        break;

                                }




                                break;



                        }


                        break;

                }


                break;


            case "LM2D2T6PZI4":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                            case "3":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 11)
                                        {
                                            AllStringToSend.Add("on11");
                                            AllStringToSend.Add("on12");
                                            AllStringToSend.Add("on28");
                                            StartCoroutine(SendStringsToArduino());
                                            StartCoroutine(lamp28_on_off());
                                        }

                                        if (Step == 15)
                                        {
                                            AllStringToSend.Add("on11");
                                            AllStringToSend.Add("off12");
                                            AllStringToSend.Add("on28");
                                            AllStringToSend.Add("on26");
                                            AllStringToSend.Add("on29");
                                            AllStringToSend.Add("on30");
                                            AllStringToSend.Add("on31");
                                            StartCoroutine(SendStringsToArduino());
                                            StartCoroutine(lamp28_on_off());
                                        }

                                        if (Step == 20)
                                        {
                                            AllStringToSend.Add("off28");
                                            AllStringToSend.Add("off29");
                                            AllStringToSend.Add("off30");
                                            AllStringToSend.Add("off31");
                                            StartCoroutine(SendStringsToArduino());
                                            StartCoroutine(lamp28_on_off());
                                        }

                                        if (Step == 24)
                                        {
                                            StartCoroutine(lamp28_on_off());
                                        }

                                        if (Step == 27)
                                        {
                                            AllStringToSend.Add("on11");
                                            AllStringToSend.Add("on26");
                                            AllStringToSend.Add("on28");
                                            AllStringToSend.Add("on29");
                                            AllStringToSend.Add("on30");
                                            AllStringToSend.Add("on31");
                                            StartCoroutine(SendStringsToArduino());
                                            StartCoroutine(lamp28_on_off());
                                        }


                                        break;



                                }


                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step != 25)
                                        {
                                            sendToArduino("on32");
                                            StartCoroutine(lamp28_on_off());
                                        }

                                        if (Step == 25)
                                        {
                                            AllStringToSend.Add("off11");
                                            AllStringToSend.Add("off26");
                                            AllStringToSend.Add("off27");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    default:

                                        sendToArduino("off32");


                                        break;



                                }


                                break;





                        }


                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "1":
                                switch (StrFromArduino[2])

                                {

                                    case "8":

                                        if (Step == 7)
                                        {
                                            StartCoroutine(lamp28_on_off());
                                        }



                                        break;


                                }




                                break;



                        }


                        break;

                }


                break;


            case "LM2D2T6PZI5":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                        }


                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 1)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("on6");
                                            AllStringToSend.Add("on7");
                                            AllStringToSend.Add("on8");
                                            AllStringToSend.Add("on9");
                                            AllStringToSend.Add("on10");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 17)
                                        {
                                            AllStringToSend.Add("off7");
                                            AllStringToSend.Add("off8");
                                            AllStringToSend.Add("off9");
                                            AllStringToSend.Add("off10");
                                            AllStringToSend.Add("on3");
                                            AllStringToSend.Add("on4");
                                            AllStringToSend.Add("on5");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "4":

                                        if (Step == 5)
                                        {
                                            AllStringToSend.Add("off7");
                                            AllStringToSend.Add("off8");
                                            AllStringToSend.Add("off9");
                                            AllStringToSend.Add("off10");
                                            AllStringToSend.Add("on3");
                                            AllStringToSend.Add("on4");
                                            AllStringToSend.Add("on5");
                                            StartCoroutine(SendStringsToArduino());
                                        }




                                        break;

                                    case "6":

                                        if (Step == 11)
                                        {
                                            AllStringToSend.Add("off7");
                                            AllStringToSend.Add("off8");
                                            AllStringToSend.Add("off9");
                                            AllStringToSend.Add("off10");
                                            AllStringToSend.Add("on3");
                                            AllStringToSend.Add("on4");
                                            AllStringToSend.Add("on5");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;



                                }


                                break;

                            case "4":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 31)
                                        {
                                            AllStringToSend.Add("off6");
                                            AllStringToSend.Add("off7");
                                            AllStringToSend.Add("off8");
                                            AllStringToSend.Add("off9");
                                            AllStringToSend.Add("off10");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "2":

                                        if (Step == 7)
                                        {
                                            AllStringToSend.Add("off3");
                                            AllStringToSend.Add("off4");
                                            AllStringToSend.Add("off5");
                                            AllStringToSend.Add("on6");
                                            AllStringToSend.Add("on7");
                                            AllStringToSend.Add("on8");
                                            AllStringToSend.Add("on9");
                                            AllStringToSend.Add("on10");
                                            StartCoroutine(SendStringsToArduino());
                                        }


                                        break;

                                    case "3":

                                        if (Step == 13)
                                        {
                                            AllStringToSend.Add("off3");
                                            AllStringToSend.Add("off4");
                                            AllStringToSend.Add("off5");
                                            AllStringToSend.Add("on6");
                                            AllStringToSend.Add("on7");
                                            AllStringToSend.Add("on8");
                                            AllStringToSend.Add("on9");
                                            AllStringToSend.Add("on10");
                                            StartCoroutine(SendStringsToArduino());
                                        }


                                        break;

                                    case "4":

                                        if (Step == 20)
                                        {
                                            AllStringToSend.Add("off3");
                                            AllStringToSend.Add("off4");
                                            AllStringToSend.Add("off5");
                                            AllStringToSend.Add("on6");
                                            AllStringToSend.Add("on7");
                                            AllStringToSend.Add("on8");
                                            AllStringToSend.Add("on9");
                                            AllStringToSend.Add("on10");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 36)
                                        {

                                            AllStringToSend.Add("on6");
                                            AllStringToSend.Add("on7");
                                            AllStringToSend.Add("on8");
                                            AllStringToSend.Add("on9");
                                            AllStringToSend.Add("on10");
                                            StartCoroutine(SendStringsToArduino());
                                        }


                                        break;


                                }




                                break;



                        }


                        break;

                }


                break;

            case "LM2D2T6PZI6":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                        }


                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 2)
                                        {
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("off6");
                                            AllStringToSend.Add("off7");
                                            AllStringToSend.Add("off8");
                                            AllStringToSend.Add("off9");
                                            AllStringToSend.Add("off10");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 23)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off6");
                                            AllStringToSend.Add("off7");
                                            AllStringToSend.Add("off8");
                                            AllStringToSend.Add("off9");
                                            AllStringToSend.Add("off10");
                                            AllStringToSend.Add("on2");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "5":

                                        if (Step == 6)
                                        {
                                            AllStringToSend.Add("on6");
                                            AllStringToSend.Add("on7");
                                            AllStringToSend.Add("on8");
                                            AllStringToSend.Add("on9");
                                            AllStringToSend.Add("on10");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 27)
                                        {
                                            AllStringToSend.Add("on6");
                                            AllStringToSend.Add("on7");
                                            AllStringToSend.Add("on8");
                                            AllStringToSend.Add("on9");
                                            AllStringToSend.Add("on10");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;



                                }


                                break;





                        }


                        break;

                }


                break;


            case "LM2D2T6PZI7":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                        }


                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "0":

                                        if (Step == 23)
                                        {
                                            AllStringToSend.Add("off11");
                                            AllStringToSend.Add("off12");
                                            AllStringToSend.Add("off13");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;

                                    case "1":

                                        if (Step == 2)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on6");
                                            AllStringToSend.Add("on7");
                                            AllStringToSend.Add("on8");
                                            AllStringToSend.Add("on9");
                                            AllStringToSend.Add("on10");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;

                                    case "3":

                                        if (Step == 11)
                                        {
                                            AllStringToSend.Add("off11");
                                            AllStringToSend.Add("off12");
                                            AllStringToSend.Add("off13");
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;

                                    case "4":

                                        if (Step == 13)
                                        {
                                            AllStringToSend.Add("on11");
                                            AllStringToSend.Add("on12");
                                            AllStringToSend.Add("on13");
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;

                                    case "5":

                                        if (Step == 15)
                                        {
                                            AllStringToSend.Add("off11");
                                            AllStringToSend.Add("off12");
                                            AllStringToSend.Add("off13");
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;

                                    case "6":

                                        if (Step == 17)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("on11");
                                            AllStringToSend.Add("on12");
                                            AllStringToSend.Add("on13");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;

                                    case "7":

                                        if (Step == 19)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;

                                    case "8":

                                        if (Step == 21)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;


                                }


                                break;

                            case "3":

                                switch (StrFromArduino[2])

                                {

                                    case "2":

                                        if (Step == 4)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("on1");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;

                                    case "3":

                                        if (Step == 6)
                                        {
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("on2");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;

                                    case "6":

                                        if (Step == 9)
                                        {
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("on11");
                                            AllStringToSend.Add("on12");
                                            AllStringToSend.Add("on13");
                                            StartCoroutine(SendStringsToArduino());
                                        }



                                        break;

                                }


                                break;



                        }


                        break;

                }


                break;

            case "LM2D2T6PZI8":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step != 9)
                                        {
                                            sendToArduino("on11");
                                        }

                                        break;

                                    default:

                                        sendToArduino("off11");


                                        break;



                                }


                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        StartCoroutine(lamp28_on_off());

                                        break;

                                    default:



                                        break;



                                }


                                break;


                        }


                        break;




                }


                break;

            case "LM2D2T6PZI9":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on11");

                                        break;

                                    default:

                                        sendToArduino("off11");


                                        break;



                                }


                                break;




                        }


                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "4":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        StartCoroutine(lamp28_on_off());

                                        break;

                                    case "2":

                                        AllStringToSend.Add("on3");
                                        AllStringToSend.Add("on4");
                                        AllStringToSend.Add("on5");
                                        StartCoroutine(SendStringsToArduino());
                                        StartCoroutine(lamp28_on_off());

                                        break;



                                }

                                break;






                        }


                        break;


                }


                break;

            case "LM2D2T6PZI10":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step != 3)
                                        {
                                            sendToArduino("on11");
                                        }


                                        break;

                                    default:

                                        sendToArduino("off11");


                                        break;



                                }


                                break;




                        }


                        break;



                }


                break;

            case "LM2D2T6PZI11":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step > 12)
                                        {
                                            sendToArduino("on11");
                                        }


                                        break;

                                    default:

                                        sendToArduino("off11");


                                        break;



                                }


                                break;




                        }


                        break;



                }


                break;

            case "LM2D2T6PZI12":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step > 11)
                                        {
                                            sendToArduino("on11");
                                        }


                                        break;

                                    default:

                                        sendToArduino("off11");


                                        break;



                                }


                                break;




                        }


                        break;



                }


                break;


            case "LM2D2T6PZI13":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step > 11)
                                        {
                                            sendToArduino("on11");
                                        }


                                        break;

                                    default:

                                        sendToArduino("off11");


                                        break;



                                }


                                break;




                        }


                        break;



                }


                break;


            case "LM2D2T6PZI14":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;



                        }


                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "2":
                                        if (Step == 6)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "3":
                                        if (Step == 8)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "4":
                                        if (Step == 10)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "5":
                                        if (Step == 12)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "6":
                                        if (Step == 14)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "7":
                                        if (Step == 16)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "8":
                                        if (Step == 18)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "0":
                                        if (Step == 21)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                }

                                break;






                        }


                        break;

                }


                break;

            case "LM2D2T6PZI15":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s2goto146");


                                        break;

                                    default:

                                        sendToArduino("s2goto0");


                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s1goto100");


                                        break;

                                    default:

                                        sendToArduino("s1goto0");


                                        break;



                                }


                                break;

                            case "3":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 22)
                                        {
                                            AllStringToSend.Add("off21");
                                            AllStringToSend.Add("on27");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step > 29)
                                        {
                                            sendToArduino("off21");
                                        }


                                        break;

                                    case "0":

                                        sendToArduino("on21");


                                        break;


                                }


                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on19");


                                        break;

                                    default:

                                        AllStringToSend.Add("off18");
                                        AllStringToSend.Add("off19");
                                        StartCoroutine(SendStringsToArduino());


                                        break;



                                }


                                break;

                            case "4":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on18");


                                        break;

                                    default:

                                        sendToArduino("off18");


                                        break;



                                }


                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 12)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on8");
                                            AllStringToSend.Add("on9");
                                            AllStringToSend.Add("on32");
                                            StartCoroutine(SendStringsToArduino());
                                        }


                                        break;

                                    case "0":

                                        if (Step == 18)
                                        {
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("off8");
                                            AllStringToSend.Add("off9");
                                            AllStringToSend.Add("off32");
                                            StartCoroutine(SendStringsToArduino());
                                        }


                                        break;


                                }


                                break;


                        }


                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "2":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 6)
                                        {
                                            AllStringToSend.Add("on8");
                                            AllStringToSend.Add("s3goto50");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "2":

                                        if (Step == 9)
                                        {
                                            AllStringToSend.Add("off8");
                                            AllStringToSend.Add("s3goto0");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "3":

                                        if (Step == 20)
                                        {
                                            AllStringToSend.Add("on21");
                                            AllStringToSend.Add("on20");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                }

                                break;

                            case "3":

                                switch (StrFromArduino[2])

                                {

                                    case "2":

                                        if (Step == 14)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("on1");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "3":

                                        if (Step == 16)
                                        {
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("on2");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 24)
                                        {
                                            AllStringToSend.Add("off27");
                                            AllStringToSend.Add("on28");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "3":

                                        if (Step == 28)
                                        {
                                            sendToArduino("on29");
                                        }

                                        break;

                                    case "5":

                                        if (Step == 32)
                                        {
                                            sendToArduino("on30");
                                        }

                                        break;

                                    case "7":

                                        if (Step == 36)
                                        {
                                            sendToArduino("on31");
                                        }

                                        break;

                                }

                                break;




                        }


                        break;


                }


                break;

            case "LM2D2T7PZI1":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on31");
                                        break;

                                    default:

                                        sendToArduino("off");


                                        break;



                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on30");
                                        break;

                                    default:

                                        sendToArduino("off30");


                                        break;




                                }

                                break;

                        }

                        break;



                }


                break;

            case "LM2D2T7PZI3":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on31");
                                        break;

                                    default:

                                        sendToArduino("off");


                                        break;



                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on30");
                                        break;

                                    default:

                                        sendToArduino("off30");


                                        break;




                                }

                                break;

                        }

                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "3":
                                
                                switch (StrFromArduino[2])

                                {

                                    case "12":

                                        if (Step == 0)
                                        { 
                                            sendToArduino("on22");
                                        }

                                        break;

                                    case "13":

                                        if (Step == 2)
                                        { 
                                            AllStringToSend.Add("off22");
                                            AllStringToSend.Add("on23");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "14":

                                        if (Step == 4)
                                        {
                                            AllStringToSend.Add("off23");
                                            AllStringToSend.Add("on24");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "15":

                                        if (Step == 6)
                                        {
                                            AllStringToSend.Add("off24");
                                            AllStringToSend.Add("on25");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "16":

                                        if (Step == 8)
                                        {
                                            AllStringToSend.Add("off25");
                                            AllStringToSend.Add("on26");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "17":

                                        if (Step == 10)
                                        {
                                            AllStringToSend.Add("off26");
                                            AllStringToSend.Add("on27");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "18":

                                        if (Step == 12)
                                        {
                                            AllStringToSend.Add("off27");
                                            AllStringToSend.Add("on28");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "19":

                                        if (Step == 14)
                                        {
                                            AllStringToSend.Add("off28");
                                            AllStringToSend.Add("on29");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "20":

                                        if (Step == 16)
                                        {
                                            AllStringToSend.Add("off29");
                                            AllStringToSend.Add("on8");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                }

                                break;



                        }

                        break;


                }


                break;

            case "LM2D2T7PZI4":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        AllStringToSend.Add("on7");
                                        AllStringToSend.Add("on31");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                    default:

                                        sendToArduino("off");

                                        break;



                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on30");

                                        break;

                                    default:

                                        sendToArduino("off30");

                                        break;




                                }

                                break;

                            case "2":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on20");

                                        break;

                                    default:

                                        sendToArduino("off20");

                                        break;

                                }

                                break;

                            case "4":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on8");

                                        break;

                                    default:

                                        sendToArduino("off8");

                                        break;

                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 4)
                                        {
                                            AllStringToSend.Add("on10");
                                            AllStringToSend.Add("on14");
                                            AllStringToSend.Add("on19");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;


                                }

                                break;

                        }

                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "3":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 6)
                                        {
                                            AllStringToSend.Add("off10");
                                            AllStringToSend.Add("off14");
                                            AllStringToSend.Add("on11");
                                            AllStringToSend.Add("on15");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "2":

                                        if (Step == 9)
                                        {
                                            AllStringToSend.Add("on10");
                                            AllStringToSend.Add("on14");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "6":

                                        if (Step == 12)
                                        {
                                            AllStringToSend.Add("on12");
                                            AllStringToSend.Add("on16");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "10":

                                        if (Step == 15)
                                        {
                                            AllStringToSend.Add("off12");
                                            AllStringToSend.Add("off16");
                                            AllStringToSend.Add("on13");
                                            AllStringToSend.Add("on17");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "18":

                                        if (Step == 18)
                                        {
                                            AllStringToSend.Add("off10");
                                            AllStringToSend.Add("off11");
                                            AllStringToSend.Add("off17");
                                            AllStringToSend.Add("on18");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "20":

                                        if (Step == 20)
                                        {
                                            AllStringToSend.Add("off15");
                                            AllStringToSend.Add("on16");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;



                                }

                                break;



                        }

                        break;


                }


                break;

            case "LM2D2T7PZI5":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        AllStringToSend.Add("on20");
                                        AllStringToSend.Add("on31");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                    default:

                                        sendToArduino("off");

                                        break;



                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on30");

                                        break;

                                    default:

                                        sendToArduino("off30");

                                        break;




                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on21");

                                        break;

                                    default:

                                        sendToArduino("off21");

                                        break;


                                }

                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        AllStringToSend.Add("off0");
                                        AllStringToSend.Add("off1");
                                        AllStringToSend.Add("off2");
                                        AllStringToSend.Add("off3");
                                        AllStringToSend.Add("off4");
                                        AllStringToSend.Add("off5");
                                        AllStringToSend.Add("off6");
                                        AllStringToSend.Add("off23");
                                        AllStringToSend.Add("off29");
                                        StartCoroutine(SendStringsToArduino());

                                        break;



                                }

                                break;

                        }

                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "0":
                                
                                switch (StrFromArduino[2])

                                {

                                    case "1":
                                       
                                        if (Step == 5)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on22");
                                            AllStringToSend.Add("on24");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "2":

                                        if (Step == 8)
                                        {
                                            AllStringToSend.Add("off24");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on25");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "3":

                                        if (Step == 11)
                                        {
                                            AllStringToSend.Add("off25");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("on26");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "4":

                                        if (Step == 14)
                                        {
                                            AllStringToSend.Add("off26");
                                            AllStringToSend.Add("on3");
                                            AllStringToSend.Add("on27");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "5":

                                        if (Step == 17)
                                        {
                                            AllStringToSend.Add("off27");
                                            AllStringToSend.Add("on4");
                                            AllStringToSend.Add("on28");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "6":

                                        if (Step == 20)
                                        {
                                            AllStringToSend.Add("off28");
                                            AllStringToSend.Add("on5");
                                            AllStringToSend.Add("on6");
                                            AllStringToSend.Add("on29");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;



                                }

                                break;



                        }

                        break;

                    case "t":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "2":

                                        if (Step == 22)
                                        {
                                            AllStringToSend.Add("off22");
                                            AllStringToSend.Add("on23");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;



                                }

                                break;


                        }

                        break;

                }

                break;

            case "LM2D2T7PZI6":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on31");

                                        break;

                                    default:

                                        sendToArduino("off31");

                                        break;



                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on30");

                                        break;

                                    default:

                                        sendToArduino("off30");

                                        break;




                                }

                                break;

                            

                        }

                        break;

                    

                }

                break;

            case "LM2D2T7PZI7":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on31");
                                        break;

                                    default:

                                        sendToArduino("off31");


                                        break;



                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on30");
                                        break;

                                    default:

                                        sendToArduino("off30");


                                        break;




                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on9");

                                        break;

                                    default:

                                        sendToArduino("off9");

                                        break;




                                }

                                break;

                        }

                        break;



                }


                break;

            case "LM2D2T7PZI8":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on31");
                                        break;

                                    default:

                                        sendToArduino("off31");


                                        break;



                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on30");
                                        break;

                                    default:

                                        sendToArduino("off30");


                                        break;




                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on9");

                                        break;

                                    default:

                                        sendToArduino("off9");

                                        break;




                                }

                                break;

                        }

                        break;



                }


                break;

            case "LM2D2T7PZI9":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on31");
                                        break;

                                    default:

                                        sendToArduino("off");


                                        break;



                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on30");
                                        break;

                                    default:

                                        sendToArduino("off30");


                                        break;




                                }

                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 6)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("off6");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        

                                        if (Step == 10)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("off5");
                                            AllStringToSend.Add("off6");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        

                                        if (Step == 15)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("off5");
                                            AllStringToSend.Add("off6");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        

                                        if (Step == 19)
                                        { 
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("off6");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 7)
                                        {
                                            AllStringToSend.Add("on5");
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("on6");
                                            StartCoroutine(LampWait_4s());
                                        }

                                        if (Step == 11)
                                        {
                                            AllStringToSend.Add("on5");
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("on6");
                                            StartCoroutine(LampWait_4s());
                                        }

                                        if (Step == 16)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("on6");
                                            StartCoroutine(LampWait_4s());
                                        }

                                        if (Step == 20)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("on6");
                                            StartCoroutine(LampWait_4s());
                                        }

                                        break;


                                }

                                break;


                        }

                        break;

                    case "t":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "0":

                                        sendToArduino("on0");

                                        break;

                                    default:

                                        sendToArduino("off0");

                                        break;



                                }

                                break;




                        }

                        break;


                }


                break;

            case "LM2D2T7PZI11":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on31");

                                        break;

                                    default:

                                        sendToArduino("off");

                                        break;



                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on30");

                                        break;

                                    default:

                                        sendToArduino("off30");


                                        break;




                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 1)
                                        {
                                            AllStringToSend.Add("on19");
                                            AllStringToSend.Add("on14");
                                            AllStringToSend.Add("on20");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;



                                }

                                break;

                        }

                        break;



                }


                break;

            case "LM2D2T7PZI12":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on31");

                                        break;

                                    default:

                                        sendToArduino("off");

                                        break;



                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on30");

                                        break;

                                    default:

                                        sendToArduino("off30");


                                        break;




                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 3)
                                        {
                                            AllStringToSend.Add("on14");
                                            AllStringToSend.Add("on20");
                                            AllStringToSend.Add("on19");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;



                                }

                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("off");

                                        break;



                                }

                                break;


                        }

                        break;



                }


                break;

            case "LM2D2T7PZI13":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on31");

                                        break;

                                    default:

                                        sendToArduino("off");

                                        break;



                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on30");

                                        break;

                                    default:
                                        
                                        StopCoroutine(_coroutine);
                                        AllStringToSend.Add("off30");
                                        AllStringToSend.Add("off8");
                                        AllStringToSend.Add("off9");
                                        StartCoroutine(SendStringsToArduino());

                                        break;




                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 1)
                                        {
                                            if (!lamp9_10_flashing_bool)
                                            {
                                                _coroutine = StartCoroutine(lamp9_10_flashing());

                                                lamp9_10_flashing_bool = true;
                                            }

                                            // StartCoroutine(lamp9_10_flashing());
                                        }

                                        break;



                                }

                                break;




                        }

                        break;



                }


                break;

            case "LM2D2T7PZI14":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        AllStringToSend.Add("on31");
                                        AllStringToSend.Add("on7");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                    default:

                                        sendToArduino("off");

                                        break;



                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on30");

                                        break;

                                    default:

                                        sendToArduino("off30");

                                        break;




                                }

                                break;

                            case "3":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on");

                                        break;

                                    default:

                                        AllStringToSend.Add("off0");
                                        AllStringToSend.Add("off1");
                                        AllStringToSend.Add("off2");
                                        AllStringToSend.Add("off3");
                                        AllStringToSend.Add("off4");
                                        AllStringToSend.Add("off5");
                                        AllStringToSend.Add("off6");
                                        AllStringToSend.Add("off8");
                                        AllStringToSend.Add("off9");
                                        AllStringToSend.Add("off10");
                                        AllStringToSend.Add("off11");
                                        AllStringToSend.Add("off12");
                                        AllStringToSend.Add("off13");
                                        AllStringToSend.Add("off14");
                                        AllStringToSend.Add("off15");
                                        AllStringToSend.Add("off16");
                                        AllStringToSend.Add("off17");
                                        AllStringToSend.Add("off18");
                                        AllStringToSend.Add("off19");
                                        AllStringToSend.Add("off20");
                                        AllStringToSend.Add("off21");
                                        AllStringToSend.Add("off22");
                                        AllStringToSend.Add("off23");
                                        AllStringToSend.Add("off24");
                                        AllStringToSend.Add("off25");
                                        AllStringToSend.Add("off26");
                                        AllStringToSend.Add("off27");
                                        AllStringToSend.Add("off28");
                                        AllStringToSend.Add("off29");
                                        AllStringToSend.Add("off0");
                                        StartCoroutine(SendStringsToArduino());

                                        break;


                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 11)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("on6");
                                            StartCoroutine(LampWait_4s());
                                        }

                                        if (Step == 16)
                                        {
                                            AllStringToSend.Add("on5");
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("on6");
                                            StartCoroutine(LampWait_4s());
                                        }

                                        if (Step == 21)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("on6");
                                            StartCoroutine(LampWait_4s());
                                        }

                                        if (Step == 26)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("on6");
                                            StartCoroutine(LampWait_4s());
                                        }

                                        if (Step == 32)
                                        {
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            StartCoroutine(LampWait_4s());
                                        }

                                        if (Step == 37)
                                        {
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("on3");
                                            AllStringToSend.Add("on4");
                                            StartCoroutine(LampWait_4s());
                                        }

                                        if (Step == 42)
                                        {
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("on4");
                                            StartCoroutine(LampWait_4s());
                                        }

                                        break;



                                }

                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 13)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("off6");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 18)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("off5");
                                            AllStringToSend.Add("off6");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 23)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("off6");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 28)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("off6");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 34)
                                        {
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 39)
                                        {
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("off3");
                                            AllStringToSend.Add("off4");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 44)
                                        {
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("off4");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;



                                }

                                break;



                        }

                        break;



                }


                break;

            case "LM2D2T7PZI15":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on31");

                                        break;

                                    default:

                                        sendToArduino("off");

                                        break;



                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on30");

                                        break;

                                    default:

                                        sendToArduino("off30");

                                        break;




                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 3)
                                        {
                                            sendToArduino("on10");
                                        }

                                        break;



                                }

                                break;




                        }

                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "3":

                                switch (StrFromArduino[2])

                                {

                                    case "1":
                                        if (Step == 6)
                                        {
                                            AllStringToSend.Add("off10");
                                            AllStringToSend.Add("on11");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "2":
                                        if (Step == 8)
                                        {
                                            AllStringToSend.Add("off11");
                                            AllStringToSend.Add("on12");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "3":
                                        if (Step == 10)
                                        {
                                            AllStringToSend.Add("off12");
                                            AllStringToSend.Add("on13");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "4":
                                        if (Step == 12)
                                        {
                                            AllStringToSend.Add("off13");
                                            AllStringToSend.Add("on14");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "5":
                                        if (Step == 14)
                                        {
                                            AllStringToSend.Add("off14");
                                            AllStringToSend.Add("on15");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "6":
                                        if (Step == 16)
                                        {
                                            AllStringToSend.Add("off15");
                                            AllStringToSend.Add("on16");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "7":
                                        if (Step == 18)
                                        {
                                            AllStringToSend.Add("off16");
                                            AllStringToSend.Add("on17");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "8":
                                        if (Step == 20)
                                        {
                                            AllStringToSend.Add("off17");
                                            AllStringToSend.Add("on18");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "9":
                                        if (Step == 22)
                                        {
                                            AllStringToSend.Add("off18");
                                            AllStringToSend.Add("on19");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "10":
                                        if (Step == 24)
                                        {
                                            AllStringToSend.Add("off19");
                                            AllStringToSend.Add("on20");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "11":
                                        if (Step == 26)
                                        {
                                            AllStringToSend.Add("off20");
                                            AllStringToSend.Add("on21");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "12":
                                        if (Step == 28)
                                        {
                                            AllStringToSend.Add("off21");
                                            AllStringToSend.Add("on22");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "13":
                                        if (Step == 30)
                                        {
                                            AllStringToSend.Add("off22");
                                            AllStringToSend.Add("on23");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "14":
                                        if (Step == 32)
                                        {
                                            AllStringToSend.Add("off23");
                                            AllStringToSend.Add("on24");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "15":
                                        if (Step == 34)
                                        {
                                            AllStringToSend.Add("off24");
                                            AllStringToSend.Add("on25");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "16":
                                        if (Step == 36)
                                        {
                                            AllStringToSend.Add("off25");
                                            AllStringToSend.Add("on26");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "17":
                                        if (Step == 38)
                                        {
                                            AllStringToSend.Add("off26");
                                            AllStringToSend.Add("on27");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "18":
                                        if (Step == 40)
                                        {
                                            AllStringToSend.Add("off27");
                                            AllStringToSend.Add("on28");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "20":
                                        if (Step == 42)
                                        {
                                            AllStringToSend.Add("off28");
                                            AllStringToSend.Add("on8");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        if (Step == 47)
                                        {
                                            AllStringToSend.Add("off29");
                                            AllStringToSend.Add("on7");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;

                                    case "19":
                                        if (Step == 44)
                                        {
                                            AllStringToSend.Add("off8");
                                            AllStringToSend.Add("on29");
                                            StartCoroutine(SendStringsToArduino());
                                        }
                                        break;


                                }

                                break;






                        }


                        break;


                }


                break;

            case "LM2D2T8PZI1":


                switch (StrFromArduino[0])

                {

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "2":

                                switch (StrFromArduino[2])

                                {

                                    case "3":

                                        if (Step == 2)
                                        {
                                            AllStringToSend.Add("off4");
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on3");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "2":

                                        if (Step == 10)
                                        {
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off3");
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("s0goto78");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "1":

                                        if (Step == 12)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off2");
                                            AllStringToSend.Add("on1");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "0":

                                        if (Step == 14)
                                        {
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("on0");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;


                                }

                                break;


                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "10":

                                        if (Step == 4)
                                        {
                                            sendToArduino("s0goto47");
                                        }

                                        break;

                                    case "0":

                                        if (Step == 7)
                                        {
                                            sendToArduino("s0goto110");
                                        }

                                        break;


                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "10":

                                        if (Step == 5)
                                        {
                                            sendToArduino("s0goto39");
                                        }

                                        break;

                                    case "0":

                                        if (Step == 8)
                                        {
                                            sendToArduino("s0goto118");
                                        }

                                        break;


                                }

                                break;




                        }

                        break;



                }


                break;

            case "LM2D2T8PZI3":


                switch (StrFromArduino[0])

                {

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "2":

                                switch (StrFromArduino[2])

                                {

                                    case "4":

                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("on4");
                                            StartCoroutine(SendStringsToArduino());

                                        break;

                                    case "0":
                                        
                                            AllStringToSend.Add("off4");
                                            AllStringToSend.Add("on0");
                                            StartCoroutine(SendStringsToArduino());

                                        break;


                                }

                                break;


                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "4":

                                        if (Step == 7)
                                        {
                                            AllStringToSend.Add("off3");
                                            AllStringToSend.Add("s0goto69");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "3":

                                        if (Step == 7)
                                        {
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("s0goto61");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "2":

                                        if (Step == 7)
                                        {
                                            AllStringToSend.Add("on0");
                                            AllStringToSend.Add("s0goto54");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 15)
                                        {
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("on0");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "1":

                                        if (Step == 7)
                                        {
                                            sendToArduino("s0goto46");
                                        }

                                        break;

                                    case "0":

                                        if (Step == 7)
                                        {
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("s0goto39");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "6":

                                        if (Step == 10)
                                        {
                                            sendToArduino("off2");
                                        }

                                        break;

                                    case "8":

                                        if (Step == 12)
                                        {
                                            
                                            
                                           
                                            if (!Lamp3_flashing_2600_bool)
                                            {
                                                _coroutine = StartCoroutine(Lamp3_flashing_2600());
                                                
                                                Lamp3_flashing_2600_bool = true;
                                            }
                                        }

                                        break;

                                }

                                break;

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "5":

                                        if (Step == 9)
                                        {
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("s0goto79");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "4":

                                        if (Step == 9)
                                        {
                                            sendToArduino("s0goto69");
                                        }

                                        break;

                                    case "3":

                                        if (Step == 9)
                                        {
                                            sendToArduino("s0goto61");
                                        }

                                        break;

                                    case "2":

                                        if (Step == 9)
                                        {
                                            sendToArduino("s0goto54");
                                        }

                                        break;

                                    case "1":

                                        if (Step == 9)
                                        {
                                            sendToArduino("s0goto46");
                                        }

                                        break;


                                }

                                break;


                        }

                        break;

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 16)
                                        {
                                           
                                            if (!Lamp4_1_flashing_2600_bool)
                                            {
                                                _coroutine = StartCoroutine(Lamp4_1_flashing_2600());

                                                Lamp4_1_flashing_2600_bool = true;
                                            }
                                        }

                                        break;

                                    case "0":

                                        if (Step == 14)
                                        {
                                            StopCoroutine(_coroutine);
                                            sendToArduino("on1");
                                            
                                        }

                                        if (Step == 18)
                                        {
                                            StopCoroutine(_coroutine);
                                            AllStringToSend.Add("on2");
                                            AllStringToSend.Add("on0");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;


                                }

                                break;




                        }

                        break;


                }


                break;

            case "LM3D5T8PZI6":


                switch (StrFromArduino[0])

                {

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "5":

                                        if (Step == 7)
                                        {
                                            sendToArduino("off0");
                                        }

                                        break;


                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "4":

                                        if (Step == 8)
                                        {
                                            sendToArduino("on0");
                                        }

                                        break;

                                    case "7":

                                        if (Step == 16)
                                        {
                                            sendToArduino("off0");
                                        }

                                        break;


                                }

                                break;




                        }

                        break;

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":
                                        if (Step == 9)
                                        {
                                            if (!Lamp0_flashing_2600_bool)
                                            {
                                                _coroutine = StartCoroutine(Lamp0_flashing_2600());

                                                Lamp0_flashing_2600_bool = true;
                                            }
                                        }

                                        break;

                                    case "0":
                                        if (Step == 12)
                                        {
                                            StopCoroutine(_coroutine);
                                            sendToArduino("on0");
                                        }
                                        break;


                                }

                                break;




                        }

                        break;



                }


                break;

            case "LM3D2T5PZI1":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "4":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on17");

                                        break;

                                    default:

                                        StopCoroutine(_coroutine);
                                        sendToArduino("off");

                                        break;



                                }

                                break;




                        }

                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "9":

                                        if (Step == 1)
                                        {
                                            AllStringToSend.Add("on6");
                                            AllStringToSend.Add("on16");
                                            StartCoroutine(SendStringsToArduino());
                                            
                                            if (!YellowLampSAS_flashing_bool)
                                            {
                                                _coroutine = StartCoroutine(YellowLampSAS_flashing());

                                                YellowLampSAS_flashing_bool = true;
                                            }

                                        }

                                        if (Step == 13)
                                        {
                                            AllStringToSend.Add("off14");
                                            AllStringToSend.Add("on16");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "4":

                                        if (Step == 3)
                                        {
                                            AllStringToSend.Add("off16");
                                            AllStringToSend.Add("on11");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "0":

                                        if (Step == 5)
                                        {
                                            AllStringToSend.Add("off11");
                                            AllStringToSend.Add("on7");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 23)
                                        {
                                            AllStringToSend.Add("off9");
                                            AllStringToSend.Add("on7");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "1":

                                        if (Step == 9)
                                        {
                                            AllStringToSend.Add("off7");
                                            AllStringToSend.Add("on8");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "7":

                                        if (Step == 11)
                                        {
                                            AllStringToSend.Add("off8");
                                            AllStringToSend.Add("on14");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "8":

                                        if (Step == 17)
                                        {
                                            AllStringToSend.Add("off16");
                                            AllStringToSend.Add("on15");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "6":

                                        if (Step == 19)
                                        {
                                            AllStringToSend.Add("off15");
                                            AllStringToSend.Add("on13");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "2":

                                        if (Step == 21)
                                        {
                                            AllStringToSend.Add("off13");
                                            AllStringToSend.Add("on9");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;



                                }

                                break;




                        }

                        break;


                }


                break;

            case "LM3D2T5PZI2":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "4":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on17");

                                        break;

                                    default:

                                        sendToArduino("off");

                                        break;



                                }

                                break;



                        }

                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "9":

                                        if (Step == 1)
                                        {
                                            AllStringToSend.Add("on6");
                                            AllStringToSend.Add("on16");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 13)
                                        {
                                            AllStringToSend.Add("off15");
                                            AllStringToSend.Add("on16");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "5":

                                        if (Step == 3)
                                        {
                                            AllStringToSend.Add("off16");
                                            AllStringToSend.Add("on12");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "0":

                                        if (Step == 5)
                                        {
                                            AllStringToSend.Add("off12");
                                            AllStringToSend.Add("on7");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 23)
                                        {
                                            AllStringToSend.Add("off9");
                                            AllStringToSend.Add("on7");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "3":

                                        if (Step == 9)
                                        {
                                            AllStringToSend.Add("off7");
                                            AllStringToSend.Add("on10");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "8":

                                        if (Step == 11)
                                        {
                                            AllStringToSend.Add("off10");
                                            AllStringToSend.Add("on15");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 17)
                                        {
                                            AllStringToSend.Add("off16");
                                            AllStringToSend.Add("on15");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "6":

                                        if (Step == 19)
                                        {
                                            AllStringToSend.Add("off15");
                                            AllStringToSend.Add("on13");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "2":

                                        if (Step == 21)
                                        {
                                            AllStringToSend.Add("off13");
                                            AllStringToSend.Add("on9");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;



                                }

                                break;



                        }

                        break;


                }


                break;

            case "LM3D2T5PZI3":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "4":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on17");
                                        if (!RedLampSAS_flashing_bool)
                                        {
                                            _coroutine = StartCoroutine(RedLampSAS_flashing());

                                            RedLampSAS_flashing_bool = true;
                                        }

                                        break;

                                    default:

                                        StopCoroutine(_coroutine);
                                        AllStringToSend.Add("off");
                                        AllStringToSend.Add("s0goto0");
                                        StartCoroutine(SendStringsToArduino());

                                        break;



                                }

                                break;




                        }

                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "2":

                                switch (StrFromArduino[2])

                                {

                                    case "3":

                                        if (Step == 4)
                                        {
                                            sendToArduino("s0goto69");
                                        }

                                        break;

                                    case "2":

                                        if (Step == 8)
                                        {
                                            sendToArduino("s0goto7");
                                        }

                                        break;

                                }

                                break;


                        }

                        break;

                    case "t":

                        switch (StrFromArduino[1])

                        {

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "0":

                                        if (Step == 15)
                                        {
                                            StopCoroutine(_coroutine);
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("off1");
                                            StartCoroutine(SendStringsToArduino());

                                            if (!YellowLampSAS_flashing_bool)
                                            {
                                                _coroutine = StartCoroutine(YellowLampSAS_flashing());

                                                YellowLampSAS_flashing_bool = true;
                                            }

                                        }

                                        break;




                                }

                                break;




                        }

                        break;


                }


                break;



            case "LM3D3T3PZI1":


                switch (StrFromArduino[0])

                {

                    case "t":

                        switch (StrFromArduino[1])

                        {

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "2":
                                        AllStringToSend.Add("on4");
                                        if (Step == 12)
                                        {
                                            AllStringToSend.Add("s0goto110");
                                            AllStringToSend.Add("s1goto70");
                                        }

                                        StartCoroutine(SendStringsToArduino());
                                        break;

                                    default:
                                        AllStringToSend.Add("off4");
                                        AllStringToSend.Add("s0goto0");


                                        StartCoroutine(SendStringsToArduino());

                                        break;



                                }

                                break;



                        }

                        break;




                }


                break;



            case "LM3D3T3PZI11":


                switch (StrFromArduino[0])

                {

                    case "t":

                        switch (StrFromArduino[1])

                        {

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "2":
                                        AllStringToSend.Add("on4");
                                        AllStringToSend.Add("s0goto110");
                                        StartCoroutine(SendStringsToArduino());
                                        break;

                                    default:
                                        AllStringToSend.Add("off4");
                                        AllStringToSend.Add("off0");
                                        AllStringToSend.Add("off1");
                                        AllStringToSend.Add("s0goto0");
                                        StartCoroutine(SendStringsToArduino());
                                        break;



                                }

                                break;



                        }

                        break;


                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "5":

                                switch (Convert.ToInt32(StrFromArduino[2]))

                                {

                                    case 0:

                                        sendToArduino("s0goto18");
                                        break;

                                    case 1:


                                        sendToArduino("s0goto110");
                                        Debug.Log("StrFromArduino[2] --- " + StrFromArduino[2]);

                                        break;

                                    default:

                                        Debug.Log("StrFromArduino[2] --- " + StrFromArduino[2]);

                                        break;



                                }

                                break;



                        }

                        break;


                    case "p":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    default:


                                        if (Convert.ToInt32(StrFromArduino[2]) > 950)
                                        {

                                            if (Step == 7)
                                            {

                                                AllStringToSend.Add("on0");
                                                AllStringToSend.Add("on1");
                                                AllStringToSend.Add("s0goto11");



                                                StartCoroutine(SendStringsToArduino());
                                            }

                                        }








                                        break;



                                }

                                break;



                        }

                        break;




                }


                break;




            case "LM3D3T3PZI12":


                switch (StrFromArduino[0])

                {

                    case "t":

                        switch (StrFromArduino[1])

                        {

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "2":
                                        AllStringToSend.Add("on4");
                                        AllStringToSend.Add("s0goto110");
                                        StartCoroutine(SendStringsToArduino());
                                        break;

                                    default:
                                        AllStringToSend.Add("off4");
                                        AllStringToSend.Add("s0goto0");
                                        StartCoroutine(SendStringsToArduino());
                                        break;



                                }

                                break;



                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "0":
                                        sendToArduino("on2");
                                        break;

                                    case "2":
                                        sendToArduino("off2");
                                        break;






                                }

                                break;


                            case "2":

                                switch (StrFromArduino[2])

                                {

                                    case "1":
                                        sendToArduino("s1goto45");
                                        break;

                                    case "0":
                                        sendToArduino("s1goto70");
                                        break;

                                }

                                break;



                        }

                        break;


                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "5":

                                switch (Convert.ToInt32(StrFromArduino[2]))

                                {

                                    case 1:

                                        sendToArduino("s0goto110");

                                        break;

                                    case 2:


                                        sendToArduino("s0goto0");


                                        break;

                                    case 4:


                                        sendToArduino("s0goto130");


                                        break;





                                }

                                break;



                        }

                        break;



                    case "p":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    default:


                                        //if (Convert.ToInt32(StrFromArduino[2]) > 950)


                                        if (Step == 4 || Step == 6)
                                        {

                                            // AllStringToSend.Add("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 1000, 0, 203));


                                            sendToArduino("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 1000, 0, 203));

                                            // StartCoroutine(SendStringsToArduino());
                                        }


                                        if (Step == 21)
                                        {


                                            sendToArduino("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 480, 0, 98));
                                            //AllStringToSend.Add("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 480, 0, 98));




                                            //StartCoroutine(SendStringsToArduino());
                                        }










                                        break;



                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    default:

                                        if (Step == 22)
                                        {

                                            sendToArduino("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 500, 98, 100));
                                            //AllStringToSend.Add("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 500, 98, 100));
                                            // StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                }

                                break;



                        }

                        break;




                }


                break;


            case "LM3D3T3PZI13":


                switch (StrFromArduino[0])
                {
                    case "t":
                        switch (StrFromArduino[1])
                        {
                            case "5":
                                switch (StrFromArduino[2])

                                {
                                    case "2":
                                        AllStringToSend.Add("on4");
                                        AllStringToSend.Add("s0goto110");
                                        StartCoroutine(SendStringsToArduino());
                                        break;
                                    default:
                                        AllStringToSend.Add("off4");
                                        AllStringToSend.Add("s0goto0");
                                        StartCoroutine(SendStringsToArduino());
                                        break;
                                }
                                break;
                        }
                        break;


                    case "e":
                        switch (StrFromArduino[1])
                        {
                            case "5":
                                switch (Convert.ToInt32(StrFromArduino[2]))
                                {
                                    case 1:
                                        sendToArduino("s0goto110");
                                        break;
                                    case 2:
                                        sendToArduino("s0goto0");
                                        break;
                                }
                                break;
                        }
                        break;
                    case "p":
                        switch (StrFromArduino[1])
                        {
                            case "0":
                                switch (StrFromArduino[2])
                                {
                                    default:

                                        if (Step == 5)
                                        {
                                            // AllStringToSend.Add("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 1000, 0, 203));
                                            sendToArduino("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 1000, 0, 203));
                                            // StartCoroutine(SendStringsToArduino());
                                        }
                                        break;
                                }
                                break;
                            case "1":
                                switch (StrFromArduino[2])
                                {
                                    default:
                                        if (Step == 6)
                                        {
                                            sendToArduino("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 500, 98, 100));
                                            //AllStringToSend.Add("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 500, 98, 100));
                                            // StartCoroutine(SendStringsToArduino());
                                            if (Convert.ToInt32(StrFromArduino[2]) > 450)
                                            {
                                                if (!_lamp_3_3_3_13_bool)
                                                {
                                                    _coroutine = StartCoroutine(lamp_3_3_3_13());

                                                    _lamp_3_3_3_13_bool = true;
                                                }

                                            }




                                        }
                                        break;
                                }
                                break;
                        }
                        break;
                }
                break;


            case "LM3D3T3PZI14":


                switch (StrFromArduino[0])
                {
                    case "t":
                        switch (StrFromArduino[1])
                        {
                            case "5":
                                switch (StrFromArduino[2])

                                {
                                    case "2":
                                        AllStringToSend.Add("on4");
                                        AllStringToSend.Add("s0goto110");
                                        StartCoroutine(SendStringsToArduino());
                                        break;
                                    default:
                                        AllStringToSend.Add("off4");
                                        AllStringToSend.Add("s0goto0");
                                        StartCoroutine(SendStringsToArduino());
                                        break;
                                }
                                break;
                        }
                        break;


                    case "e":
                        switch (StrFromArduino[1])
                        {
                            case "5":
                                switch (Convert.ToInt32(StrFromArduino[2]))
                                {

                                    case 2:
                                        sendToArduino("s0goto0");
                                        break;
                                }
                                break;
                        }
                        break;



                    case "p":
                        switch (StrFromArduino[1])
                        {
                            case "0":
                                switch (StrFromArduino[2])
                                {
                                    default:

                                        if (Step == 3)
                                        {
                                            // AllStringToSend.Add("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 1000, 0, 203));
                                            sendToArduino("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 700, 0, 138));
                                            // StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 11)
                                        {
                                            // AllStringToSend.Add("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 1000, 0, 203));
                                            sendToArduino("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 200, 700, 42, 138));
                                            // StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 19)
                                        {
                                            // AllStringToSend.Add("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 0, 1000, 0, 203));
                                            sendToArduino("s0goto" + map(Convert.ToInt32(StrFromArduino[2]), 200, 500, 42, 98));
                                            // StartCoroutine(SendStringsToArduino());
                                        }
                                        break;
                                }
                                break;

                            case "1":
                                switch (StrFromArduino[2])
                                {
                                    default:
                                        if (Step == 4)
                                        {
                                            sendToArduino("s0goto" + (map(Convert.ToInt32(StrFromArduino[2]), 0, 500, 0, 4) + 138));

                                        }
                                        if (Step == 12)
                                        {
                                            sendToArduino("s0goto" + (map(Convert.ToInt32(StrFromArduino[2]), 0, 500, -4, 0) + 42));

                                        }
                                        if (Step == 20)
                                        {
                                            sendToArduino("s0goto" + (map(Convert.ToInt32(StrFromArduino[2]), 0, 500, 0, 4) + 98));

                                        }
                                        break;




                                }
                                break;
                        }
                        break;

                }
                break;

            case "LM3D3T3PZI4":


                switch (StrFromArduino[0])
                {
                    case "b":
                        switch (StrFromArduino[1])
                        {
                            case "0":
                                switch (StrFromArduino[2])

                                {
                                    case "1":
                                        AllStringToSend.Add("on1");
                                        AllStringToSend.Add("on3");
                                        AllStringToSend.Add("s0goto11");
                                        StartCoroutine(SendStringsToArduino());
                                        break;
                                    default:
                                        AllStringToSend.Add("off1");
                                        AllStringToSend.Add("off3");
                                        AllStringToSend.Add("s0goto0");
                                        StartCoroutine(SendStringsToArduino());
                                        break;
                                }
                                break;
                        }
                        break;

                }
                break;


            case "LM3D3T3PZI5":


                switch (StrFromArduino[0])
                {
                    case "b":
                        switch (StrFromArduino[1])
                        {
                            case "9":
                                switch (StrFromArduino[2])

                                {
                                    case "1":
                                        sendToArduino("mon2044");
                                        break;
                                    default:
                                        sendToArduino("mon0");
                                        break;
                                }
                                break;
                        }
                        break;

                    case "p":
                        switch (StrFromArduino[1])
                        {
                            case "0":
                                switch (StrFromArduino[2])

                                {
                                    default:


                                        sendToArduino("mon" + map(Convert.ToInt32(StrFromArduino[2]), 0, 1000, 2044, 2024));

                                        break;
                                }
                                break;
                        }
                        break;

                }
                break;

            case "LM3D3T3PZI6":


                switch (StrFromArduino[0])
                {
                    case "b":
                        switch (StrFromArduino[1])
                        {
                            case "12":
                                switch (StrFromArduino[2])

                                {
                                    case "1":
                                        sendToArduino("mon2021");
                                        break;
                                    default:
                                        sendToArduino("mon0");
                                        break;
                                }
                                break;
                        }
                        break;


                }
                break;

            case "LM3D3T3PZI7":


                switch (StrFromArduino[0])
                {
                    case "b":
                        switch (StrFromArduino[1])
                        {
                            case "0":
                                switch (StrFromArduino[2])

                                {
                                    case "1":

                                        AllStringToSend.Add("s0goto11");
                                        StartCoroutine(SendStringsToArduino());
                                        break;
                                    default:

                                        AllStringToSend.Add("s0goto0");
                                        StartCoroutine(SendStringsToArduino());
                                        break;
                                }
                                break;
                            case "12":
                                switch (StrFromArduino[2])

                                {
                                    case "1":
                                        sendToArduino("mon2021");
                                        break;
                                    default:
                                        sendToArduino("mon0");
                                        break;
                                }
                                break;
                        }
                        break;

                    case "p":
                        switch (StrFromArduino[1])
                        {
                            case "0":
                                switch (StrFromArduino[2])

                                {
                                    default:


                                        sendToArduino("mon" + map(Convert.ToInt32(StrFromArduino[2]), 0, 1000, 2021, 2018));

                                        break;
                                }
                                break;
                        }
                        break;



                }
                break;

            case "LM3D3T3PZI8":


                switch (StrFromArduino[0])
                {
                    case "b":
                        switch (StrFromArduino[1])
                        {

                            case "12":
                                switch (StrFromArduino[2])

                                {
                                    case "1":
                                        sendToArduino("mon0960");
                                        break;
                                    default:
                                        sendToArduino("mon0");
                                        break;
                                }
                                break;
                        }
                        break;


                }
                break;

            case "LM3D3T3PZI9":


                switch (StrFromArduino[0])
                {
                    case "b":
                        switch (StrFromArduino[1])
                        {

                            case "10":
                                switch (StrFromArduino[2])

                                {
                                    case "1":
                                        sendToArduino("mon-2560");
                                        break;
                                    default:
                                        sendToArduino("mon0");
                                        break;
                                }
                                break;
                        }
                        break;


                }
                break;

            case "LM3D3T3PZI10":


                switch (StrFromArduino[0])
                {

                    case "b":
                        switch (StrFromArduino[1])
                        {
                            case "12":
                                switch (StrFromArduino[2])

                                {
                                    case "1":
                                        sendToArduino("mon00900");
                                        break;
                                    default:
                                        sendToArduino("mon0");
                                        break;
                                }
                                break;
                            case "0":
                                switch (StrFromArduino[2])

                                {
                                    case "1":

                                        AllStringToSend.Add("s0goto11");
                                        StartCoroutine(SendStringsToArduino());
                                        break;
                                    default:

                                        AllStringToSend.Add("s0goto0");
                                        StartCoroutine(SendStringsToArduino());
                                        break;
                                }
                                break;

                        }
                        break;


                }
                break;

            case "LM3D4T6PZI1":


                switch (StrFromArduino[0])

                {

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "13":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        
                                            sendToArduino("on0");
                                        

                                        break;

                                    case "2":

                                        
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("on0");
                                            StartCoroutine(SendStringsToArduino());
                                        

                                        break;

                                    case "3":

                                        
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("on0");
                                            StartCoroutine(SendStringsToArduino());
                                        

                                        break;

                                    case "4":

                                        
                                            AllStringToSend.Add("off0");
                                            AllStringToSend.Add("on0");
                                            StartCoroutine(SendStringsToArduino());
                                        

                                        break;

                                    case "0":

                                        
                                            sendToArduino("off0");
                                        

                                        break;

                                }

                                break;





                        }

                        break;



                }


                break;

            case "LM3D2T6PZI1":


                switch (StrFromArduino[0])

                {

                    case "t":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "2":


                                        AllStringToSend.Add("on0");
                                        AllStringToSend.Add("s1goto149");
                                        StartCoroutine(SendStringsToArduino());


                                        break;

                                    case "0":


                                        AllStringToSend.Add("off0");
                                        AllStringToSend.Add("s1goto0");
                                        StartCoroutine(SendStringsToArduino());


                                        break;


                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "2":


                                        sendToArduino("on1");


                                        break;

                                    case "0":


                                        sendToArduino("off1");


                                        break;


                                }

                                break;



                        }

                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "0":


                                        AllStringToSend.Add("off1");
                                        AllStringToSend.Add("on1");
                                        StartCoroutine(SendStringsToArduino());


                                        break;

                                    case "1":


                                        AllStringToSend.Add("off1");
                                        AllStringToSend.Add("on1");
                                        StartCoroutine(SendStringsToArduino());


                                        break;

                                    case "2":


                                        AllStringToSend.Add("off1");
                                        AllStringToSend.Add("on1");
                                        StartCoroutine(SendStringsToArduino());


                                        break;

                                    case "3":


                                        AllStringToSend.Add("off1");
                                        AllStringToSend.Add("on1");
                                        StartCoroutine(SendStringsToArduino());


                                        break;

                                    case "4":


                                        AllStringToSend.Add("off1");
                                        AllStringToSend.Add("on1");
                                        StartCoroutine(SendStringsToArduino());


                                        break;

                                    case "5":


                                        AllStringToSend.Add("off1");
                                        AllStringToSend.Add("on1");
                                        StartCoroutine(SendStringsToArduino());


                                        break;


                                }

                                break;



                        }

                        break;


                }


                break;

            case "LM3D2T6PZI2":


                switch (StrFromArduino[0])

                {

                    case "t":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "2":


                                        AllStringToSend.Add("on0");
                                        AllStringToSend.Add("s1goto149");
                                        StartCoroutine(SendStringsToArduino());


                                        break;

                                    case "0":


                                        AllStringToSend.Add("off0");
                                        AllStringToSend.Add("s1goto0");
                                        StartCoroutine(SendStringsToArduino());


                                        break;


                                }

                                break;



                        }

                        break;

                    case "p":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "0":


                                        sendToArduino("s0goto0");


                                        break;

                                    case "1":


                                        sendToArduino("s0goto20");


                                        break;

                                    

                                    case "2":


                                        sendToArduino("s0goto40");


                                        break;

                                    

                                    case "3":


                                        sendToArduino("s0goto60");


                                        break;

                                    

                                    

                                    case "4":


                                        AllStringToSend.Add("off1");
                                        AllStringToSend.Add("s0goto80");
                                        StartCoroutine(SendStringsToArduino());


                                        break;

                                    case "5":


                                        AllStringToSend.Add("on1");
                                        AllStringToSend.Add("s0goto102");
                                        StartCoroutine(SendStringsToArduino());


                                        break;

                                    

                                    case "6":


                                        sendToArduino("s0goto120");


                                        break;

                                    

                                    case "7":


                                        sendToArduino("s0goto140");


                                        break;

                                    

                                    case "8":


                                        sendToArduino("s0goto160");


                                        break;

                                    

                                    case "9":


                                        sendToArduino("s0goto180");


                                        break;

                                    

                                    case "10":


                                        sendToArduino("s0goto205");


                                        break;


                                }

                                break;



                        }

                        break;


                }


                break;

            case "LM3D2T6PZI3":


                switch (StrFromArduino[0])

                {

                    case "t":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "2":


                                        AllStringToSend.Add("on0");
                                        AllStringToSend.Add("s1goto149");
                                        StartCoroutine(SendStringsToArduino());


                                        break;

                                    case "0":


                                        AllStringToSend.Add("off0");
                                        AllStringToSend.Add("s1goto0");
                                        StartCoroutine(SendStringsToArduino());


                                        break;


                                }

                                break;

                            case "2":

                                switch (StrFromArduino[2])

                                {

                                    case "0":


                                        sendToArduino("s0goto0");


                                        break;


                                }

                                break;


                        }

                        break;

                    case "p":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "0":


                                        sendToArduino("s0goto0");


                                        break;

                                    case "1":


                                        sendToArduino("s0goto20");


                                        break;



                                    case "2":


                                        sendToArduino("s0goto40");


                                        break;



                                    case "3":


                                        sendToArduino("s0goto60");


                                        break;





                                    case "4":


                                        sendToArduino("s0goto80");


                                        break;

                                    case "5":


                                        sendToArduino("s0goto102");


                                        break;



                                    case "6":


                                        sendToArduino("s0goto120");


                                        break;



                                    case "7":


                                        sendToArduino("s0goto140");


                                        break;



                                    case "8":


                                        sendToArduino("s0goto160");


                                        break;



                                    case "9":


                                        sendToArduino("s0goto180");


                                        break;



                                    case "10":


                                        sendToArduino("s0goto205");


                                        break;


                                }

                                break;



                        }

                        break;


                }


                break;

            case "LM3D5T5PZI1":


                switch (StrFromArduino[0])

                {

                    case "t":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":


                                        sendToArduino("on0");


                                        break;

                                    case "2":


                                        sendToArduino("on");


                                        break;

                                    case "0":


                                        sendToArduino("off");


                                        break;

                                }

                                break;



                        }

                        break;

                    case "p":

                        switch (StrFromArduino[1])

                        {

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "10":

                                        if (Step == 6)
                                        {
                                            sendToArduino("s0goto205");
                                        }

                                        break;

                                    case "9":

                                        if (Step == 6)
                                        {
                                            sendToArduino("s0goto180");
                                        }

                                        break;

                                    case "8":

                                        if (Step == 6)
                                        {
                                            sendToArduino("s0goto160");
                                        }

                                        break;

                                    case "7":

                                        if (Step == 6)
                                        {
                                            sendToArduino("s0goto140");
                                        }

                                        break;

                                    case "6":

                                        if (Step == 6)
                                        {
                                            sendToArduino("s0goto120");
                                        }

                                        break;

                                    case "5":

                                        if (Step == 6)
                                        {
                                            sendToArduino("s0goto100");
                                        }

                                        break;

                                    case "4":

                                        if (Step == 6)
                                        {
                                            sendToArduino("s0goto80");
                                        }

                                        break;

                                    case "3":

                                        if (Step == 6)
                                        {
                                            sendToArduino("s0goto60");
                                        }

                                        break;

                                    case "2":

                                        if (Step == 6)
                                        {
                                            sendToArduino("s0goto40");
                                        }

                                        break;

                                    case "1":

                                        if (Step == 6)
                                        {
                                            sendToArduino("s0goto20");
                                        }

                                        break;



                                }

                                break;

                            case "3":

                                switch (StrFromArduino[2])

                                {

                                    case "10":
                                        
                                            sendToArduino("s0goto0");

                                        break;

                                    case "9":

                                            sendToArduino("s0goto20");

                                        break;

                                    case "8":

                                            sendToArduino("s0goto40");

                                        break;

                                    case "7":

                                            sendToArduino("s0goto60");

                                        break;

                                    case "6":

                                            sendToArduino("s0goto80");

                                        break;

                                    case "5":

                                            sendToArduino("s0goto100");

                                        break;

                                    case "4":

                                            sendToArduino("s0goto120");

                                        break;

                                    case "3":

                                            sendToArduino("s0goto140");

                                        break;

                                    case "2":

                                            sendToArduino("s0goto160");

                                        break;

                                    case "1":

                                            sendToArduino("s0goto180");

                                        break;



                                }

                                break;


                        }

                        break;


                }


                break;

            case "LM3D5T5PZI2":


                switch (StrFromArduino[0])

                {

                    case "t":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":


                                        sendToArduino("on0");


                                        break;

                                    case "2":


                                        sendToArduino("on");


                                        break;

                                    case "0":


                                        sendToArduino("off");


                                        break;

                                }

                                break;



                        }

                        break;

                    case "p":

                        switch (StrFromArduino[1])

                        {

                            case "2":

                                switch (StrFromArduino[2])

                                {

                                    case "10":

                                        if (Step == 7)
                                        {
                                            sendToArduino("s0goto205");
                                        }

                                        break;

                                    case "9":

                                        if (Step == 7)
                                        {
                                            sendToArduino("s0goto180");
                                        }

                                        break;

                                    case "8":

                                        if (Step == 7)
                                        {
                                            sendToArduino("s0goto160");
                                        }

                                        break;

                                    case "7":

                                        if (Step == 7)
                                        {
                                            sendToArduino("s0goto140");
                                        }

                                        break;

                                    case "6":

                                        if (Step == 7)
                                        {
                                            sendToArduino("s0goto120");
                                        }

                                        break;

                                    case "5":

                                        if (Step == 7)
                                        {
                                            sendToArduino("s0goto100");
                                        }

                                        break;

                                    case "4":

                                        if (Step == 7)
                                        {
                                            sendToArduino("s0goto80");
                                        }

                                        break;

                                    case "3":

                                        if (Step == 7)
                                        {
                                            sendToArduino("s0goto60");
                                        }

                                        break;

                                    case "2":

                                        if (Step == 7)
                                        {
                                            sendToArduino("s0goto40");
                                        }

                                        break;

                                    case "1":

                                        if (Step == 7)
                                        {
                                            sendToArduino("s0goto20");
                                        }

                                        break;



                                }

                                break;

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "10":

                                        sendToArduino("s0goto0");

                                        break;

                                    case "9":

                                        sendToArduino("s0goto20");

                                        break;

                                    case "8":

                                        sendToArduino("s0goto40");

                                        break;

                                    case "7":

                                        sendToArduino("s0goto60");

                                        break;

                                    case "6":

                                        sendToArduino("s0goto80");

                                        break;

                                    case "5":

                                        sendToArduino("s0goto100");

                                        break;

                                    case "4":

                                        sendToArduino("s0goto120");

                                        break;

                                    case "3":

                                        sendToArduino("s0goto140");

                                        break;

                                    case "2":

                                        sendToArduino("s0goto160");

                                        break;

                                    case "1":

                                        sendToArduino("s0goto180");

                                        break;



                                }

                                break;


                        }

                        break;


                }


                break;

            case "LM3D2T8PZI1":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on0");

                                        break;

                                    default:

                                        sendToArduino("off0");

                                        break;


                                }

                                break;

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("off1");

                                        break;

                                    default:

                                        sendToArduino("on1");

                                        break;


                                }

                                break;



                        }

                        break;

                    case "p":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "80":

                                        if (Step == 8)
                                        {
                                            sendToArduino("on1");
                                        }

                                        break;

                                    default:

                                        sendToArduino("off1");

                                        break;




                                }

                                break;



                        }

                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "3":

                                switch (StrFromArduino[2])

                                {

                                    case "5":

                                        if (Step == 12)
                                        {
                                            sendToArduino("on1");
                                        }

                                        break;

                                    default:

                                        if (Step == 14)
                                        {
                                            sendToArduino("off1");
                                        }

                                        break;


                                }

                                break;

                            case "4":

                                switch (StrFromArduino[2])

                                {

                                    case "8":

                                        if (Step == 16)
                                        {
                                            sendToArduino("on1");
                                        }

                                        break;

                                    default:

                                        if (Step == 16)
                                        {
                                            sendToArduino("off1");
                                        }

                                        break;


                                }

                                break;



                        }

                        break;


                }

                break;

            case "LM3D2T8PZI2":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("on0");

                                        break;

                                    default:

                                        sendToArduino("off0");

                                        break;


                                }

                                break;

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("off1");

                                        break;

                                    default:

                                        sendToArduino("on1");

                                        break;


                                }

                                break;



                        }

                        break;

                    case "p":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "80":

                                        if (Step == 4)
                                        {
                                            sendToArduino("on1");
                                        }

                                        break;

                                    default:

                                        sendToArduino("off1");

                                        break;




                                }

                                break;



                        }

                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "3":

                                switch (StrFromArduino[2])

                                {

                                    case "2":

                                        if (Step == 8)
                                        {
                                            sendToArduino("on1");
                                        }

                                        break;

                                    default:

                                        if (Step == 8)
                                        {
                                            sendToArduino("off1");
                                        }

                                        break;

                                }

                                break;

                            case "4":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 10)
                                        {
                                            sendToArduino("off1");
                                        }

                                        break;

                                    case "6":

                                        if (Step == 12)
                                        {
                                            sendToArduino("on1");
                                        }

                                        break;

                                    default:

                                        if (Step == 12)
                                        {
                                            sendToArduino("off1");
                                        }

                                        break;


                                }

                                break;



                        }

                        break;


                }

                break;

            case "LM3D2T8PZI3":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 4)
                                        {
                                            sendToArduino("off0");
                                        }

                                        if (Step == 12)
                                        {
                                            sendToArduino("off1");
                                        }

                                        break;

                                    case "0":

                                        if (Step == 9)
                                        {
                                            sendToArduino("off0");
                                        }

                                        if (Step == 16)
                                        {
                                            sendToArduino("off1");
                                        }

                                        break;


                                }

                                break;



                        }

                        break;

                    case "p":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "80":

                                        if (Step == 3)
                                        {
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on0");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 11)
                                        {
                                            sendToArduino("off0");
                                        }

                                        break;

                                    case "60":

                                        AllStringToSend.Add("off1");
                                        AllStringToSend.Add("off0");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                    case "100":

                                        if (Step == 3)
                                        {
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off0");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        if (Step == 11)
                                        {
                                            sendToArduino("on0");
                                        }

                                        break;



                                }

                                break;



                        }

                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "4":

                                switch (StrFromArduino[2])

                                {

                                    case "0":

                                        if (Step == 7)
                                        {
                                            sendToArduino("on0");
                                        }

                                        break;

                                    case "6":

                                        if (Step == 15)
                                        {
                                            sendToArduino("on1");
                                        }

                                        break;

                                    default:

                                        if (Step == 7)
                                        {
                                            sendToArduino("off0");
                                        }

                                        if (Step == 15)
                                        {
                                            sendToArduino("off1");
                                        }

                                        break;


                                }

                                break;



                        }

                        break;


                }

                break;

            case "LM3D2T8PZI4":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 8)
                                        {
                                            sendToArduino("off0");
                                        }

                                        if (Step == 10)
                                        {
                                            sendToArduino("on1");
                                        }

                                        break;

                                    default:

                                        if (Step == 8)
                                        {
                                            sendToArduino("on0");
                                        }

                                        if (Step == 10)
                                        {
                                            sendToArduino("off1");
                                        }

                                        break;


                                }

                                break;


                        }

                        break;

                    case "p":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "80":

                                        if (Step == 7)
                                        {
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on0");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "60":

                                        AllStringToSend.Add("off1");
                                        AllStringToSend.Add("off0");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                    case "100":

                                        if (Step == 7)
                                        {
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off0");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;


                                }

                                break;


                        }

                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "4":

                                switch (StrFromArduino[2])

                                {

                                    case "3":

                                        if (Step == 9)
                                        {
                                            sendToArduino("on0");
                                        }

                                        break;

                                    default:

                                        if (Step == 9)
                                        {
                                            sendToArduino("off0");
                                        }

                                        break;


                                }

                                break;



                        }

                        break;


                }

                break;

            case "LM3D2T8PZI5":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 7)
                                        {
                                            sendToArduino("off0");
                                        }

                                        if (Step == 9)
                                        {
                                            sendToArduino("on1");
                                        }

                                        break;

                                    default:

                                        if (Step == 7)
                                        {
                                            sendToArduino("on0");
                                        }

                                        if (Step == 9)
                                        {
                                            sendToArduino("off1");
                                        }

                                        break;


                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        if (Step == 10)
                                        {
                                            sendToArduino("on0");
                                        }

                                        break;

                                    default:

                                        if (Step == 10)
                                        {
                                            sendToArduino("off0");
                                        }

                                        break;


                                }

                                break;


                        }

                        break;

                    case "p":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "80":

                                        if (Step == 6)
                                        {
                                            AllStringToSend.Add("on1");
                                            AllStringToSend.Add("on0");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "60":

                                        AllStringToSend.Add("off1");
                                        AllStringToSend.Add("off0");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                    case "100":

                                        if (Step == 6)
                                        {
                                            AllStringToSend.Add("off1");
                                            AllStringToSend.Add("off0");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;


                                }

                                break;


                        }

                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "4":

                                switch (StrFromArduino[2])

                                {

                                    case "2":

                                        if (Step == 8)
                                        {
                                            sendToArduino("on0");
                                        }

                                        break;

                                    default:

                                        if (Step == 8)
                                        {
                                            sendToArduino("off0");
                                        }

                                        break;


                                }

                                break;



                        }

                        break;


                }

                break;

            case "LM3D4T7PZI1":


                switch (StrFromArduino[0])

                {

                    case "t":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s6goto111");

                                        break;

                                    case "0":

                                        sendToArduino("s6goto74");

                                        break;

                                    case "2":

                                        sendToArduino("s6goto37");

                                        break;
                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s5goto37");

                                        break;

                                    case "0":

                                        sendToArduino("s5goto74");

                                        break;

                                    case "2":

                                        sendToArduino("s5goto111");

                                        break;

                                }

                                break;


                        }

                        break;



                }

                break;

            case "LM3D4T7PZI2":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s0goto141");

                                        break;

                                    case "0":

                                        sendToArduino("s0goto0");

                                        break;

                                }

                                break;

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        AllStringToSend.Add("s1goto84");
                                        AllStringToSend.Add("s2goto100");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                    case "0":

                                        AllStringToSend.Add("s1goto0");
                                        AllStringToSend.Add("s2goto0");
                                        StartCoroutine(SendStringsToArduino());

                                        break;


                                }

                                break;

                            case "2":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s3goto0");

                                        break;

                                    case "0":

                                        sendToArduino("s3goto100");

                                        break;

                                }

                                break;

                            

                        }

                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        StartCoroutine(_3_4_7_2());

                                        break;

                                    case "0":

                                        StartCoroutine(_3_4_7_2());

                                        break;

                                    case "2":

                                        StartCoroutine(_3_4_7_2());

                                        break;
                                }

                                break;



                        }

                        break;


                }

                break;

            case "LM3D4T7PZI3":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s0goto141");

                                        break;

                                    case "0":

                                        AllStringToSend.Add("s0goto0");
                                        AllStringToSend.Add("off0");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                }

                                break;

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        AllStringToSend.Add("s1goto86");
                                        AllStringToSend.Add("s2goto100");
                                        AllStringToSend.Add("s5goto100");
                                        AllStringToSend.Add("s6goto100");
                                        AllStringToSend.Add("on0");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                    case "0":

                                        AllStringToSend.Add("s1goto0");
                                        AllStringToSend.Add("s2goto0");
                                        AllStringToSend.Add("s5goto74");
                                        AllStringToSend.Add("s6goto74");
                                        AllStringToSend.Add("off0");
                                        StartCoroutine(SendStringsToArduino());

                                        break;


                                }

                                break;

                            case "2":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s3goto0");

                                        break;

                                    case "0":

                                        sendToArduino("s3goto100");

                                        break;

                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        AllStringToSend.Add("off0");
                                        AllStringToSend.Add("on1");
                                        AllStringToSend.Add("s1goto150");
                                        StartCoroutine(SendStringsToArduino());

                                        if (Step == 7)
                                        { 
                                            if (!_3_4_7_3_bool)
                                            {
                                                _coroutine = StartCoroutine(_3_4_7_3());

                                                _3_4_7_3_bool = true;
                                            }
                                        }

                                        if (Step == 26)
                                        {
                                            StartCoroutine(lamp3473_on_off());
                                            AllStringToSend.Add("s5goto74");
                                            AllStringToSend.Add("s6goto74");
                                            AllStringToSend.Add("s1goto84");
                                            StartCoroutine(SendStringsToArduino());
                                        }

                                        break;

                                    case "0":

                                        AllStringToSend.Add("on0");
                                        AllStringToSend.Add("off1");
                                        AllStringToSend.Add("s5goto74");
                                        AllStringToSend.Add("s6goto74");
                                        AllStringToSend.Add("s1goto84");
                                        StartCoroutine(SendStringsToArduino());

                                        break;


                                }

                                break;


                        }

                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        StartCoroutine(_3_4_7_2());

                                        break;

                                    case "0":

                                        StartCoroutine(_3_4_7_2());

                                        break;

                                    case "2":

                                        StartCoroutine(_3_4_7_2());

                                        break;
                                }

                                break;



                        }

                        break;

                    case "t":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s6goto124");

                                        break;

                                    case "2":

                                        sendToArduino("s6goto19");

                                        break;
                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("s5goto19");

                                        break;

                                    case "2":

                                        sendToArduino("s5goto118");

                                        break;

                                }

                                break;


                        }

                        break;



                }

                break;

            case "LM3D5T6PZI1":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        AllStringToSend.Add("s0goto20");
                                        AllStringToSend.Add("s1goto83");
                                        AllStringToSend.Add("s2goto98");
                                        AllStringToSend.Add("on4");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                    case "0":

                                        AllStringToSend.Add("s0goto0");
                                        AllStringToSend.Add("s1goto0");
                                        AllStringToSend.Add("s2goto0");
                                        AllStringToSend.Add("off4");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                }

                                break;

                            case "2":

                                switch (StrFromArduino[2])

                                {

                                    case "0":

                                        if (Step == 8)
                                        {
                                            StartCoroutine(_3_5_6_1());
                                        }
                                        break;


                                }

                                break;


                        }

                        break;


                }

                break;

            case "LM4D3T5PZI1":


                switch (StrFromArduino[0])

                {


                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "42":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        AllStringToSend.Add("on40");
                                        AllStringToSend.Add("on55");
                                        AllStringToSend.Add("on60");
                                        AllStringToSend.Add("on50");
                                        AllStringToSend.Add("on44");
                                        AllStringToSend.Add("on43");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                    case "0":

                                        sendToArduino("off");

                                        break;

                                }

                                break;

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        AllStringToSend.Add("on30");
                                        AllStringToSend.Add("on65");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                }

                                break;

                            case "1":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        AllStringToSend.Add("off43");
                                        AllStringToSend.Add("on53");
                                        AllStringToSend.Add("off30");
                                        AllStringToSend.Add("on31");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                }

                                break;

                            case "9":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("off");

                                        break;

                                }

                                break;

                            case "2":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        AllStringToSend.Add("on40");
                                        AllStringToSend.Add("on55");
                                        AllStringToSend.Add("on60");
                                        AllStringToSend.Add("on50");
                                        AllStringToSend.Add("on44");
                                        AllStringToSend.Add("on43");
                                        AllStringToSend.Add("on65");
                                        AllStringToSend.Add("on32");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                }

                                break;

                            case "3":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        AllStringToSend.Add("off43");
                                        AllStringToSend.Add("on48");
                                        AllStringToSend.Add("off32");
                                        AllStringToSend.Add("on33");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                }

                                break;

                        }

                        break;

                    


                }


                break;

            case "LM4D3T5PZI2":


                switch (StrFromArduino[0])

                {


                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "42":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        AllStringToSend.Add("on40");
                                        AllStringToSend.Add("on55");
                                        AllStringToSend.Add("on60");
                                        AllStringToSend.Add("on50");
                                        AllStringToSend.Add("on44");
                                        AllStringToSend.Add("on43");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                    case "0":

                                        sendToArduino("off");

                                        break;

                                }

                                break;

                            case "35":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        AllStringToSend.Add("on14");
                                        AllStringToSend.Add("on65");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                }

                                break;

                            case "36":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        AllStringToSend.Add("off14");
                                        AllStringToSend.Add("on13");
                                        AllStringToSend.Add("off43");
                                        AllStringToSend.Add("on48");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                }

                                break;

                            case "39":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        sendToArduino("off");

                                        break;

                                }

                                break;


                        }

                        break;


                }


                break;

            case "LM3D5T8PZI3":


                switch (StrFromArduino[0])

                {


                    case "p":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "0":

                                        sendToArduino("s0goto0");

                                        break;

                                    case "20":

                                        sendToArduino("s0goto3");

                                        break;

                                    case "60":

                                        sendToArduino("s0goto43");

                                        break;

                                    case "100":

                                        sendToArduino("s0goto110");

                                        break;

                                    case "140":

                                        sendToArduino("s0goto176");

                                        break;

                                    case "180":

                                        sendToArduino("s0goto216");

                                        break;

                                }

                                break;



                        }

                        break;


                }


                break;

            case "LM3D5T8PZI4":


                switch (StrFromArduino[0])

                {


                    case "p":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "0":

                                        sendToArduino("s0goto0");

                                        break;

                                    case "20":

                                        sendToArduino("s0goto3");

                                        break;

                                    case "40":

                                        sendToArduino("s0goto34");

                                        break;

                                    case "60":

                                        sendToArduino("s0goto40");

                                        break;

                                    case "80":

                                        sendToArduino("s0goto67");

                                        break;


                                }

                                break;



                        }

                        break;


                }


                break;

            case "LM3D5T8PZI5":


                switch (StrFromArduino[0])

                {


                    case "p":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "0":

                                        sendToArduino("s0goto0");

                                        break;

                                    case "20":

                                        sendToArduino("s0goto3");

                                        break;

                                    case "60":

                                        sendToArduino("s0goto43");

                                        break;

                                    case "100":

                                        sendToArduino("s0goto110");

                                        break;

                                    case "140":

                                        sendToArduino("s0goto176");

                                        break;

                                    case "180":

                                        sendToArduino("s0goto216");

                                        break;

                                }

                                break;



                        }

                        break;


                }


                break;

            case "LM3D5T1PZI1":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        AllStringToSend.Add("on2");
                                        AllStringToSend.Add("on8");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                    case "0":

                                        AllStringToSend.Add("off");
                                        AllStringToSend.Add("s0goto0");
                                        AllStringToSend.Add("s1goto0");
                                        AllStringToSend.Add("s2goto0");
                                        AllStringToSend.Add("s3goto0");
                                        AllStringToSend.Add("s4goto0");
                                        StartCoroutine(SendStringsToArduino());

                                        break;


                                }

                                break;



                        }

                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "3":

                                switch (StrFromArduino[2])

                                {

                                    case "7":
                                        if (Step == 2) 
                                        {
                                            StartCoroutine(_3_5_1_1sh3());
                                        }
                                        break;

                                    case "8":
                                        if (Step == 7)
                                        {
                                            sendToArduino("s0goto-2160");
                                        }

                                        if (Step == 9)
                                        {
                                            sendToArduino("s0goto-4240");
                                        }

                                        if (Step == 11)
                                        {
                                            sendToArduino("s0goto-6240");
                                        }

                                        if (Step == 13)
                                        {
                                            sendToArduino("s0goto-10080");
                                        }

                                        if (Step == 15)
                                        {
                                            sendToArduino("s0goto-14160");
                                        }

                                        if (Step == 17)
                                        {
                                            StartCoroutine(_3_5_1_1sh18());
                                        }

                                        if (Step == 19)
                                        {
                                            sendToArduino("s1goto-5920");
                                        }

                                        if (Step == 21)
                                        {
                                            sendToArduino("s1goto-7520");
                                        }
                                        break;

                                }

                                break;

                            case "4":

                                switch (StrFromArduino[2])

                                {

                                    case "3":
                                        if (Step == 4)
                                        {
                                            StartCoroutine(_3_5_1_1sh5());
                                        }

                                        if (Step == 23)
                                        {
                                            sendToArduino("s1goto-5920");
                                        }

                                        if (Step == 25)
                                        {
                                            sendToArduino("s1goto-2720");
                                        }

                                        if (Step == 27)
                                        {
                                            StartCoroutine(_3_5_1_1sh28());
                                        }

                                        if (Step == 29)
                                        {
                                            sendToArduino("s0goto-10080");
                                        }

                                        if (Step == 31)
                                        {
                                            sendToArduino("s0goto-6240");
                                        }

                                        if (Step == 33)
                                        {
                                            sendToArduino("s0goto-4240");
                                        }

                                        if (Step == 35)
                                        {
                                            sendToArduino("s0goto-2160");
                                        }

                                        if (Step == 37)
                                        {
                                            sendToArduino("s0goto-400");
                                        }

                                        break;

                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "9":
                                        if (Step == 5)
                                        {
                                            sendToArduino("s0goto0");
                                        }

                                        if (Step == 38)
                                        {
                                            sendToArduino("s0goto0");
                                        }
                                        break;

                                }

                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "3":
                                        if (Step == 40)
                                        {
                                            sendToArduino("s0goto-400");
                                        }

                                        break;

                                }

                                break;

                        }

                        break;


                }


                break;

            case "LM3D5T2PZI1":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        AllStringToSend.Add("on2");
                                        AllStringToSend.Add("on8");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                    case "0":

                                        AllStringToSend.Add("off");
                                        AllStringToSend.Add("s0goto0");
                                        AllStringToSend.Add("s1goto0");
                                        AllStringToSend.Add("s2goto0");
                                        AllStringToSend.Add("s3goto0");
                                        AllStringToSend.Add("s4goto0");
                                        StartCoroutine(SendStringsToArduino());

                                        break;


                                }

                                break;



                        }

                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "9":
                                        if (Step == 6)
                                        {
                                            sendToArduino("s3goto102");
                                        }

                                        if (Step == 8)
                                        {
                                            sendToArduino("s3goto284");
                                        }
                                        break;

                                    case "8":
                                        if (Step == 10)
                                        {
                                            sendToArduino("s3goto3546");
                                        }

                                        break;
                                }

                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "2":
                                        if (Step == 12)
                                        {
                                            sendToArduino("s3goto284");
                                        }

                                        if (Step == 14)
                                        {
                                            sendToArduino("s3goto102");
                                        }
                                        if (Step == 16)
                                        {
                                            sendToArduino("s3goto0");
                                        }
                                        break;

                                }

                                break;

                        }

                        break;


                }


                break;

            case "LM3D5T2PZI2":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        AllStringToSend.Add("on2");
                                        AllStringToSend.Add("on8");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                    case "0":

                                        AllStringToSend.Add("off");
                                        AllStringToSend.Add("s0goto0");
                                        AllStringToSend.Add("s1goto0");
                                        AllStringToSend.Add("s2goto0");
                                        AllStringToSend.Add("s3goto0");
                                        AllStringToSend.Add("s4goto0");
                                        StartCoroutine(SendStringsToArduino());

                                        break;


                                }

                                break;



                        }

                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "3":

                                switch (StrFromArduino[2])

                                {

                                    case "7":
                                        if (Step == 6)
                                        {
                                            StartCoroutine(_3_5_2_2sh7());
                                        }
                                        break;

                                }

                                break;

                            case "4":

                                switch (StrFromArduino[2])

                                {

                                    case "2":
                                        if (Step == 8)
                                        {
                                            StartCoroutine(_3_5_2_2sh9());
                                        }
                                        break;

                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "8":
                                        if (Step == 12)
                                        {
                                            sendToArduino("s3goto7200");
                                        }
                                        break;

                                }

                                break;

                            case "6":

                                switch (StrFromArduino[2])

                                {

                                    case "2":
                                        if (Step == 14)
                                        {
                                            sendToArduino("s3goto0");
                                        }
                                        break;

                                }

                                break;

                        }

                        break;


                }


                break;

            case "LM3D5T3PZI1":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        AllStringToSend.Add("on2");
                                        AllStringToSend.Add("on8");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                    case "0":

                                        AllStringToSend.Add("off");
                                        AllStringToSend.Add("s0goto0");
                                        AllStringToSend.Add("s1goto0");
                                        AllStringToSend.Add("s2goto0");
                                        AllStringToSend.Add("s3goto0");
                                        AllStringToSend.Add("s4goto0");
                                        StartCoroutine(SendStringsToArduino());

                                        break;


                                }

                                break;



                        }

                        break;

                    case "e":

                        switch (StrFromArduino[1])

                        {

                            case "3":

                                switch (StrFromArduino[2])

                                {

                                    case "5":
                                        if (Step == 6)
                                        {
                                            StartCoroutine(_3_5_3_1sh7());
                                        }

                                        if (Step == 14)
                                        {
                                            StartCoroutine(_3_5_3_1sh15());
                                        }
                                        break;

                                }

                                break;

                            case "4":

                                switch (StrFromArduino[2])

                                {

                                    case "5":
                                        if (Step == 9)
                                        {
                                            sendToArduino("s1goto-6400");
                                        }

                                        if (Step == 13)
                                        {
                                            StartCoroutine(_3_5_3_1sh14());
                                        }
                                        break;

                                    case "10":
                                        if (Step == 16)
                                        {
                                            StartCoroutine(_3_5_3_1sh17());
                                        }
                                        break;

                                }

                                break;

                            

                        }

                        break;


                }


                break;

            case "LM2D2T7PZI10":


                switch (StrFromArduino[0])

                {

                    case "b":

                        switch (StrFromArduino[1])

                        {

                            case "0":

                                switch (StrFromArduino[2])

                                {

                                    case "1":

                                        AllStringToSend.Add("on31");
                                        AllStringToSend.Add("on14");
                                        AllStringToSend.Add("on20");
                                        StartCoroutine(SendStringsToArduino());

                                        break;

                                    case "0":

                                        sendToArduino("off");

                                        break;


                                }

                                break;

                            case "4":

                                switch (StrFromArduino[2])

                                {

                                    case "1":
                                        if (Step == 8) 
                                        {
                                            sendToArduino("on19");
                                        }

                                        if (Step == 14)
                                        {
                                            sendToArduino("off19");
                                        }

                                        if (Step == 16)
                                        {
                                            sendToArduino("on19");
                                        }

                                        if (Step == 33)
                                        {
                                            sendToArduino("off19");
                                        }
                                        break;

                                    case "0":
                                        if (Step == 11)
                                        {
                                            sendToArduino("off19");
                                        }
                                        break;


                                }

                                break;

                            case "5":

                                switch (StrFromArduino[2])

                                {

                                    case "1":
                                        if (Step == 12)
                                        {
                                            sendToArduino("on19");
                                        }
                                        break;


                                }

                                break;

                        }

                        break;

                    


                }


                break;

        }




    }


    private float map(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }


    public void LM3D3T3PZI14()
    {
        if (Step == 0)
        {
            sendToArduino("s1goto70");
        }
    }
    public void LM3D3T3PZI13()
    {
        if (Step == 0)
        {
            sendToArduino("s1goto70");
        }
        if (Step == 16)
        {
            StopCoroutine(_coroutine);
        }
    }
    public void LM3D3T3PZI12()
    {

        if (Step == 0)
        {
            sendToArduino("s1goto70");
        }



    }
    public void LM3D3T3PZI11()
    {

        if (Step == 0)
        {
            sendToArduino("s1goto70");
        }



    }
    public void LM3D3T3PZI1()
    {

        if (Step == 0)
        {
            sendToArduino("s1goto70");
        }


        if (Step == 17)
        {
            sendToArduino("s1goto65");
        }

    }
    public void LM2D2T6PZI1()
    {

        if (Step == 10)
        {
            sendToArduino("off0");
        }

        if (Step == 12)
        {
            sendToArduino("on0");
        }

        if (Step == 17)
        {
            AllStringToSend.Add("off0");
            AllStringToSend.Add("on1");
            AllStringToSend.Add("s3goto50");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 20)
        {
            AllStringToSend.Add("off1");
            AllStringToSend.Add("on2");
            AllStringToSend.Add("s3goto100");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 23)
        {
            AllStringToSend.Add("off2");
            AllStringToSend.Add("on7");
            AllStringToSend.Add("on13");
            AllStringToSend.Add("on15");
            AllStringToSend.Add("s3goto353");
            StartCoroutine(SendStringsToArduino());
        }

    }
    public void LM2D2T6PZI2()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("s2goto146");
            AllStringToSend.Add("s1goto100");
            AllStringToSend.Add("s3goto353");
            AllStringToSend.Add("on7");
            AllStringToSend.Add("on13");
            AllStringToSend.Add("on15");
            StartCoroutine(SendStringsToArduino());
        }


        if (Step == 1)
        {
            AllStringToSend.Add("s3goto404");
            AllStringToSend.Add("off7");
            AllStringToSend.Add("off13");
            AllStringToSend.Add("on8");
            AllStringToSend.Add("on14");
            AllStringToSend.Add("on15");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 4)
        {
            AllStringToSend.Add("s3goto702");
            AllStringToSend.Add("off8");
            AllStringToSend.Add("off14");
            AllStringToSend.Add("on11");
            AllStringToSend.Add("on16");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 7)
        {
            AllStringToSend.Add("off11");
            AllStringToSend.Add("off15");
            AllStringToSend.Add("off16");
            AllStringToSend.Add("on12");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 10)
        {
            AllStringToSend.Add("on13");
            AllStringToSend.Add("on14");
            AllStringToSend.Add("on15");
            AllStringToSend.Add("on16");
            StartCoroutine(SendStringsToArduino());
        }

    }
    public void LM2D2T6PZI5()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("s2goto146");
            AllStringToSend.Add("s1goto100");
            StartCoroutine(SendStringsToArduino());
        }



    }
    public void LM2D2T6PZI6()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("s2goto146");
            AllStringToSend.Add("s1goto100");
            AllStringToSend.Add("on0");
            AllStringToSend.Add("on1");
            AllStringToSend.Add("on2");
            AllStringToSend.Add("on6");
            AllStringToSend.Add("on7");
            AllStringToSend.Add("on8");
            AllStringToSend.Add("on9");
            AllStringToSend.Add("on10");
            StartCoroutine(SendStringsToArduino());
        }



    }
    public void LM2D2T6PZI7()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("s2goto146");
            AllStringToSend.Add("s1goto100");
            StartCoroutine(SendStringsToArduino());
        }



    }
    public void LM2D2T6PZI8()
    {
        if (Step == 14)
        {
            AllStringToSend.Add("on6");
            AllStringToSend.Add("on7");
            AllStringToSend.Add("s3goto50");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 19)
        {
            AllStringToSend.Add("off6");
            AllStringToSend.Add("on8");
            AllStringToSend.Add("s3goto100");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }



    }
    public void LM2D2T6PZI9()
    {

        if (Step == 13)
        {
            AllStringToSend.Add("on6");
            AllStringToSend.Add("on7");
            AllStringToSend.Add("s3goto50");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 17)
        {
            AllStringToSend.Add("off6");
            AllStringToSend.Add("on8");
            AllStringToSend.Add("s3goto100");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 20)
        {
            sendToArduino("s3goto150");
            StartCoroutine(lamp28_on_off());
        }

    }
    public void LM2D2T6PZI10()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("s2goto146");
            AllStringToSend.Add("s1goto100");
            AllStringToSend.Add("s3goto702");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 3)
        {
            sendToArduino("s3goto0");
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 7)
        {
            AllStringToSend.Add("on6");
            AllStringToSend.Add("on7");
            AllStringToSend.Add("s3goto50");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 11)
        {
            AllStringToSend.Add("off6");
            AllStringToSend.Add("on8");
            AllStringToSend.Add("s3goto100");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 15)
        {
            AllStringToSend.Add("off8");
            AllStringToSend.Add("s3goto251");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 19)
        {
            AllStringToSend.Add("on9");
            AllStringToSend.Add("s3goto404");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 23)
        {
            sendToArduino("s3goto702");
            StartCoroutine(lamp28_on_off());
        }

    }
    public void LM2D2T6PZI11()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("s2goto146");
            AllStringToSend.Add("s1goto100");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 4)
        {
            AllStringToSend.Add("on6");
            AllStringToSend.Add("on7");
            AllStringToSend.Add("s3goto50");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 8)
        {
            AllStringToSend.Add("off6");
            AllStringToSend.Add("on8");
            AllStringToSend.Add("s3goto100");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 13)
        {
            AllStringToSend.Add("off8");
            AllStringToSend.Add("s3goto302");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 17)
        {
            AllStringToSend.Add("on9");
            AllStringToSend.Add("s3goto404");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 22)
        {
            sendToArduino("s3goto453");
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 27)
        {
            sendToArduino("s3goto601");
            StartCoroutine(lamp28_on_off());
        }

    }
    public void LM2D2T6PZI12()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("s2goto146");
            AllStringToSend.Add("s1goto100");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 3)
        {
            AllStringToSend.Add("on6");
            AllStringToSend.Add("on7");
            AllStringToSend.Add("s3goto50");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 7)
        {
            AllStringToSend.Add("off6");
            AllStringToSend.Add("on8");
            AllStringToSend.Add("s3goto100");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 12)
        {
            AllStringToSend.Add("off8");
            AllStringToSend.Add("s3goto302");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 16)
        {
            AllStringToSend.Add("on9");
            AllStringToSend.Add("s3goto404");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 21)
        {
            sendToArduino("s3goto452");
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 26)
        {
            sendToArduino("s3goto602");
            StartCoroutine(lamp28_on_off());
        }

    }
    public void LM2D2T6PZI13()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("s2goto146");
            AllStringToSend.Add("s1goto100");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 3)
        {
            AllStringToSend.Add("on6");
            AllStringToSend.Add("on7");
            AllStringToSend.Add("s3goto50");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 7)
        {
            AllStringToSend.Add("off6");
            AllStringToSend.Add("on8");
            AllStringToSend.Add("s3goto201");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 12)
        {
            AllStringToSend.Add("off8");
            AllStringToSend.Add("s3goto353");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 17)
        {
            AllStringToSend.Add("on9");
            AllStringToSend.Add("s3goto453");
            StartCoroutine(SendStringsToArduino());
            StartCoroutine(lamp28_on_off());
        }

        if (Step == 22)
        {
            sendToArduino("s3goto652");
            StartCoroutine(lamp28_on_off());
        }

    }
    public void LM2D2T6PZI14()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("s2goto146");
            AllStringToSend.Add("s1goto100");
            AllStringToSend.Add("s3goto100");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 4)
        {
            sendToArduino("s3goto0");
        }


    }
    public void LM2D2T6PZI15()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("s2goto146");
            AllStringToSend.Add("s1goto100");
            StartCoroutine(SendStringsToArduino());
        }


    }
    public void LM2D2T7PZI3()
    {

        if (Step == 0)
        {
            sendToArduino("on31");
        }


    }
    public void LM2D2T7PZI7()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("on30");
            AllStringToSend.Add("on31");
            StartCoroutine(SendStringsToArduino());
        }


    }
    public void LM2D2T7PZI8()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("on30");
            AllStringToSend.Add("on31");
            StartCoroutine(SendStringsToArduino());
        }


    }
    public void LM2D2T7PZI9()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("on30");
            AllStringToSend.Add("on31");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 3)
        {
            AllStringToSend.Add("on1");
            AllStringToSend.Add("on2");
            AllStringToSend.Add("on6");
            StartCoroutine(LampWait_4s());
        }

    }
    public void LM2D2T7PZI11()
    {

        if (Step == 0)
        {
            sendToArduino("on31");
        }

        if (Step == 4)
        {
            AllStringToSend.Add("off20");
            AllStringToSend.Add("on10");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 6)
        {
            AllStringToSend.Add("off10");
            AllStringToSend.Add("on11");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 8)
        {
            sendToArduino("on10");
        }

        if (Step == 10)
        {
            AllStringToSend.Add("off10");
            AllStringToSend.Add("off11");
            AllStringToSend.Add("on12");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 12)
        {
            sendToArduino("on10");
        }

        if (Step == 14)
        {
            AllStringToSend.Add("off10");
            AllStringToSend.Add("on11");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 16)
        {
            sendToArduino("on10");
        }

        if (Step == 18)
        {
            AllStringToSend.Add("off10");
            AllStringToSend.Add("off11");
            AllStringToSend.Add("off12");
            AllStringToSend.Add("on13");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 20)
        {
            sendToArduino("on10");
        }

        if (Step == 22)
        {
            AllStringToSend.Add("off10");
            AllStringToSend.Add("on11");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 24)
        {
            sendToArduino("on10");
        }

    }
    public void LM2D2T7PZI12()
    {

        if (Step == 8)
        {
            AllStringToSend.Add("off14");
            AllStringToSend.Add("on15");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 10)
        {
            sendToArduino("on14");
        }

        if (Step == 12)
        {
            AllStringToSend.Add("off14");
            AllStringToSend.Add("off15");
            AllStringToSend.Add("on16");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 14)
        {
            sendToArduino("on14");
        }

        if (Step == 16)
        {
            AllStringToSend.Add("off14");
            AllStringToSend.Add("on15");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 18)
        {
            sendToArduino("on14");
        }

        if (Step == 20)
        {
            AllStringToSend.Add("off14");
            AllStringToSend.Add("off15");
            AllStringToSend.Add("off16");
            AllStringToSend.Add("on17");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 22)
        {
            sendToArduino("on14");
        }

        if (Step == 24)
        {
            AllStringToSend.Add("off14");
            AllStringToSend.Add("on15");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 26)
        {
            sendToArduino("on14");
        }

        if (Step == 28)
        {
            AllStringToSend.Add("off14");
            AllStringToSend.Add("off15");
            AllStringToSend.Add("on16");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 30)
        {
            sendToArduino("on14");
        }

        if (Step == 32)
        {
            AllStringToSend.Add("off14");
            AllStringToSend.Add("on15");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 34)
        {
            sendToArduino("on14");
        }

        if (Step == 36)
        {
            AllStringToSend.Add("off14");
            AllStringToSend.Add("off15");
            AllStringToSend.Add("off16");
            AllStringToSend.Add("off17");
            AllStringToSend.Add("on18");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 38)
        {
            sendToArduino("on14");
        }

        if (Step == 40)
        {
            AllStringToSend.Add("off14");
            AllStringToSend.Add("on15");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 42)
        {
            sendToArduino("on14");
        }

        if (Step == 44)
        {
            AllStringToSend.Add("off14");
            AllStringToSend.Add("off15");
            AllStringToSend.Add("on16");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 46)
        {
            sendToArduino("on14");
        }


    }
    public void LM2D2T7PZI13()
    {

        if (Step == 0)
        {
            AllStringToSend.Add("on30");
            AllStringToSend.Add("on31");
            AllStringToSend.Add("on7");
            StartCoroutine(SendStringsToArduino());
        }


    }
    public void LM2D2T8PZI1()
    {
        if (Step == 0)
        {
            sendToArduino("s0goto79");
        }

        if (Step == 1)
        {
            sendToArduino("on4");
        }

    }
    public void LM2D2T8PZI2()
    {
        if (Step == 0)
        {
            sendToArduino("s0goto79");
        }

        if (Step == 3)
        {
            sendToArduino("on4");
        }

        if (Step == 5)
        {
            AllStringToSend.Add("on1");
            AllStringToSend.Add("on3");
            AllStringToSend.Add("s0goto125");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 9)
        {
            AllStringToSend.Add("off1");
            AllStringToSend.Add("off3");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 12)
        {
            AllStringToSend.Add("on0");
            AllStringToSend.Add("on2");
            AllStringToSend.Add("s0goto30");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 16)
        {
            AllStringToSend.Add("off0");
            AllStringToSend.Add("off2");
            StartCoroutine(SendStringsToArduino());
        }


    }
    public void LM2D2T8PZI3()
    {
        if (Step == 0)
        {
            AllStringToSend.Add("on0");
            AllStringToSend.Add("s0goto79");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 5)
        {
            AllStringToSend.Add("on1");
            AllStringToSend.Add("on3");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 20)
        {
            AllStringToSend.Add("off0");
            AllStringToSend.Add("off2");
            StartCoroutine(SendStringsToArduino());
        }


    }
    public void LM3D5T8PZI6()
    {
        if (Step == 0)
        {
            sendToArduino("s0goto76");
        }

        if (Step == 5)
        {
            AllStringToSend.Add("on4");
            AllStringToSend.Add("on0");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 20)
        {
            sendToArduino("off4");
        }

    }
    public void LM3D2T6PZI3()
    {
        if (Step == 4)
        {
            sendToArduino("s0goto10");
        }

        if (Step == 6)
        {
            sendToArduino("s0goto205");
        }

        if (Step == 8)
        {
            sendToArduino("s0goto11");
        }

        if (Step == 10)
        {
            sendToArduino("s0goto205");
        }

        if (Step == 13)
        {
            sendToArduino("s0goto20");
        }

        if (Step == 15)
        {
            sendToArduino("s0goto0");
        }

        if (Step == 18)
        {
            sendToArduino("s0goto20");
        }

        if (Step == 20)
        {
            sendToArduino("s0goto0");
        }

    }
    public void LM3D5T5PZI1()
    {
        if (Step == 14)
        {
            sendToArduino("s0goto202");
        }


    }
    public void LM3D5T5PZI2()
    {
        if (Step == 19)
        {
            sendToArduino("s0goto202");
        }


    }
    public void LM3D4T7PZI1()
    {
        if (Step == 0)
        {
            AllStringToSend.Add("s5goto74");
            AllStringToSend.Add("s6goto74");
            AllStringToSend.Add("s3goto100");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 13)
        {
            AllStringToSend.Add("s5goto100");
            AllStringToSend.Add("s6goto50");
            AllStringToSend.Add("on0");
            AllStringToSend.Add("s0goto141");
            AllStringToSend.Add("s1goto84");
            AllStringToSend.Add("s2goto100");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 14)
        {
            StartCoroutine(_3_4_7_1());
        }
    }
    public void LM3D4T7PZI2()
    {
        if (Step == 0)
        {
            AllStringToSend.Add("s5goto74");
            AllStringToSend.Add("s6goto74");
            AllStringToSend.Add("s3goto100");
            StartCoroutine(SendStringsToArduino());
        }

    }
    public void LM3D4T7PZI3()
    {
        if (Step == 0)
        {
            AllStringToSend.Add("s5goto74");
            AllStringToSend.Add("s6goto74");
            AllStringToSend.Add("s3goto100");
            StartCoroutine(SendStringsToArduino());
        }

        if (Step == 13)
        {
            StopCoroutine(_coroutine);
        }

    }

    public void LM2D2T7PZI10()
    {
        if (Step == 14)
        {
            sendToArduino("111");
        }

        if (Step == 16)
        {
            sendToArduino("222");
        }

    }
}