using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksBilder : MonoBehaviour
{
    [SerializeField] private float distanceToBild, speedStage;
    [SerializeField] private GameObject[] bricks;
    [SerializeField] private Transform respawnBriks;
    [SerializeField] private TextureScroll[] wallScrollTexture;
    private float _currenSpeed;
    private List<BricksController> _brContList = new List<BricksController>();
    private int iBricks = 0;

    void Start()
    {       
        DeadZone._deadZ += Dead;
        CanvasController._stageUp += StageUp;
       // CreateBriks();
        _currenSpeed = speedStage;
    }

    // Update is called once per frame
    void Update()
    {
        if (_brContList.Count > 0 && (respawnBriks.position.x - _brContList[_brContList.Count-1]._thisTR.position.x) > distanceToBild)
        {
            CreateBriks();
        }

        ScrollWall();
    }

    private void ScrollWall()
    {
        for (int i =0; i < wallScrollTexture.Length; i++)
        {
            wallScrollTexture[i].Scroll(speedStage, Time.deltaTime);
        }
        if (_brContList.Count>0)
        {
            for (int i=0; i < _brContList.Count; i++)
            {
                _brContList[i].Moved(3.7f * speedStage, Time.deltaTime);
                if (_brContList[i]._thisTR.position.x < -7f)
                {
                    _brContList[i].Destroy();
                    DeletList(i);
                    i--;
                }
            }
        }
    }

    public void CreateBriks()
    {
        GameObject obj = Instantiate(bricks[iBricks]);
        BricksController bCOBJ = obj.AddComponent<BricksController>();
        _brContList.Add(bCOBJ);
        obj.transform.position = respawnBriks.position;
        bCOBJ.UpdateY();      
        
    }

    public void DeletList(int bC)
    {       
        _brContList.RemoveAt(bC);
    }   

   

    public void Dead()
    {        
        for (int i = 0; i < _brContList.Count; i++)
        {
            Destroy(_brContList[i].transform.gameObject);
            DeletList(i);
            i--;
        }
        enabled = false;
    }

    public void StageUp()
    {
        if (iBricks < bricks.Length-1)
        {
            iBricks++;
        }
        else
        {
            _currenSpeed -= 0.05f;
        }
    }

    public void NewGame()
    {
        _currenSpeed = speedStage;
        iBricks = 0;
        CreateBriks();
    }
}
