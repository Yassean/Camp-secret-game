using StarterAssets;
using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

namespace CameraDoorScript
{
public class CameraInteract : MonoBehaviour {
	public float DistanceOpen=3;
	public GameObject text;
	public GameObject text2;
	public GameObject pickUPChestK;
	public GameObject pickUPDoorK;
	public GameObject pikFN;
		public GameObject pikLighter;
		public GameObject FNoteObj;
		public GameObject LighterObj;
		public GameObject hand;
		public GameObject player;
	public GameObject HUD;
	public GameObject openChest;
	public GameObject XopenChest;
		public GameObject LighterFire;
		public GameObject chest;
		public bool fireActivated = false;
	public AudioSource pickUpSound;
	public AudioSource ChestSound;
	public bool doorKey;
	public bool chestKey;
	public bool chestOpened;
		public bool haveLighter = false;
		public GameObject carryBarrel;
		public bool haveBarrel;
		public GameObject XBarrel;
		public int kits = 0;
		public int Wrenches;
		public GameObject wrenchObj;
		public GameObject pikKit;
		public GameObject pikWrench;
		public GameObject Fixcar;
		public GameObject noFix;
		public GameObject particle;
		public GameObject timeLine;
		public GameObject pausePanel;
		public GameObject chestK;
		public GameObject doorK;
		public GameObject Qlighter;
		public GameObject firstTimeLine;
		public GameObject code;
		private float pass = 0;
		public GameObject cheatActivatedTXT;
		public float timer =10;
		public GameObject bossSpawner;
		public GameObject huntSound;
		
		// Use this for initialization
		void Start () {
			Time.timeScale = 1;
			firstTimeLine.SetActive(true);
			player.SetActive(false);
		
		}

		// Update is called once per frame
		void Update()
		{
            if (kits == 3 && Wrenches == 1 )
            {
				Debug.Log("playerS");
				player.tag = "PlayerS";
				bossSpawner.SetActive(true);
				huntSound.SetActive(true);
            }
			RaycastHit hit;
			//open door
			if (Physics.Raycast(transform.position, transform.forward, out hit, DistanceOpen) && doorKey)
			{
				if (hit.transform.GetComponent<DoorScript.Door>())
				{
					text.SetActive(true);
					if (Input.GetKeyDown(KeyCode.E))
                    {
						hit.transform.GetComponent<DoorScript.Door>().OpenDoor();
						doorK.SetActive(false);
                    }    
				}
				else
				{
					text.SetActive(false);
				}
			}
			else
			{
				text.SetActive(false);
			}
			//can't open door
			if (Physics.Raycast(transform.position, transform.forward, out hit, DistanceOpen) && doorKey == false)
			{
				if (hit.transform.GetComponent<DoorScript.Door>())
				{
					text2.SetActive(true);

				}
				else
				{
					text.SetActive(false);
				}
			}
			else
			{
				text2.SetActive(false);
			}
			//pick up chest key
			if (Physics.Raycast(transform.position, transform.forward, out hit, DistanceOpen))
			{
				if (hit.transform.GetComponent<KeyScript.Key>())
				{
					pickUPChestK.SetActive(true);
					if (Input.GetKeyDown(KeyCode.E)) {
						chestKey = true;
						chestK.SetActive(true);
						pickUpSound.Play();
						hit.transform.GetComponent<KeyScript.Key>().hide();
					}
						
					    
				}
				else
				{
					pickUPChestK.SetActive(false);
				}
			}
			else
			{
				pickUPChestK.SetActive(false);
			}
			//pick up door key
			if (Physics.Raycast(transform.position, transform.forward, out hit, DistanceOpen))
			{
				if (hit.transform.GetComponent<doorKeyScript.DoorKey>())
				{
					pickUPDoorK.SetActive(true);
					if (Input.GetKeyDown(KeyCode.E))
					{
						doorKey = true;
						doorK.SetActive(true);
						pickUpSound.Play();
						hit.transform.GetComponent<doorKeyScript.DoorKey>().hide();
					}


				}
				else
				{
					pickUPDoorK.SetActive(false);
				}
			}
			else
			{
				pickUPChestK.SetActive(false);
			}
			//openChest
			if (Physics.Raycast(transform.position, transform.forward, out hit, DistanceOpen) && chestKey&&chestOpened==false)
			{
				if (hit.transform.GetComponent<chestScript.Chest>())
				{
					openChest.SetActive(true);
					if (Input.GetKeyDown(KeyCode.E))
                    {
					hit.transform.GetComponent <chestScript.Chest>().open();
					ChestSound.Play();
					chestK.SetActive(false);
					chestOpened = true;
						chest.GetComponent<Collider>().enabled = false;
                    }
					
				}
				else
				{
					openChest.SetActive(false);
				}
			}
			else
			{
				openChest.SetActive(false);
			}
			//can't open chest
			if (Physics.Raycast(transform.position, transform.forward, out hit, DistanceOpen) && chestKey == false)
			{
				if (hit.transform.GetComponent<chestScript.Chest>())
				{
					XopenChest.SetActive(true);

				}
				else
				{
					XopenChest.SetActive(false);
				}
			}
			else
			{
				XopenChest.SetActive(false);
			}
			//pick up fire note
			if (Physics.Raycast(transform.position, transform.forward, out hit, DistanceOpen))
			{
				if (hit.transform.GetComponent<firenoteNS.FireNote>())
				{
					pikFN.SetActive(true);
					if (Input.GetKeyDown(KeyCode.E))
					{		
						HUD.SetActive(false);
						FNoteObj.SetActive(true);
						player.GetComponent<FirstPersonController>().enabled = false;
						Cursor.visible = true;
						Cursor.lockState = CursorLockMode.None;
					}

				}
				else
				{
					pikFN.SetActive(false);
				}
			}
			else
			{
				pikFN.SetActive(false);
			}
            //pause
            if (Input.GetKeyDown(KeyCode.Escape))
            {
				AudioListener.pause = true;
				HUD.SetActive(false);
				pausePanel.SetActive(true);
				firstTimeLine.SetActive(false);
				player.GetComponent<FirstPersonController>().enabled = false;
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.None;
				Time.timeScale = 0;
			}
			//pick up lighter
			if (Physics.Raycast(transform.position, transform.forward, out hit, DistanceOpen))
			{
				if (hit.transform.GetComponent<NSLighterPik.lighterPik>())
				{
					pikLighter.SetActive(true);
					if (Input.GetKeyDown(KeyCode.E))
					{
						Qlighter.SetActive(true);
						LighterObj.transform.position = hand.transform.position;
						LighterObj.transform.parent = hand.transform;
						haveLighter = true;
					}

				}
				else
				{
					pikLighter.SetActive(false);
				}
			}
			else
			{
				pikLighter.SetActive(false);
			}
            //

            
            //activate and deactivate lighter
            if (Input.GetKeyDown(KeyCode.Q) && haveLighter)
            {
                if (fireActivated == false)
                {
					LighterFire.SetActive(true);
					fireActivated = true;
					code.SetActive(true);
                }else if (fireActivated == true)
                {
					LighterFire.SetActive(false);
					fireActivated = false;
					code.SetActive(false);
				}
            }
			//carry barrel
			//if (Physics.Raycast(transform.position, transform.forward, out hit, DistanceOpen))
			//{
			//	if (hit.transform.GetComponent<XBarrelNS.explosiveBarrel>())
			//	{
			//		carryBarrel.SetActive(true);
			//		if (Input.GetKeyDown(KeyCode.E))
			//		{
						
			//			haveBarrel = true;
			//			XBarrel.SetActive(false);
			//			player.GetComponent<staminaController>().slowed = true;
			//			hit.transform.GetComponent<XBarrelNS.explosiveBarrel>();
			//		}


			//	}
			//	else
			//	{
			//		carryBarrel.SetActive(false);
			//	}
			//}
			//else
			//{
			//	carryBarrel.SetActive(false);
			//}
   //         //drop barrel
   //         if (Input.GetKeyDown(KeyCode.C) && haveBarrel)
   //         {
			////	player.GetComponent<staminaController>().NormalRunSpeed = 4;
			//	haveBarrel = false;
			//	player.GetComponent<staminaController>().slowed = false;

			//}
			//pick up kit1
			if (Physics.Raycast(transform.position, transform.forward, out hit, DistanceOpen))
			{
				if (hit.transform.GetComponent<NSkit1.kit1>())
				{
					pikKit.SetActive(true);
					if (Input.GetKeyDown(KeyCode.E))
					{
						kits++;
						pickUpSound.Play();
						hit.transform.GetComponent<NSkit1.kit1>().hide();
					}


				}
				else
				{
					pikKit.SetActive(false);
				}
			}
			//else
			//{
			//	pikKit.SetActive(false);
			//}
			//pick up kit2
			if (Physics.Raycast(transform.position, transform.forward, out hit, DistanceOpen))
			{
				if (hit.transform.GetComponent<NSkit2.kit2>())
				{
					pikKit.SetActive(true);
					if (Input.GetKeyDown(KeyCode.E))
					{
						kits++;
						pickUpSound.Play();
						hit.transform.GetComponent<NSkit2.kit2>().hide();
					}


				}
		//		else
		//		{
		//			pikKit.SetActive(false);
		//		}
			}
			else
			{
				pikKit.SetActive(false);
			}
			//pick up kit3
			if (Physics.Raycast(transform.position, transform.forward, out hit, DistanceOpen))
			{
				if (hit.transform.GetComponent<NSkit3.kit3>())
				{
					pikKit.SetActive(true);
					if (Input.GetKeyDown(KeyCode.E))
					{
						kits++;
						pickUpSound.Play();
						hit.transform.GetComponent<NSkit3.kit3>().hide();
					}


				}
		//		else
		//		{
		//			pikKit.SetActive(false);
		//		}
			}
			else
			{
				pikKit.SetActive(false);
			}
			//pick up wrench
			if (Physics.Raycast(transform.position, transform.forward, out hit, DistanceOpen))
			{
				if (hit.transform.GetComponent<NSwrench.wrench>())
				{
					pikWrench.SetActive(true);
					if (Input.GetKeyDown(KeyCode.E))
					{
						Wrenches = 1;
						pickUpSound.Play();
						hit.transform.GetComponent<NSwrench.wrench>().hide();
					}


				}
		//		else
		//		{
		//			pikWrench.SetActive(false);
		//		}
			}
			else
			{
				pikWrench.SetActive(false);
			}
			//fix car
			if (Physics.Raycast(transform.position, transform.forward, out hit, DistanceOpen) && Wrenches==1&& kits==3)
			{
				if (hit.transform.GetComponent<NScar.car>())
				{
					Fixcar.SetActive(true);
					if (Input.GetKeyDown(KeyCode.E))
                    {
					particle.SetActive(false);
					timeLine.SetActive(true);
					pickUpSound.Play();
						player.SetActive(false);
					StartCoroutine(CountDownCoroutine(timer));
					}
						
				}
				else
				{
					Fixcar.SetActive(false);
				}
			}
			else
			{
				Fixcar.SetActive(false);
			}

			//can't fix
			if (Physics.Raycast(transform.position, transform.forward, out hit, DistanceOpen) )
			{
				if (hit.transform.GetComponent<NScar.car>())
				{
					Debug.Log("hit car");
					if(Wrenches == 0 || kits != 3)
                    {
						noFix.SetActive(true);
                    }
					

				}
				else if(kits==3 && Wrenches==1)
				{
					Fixcar.SetActive(false);
				}
			}
			else
			{
				noFix.SetActive(false);
			}
            //cheat code
            if (Input.GetKeyDown(KeyCode.I))
            {
				pass = 1;
            }
            if (Input.GetKeyDown(KeyCode.M) && pass == 1)
            {
				pass = 2;
            }
            if (Input.GetKeyDown(KeyCode.O) && pass == 2)
            {
				cheatActive();
            }
				//update end____________________
			}
		IEnumerator CountDownCoroutine(float time)
		{
			
			yield return new WaitForSeconds(time);
			SceneManager.LoadScene(0);
			player.SetActive(false);

		}
		private void cheatActive()
        {
			player.GetComponent<staminaController>().staminaDrain = 0;
			cheatActivatedTXT.SetActive(true);
			player.gameObject.tag = "Untagged";
        }
		public void ExtFNote()
        {
			Cursor.visible = false;
			HUD.SetActive(true);
			FNoteObj.SetActive(false);
			player.GetComponent<FirstPersonController>().enabled = true;
		}
		public void Continue()
        {
			AudioListener.pause = false;
			Time.timeScale = 1;
			Cursor.visible = false;
			HUD.SetActive(true);
			pausePanel.SetActive(false);
			player.GetComponent<FirstPersonController>().enabled = true;
		}
 }
}

