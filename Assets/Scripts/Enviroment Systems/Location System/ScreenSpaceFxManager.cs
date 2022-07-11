using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace EnviromentSystems.LevelLoading
{
    public class ScreenSpaceFxManager : MonoBehaviour
	{
		static ScreenSpaceFxManager screenSpaceFxInstance;
		public static ScreenSpaceFxManager ScreenSpaceFXInstance => screenSpaceFxInstance;

		public float FadeAnimationLength { get { return screenSpaceAnimators[targetAnimatorIndex].GetCurrentAnimatorClipInfo(0).Length; } }

		public bool IsFading => isFading;

		bool isFading;

		[SerializeField]
		Canvas canvas;

		[SerializeField]
		List<Animator> screenSpaceAnimators = new List<Animator>();

		int targetAnimatorIndex;


        private void Awake()
        {
			screenSpaceFxInstance = this;
			foreach (Animator screenEffect in screenSpaceAnimators) {

				if (screenEffect != screenSpaceAnimators[targetAnimatorIndex])
					screenEffect.gameObject.SetActive(false);
			}
		}
        public void FadeFromBlack()
		{


			Debug.Log("Fade ends!");
			screenSpaceAnimators[targetAnimatorIndex].SetTrigger("FadeFromBlack");
			StartCoroutine(WaitUntilFadeHasFinished());

		}

		public void FadeToBlack()
		{
			Debug.Log("Fade begins!");
			isFading = true;
			screenSpaceAnimators[targetAnimatorIndex].Play("FadeToBlack");

		}

		public void SetCanvasOrder(int orderIndex) {

			canvas.sortingOrder = orderIndex;
		}

		public void ChangeAnimatorIndex(int index)
		{
			targetAnimatorIndex = index;
			//fadeImage.CrossFadeAlpha(1f, fadeSpeed, false);

		}

		IEnumerator WaitUntilFadeHasFinished() {

			yield return new WaitForSeconds(FadeAnimationLength);
			isFading = false;
		}


	}
}