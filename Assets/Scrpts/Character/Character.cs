using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	public In_GameManager mIn_GameManager;
	
	//mAnimator를 선언.
	private Animator mAnimator;
	
	//히어로 의 공격력, 채력, 공격 속도에 사용 될 변수.
	// HP
	public int mOrinHP;
	[HideInInspector]
	public int mHP;

	//MANA
	public int mOrinMP;
	[HideInInspector]
	public int mMP;


	//데미지 표시..
	[HideInInspector]
	public int saveDamageTextForShow;

	public TextMesh hptext;

	//히어로 의 상태 (대기, 달림, 공격, 사망)
	public enum Status
	{
		Idle,
		Attack,
		Damaged,
		UseSkill,
		Dead
	}
	
	//public으로 선언 되었지만, 인스팩터 뷰에서 노출되지 않기를 원하는 경우
	//hideinspector를 선언합니다.
	[HideInInspector]
	public Status mStatus = Status.Idle; //히이로의 기본상태를 idle로 설정.
	

}
