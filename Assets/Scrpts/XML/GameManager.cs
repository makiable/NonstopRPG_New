using UnityEngine;
using System.Collections;
using System.Xml;
using System.IO; 
using System;

public class GameManager : MonoBehaviour {

	public string _filename = "xml_Test_01";

	// Use this for initialization
	void Start () {
		Xml_Load (_filename);
		UpdateXml ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//읽어오기..
	void Xml_Load(string filename){

		string filepath = Application.dataPath+"/Resources/xml_Test_01.xml";

		if (File.Exists (filepath)) {
			Debug.Log ("file exist");

			TextAsset textAsset = (TextAsset)Resources.Load (filename);
			XmlDocument xmldoc = new XmlDocument ();
			xmldoc.LoadXml (textAsset.text);
			//xml 생성.

			//각 요소 별로 가져오기.
			XmlNodeList KillCount = xmldoc.GetElementsByTagName ("MONSTERKILLCOUNT");
			int killcount = int.Parse (KillCount [0].InnerText);
			int killcount2 = int.Parse (KillCount [1].InnerText);
			Debug.Log ("1=" + killcount + ", 2=" + killcount2);


			//각 요소 별로 가져오기.
			XmlNodeList name = xmldoc.GetElementsByTagName ("NAME");
			string name01 = name [0].InnerText;
			string name02 = name [1].InnerText;
			Debug.Log ("name01 = " + name01 + "name02 = " + name02);

			//전체 가져오기..
			XmlNodeList nodes = xmldoc.SelectNodes ("dataroot/Node");

			//string s = "";

			foreach (XmlNode node in nodes) {
				Debug.Log ("ID: " + node.SelectSingleNode ("ID").InnerText);
				Debug.Log ("NAME: " + node.SelectSingleNode ("NAME").InnerText);
				Debug.Log ("LEVEL: " + node.SelectSingleNode ("LEVEL").InnerText);
				Debug.Log ("GOLD: " + node.SelectSingleNode ("GOLD").InnerText);
				Debug.Log ("MONSTERKILLCOUNT: " + node.SelectSingleNode ("MONSTERKILLCOUNT").InnerText);

			}
		} else
			Debug.Log ("file not exist");

	}



	public void UpdateXml()
	{

		string filepath = Application.dataPath+"/Resources/xml_Test_01.xml";
		
		if (File.Exists (filepath)) {
			Debug.Log ("file exist");
			
			TextAsset textAsset = (TextAsset)Resources.Load (_filename);
			//xmlDoc.Load(filepath); 이렇게 해도 된다..

			//임시 사용할 파일 을 새로 생성.
			XmlDocument xmldoc = new XmlDocument ();
			xmldoc.LoadXml (textAsset.text);
			//xml 생성.


			//transforms 아래 모든 하위 노드 받다
			XmlNodeList nodeList = xmldoc.SelectNodes("dataroot/Node");
			//XmlNodeList nodeList = xmldoc.SelectSingleNode("Node").ChildNodes;

			//사이를 옮겨다니기 모든 하위 노드
			foreach(XmlElement xe in nodeList)
			{
				//받은 노드 중 속성 ID =1 있는 노드
				if(xe.GetAttribute("id")=="1")
				{
					//업데이트 노드 속성
					xe.SetAttribute("id","1000");
					//계속 사이를 옮겨다니기
					foreach(XmlElement x1 in xe.ChildNodes)
					{
						if(x1.Name=="GOLD")
						{
							//여기가 수정 노드 이름 대응 수만은 때문에 위의 받은 노드 연대 속성. . .
							x1.InnerText="10000";


						}
						
					}
					break;
				}
			}
			xmldoc.Save(filepath);
			Debug.Log("UpdateXml OK!");
		}
		
	}



}
