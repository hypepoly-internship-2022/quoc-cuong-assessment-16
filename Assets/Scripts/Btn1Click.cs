using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Btn1Click : MonoBehaviour
{

    [SerializeField] private Transform cube1;
    [SerializeField] private Transform cube2;
    [SerializeField] private float timeMoveCube1;
    [SerializeField] private float timeScaleCube2;
    [SerializeField] private Button button2;

    private Vector3 cube2Pos;
    private Vector3 cube2Scale;

    // Start is called before the first frame update
    private void Start()
    {
        cube2Pos = cube2.position;
        cube2Scale = cube2.localScale;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void tweenAction()
    {
        cube1.DOMove(new Vector3(cube2Pos.x + 3, cube2Pos.y + 3, 0), timeMoveCube1).SetEase(Ease.InOutSine).OnComplete(() => {
            cube1.DOMove(new Vector3(cube2Pos.x, cube2Pos.y, 0), 2).SetEase(Ease.InOutSine).OnComplete(() => {
                cube2.DOScale(cube2Scale * 2, timeScaleCube2).SetEase(Ease.InOutSine).OnComplete(() => {
                    cube2.DOScale(cube2Scale, 2).SetEase(Ease.InOutSine).OnComplete(() => {
                        button2.GetComponent<Button>().interactable = false;
                        this.GetComponent<Image>().DOFade(0, 2f);
                        button2.GetComponent<Image>().DOFade(0, 2f);
                    });
                });
            });
        });
    }

    public void OnclickButton1()
    {
        this.GetComponent<Button>().interactable = false;
        tweenAction();
    }
}
