using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CedarWoodSoftware
{
	public class ColourSwapper : MonoBehaviour
	{
		#region Variables
		[Header("Old Colour")]
		[SerializeField] Color colorA;

		[Header("New Colour")]
		[SerializeField] Color colorB;

		[Header("Swap Colour Time")]
		[SerializeField] float swapTime;
		[SerializeField] bool loopSwap = false;

		SpriteRenderer spriteRenderer;
		#endregion

		#region Unity Base Methods
		void Start()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
			StartCoroutine(SwapTo());

		}
		#endregion

		#region User Methods
		IEnumerator SwapTo()
		{
			for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / swapTime)
			{
				Color newColor = new Color(Mathf.Lerp(colorA.r, colorB.r, t), Mathf.Lerp(colorA.g, colorB.g, t), Mathf.Lerp(colorA.b, colorB.b, t), 1);
				spriteRenderer.color = newColor;
				yield return null;
			}

			if (loopSwap)
			{
				yield return new WaitForSeconds(2f);
				StartCoroutine(SwapBack());
			}
		}

		IEnumerator SwapBack()
		{
			for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / swapTime)
			{
				Color newColor = new Color(Mathf.Lerp(colorB.r, colorA.r, t), Mathf.Lerp(colorB.g, colorA.g, t), Mathf.Lerp(colorB.b, colorA.b, t), 1);
				spriteRenderer.color = newColor;
				yield return null;
			}

			yield return new WaitForSeconds(2f);
			StartCoroutine(SwapTo());
		}
		#endregion
	}
}