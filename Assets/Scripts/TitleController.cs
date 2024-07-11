using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class TitleController : MonoBehaviour
{
    [SerializeField] private Text pressText;       // 깜빡거릴 PressText 컴포넌트
    [SerializeField] private float fadingInterval; // 깜빡거릴 시간 간격
    private float elapsedTime;                     // 진행시간
    private bool isFadeIn = false;                 // FadeIn 중 인지?

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (isFadeIn)
        {
            float alpha = Mathf.Lerp(0.0f, 1.0f, elapsedTime / fadingInterval);
            SetTextAlpha(alpha);

            if (elapsedTime > fadingInterval)
            {
                isFadeIn = false;
                elapsedTime = 0.0f;
            }
        }
        else
        {
            float alpha = Mathf.Lerp(1.0f, 0.0f, elapsedTime / fadingInterval);
            SetTextAlpha(alpha);

            if (elapsedTime > fadingInterval)
            {
                isFadeIn = true;
                elapsedTime = 0.0f;
            }
        }
    }

    // Text의 투명도를 변경해주는 메서드
    private void SetTextAlpha(float alpha)
    {
        Color color = pressText.color;
        color.a = alpha;
        pressText.color = color;
    }

    // 메인화면을 로드하는 메서드
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main");
    }
}
