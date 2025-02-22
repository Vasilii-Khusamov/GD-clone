using System;
using Unity.VisualScripting;
using UnityEngine;

namespace LevelManager
{
    public class ObjectSerializer
    {
        public ObjectSerializer()
        {
        
        }
    
        
        public string SerializeObject(GameObject obj)
        {
            string objectType = GetPrefabName(obj);
            string objectName = obj.name;
            string objectParent = obj.GetComponentInParent<Transform>().gameObject.name;
            Vector3 objectPosition = obj.transform.position;
            Quaternion objectRotation = obj.transform.rotation;
            Vector3 objectScale = obj.transform.localScale;
            String objectString = "";

            if (objectName == objectParent) objectParent = "";

            objectString += (
                SerializeProperty("type", objectType)
                + SerializeProperty("Name", objectName)
                + SerializeProperty("Parent", objectParent)
                + SerializeProperty("posX", objectPosition.x.ToString())
                + SerializeProperty("posY", objectPosition.y.ToString())
                + SerializeProperty("posZ", objectPosition.z.ToString())
                + SerializeProperty("rotX", objectRotation.x.ToString())
                + SerializeProperty("rotY", objectRotation.y.ToString())
                + SerializeProperty("rotZ", objectRotation.z.ToString())
                + SerializeProperty("rotW", objectRotation.w.ToString())
                + SerializeProperty("scaleX", objectScale.x.ToString())
                + SerializeProperty("scaleY", objectScale.y.ToString())
                + SerializeProperty("scaleZ", objectScale.z.ToString())
            );

            return objectString;
        }

        private string GetPrefabName(GameObject obj)
        {
            var prefabDefinition = obj.GetPrefabDefinition();
            if (prefabDefinition is null)
            {
                throw new Exception("У объекта должен быть префаб!");
            }
        
            return prefabDefinition.name;
        }

        private string SerializeProperty(string name, string value)
        {
            if (value == "0" || value == "") return ""; 
            return name + ";" + value + ";";
        }
    }
}