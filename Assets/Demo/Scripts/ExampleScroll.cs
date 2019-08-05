using System.Collections;
using example;
using UnityEngine;
using UnityDynamicScrollRect;

public class ExampleScroll : MonoBehaviour
{
	public DynamicScrollRect verticalScroll;
	public DynamicScrollRect horizontalScroll;
	public DynamicScrollRect gridScroll;
	public GameObject referenceObject;

	public Transform GridHolder;

	private ExampleData[] mData;
	private DynamicScroll<ExampleData, ExampleDynamicObject> mVerticalDynamicScroll = new DynamicScroll<ExampleData, ExampleDynamicObject>();
	private DynamicScroll<ExampleData, ExampleDynamicObject> mHorizontalDynamicScroll = new DynamicScroll<ExampleData, ExampleDynamicObject>();
	private DynamicScroll<ExampleData, ExampleDynamicObject> mGridDynamicScroll = new DynamicScroll<ExampleData, ExampleDynamicObject>();

	public IEnumerator Start()
	{
		WWW www = new WWW(@"https://jsonplaceholder.typicode.com/comments");
		yield return www;
		mData = JsonHelper.getJsonArray<ExampleData>(www.text);

		mVerticalDynamicScroll.spacing = 5f;
		mVerticalDynamicScroll.Initiate(verticalScroll, mData, 0, referenceObject);

		mHorizontalDynamicScroll.spacing = 5f;
		mHorizontalDynamicScroll.Initiate(horizontalScroll, mData, 0, referenceObject);

		mGridDynamicScroll.spacing = 5f;
		mGridDynamicScroll.Initiate(horizontalScroll, mData, 0, referenceObject);

		foreach (var item in mData)
		{
			GameObject exampleObject = Instantiate(referenceObject, GridHolder);
			ExampleDynamicObject exampleDynamicObject = exampleObject.AddComponent<ExampleDynamicObject>();

			ExampleData exampleData = new ExampleData
			{
				id = item.id,
				name = item.name,
				body = item.body,
				email = item.email,
				postId = item.postId
			};

			exampleDynamicObject.updateScrollObject(exampleData, item.id);
		}
	}
}