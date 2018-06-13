using UnityEngine;
using UnityEngine.UI;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using DG.Tweening;

public static class Utils : object {

	public static Vector3 mousePost(){
		Vector3 position = Camera.main.ScreenToWorldPoint( Input.mousePosition );
		position.z = 0;
		return position;
	}

	public static float moveTo(float source, float target, float speed){
		float dist = target - source;
		if (Mathf.Abs (dist) > speed) {
			if (dist > 0)
				return source + speed;
			else
				return source - speed;
		} else
			return target;
	}

	/// <summary>
	/// Unclamped Lerp
	/// </summary>
	/// <param name="from">From.</param>
	/// <param name="to">To.</param>
	/// <param name="value">Value.</param>
	public static float Lerp (float from, float to, float value) {
		return (1.0f - value) * from + value * to;
	}


	/// <summary>
	/// Set to the values to Not a Number so that it will be assumed as null
	/// </summary>
	/// <param name="vector">Vector.</param>
	public static void nullify(this Vector2 vector)
	{
		vector.x = float.NaN;
		vector.y = float.NaN;
	}
	
	/// <summary>
	/// Check if the values are Not a Number, for which it will be assumed as null
	/// </summary>
	/// <param name="vector">Vector.</param>
	public static bool isNull(this Vector2 vector)
	{
		if(float.IsNaN(vector.x) && float.IsNaN(vector.y)) return true;
		else return false;
	}
	
	/// <summary>
	/// Set to the values to Not a Number so that it will be assumed as null
	/// </summary>
	/// <param name="vector">Vector.</param>
	public static void nullify(this Vector3 vector)
	{
		vector.x = float.NaN;
		vector.y = float.NaN;
		vector.z = float.NaN;
	}
	
	/// <summary>
	/// Check if the values are Not a Number, for which it will be assumed as null
	/// </summary>
	/// <param name="vector">Vector.</param>
	public static bool isNull(this Vector3 vector)
	{
		if(float.IsNaN(vector.x) && float.IsNaN(vector.y) && float.IsNaN(vector.z)) return true;
		else return false;
	}


	// renderer extension functions
	// 		color functions
	//			SpriteRenderer
	public static void setAlpha(this SpriteRenderer renderer, float a)
	{
		renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, a);
	}
	public static void changeAlphaBy(this SpriteRenderer renderer, float a)
	{
		renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, renderer.color.a + a);
	}
	public static void setColor(this SpriteRenderer renderer, Color color)
	{
		renderer.color = new Color(color.r, color.g, color.b, renderer.color.a);
	}

	//			Image (UI)
	public static void setAlpha(this Image image, float a)
	{
		image.color = new Color(image.color.r, image.color.g, image.color.b, a);
	}
	public static void changeAlphaBy(this Image image, float a)
	{
		image.color = new Color(image.color.r, image.color.g, image.color.b, image.color.a + a);
	}
	public static void setColor(this Image image, Color color)
	{
		image.color = new Color(color.r, color.g, color.b, image.color.a);
	}

	//			TextMesh
	public static void setAlpha(this TextMesh textMesh, float a)
	{
		textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, a);
	}
	public static void changeAlphaBy(this TextMesh textMesh, float a)
	{
		textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, textMesh.color.a + a);
	}
	public static void setColor(this TextMesh textMesh, Color color)
	{
		textMesh.color = new Color(color.r, color.g, color.b, textMesh.color.a);
	}

	//			Text (UI)
	public static void setAlpha(this Text text, float a)
	{
		text.color = new Color(text.color.r, text.color.g, text.color.b, a);
	}
	public static void setColor(this Text text, Color color)
	{
		text.color = new Color(color.r, color.g, color.b, text.color.a);
	}

	//			Material
	public static void setAlpha(this Material material, float a)
	{
		material.color = new Color(material.color.r, material.color.g, material.color.b, a);
	}


//	public static Tweener DOFade(this TextMesh textMesh, float alpha, float duration){
//		return DOTween.To (value => Utils.setAlpha( textMesh, value), textMesh.color.a, alpha, duration);
//	}

	public static Tweener DOCall(float delay, TweenCallback onComplete){
		return DOTween.To(() => 0, (x) => x=0, 0, delay).OnComplete(onComplete);
	}

	public static T[] subArray<T>(this T[] source, int startIndex, int length)
	{
		T[] result = new T[length];
		for (int i = 0; i < length; i++)
			result [i] = source [i + startIndex];
		return result;
	}
	public static int[] multiply(this int[] source, int multiplier)
	{
		for (int i = 0; i < source.Length; i++)
			source [i] = source[i] * multiplier;
		return source;
	}
	public static void shuffleArray<T>(T[] arr) {
		for (int i = arr.Length - 1; i > 0; i--) {
			int r = UnityEngine.Random.Range(0, i+1);
			T tmp = arr[i];
			arr[i] = arr[r];
			arr[r] = tmp;
		}
	}

	public static string secondsToString(float seconds){
		string result = "";

		if (seconds < 0)
			result += "-";
			
		seconds = Mathf.Abs (Mathf.Round (seconds));

		if (seconds >= 3600f) {
			int hours = Mathf.FloorToInt (seconds / 3600);
			result += hours.ToString () + ":";
			seconds -= hours * 3600;
		}if (seconds >= 60) {
			int minutes = Mathf.FloorToInt (seconds / 60);
			if (minutes < 10)
				result += "0";
			result += minutes.ToString ();
			seconds -= minutes * 60;
		}else
			result += "00";
		result += ":";
		if (seconds < 10)
			result += "0";
		result += seconds;
		return result;
	}

	public static float normalizeAngle(float angle){
		while (angle > 180)
			angle -= 360;
		while (angle < -180)
			angle += 360;
		return angle;
	}

	public static float getDegreesBetween(Vector2 a, Vector2 b){
		return Mathf.Atan2 (a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}

	public static bool valueIsBetween(int value, int limitA, int limitB){
		if (limitA < limitB) {
			if (value >= limitA && value <= limitB)
				return true;
		} else if (limitA > limitB) {
			if (value >= limitB && value <= limitA)
				return true;
		} else {
			if (value == limitA)
				return true;
		}
		return false;
	}

	public static BoxCollider2D coverWithCollider(RectTransform rectTransform){
		BoxCollider2D collider = rectTransform.gameObject.AddComponent<BoxCollider2D>();

		collider.offset = new Vector2 (
			rectTransform.sizeDelta.x * (.5f - rectTransform.pivot.x),
			rectTransform.sizeDelta.y * (.5f - rectTransform.pivot.y)
		);
		collider.size = new Vector2 (rectTransform.sizeDelta.x, rectTransform.sizeDelta.y);

		return collider;
	}

	/// <summary>
	/// Sets the blend mode.
	/// </summary>
	/// <param name="material">Material.</param>
	/// <param name="blendMode">Blend mode 0 = Opaque, 1 = Cutout, 2 = Fade, 3 = Transparent.</param>
	public static void setBlendMode(this Material material, int blendMode)
	{
		material.SetFloat("_Mode", blendMode);
		switch (blendMode)
		{
		case 0:
			material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
			material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
			material.SetInt("_ZWrite", 1);
			material.DisableKeyword("_ALPHATEST_ON");
			material.DisableKeyword("_ALPHABLEND_ON");
			material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
			material.renderQueue = -1;
			break;
		case 1:
			material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
			material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
			material.SetInt("_ZWrite", 1);
			material.EnableKeyword("_ALPHATEST_ON");
			material.DisableKeyword("_ALPHABLEND_ON");
			material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
			material.renderQueue = 2450;
			break;
		case 2:
			material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
			material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
			material.SetInt("_ZWrite", 0);
			material.DisableKeyword("_ALPHATEST_ON");
			material.EnableKeyword("_ALPHABLEND_ON");
			material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
			material.renderQueue = 3000;
			break;
		case 3:
			material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
			material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
			material.SetInt("_ZWrite", 0);
			material.DisableKeyword("_ALPHATEST_ON");
			material.DisableKeyword("_ALPHABLEND_ON");
			material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
			material.renderQueue = 3000;
			break;
		}
	}


	public static List<T> GetComponentsInAllChildren<T>(this Transform transform){
		List<T> list = new List<T> ();

		foreach (Transform child in transform) {
			T component = child.GetComponent<T>();
			if (component != null && !component.Equals(null)) {
				list.Add (component);
				continue;// if found, don't dig deeper
			}
			
			list.AddRange (child.GetComponentsInAllChildren<T>());
		}

		return list;
	}

	// Create or get a series of GameObjects, based on given path
	public static Transform GetOrCreateGameObjectPath(Transform parent, string path){
		
		string[] transformNames = path.Split('/');

		foreach(string transformName in transformNames){
			
			Transform child = parent.FindChild(transformName);

			if(child == null){
				child = new GameObject (transformName).transform;
				child.SetParent(parent);
			}

			parent = child;
		}

		return parent;
	}


	// TextMesh

	public static void wrapTextMesh(this TextMesh textMesh, MeshRenderer renderer, float widthLimit){

		string[] words = textMesh.text.Split(' ');
		textMesh.text = "";
		string wrappedText = "";

		for (int i = 0; i < words.Length; i++)
		{
			textMesh.text += words[i] + " ";
			if (renderer.bounds.extents.x > widthLimit && i > 0)
			{
				textMesh.text = wrappedText.TrimEnd() + System.Environment.NewLine + words[i] + " ";
			}
			wrappedText = textMesh.text;
		}

		textMesh.text = textMesh.text.Substring (0, textMesh.text.Length - 1);
	}

	public static void wrapTextMesh(this Text text, float widthLimit){

		string[] words = text.text.Split(' ');
		text.text = "";
		string wrappedText = "";

		for (int i = 0; i < words.Length; i++)
		{
			text.text += words[i] + " ";
			if (text.preferredWidth > widthLimit && i > 0)
			{
				text.text = wrappedText.TrimEnd() + System.Environment.NewLine + words[i] + " ";
			}
			wrappedText = text.text;
		}

		text.text = text.text.Substring (0, text.text.Length - 1);
	}

	public delegate void GenericFunction();

	public static bool IsNotNull(System.Object obj){
		if (obj != null && !obj.Equals (null))
			return true;
		return false;
	}

//	public static float easeInOutSine(float v1, float v2, float d, float t){
//			return -v2/2 * (Mathf.Cos(Mathf.PI*t/d) - 1) + v1;
//	}
}
