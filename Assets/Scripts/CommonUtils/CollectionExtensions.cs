using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class CollectionExtensions : object {

	public static string ToPrettyNameString<T>(this T[] array) where T : MonoBehaviour{
		return string.Join(", ", array.Select(x => x.name).ToArray());
	}
	public static string ToPrettyNameString<T>(this List<T> list) where T : MonoBehaviour{
		return string.Join(", ", list.Select(x => x.name).ToArray());
	}

	public static string ToPrettyString(this string[] array){
		return string.Join(", ", array);
	}
	public static string ToPrettyString(this List<string> list){
		return string.Join(", ", list.ToArray());
	}

	public static string ToPrettyString<T>(this T[] array){
		return string.Join(", ", array.Select(x => x.toStringSave()).ToArray());
	}
	public static string ToPrettyString<T>(this List<T> list){
		return string.Join(", ", list.Select(x => x.toStringSave()).ToArray());
	}
	public static string toStringSave<T>(this T obj){
		if (obj == null)
			return "NULL";
		return obj.ToString ();
	}


	public static string ToPrettyString(this string[,] array2D){
		string result = "";

		for (int y = 0; y < array2D.GetLength(0); y++) {
			for (int x = 0; x < array2D.GetLength(1); x++) {
				result += array2D [y, x] + "\t";
			}
			result += System.Environment.NewLine;
		}

		return result;
	}

	public static string ToPrettyString(this List<string[]> list2D){
		string result = "";

		for (int y = 0; y < list2D.Count; y++) {
			for (int x = 0; x < list2D[y].Length; x++) {
				result += list2D [y][x] + "\t";
			}
			result += System.Environment.NewLine;
		}

		return result;
	}

	//	public static string dictionaryToString<T>(this T dictionary) where T : IDictionary{
	//		return string.Join(";", dictionary.Select(x => x.Key + "=" + x.Value).ToArray());
	//	}

	public static List<T> ToList<T>(this T[] array){
		List<T> list = new List<T> ();
		foreach (T member in array) {
			list.Add (member);
		}
		return list;
	}

	public static Dictionary<string, T> ToDictionary<T>(this List<T> list, IEqualityComparer<string> comparer) where T : MonoBehaviour
	{
		return ToDictionary (list, new Dictionary<string, T> (comparer));
	}

	public static Dictionary<string, T> ToDictionary<T>(this List<T> list) where T : MonoBehaviour
	{
		return ToDictionary (list, new Dictionary<string, T> ());
	}

	static Dictionary<string, T> ToDictionary<T>(List<T> list, Dictionary<string, T> dict) where T : MonoBehaviour
	{
		foreach (T member in list) {
			// if one with the same name exists, rename
			if (dict.ContainsKey (member.name)) {
				int dupNum = 0;
				string origName = member.name;
				while (dict.ContainsKey (member.name)) {
					dupNum++;
					member.name = origName + "(dup " + dupNum.ToString() +")";
				}
			}
			dict.Add (member.name, member);
		}
		return dict;
	}

	public static string ToPrettyString(this Dictionary<string, Transform> dict)
	{
		string result = "";
		bool first = true;
		foreach (KeyValuePair<string, Transform> entry in dict) {
			if (!first)
				result += ", ";
			result += entry.Key + ": " + entry.Value.name;
			first = false;
		}
		return result;
	}

}
