using UnityEngine;
using System.Collections;

public class HeroControl : Character {

	//mAnimator를 선언.
	private Animator mAnimator;



	//공격 데미지 (현제는 걍 데미지만.. 나중에 공격력이랑 수정 필요)
	public int mOrinAttackPower;
	[HideInInspector]
	public int mAttackPower;

	//공속 
	public float mAttackSpeed;

	//스킬 쿨타임.
	public float mSkillSpeed;

	//히어로의 터겟 넘버.
	public int mHeroTargetNumber;

	public bool mHeroSingleTargeted;


	void Start () {

		//1.HP 넣고, 2. 백그라운드 컴퍼넌트 넣고, 3. 활이 발사될 장소를 넣고. 스타트
		mHP = mOrinHP;
		mAttackPower = mOrinAttackPower;

		hptext.text = mHP.ToString ();

		mHeroTargetNumber = 1;
		mHeroSingleTargeted = true;

		mAnimator = gameObject.GetComponent<Animator> ();

	
	}
	//상테와 파라메터를 통해 아처의 상태를 컨트롤 합니다.
	public void SetStatus(Status status)
	{
		//animator 에서 만든 상태 간 전이를 상황에 맞게 호출 한다.
		switch (status) {
		case Status.Idle:
			mAnimator.SetTrigger("Idle");
			Debug.Log("idle---");
			break;
			
		case Status.Attack:
			mAnimator.SetTrigger("Basic_Attack");
			Debug.Log("Attack---");
			break;
			
		case Status.Dead:
			mAnimator.SetTrigger("Dead");
			Debug.Log("Die---");
			break;
			
		case Status.Damaged:
			mAnimator.SetTrigger("Damaged");
			Debug.Log("Damage---");
			break;

		case Status.UseSkill:
			mAnimator.SetTrigger("Skill01");
			Debug.Log("Skill---");
			break;

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AttackTest(){
		mAnimator.SetTrigger("Attack");
	}

	public void DamagedTest(int damage){
		mAnimator.SetTrigger("Damaged");
		
		Debug.Log ("hitted --> "+gameObject.name);
		
		saveDamageTextForShow = damage;
		mIn_GameManager.mIngTextMassage.text = "적에게 데미지:" + saveDamageTextForShow + "를 주었다.";
		
		hptext.text = mHP.ToString ();
		Debug.Log ("last hp ="+mHP);
		
	}

	public int GetRandomDamage(){
		return mAttackPower + Random.Range(-10, 10);
	}

	//데미지 처리..
	public void heroAttackedMonsterNormal(int damage){

		mHP -= damage;

		hptext.text = mHP.ToString ();



		if (mHP > 0) {
			mAnimator.SetTrigger("Damaged");
		}

		if (mHP <= 0) {
			mAnimator.SetTrigger("Dead");
			mStatus = Status.Dead;
			mHP = 0;
			hptext.text = "Dead";
			mHeroSingleTargeted = false;
			mIn_GameManager.GameOver();

		}
	}
}






































