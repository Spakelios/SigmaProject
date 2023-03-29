using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PDollarGestureRecognizer;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuzzleSpellcasting : MonoBehaviour
{
	public Transform gestureOnScreenPrefab;

	private List<Gesture> trainingSet = new List<Gesture>();

	private List<Point> points = new List<Point>();
	private int strokeId = -1;

	private Vector3 virtualKeyPosition = Vector2.zero;

	private RuntimePlatform platform;
	private int vertexCount = 0;

	private List<LineRenderer> gestureLinesRenderer = new List<LineRenderer>();
	private LineRenderer currentGestureLineRenderer;
	
	private bool recognized;

	public bool canDraw;

	public string[] symbols;

	private string[] fireSymbols;
	private string[] waterSymbols;
	private string[] mossSymbols;

	private Result gestureResult;
	
	public string spell;

	public bool fireMagic;
	public bool waterMagic;
	public bool mossMagic;

	private Gradient fireColour;
	private Gradient waterColour;
	private Gradient mossColour;
	

	public GameObject magicWandPrefab;
	private GameObject magicWand;
	private bool magicWandSpawned;

	public Vector2 mousePos;
	
	
	public Image symbol;
	private Color symbolAlpha;

	public Sprite fireSymbol;
	public Sprite waterSymbol;
	public Sprite mossSymbol;
	
	
	 private void Awake () {

		platform = Application.platform;

		//Load pre-made gestures
		TextAsset[] gesturesXml = Resources.LoadAll<TextAsset>("GestureSet/10-stylus-MEDIUM/");
		foreach (TextAsset gestureXml in gesturesXml)
			trainingSet.Add(GestureIO.ReadGestureFromXML(gestureXml.text));

		//Load user custom gestures
		string[] filePaths = Directory.GetFiles(Application.persistentDataPath, "*.xml");
		foreach (string filePath in filePaths)
			trainingSet.Add(GestureIO.ReadGestureFromFile(filePath));

		/*
		symbols = new[]
		{
			"F", "T", "L"
		};
		*/

		fireColour = new Gradient();
		fireColour.SetKeys(
			new GradientColorKey[]
			{
				new GradientColorKey(Color.red, 0.0f), new GradientColorKey(new Color(1f, 0.5f, 0f, 1f), 0.5f), new GradientColorKey(Color.yellow, 1.0f)
			},
			new GradientAlphaKey[] 
				{new GradientAlphaKey(1f, 0.0f), new GradientAlphaKey(1f, 0.5f), new GradientAlphaKey(1f, 1f)}
		);

		waterColour = new Gradient();
		waterColour.SetKeys(
			new GradientColorKey[]
			{
				new GradientColorKey(new Color(0f, 0f, 0.5f, 1f), 0.0f), new GradientColorKey(Color.blue, 0.5f), new GradientColorKey(new Color(0f, 1f, 1f, 1f), 1.0f)
			},
			new GradientAlphaKey[]
				{new GradientAlphaKey(1f, 0.0f), new GradientAlphaKey(1f, 0.5f), new GradientAlphaKey(1f, 1f)}
		);

		mossColour = new Gradient();
		mossColour.SetKeys(
			new GradientColorKey[]
			{
				new GradientColorKey(new Color(0f, 0.2f, 0f, 1f), 0.0f), new GradientColorKey(new Color(0f, 0.5f, 0f, 1f), 0.5f), new GradientColorKey(Color.green, 1.0f)
			},
			new GradientAlphaKey[]
				{new GradientAlphaKey(1f, 0.0f), new GradientAlphaKey(1f, 0.5f), new GradientAlphaKey(1f, 1f)}
		);
		

		fireMagic = false;
		waterMagic = false;
		mossMagic = false;

		fireSymbols = new[]
		{
			"F"
		};

		waterSymbols = new[]
		{
			"W"
		};

		mossSymbols = new[]
		{
			"M"
		};
		
		symbolAlpha = Color.white;
		symbolAlpha.a = 0f;
		symbol.color = symbolAlpha;
		symbol.sprite = null;
		canDraw = false;

	 }

	 private void Update ()
	{

		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		if (platform == RuntimePlatform.Android || platform == RuntimePlatform.IPhonePlayer) {
			if (Input.touchCount > 0) {
				virtualKeyPosition = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
			}
		} else {
			if (Input.GetMouseButton(0)) {
				virtualKeyPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
			}
		}
		
		if(!canDraw)
			return;

		if (magicWandSpawned)
		{
			magicWand.transform.position = mousePos;
		}

		if (Input.GetMouseButtonDown(0)) {

				if (recognized) {

					recognized = false;
					strokeId = -1;

					points.Clear();

					foreach (LineRenderer lineRenderer in gestureLinesRenderer) {

						lineRenderer.SetVertexCount(0);
						Destroy(lineRenderer.gameObject);
					}

					gestureLinesRenderer.Clear();
				}

				++strokeId;
				
				Transform tmpGesture = Instantiate(gestureOnScreenPrefab, transform.position, transform.rotation) as Transform;
				currentGestureLineRenderer = tmpGesture.GetComponent<LineRenderer>();
				currentGestureLineRenderer.startWidth = 0.05f;
				currentGestureLineRenderer.endWidth = 0.05f;

				if (fireMagic)
				{
					currentGestureLineRenderer.colorGradient = fireColour;
				}
				
				else if (waterMagic)
				{
					currentGestureLineRenderer.colorGradient = waterColour;
				}

				else if (mossMagic)
				{
					currentGestureLineRenderer.colorGradient = mossColour;
				}

				gestureLinesRenderer.Add(currentGestureLineRenderer);
				
				vertexCount = 0;
		}
			
		if (Input.GetMouseButton(0)) {
				points.Add(new Point(virtualKeyPosition.x, -virtualKeyPosition.y, strokeId));

				currentGestureLineRenderer.SetVertexCount(++vertexCount);
				currentGestureLineRenderer.SetPosition(vertexCount - 1, Camera.main.ScreenToWorldPoint(new Vector3(virtualKeyPosition.x, virtualKeyPosition.y, 10)));
		}
		
		
	}

	private void OnMouseOver()
	{

		if (fireMagic || waterMagic || mossMagic)
		{
			canDraw = true;
			
			if (magicWandSpawned) return;
			magicWand = Instantiate(magicWandPrefab);
			magicWandSpawned = true;
			Cursor.visible = false;
		}
					

		

	}

	public void OnMouseExit()
	{
		canDraw = false;
		Destroy(magicWand);
		magicWandSpawned = false;
		Cursor.visible = true;
	}

	public void TryRecognise()
	{
		Gesture candidate = new Gesture(points.ToArray());

		gestureResult = PointCloudRecognizer.Classify(candidate, trainingSet.ToArray());
		
		if (symbols.Contains(gestureResult.GestureClass))
		{
			recognized = true;
			//print(gestureResult.Score);
			if (gestureResult.GestureClass == fireSymbols[0])
			{
				//put in stuff for fire spell here!
				spell = "Fire";
				print(spell);
			}
			
			else if (gestureResult.GestureClass == waterSymbols[0])
			{
				//put in stuff for water spell here!
				spell = "Water";
				print(spell);
			}

			else if(gestureResult.GestureClass == mossSymbols[0])
			{
				//put in stuff for moss spell here!
				spell = "Moss";
				print(spell);
			}
			
			//notif.text = "Casted " + spell + "!";
			ClearLine();
		}

		else
		{
			recognized = false;
			print("Failed");
			ClearLine();
		}
		
	}

	public void ClearLine()
	{
		recognized = false;
		strokeId = -1;
		points.Clear();
		foreach (LineRenderer lineRenderer in gestureLinesRenderer)
		{
			lineRenderer.SetVertexCount(0);
			Destroy(lineRenderer.gameObject);
		}
		gestureLinesRenderer.Clear();
	}

	public void FireMagic()
	{
		ClearLine();
		fireMagic = true;
		waterMagic = false;
		mossMagic = false;
		
		symbols = fireSymbols;
		symbolAlpha.a = 1f;
		symbol.color = symbolAlpha;
		symbol.sprite = fireSymbol;
		
	}

	public void WaterMagic()
	{
		ClearLine();
		fireMagic = false;
		waterMagic = true;
		mossMagic = false;
		
		symbols = waterSymbols;
		symbolAlpha.a = 1f;
		symbol.color = symbolAlpha;
		symbol.sprite = waterSymbol;

	}
	
	public void MossMagic()
	{
		ClearLine();
		fireMagic = false;
		waterMagic = false;
		mossMagic = true;

		symbols = mossSymbols;
		symbolAlpha.a = 1f;
		symbol.color = symbolAlpha;
		symbol.sprite = mossSymbol;
	}

	public void CloseBookPage()
	{
		ClearLine();
		canDraw = false;
		fireMagic = false;
		waterMagic = false;
		mossMagic = false;

		symbols = null;
		symbolAlpha.a = 0f;
		symbol.color = symbolAlpha;
		symbol.sprite = null;
	}
}
