using UnityEngine;
using System.Collections;

public class Setting : Singleton<Setting>
{
	public float backgroundScale = 1.0f;
	public int language;
	public int difficulty;

	protected Setting ()
	{
	}
}