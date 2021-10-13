////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Filename:       ScoreScript.cs
/// Author:         Chris Johnson
/// Date Created:   12/10/2021
/// Brief:  All functions relating to the score
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// All functions relating to the score
/// </summary>
public class ScoreScript : MonoBehaviour
{
    //SerializeFields
    [SerializeField]
    GameObject UIfootballPrefab;
    [SerializeField]
    GameObject UICrossPrefab;
    [SerializeField]
    GameObject UITickPrefab;

    [SerializeField]
    private int m_shotsMax = 5;

    //private
    private int m_shots;
    private int m_goalsScored;

    private GameObject[] UI_FootBall;
    private GameObject[] UI_Tick;
    private GameObject[] UI_Cross;

    //public
    #region gets/sets

    public int Shots
    {
        get { return m_shots; }
    }
    public int GoalsScored
    {
        get { return m_goalsScored; }
        
    }
    #endregion

    /// <summary> - Call this on goal score - 
    /// update stored score and displayed score
    /// </summary>
    public void GoalScored()
    {
        m_shots++;
        m_goalsScored++;

        UI_Cross[m_shots].SetActive(false);
        UI_Tick[m_shots].SetActive(true);

    }

    /// <summary>
    /// 
    /// </summary>
    public void GoalMissed()
    {
        m_shots++;

        UI_Cross[m_shots].SetActive(true);
        UI_Tick[m_shots].SetActive(false);

    }

    /// <summary>
    /// 
    /// </summary>
    public void ResetScore()
    {
        m_shots = 0;
        foreach (GameObject go in UI_Cross)
        {
            go.SetActive(false);
        }
        foreach (GameObject go in UI_Tick)
        {
            go.SetActive(false);
        }
    }


    // Start is called before the first frame update
    void Start()
    {

        UI_FootBall = new GameObject[m_shotsMax];
        UI_Cross = new GameObject[m_shotsMax];
        UI_Tick = new GameObject[m_shotsMax];

        //Instantiate all of the score ui elements
        for (int i = 0; i < m_shotsMax; i++)
        {
            UI_FootBall[i] = Instantiate(UIfootballPrefab, new Vector3(10+i*20, 15, 0), Quaternion.identity);
            UI_FootBall[i].transform.SetParent(gameObject.transform);
            UI_FootBall[i].SetActive(false);

            UI_Cross[i] = Instantiate(UICrossPrefab, new Vector3(10 + i * 20, 15, 0), Quaternion.identity);
            UI_Cross[i].transform.SetParent(gameObject.transform);
            UI_Cross[i].SetActive(false);

            UI_Tick[i] = Instantiate(UITickPrefab, new Vector3(10 + i * 20, 15, 0), Quaternion.identity);
            UI_Tick[i].transform.SetParent(gameObject.transform);
            UI_Tick[i].SetActive(false);
        }

        //temp set active
        //needs to be moved later
        foreach(GameObject go in UI_FootBall)
        {
            go.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}