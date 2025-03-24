using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using Newtonsoft.Json;
using System;

public class ItemDataLoader : MonoBehaviour
{
    [SerializeField]
    private string jsonFileName = "items";

    private List<ItemData> itemList;
    // Start is called before the first frame update
    void Start()
    {
        LoadItemData();
    }

    // Update is called once per frame

    void LoadItemData()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>(jsonFileName);

        if (jsonFile != null)
        {
            //원본 텍스트에서 UTF-8로 변한 처리
            byte[] bytes = Encoding.Default.GetBytes(jsonFile.text);
            string correntText = Encoding.UTF8.GetString(bytes);

            //변환된 텍스트 사용
            itemList = JsonConvert.DeserializeObject<List<ItemData>>(correntText);

            Debug.Log($"로드된 아이템 수 : {itemList.Count}");

            foreach (var item in itemList)
            {
                Debug.Log($"아이템: {EncodeKorean(item.itemName)}, 설명 : {EncodeKorean(item.description)}");
            }

        }
        else
        {
            Debug.LogError($"JSON 파일을 찾을 수 없습니다. : {jsonFileName}");
        }
    }
    //한글 이코딩을 위한 헬퍼 함수

    private string EncodeKorean(string text)
    {
        if (string.IsNullOrEmpty(text)) return "";
        byte[] bytes = Encoding.Default.GetBytes(text);
        return Encoding.UTF8.GetString(bytes);
    }
}


