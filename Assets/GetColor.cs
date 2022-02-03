using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
[RequireComponent(typeof(BoxCollider2D))]
public class GetColor : MonoBehaviour
{
    public Sprite s;
    Image i2;
    Texture2D t;
    public Color c;
    public Color temp;
    Vector3 mpos;
    float sizeX = 0;
    float sizeY = 0;
    Vector3 pos;
    Camera cam;
    public TextMeshProUGUI text;
    public TextMeshProUGUI text2;
    // Start is called before the first frame update
    private void Awake()
    {
        i2 = GetComponent<Image>();
        sizeX = Screen.width;
        sizeY = Screen.height;
        cam = Camera.main;
        sosumaker.Sosu4ch s = new sosumaker.Sosu4ch();
        for (int i = 0; i < 100; i++)
        {
            s.MakeNum(sosumaker.Sosu4ch.Level.hard1);
        }

    }
    IEnumerator Start()
    {
        //이미지 쉐이더로 변할수있을경우 사용

        //string path = AssetDatabase.GetAssetPath(s);
        //TextureImporter A = (TextureImporter)AssetImporter.GetAtPath(path);
        //A.isReadable = true;
        //AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);

        t = new Texture2D((int)s.rect.width, (int)s.rect.height);
        Rect rect = new Rect(0, 0, t.width, t.height);
        t = textureFormSprite(s);
        yield return new WaitForEndOfFrame();
        //bool b = false;
        //for (int y = 0; y < t.height; y++)
        //{
        //    for (int x = 0; x < t.width; x++)
        //    {

        //        c = t.GetPixel(x, y);
        //        if (c == temp)
        //            b = true;
        //    }
        //}
        //A.isReadable = false;
        i2.sprite = Sprite.Create(t, rect, new Vector2(0.5f, 0.5f));
        i2.SetNativeSize();
        i2.GetComponent<BoxCollider2D>().size = new Vector2(i2.GetComponent<RectTransform>().sizeDelta.x, i2.GetComponent<RectTransform>().sizeDelta.y);
        s = i2.sprite;
        //Texture2D t = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        //yield return new WaitForEndOfFrame();
        //t.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        //t.Apply();
        //c = Color.white;
        //bool b = false;
        ////추출된 색
        //for (int y = 0; y < t.height; y++)
        //{
        //    for (int x = 0; x < t.width; x++)
        //    {
        //        c = t.GetPixel(x, y);
        //        if (c == Color.black)
        //            b = true;

        //    }
        //}
        //Debug.Log(b);

    }
    IEnumerator A()
    {

        t = new Texture2D((int)s.rect.width, (int)s.rect.height);
        Rect rect = new Rect(0, 0, t.width, t.height);
        t = textureFormSprite2(s);
        yield return new WaitForEndOfFrame();
        //bool b = false;
        //for (int y = 0; y < t.height; y++)
        //{
        //    for (int x = 0; x < t.width; x++)
        //    {

        //        c = t.GetPixel(x, y);
        //        if (c == temp)
        //            b = true;
        //    }
        //}
        i2.sprite = Sprite.Create(t, rect, new Vector2(0.5f, 0.5f));
        i2.SetNativeSize();
        i2.GetComponent<BoxCollider2D>().size = new Vector2(i2.GetComponent<RectTransform>().sizeDelta.x, i2.GetComponent<RectTransform>().sizeDelta.y);
        s = i2.sprite;
        yield break;
    }
    private void Update()
    {
        mpos = Input.mousePosition;
        pos = new Vector3(this.transform.localPosition.x + (sizeX / 2), this.transform.localPosition.y + (sizeY / 2));
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Ray2D ray = new Ray2D(wp, Vector2.zero);

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null)
            {
                if (hit.transform.name == this.transform.name)
                {
                    StartCoroutine(A());
                }
            }
        }
    }
    public Texture2D textureFormSprite(Sprite sprite)
    {
        //if (sprite.rect.width != sprite.rect.width)
        //{

        Texture2D newText = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
        Color[] newColors = sprite.texture.GetPixels((int)sprite.textureRect.x, (int)sprite.textureRect.y,
            (int)sprite.textureRect.width, (int)sprite.textureRect.height);

        //for (int i = 0; i < newColors.Length; i++)
        //{
        //    if (newColors[i].a != 0)
        //        newColors[i] = Color.yellow;
        //}

        //float width = (int)sprite.rect.width;
        //float height = (int)sprite.rect.height;
        //for (int i = 0; i < newColors.Length / 2; i++)
        //{
        //    if (newColors[i].a != 0)
        //        newColors[i] = Color.yellow;
        //}

        //for (int i=0;i< width / 2;i++)
        //{
        //    for(int y=0;y< height/2;y++)
        //    {
        //        newColors[i+(y*i)] = Color.black;
        //    }
        //}
        newText.SetPixels(newColors);
        newText.Apply();

        return newText;
        //}
        //else
        //    return sprite.texture;
    }
    public Texture2D textureFormSprite2(Sprite sprite)
    {
        //if (sprite.rect.width != sprite.rect.width)
        //{

        Texture2D newText = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
        Color[] newColors = sprite.texture.GetPixels((int)sprite.textureRect.x, (int)sprite.textureRect.y,
            (int)sprite.textureRect.width, (int)sprite.textureRect.height);
        //for (int i = 0; i < newColors.Length; i++)
        //{
        //    if (newColors[i].a != 0)
        //        newColors[i] = Color.yellow;
        //}
        float width = (int)sprite.rect.width;
        float height = (int)sprite.rect.height;
        int px = ((int)width / 2) + ((int)mpos.x - (int)pos.x);
        
        int py = ((int)height / 2) + ((int)mpos.y - (int)pos.y);
        //if (newColors[(py * (int)width) + px].a != 0)
        //{
        //    if (newColors[(py * (int)width) + px] != c)
        //    {
        //        newColors[(py * (int)width) + px] = c;
        //    }
        //}

        for (int i = 0; i < px; i++)
        {
            for (int y = 0; y < py; y++)
            {

                if (newColors[(y * (int)width) + i].a != 0)
                {
                    if (newColors[(y * (int)width) + i] != c)
                    {
                        newColors[(y * (int)width) + i] = c;
                    }
                }
            }
        }
        newText.SetPixels(newColors);
        newText.Apply();

        return newText;
        //}
        //else
        //    return sprite.texture;
    }
    // Update is called once per frame
}