using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //Scene 관련 기능을 사용한다. 그리고 그 뒤는 생략을 명시

public class UIManager : MonoBehaviour//(Mono~: 이 클래스가 유니티 엔진에 있는것들을 상속한다.)
{
    public void PlayGame()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR    //전처리기: 컴파일 전 미리 기능이 정해져있다.
        UnityEditor.EditorApplication.isPlaying = false;
        //유니티에서 편집중인 상태에 종료

#else   //빌드에서 종료
    Application.Quit();

#endif
    }
}
