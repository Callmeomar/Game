using UnityEngine;
using System.Collections;

public class SwordSwing : MonoBehaviour 
{
	public bool clockwiseRotate = false; 
	public bool antiClockwiseRotate = false;
	public float degreesPerSecond;
	public float rotationAmount = 95.0f;
	public float totalRotation = 0;

	public Player player;
	public bool isSwinging = false;

	void Update () 
	{
		if (clockwiseRotate == true)
		{
			if(Mathf.Abs(totalRotation) < Mathf.Abs(rotationAmount))
			{
				RotateClockwise();
				isSwinging = true;
			}
			else
			{
				clockwiseRotate = false;
				totalRotation = 0;
				player.swingUsed = false;
				isSwinging = false;

				if (player.facingRight == true)
				{
					player.bodyPivot.transform.rotation = Quaternion.Euler (0, 0, 0);
				}
				else
				{
					player.bodyPivot.transform.rotation = Quaternion.Euler (0, 180, 0);
				}
			}
		}

		if (antiClockwiseRotate == true)
		{
			if(Mathf.Abs(totalRotation) < Mathf.Abs(rotationAmount))
			{
				RotateAntiClockwise();
				isSwinging = true;
			}
			else
			{
				antiClockwiseRotate = false;
				totalRotation = 0;
				player.swingUsed = true;
				isSwinging = false;

				if (player.facingRight == true)
				{
				player.bodyPivot.transform.rotation = Quaternion.Euler (0, 90, 0);
				}
				else
				{
					player.bodyPivot.transform.rotation = Quaternion.Euler (0, 270, 0);
				}
			}
		}
	}

	void RotateClockwise()
	{
		float currentAngle = transform.rotation.eulerAngles.y;
		transform.rotation = Quaternion.AngleAxis(currentAngle + (Time.deltaTime * degreesPerSecond), Vector3.up);
		totalRotation += Time.deltaTime * degreesPerSecond;
	}

	void RotateAntiClockwise()
	{
		float currentAngle = transform.rotation.eulerAngles.y;
		transform.rotation = Quaternion.AngleAxis(currentAngle - (Time.deltaTime * degreesPerSecond), Vector3.up);
		totalRotation += Time.deltaTime * degreesPerSecond;
	}

	public void Clockwise()
	{
		clockwiseRotate = true;
	}

	public void Anticlockwise() 
	{
		antiClockwiseRotate = true;
	}
}