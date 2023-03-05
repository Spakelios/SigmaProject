using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PDollarGestureRecognizer;
using TMPro;

public class SymbolDrawing : MonoBehaviour
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

	public String[] symbols;

	private String[] fireSymbols;
	private String[] waterSymbols;
	private String[] mossSymbols;

	public Result gestureResult;

	public TextMeshProUGUI notif;
	private string spell;

	private bool fireMagic;
	private bool waterMagic;
	private bool electricMagic;
	private bool mossMagic;

	private Gradient fireColour;
	private Gradient waterColour;
	private Gradient electricColour;
	private Gradient mossColour;

	private GameManager gameManager;

	public GameObject magicWandPrefab;
	private GameObject magicWand;
	private bool magicWandSpawned;

	public Vector2 mousePos;

	public Texture2D mouseCursor;

	private Vector2 hotspot = Vector2.zero;

	public TextMeshProUGUI symbol;



	void Start () {

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

		electricColour = new Gradient();
		electricColour.SetKeys(
			new GradientColorKey[]
			{
				new GradientColorKey(new Color(0.3f, 0f, 0.5f, 1f), 0.0f), new GradientColorKey(new Color(0.5f, 0f, 1f, 1f), 0.5f), new GradientColorKey(Color.magenta, 1.0f)
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

		gameManager = FindObjectOfType<GameManager>();

		fireMagic = false;
		waterMagic = false;
		electricMagic = false;
		mossMagic = false;

		fireSymbols = new[]
		{
			"F"
		};

		waterSymbols = new[]
		{
			"T"
		};

		mossSymbols = new[]
		{
			"L"
		};

		symbol.text = "...";
	}

	void Update ()
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
				currentGestureLineRenderer.startWidth = 0.1f;
				currentGestureLineRenderer.endWidth = 0.1f;

				if (fireMagic)
				{
					currentGestureLineRenderer.colorGradient = fireColour;
				}
				
				else if (waterMagic)
				{
					currentGestureLineRenderer.colorGradient = waterColour;
				}
				
				else if (electricMagic)
				{
					currentGestureLineRenderer.colorGradient = electricColour;
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
		canDraw = true;

		if (magicWandSpawned) return;
		magicWand = Instantiate(magicWandPrefab);
		magicWandSpawned = true;
		//Cursor.SetCursor(mouseCursor, hotspot, CursorMode.Auto);
		Cursor.visible = false;
	}

	private void OnMouseExit()
	{
		canDraw = false;
		Destroy(magicWand);
		magicWandSpawned = false;
		//Cursor.SetCursor(null, hotspot, CursorMode.Auto);
		Cursor.visible = true;
	}

	public void TryRecognise()
	{
		Gesture candidate = new Gesture(points.ToArray());

		gestureResult = PointCloudRecognizer.Classify(candidate, trainingSet.ToArray());
		
		if (symbols.Contains(gestureResult.GestureClass))
		{
			gameManager.CalculateDamage();
			recognized = true;
			print(gestureResult.Score);
			if (gestureResult.GestureClass == fireSymbols[0])
			{
				spell = "Fireball";
			}
			
			else if (gestureResult.GestureClass == waterSymbols[0])
			{
				spell = "Tidal Wave";
			}

			else if(gestureResult.GestureClass == mossSymbols[0])
			{
				spell = "Lichen Overgrowth";
			}
			
			notif.text = "Casted " + spell + "!";
			ClearLine();
		}

		else
		{
			recognized = false;
			notif.text = "Spell failed!";
			ClearLine();
			gameManager.SpellFailed();
		}
		
	}

	private void ClearLine()
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
		fireMagic = true;
		waterMagic = false;
		electricMagic = false;
		mossMagic = false;
		
		symbols = fireSymbols;

		symbol.text = fireSymbols[0];
	}

	public void WaterMagic()
	{
		fireMagic = false;
		waterMagic = true;
		electricMagic = false;
		mossMagic = false;
		
		symbols = waterSymbols;
		symbol.text = waterSymbols[0];
		
	}

	public void ElectricMagic()
	{
		fireMagic = false;
		waterMagic = false;
		electricMagic = true;
		mossMagic = false;
	}

	public void MossMagic()
	{
		fireMagic = false;
		waterMagic = false;
		electricMagic = false;
		mossMagic = true;

		symbols = mossSymbols;
		symbol.text = mossSymbols[0];
	}
}
