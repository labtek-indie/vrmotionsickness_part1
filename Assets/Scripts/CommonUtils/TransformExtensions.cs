using UnityEngine;
using System.Collections;

public static class TransformExtensions : object {

	//	position and rotation
	public static void TransferTo(this Transform trans, Transform targetTrans)
	{
		trans.position = targetTrans.position;
		trans.rotation = targetTrans.rotation;
	}

	// 	POSITION
	// 		global
	//			to
	//				x, y, z
	public static void TranslateXTo(this Transform trans, float x)
	{
		trans.position = new Vector3(x, trans.position.y, trans.position.z);
	}
	public static void TranslateYTo(this Transform trans, float y)
	{
		trans.position = new Vector3(trans.position.x, y, trans.position.z);
	}
	public static void TranslateZTo(this Transform trans, float z)
	{
		trans.position = new Vector3(trans.position.x, trans.position.y, z);
	}

	//				all
	public static void TranslateTo(this Transform trans, float x, float y, float z)
	{
		trans.position = new Vector3(x, y, z);
	}

	//			by
	//				x, y, z
	public static void TranslateX(this Transform trans, float x)
	{
		trans.position = new Vector3(trans.position.x + x, trans.position.y, trans.position.z);
	}
	public static void TranslateY(this Transform trans, float y)
	{
		trans.position = new Vector3(trans.position.x, trans.position.y + y, trans.position.z);
	}
	public static void TranslateZ(this Transform trans, float z)
	{
		trans.position = new Vector3(trans.position.x, trans.position.y, trans.position.z + z);
	}



	// 		local
	//			to
	//				x, y, z
	public static void TranslateLocalXTo(this Transform trans, float x)
	{
		trans.localPosition = new Vector3(x, trans.localPosition.y, trans.localPosition.z);
	}
	public static void TranslateLocalYTo(this Transform trans, float y)
	{
		trans.localPosition = new Vector3(trans.localPosition.x, y, trans.localPosition.z);
	}
	public static void TranslateLocalZTo(this Transform trans, float z)
	{
		trans.localPosition = new Vector3(trans.localPosition.x, trans.localPosition.y, z);
	}

	//				all
	public static void TranslateLocalTo(this Transform trans, float x, float y, float z)
	{
		trans.localPosition = new Vector3(x, y, z);
	}

	//			by
	public static void TranslateLocal(this Transform trans, float x, float y, float z)
	{
		trans.localPosition = trans.localPosition + new Vector3 (x, y, z);
	}
	//				vector
	public static void TranslateLocal(this Transform trans, Vector3 offset)
	{
		trans.localPosition = trans.localPosition + offset;
	}


	// 		anchored
	//			to
	//				x, y
	public static void TranslateAnchoredXTo(this RectTransform trans, float x)
	{
		trans.anchoredPosition = new Vector2(x, trans.anchoredPosition.y);
	}
	public static void TranslateAnchoredYTo(this RectTransform trans, float y)
	{
		trans.anchoredPosition = new Vector2(trans.anchoredPosition.x, y);
	}

	//				all
	public static void TranslateAnchoredTo(this RectTransform trans, float x, float y)
	{
		trans.anchoredPosition = new Vector2(x, y);
	}

	//			by
	//				x, y
	public static void TranslateAnchoredX(this RectTransform trans, float x)
	{
		trans.anchoredPosition = new Vector2(trans.anchoredPosition.x + x, trans.anchoredPosition.y);
	}
	public static void TranslateAnchoredY(this RectTransform trans, float y)
	{
		trans.anchoredPosition = new Vector2(trans.anchoredPosition.x, trans.anchoredPosition.y + y);
	}

	//				all
	public static void TranslateAnchored(this RectTransform trans, float x, float y)
	{
		trans.anchoredPosition = new Vector2(trans.anchoredPosition.x + x, trans.anchoredPosition.y + y);
	}


	// 		anchor
	//			to
	//				x, y
	public static void AnchorXTo(this RectTransform trans, float x)
	{
		trans.anchorMax = trans.anchorMin = new Vector2(x, trans.anchorMax.y);
	}
	public static void AnchorYTo(this RectTransform trans, float y)
	{
		trans.anchorMax = trans.anchorMin = new Vector2(trans.anchorMax.x, y);
	}

	//				all
	public static void AnchorTo(this RectTransform trans, float x, float y)
	{
		trans.anchorMax = trans.anchorMin = new Vector2(x, y);
	}

	// 		pivot
	//			to
	//				x, y
	public static void pivotXTo(this RectTransform trans, float x)
	{
		trans.pivot = new Vector2(x, trans.pivot.y);
	}
	public static void pivotYTo(this RectTransform trans, float y)
	{
		trans.pivot = new Vector2(trans.pivot.x, y);
	}

	//				all
	public static void pivotTo(this RectTransform trans, float x, float y)
	{
		trans.pivot = new Vector2(x, y);
	}




	// 	ROTATION
	// 		global
	public static float ZRotation(this Transform trans){
		return trans.rotation.eulerAngles.z;
	}
	public static float LocalZRotation(this Transform trans){
		return trans.localRotation.eulerAngles.z;
	}
	public static void RotateTo(this Transform trans, float x, float y, float z)
	{
		trans.rotation = Quaternion.Euler(new Vector3 (x, y, z));
	}
	public static void Rotate2DTo(this Transform trans, float angle)
	{
		trans.rotation = Quaternion.Euler(new Vector3 (0, 0, angle));
	}
	public static void Rotate2DBy(this Transform trans, float angle)
	{
		trans.Rotate(new Vector3 (0, 0, trans.ZRotation() + angle));
	}
	// 		local
	public static void RotateLocal2DTo(this Transform trans, float angle)
	{
		trans.localRotation = Quaternion.Euler(new Vector3 (0, 0, angle));
	}

	// 	SCALE
	// 		local
	//			to
	//				x, y, z
	public static void ScaleLocalXTo(this Transform trans, float x)
	{
		trans.localScale = new Vector3(x, trans.localScale.y, trans.localScale.z);
	}
	public static void ScaleLocalYTo(this Transform trans, float y)
	{
		trans.localScale = new Vector3(trans.localScale.x, y, trans.localScale.z);
	}
	public static void ScaleLocalZTo(this Transform trans, float z)
	{
		trans.localScale = new Vector3(trans.localScale.x, trans.localScale.y, z);
	}

	//				all
	public static void ScaleLocalTo(this Transform trans, float scale)
	{
		trans.localScale = new Vector3(scale, scale, scale);
	}
	public static void ScaleLocalTo(this Transform trans, float x, float y, float z)
	{
		trans.localScale = new Vector3(x, y, z);
	}
	public static void ScaleLocalBy(this Transform trans, float x = 0, float y = 0, float z = 0)
	{
		trans.localScale = new Vector3(trans.localScale.x + x, trans.localScale.y + y, trans.localScale.z + z);
	}

	//	RectTransform
	public static void ScaleLocalXTo(this RectTransform trans, float x)
	{
		trans.localScale = new Vector3(x, trans.localScale.y, trans.localScale.z);
	}
	public static void ScaleLocalYTo(this RectTransform trans, float y)
	{
		trans.localScale = new Vector3(trans.localScale.x, y, trans.localScale.z);
	}
	public static void ScaleLocalTo(this RectTransform trans, float x, float y)
	{
		trans.localScale = new Vector3(x, y, trans.localScale.z);
	}
	public static void ScaleLocalBy(this RectTransform trans, float x = 0, float y = 0)
	{
		trans.localScale = new Vector3(trans.localScale.x + x, trans.localScale.y + y, trans.localScale.z);
	}

	public static void ResizeTo(this RectTransform trans, float x, float y)
	{
		trans.sizeDelta = new Vector2(x, y);
	}
	public static void ResizeBy(this RectTransform trans, float x = 0, float y = 0)
	{
		trans.sizeDelta = new Vector2(trans.sizeDelta.x + x, trans.sizeDelta.y + y);
	}
	public static void ResizeXTo(this RectTransform trans, float x)
	{
		trans.sizeDelta = new Vector2(x, trans.sizeDelta.y);
	}
	public static void ResizeYTo(this RectTransform trans, float y)
	{
		trans.sizeDelta = new Vector2(trans.sizeDelta.x, y);//trans.Translate (y = 10);
	}


	// Reset transform
	public static void Reset(this Transform trans)
	{
		trans.localPosition = new Vector3();
		trans.localRotation = Quaternion.identity;
		trans.ScaleLocalTo (1);
	}


	// RECT TRANSFORM POSITION/SIZE

	public static void SetRightTo(this RectTransform trans, float x)
	{
		trans.offsetMax = new Vector2(-x, trans.offsetMax.y);
	}
	public static void SetLeftTo(this RectTransform trans, float x)
	{
		trans.offsetMin = new Vector2(x, trans.offsetMin.y);
	}
	public static void SetBottomTo(this RectTransform trans, float y)
	{
		trans.offsetMin = new Vector2(trans.offsetMin.x, y);
	}
	public static void SetTopTo(this RectTransform trans, float y)
	{
		trans.offsetMax = new Vector2(trans.offsetMax.x, -y);
	}
	public static void SetRectEdgesTo(this RectTransform trans, float left, float top, float right, float bottom)
	{
		if (float.IsNaN (left))
			left = trans.offsetMin.x;
		if (float.IsNaN (right))
			right = trans.offsetMax.x;
		else
			right *= -1;

		if (float.IsNaN (bottom))
			bottom = trans.offsetMin.y;
		if (float.IsNaN (top))
			top = trans.offsetMax.y;
		else
			top *= -1;
		
		trans.offsetMin = new Vector2(left, bottom);
		trans.offsetMax = new Vector2(right, top);
	}
}
