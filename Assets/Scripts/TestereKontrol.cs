using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TestereKontrol : MonoBehaviour {
    public float TestereHiz = 5f;
    public GameObject deneme;

    GameObject[] gidilecekNoktalar;
    bool aradakiMesafeyiBirkereAl = true;
    bool ilerimiGerimi = true;
    Vector3 aradakiMesafe;
    int aradakiMesafeSayaci = 0;

    void Start()
    {
        gidilecekNoktalar = new GameObject[transform.childCount];

        for (int i = 0; i < gidilecekNoktalar.Length; i++)
        {
            gidilecekNoktalar[i] = transform.GetChild(0).gameObject;
            gidilecekNoktalar[i].transform.SetParent(transform.parent);
        }
    }


    void FixedUpdate()
    {

        transform.Rotate(0, 0, 5);
        noktalaraGit();

    }

    void noktalaraGit()
    {
        if (aradakiMesafeyiBirkereAl)
        {
            aradakiMesafe = (gidilecekNoktalar[aradakiMesafeSayaci].transform.position - transform.position).normalized;
            aradakiMesafeyiBirkereAl = false;
        }
        float mesafe = Vector3.Distance(transform.position, gidilecekNoktalar[aradakiMesafeSayaci].transform.position);
        transform.position += aradakiMesafe * Time.deltaTime * TestereHiz;

        if (mesafe < 0.5)
        {
            aradakiMesafeyiBirkereAl = true;
            if (aradakiMesafeSayaci == gidilecekNoktalar.Length - 1)
            {
                ilerimiGerimi = false;
            }
            else if (aradakiMesafeSayaci == 0)
            {
                ilerimiGerimi = true;
            }
            if (ilerimiGerimi)
            {
                aradakiMesafeSayaci++;
            }
            else
            {
                aradakiMesafeSayaci--;
            }


        }

    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.GetChild(i).transform.position, 1);

        }

        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.GetChild(i).transform.position, transform.GetChild(i + 1).transform.position);

        }
    }
#endif



#if UNITY_EDITOR
    [CustomEditor(typeof(TestereKontrol))]
    [System.Serializable]

    class testereEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            TestereKontrol script = (TestereKontrol)target;
            if (GUILayout.Button("ÜRET", GUILayout.MinWidth(100), GUILayout.Width(100)))
            {
                GameObject yeniObje = new GameObject();
                yeniObje.transform.parent = script.transform;
                yeniObje.transform.position = script.transform.position;
                yeniObje.name = script.transform.childCount.ToString();
            }
            EditorGUILayout.PropertyField(serializedObject.FindProperty("TestereHiz"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("deneme"));
            serializedObject.ApplyModifiedProperties();
            serializedObject.Update();
        }
    }
#endif








}
