using UnityEngine;
using System.Collections;

public class Setting : Singleton<Setting>
{
	public float backgroundScale = 1.0f;
	// 0 england,1 usa
	public int language;
	// 0 easy,1 mid,2 hard
	public int difficulty;

	public int gameLevel;
	//

	public int gameScore;
	public int previousGameScore;

	protected Setting ()
	{
	}
}