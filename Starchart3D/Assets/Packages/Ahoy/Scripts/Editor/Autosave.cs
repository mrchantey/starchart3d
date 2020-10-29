// copied from https://forum.unity.com/threads/we-need-auto-save-feature.483853/
#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Ahoy
{

	[InitializeOnLoad]
	public class AutoSaveOnRunMenuItem
	{
		public const string MenuName = "Ahoy/Autosave On Run";
		private static bool isToggled = true;

		static AutoSaveOnRunMenuItem()
		{
			EditorApplication.delayCall += () =>
			{
				isToggled = EditorPrefs.GetBool(MenuName, false);
				UnityEditor.Menu.SetChecked(MenuName, isToggled);
				SetMode();
			};
		}

		[MenuItem(MenuName)]
		private static void ToggleMode()
		{
			isToggled = !isToggled;
			UnityEditor.Menu.SetChecked(MenuName, isToggled);
			EditorPrefs.SetBool(MenuName, isToggled);
			SetMode();
		}

		private static void SetMode()
		{
			if (isToggled)
			{
				EditorApplication.playModeStateChanged += AutoSaveOnRun;
			}
			else
			{
				EditorApplication.playModeStateChanged -= AutoSaveOnRun;
			}
		}

		private static void AutoSaveOnRun(PlayModeStateChange state)
		{
			if (EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying)
			{
				Debug.Log("Auto-Saving before entering Play mode");

				EditorSceneManager.SaveOpenScenes();
				AssetDatabase.SaveAssets();
			}
		}
	}

}
#endif