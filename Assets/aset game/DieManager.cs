using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DieManager : MonoBehaviour {

	public Sprite[] Dice; 
	private bool _isRolling; 
	public float _totalTime; 
	public float _intervalTime; 
	private int _curDie;  
	private int lasNum;
	Image _die; 
	private bool _dieRolled;


	// Use this for initialization
	void Start () {
		_totalTime = 0.0f; 
		_intervalTime = 0.0f; 
		_curDie = 0; 
		_dieRolled = false; 
		_die = GameObject.Find("DieImage").GetComponent<Image>(); 
		_die.sprite = Dice[_curDie];

	}
	
	// Update is called once per frame
	void Update () {
		if (_isRolling){ 
			_intervalTime += Time.deltaTime; 
			_totalTime += Time.deltaTime; 
			if (_intervalTime >= 0.1f) 
			{ 
				//change die 
				_curDie = GetHasilRandom(0,5); 
				//set image to selected die 
				_die.sprite = Dice[_curDie]; 
				_intervalTime -= 0.1f; 
			}
			if (_totalTime >= 2.00f) 
			{  
				_isRolling = false; 
				_dieRolled = false; 
			} 
		} 
	}

	private void Init() {

		_totalTime = 0.0f; 
		_intervalTime = 0.0f; 
		_curDie = 0; 
		_dieRolled = false; 
		_die = GameObject.Find("DieImage").GetComponent<Image>(); 
		_die.sprite = Dice[_curDie];

	}

	public void DieImage_Click(){ 
		if (!_dieRolled) {
			_isRolling = true; 
		}
		_intervalTime = 0;
		_totalTime = 0;
	}

	public int GetHasilRandom(float min, float max)
	{

		int acak = (int)Random.Range(min, max);
		if (lasNum == acak)
			return GetHasilRandom(min, max);
		else
		{
			lasNum = acak;
			return acak;
		}
	} 
}
