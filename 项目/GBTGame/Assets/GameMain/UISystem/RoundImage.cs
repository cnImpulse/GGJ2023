using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundImage : RawImage
{
    public float Radius = 20f;//����Բ�뾶 ͼƬ��һ�������һ��Բ�� �����൱��ͼƬʮ��֮һ�ĳ���

    public int TriangleNum = 6;//ÿ�����������θ��� ����Խ�󻡶�Խƽ��

    protected override void OnPopulateMesh(VertexHelper vh)

    {
        vh.Clear();

        float tw = rectTransform.rect.width;//ͼƬ�Ŀ�

        float th = rectTransform.rect.height;//ͼƬ�ĸ�

        float twr = tw / 2;

        float thr = th / 2;



        if (Radius < 0)

            Radius = 0;

        float radius = tw / Radius;//�뾶������Ҫ��̬����ȷ�����ᱻ����

        if (radius > twr)

            radius = twr;

        if (radius < 0)

            radius = 0;

        if (TriangleNum <= 0)

            TriangleNum = 1;



        UIVertex vert = UIVertex.simpleVert;

        vert.color = color;

        //��߾���

        AddVert(new Vector2(-twr, -thr + radius), tw, th, vh, vert);

        AddVert(new Vector2(-twr, thr - radius), tw, th, vh, vert);

        AddVert(new Vector2(-twr + radius, thr - radius), tw, th, vh, vert);

        AddVert(new Vector2(-twr + radius, -thr + radius), tw, th, vh, vert);

        vh.AddTriangle(0, 1, 2);

        vh.AddTriangle(0, 2, 3);

        //�м����

        AddVert(new Vector2(-twr + radius, -thr), tw, th, vh, vert);

        AddVert(new Vector2(-twr + radius, thr), tw, th, vh, vert);

        AddVert(new Vector2(twr - radius, thr), tw, th, vh, vert);

        AddVert(new Vector2(twr - radius, -thr), tw, th, vh, vert);

        vh.AddTriangle(4, 5, 6);

        vh.AddTriangle(4, 6, 7);

        //�ұ߾���

        AddVert(new Vector2(twr - radius, -thr + radius), tw, th, vh, vert);

        AddVert(new Vector2(twr - radius, thr - radius), tw, th, vh, vert);

        AddVert(new Vector2(twr, thr - radius), tw, th, vh, vert);

        AddVert(new Vector2(twr, -thr + radius), tw, th, vh, vert);

        vh.AddTriangle(8, 9, 10);

        vh.AddTriangle(8, 10, 11);



        List<Vector2> CirclePoint = new List<Vector2>();//Բ���б�

        Vector2 pos0 = new Vector2(-twr + radius, -thr + radius);//���½�Բ��

        Vector2 pos1 = new Vector2(-twr, -thr + radius);//�����״���ת����ĵ�

        Vector2 pos2;

        CirclePoint.Add(pos0);

        CirclePoint.Add(pos1);

        pos0 = new Vector2(-twr + radius, thr - radius);//���Ͻ�Բ��

        pos1 = new Vector2(-twr + radius, thr);

        CirclePoint.Add(pos0);

        CirclePoint.Add(pos1);

        pos0 = new Vector2(twr - radius, thr - radius);//���Ͻ�Բ��

        pos1 = new Vector2(twr, thr - radius);

        CirclePoint.Add(pos0);

        CirclePoint.Add(pos1);

        pos0 = new Vector2(twr - radius, -thr + radius);//���½�Բ��

        pos1 = new Vector2(twr - radius, -thr);

        CirclePoint.Add(pos0);

        CirclePoint.Add(pos1);

        float degreeDelta = (float)(Mathf.PI / 2 / TriangleNum);//ÿһ�ݵ��������εĽǶ� Ĭ��6��

        List<float> degreeDeltaList = new List<float>() { Mathf.PI, Mathf.PI / 2, 0, (float)3 / 2 * Mathf.PI };



        for (int j = 0; j < CirclePoint.Count; j += 2)

        {

            float curDegree = degreeDeltaList[j / 2];//��ǰ�ĽǶ�

            AddVert(CirclePoint[j], tw, th, vh, vert);//��������������������ι�������

            int thrdIndex = vh.currentVertCount;//��ǰ�����εڶ���������

            int TriangleVertIndex = vh.currentVertCount - 1;//һ�����α��ֲ���Ķ�������

            List<Vector2> pos2List = new List<Vector2>();

            for (int i = 0; i < TriangleNum; i++)

            {

                curDegree += degreeDelta;

                if (pos2List.Count == 0)

                {

                    AddVert(CirclePoint[j + 1], tw, th, vh, vert);

                }

                else

                {

                    vert.position = pos2List[i - 1];

                    vert.uv0 = new Vector2(pos2List[i - 1].x + 0.5f, pos2List[i - 1].y + 0.5f);

                }

                pos2 = new Vector2(CirclePoint[j].x + radius * Mathf.Cos(curDegree), CirclePoint[j].y + radius * Mathf.Sin(curDegree));

                AddVert(pos2, tw, th, vh, vert);

                vh.AddTriangle(TriangleVertIndex, thrdIndex, thrdIndex + 1);

                thrdIndex++;

                pos2List.Add(vert.position);

            }

        }

    }

    protected Vector2[] GetTextureUVS(Vector2[] vhs, float tw, float th)

    {

        int count = vhs.Length;

        Vector2[] uvs = new Vector2[count];

        for (int i = 0; i < uvs.Length; i++)

        {

            uvs[i] = new Vector2(vhs[i].x / tw + 0.5f, vhs[i].y / th + 0.5f);//���ε�uv����  ��Ϊuv����ԭ�������½ǣ�vh����ԭ�������� ���������0.5��uvȡֵ��Χ0~1��

        }

        return uvs;

    }

    protected void AddVert(Vector2 pos0, float tw, float th, VertexHelper vh, UIVertex vert)

    {

        vert.position = pos0;

        vert.uv0 = GetTextureUVS(new[] { new Vector2(pos0.x, pos0.y) }, tw, th)[0];

        vh.AddVert(vert);

    }
}
