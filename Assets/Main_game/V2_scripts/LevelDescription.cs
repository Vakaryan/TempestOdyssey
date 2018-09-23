using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Data
{
using System.Xml.Serialization;

[XmlRoot("LevelDescription")]
[XmlType("LevelDescription")]


public class LevelDescription {
	
		[XmlAttribute]
		public float Duration { get; set; }
	
		[XmlElement("EnemyDescription", typeof(EnemyDescription))]
		public EnemyDescription[] Enemies { get; private set; }

		[XmlElement]
		public string Scene { get; set; }

		[XmlAttribute]
		public string Name { get; set; }
	}
}
