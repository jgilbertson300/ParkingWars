#pragma strict
         
function QuitGame() {				
	Debug.Log("Quit doesn't work in editor.");
	Application.Quit();
}
function SelectSportsCar(){
	Debug.Log("SportsCar is selected for player1.");
	PlayerPrefs.SetString("Player1Choice", "Car_Sports");
	PlayerPrefs.SetString("Player1Source", "SportsCar_Src");
	PlayerPrefs.SetString("Player1Source2", "SportsCar_Src2");
	PlayerPrefs.SetInt("Player1Conf", 0);
	PlayerPrefs.SetFloat("Player1Speed", 8.0f);
	PlayerPrefs.SetFloat("Player1Rotation", 100.0f);
	PlayerPrefs.SetInt("Player1MaxHits", 3);
}

function SelectSedan(){
	Debug.Log("Sedan is selected for player1.");
	PlayerPrefs.SetString("Player1Choice", "Car_Sedan");
	PlayerPrefs.SetString("Player1Source", "Sedan_Src");
	PlayerPrefs.SetString("Player1Source2", "Sedan_Src2");
	PlayerPrefs.SetInt("Player1Conf", 2);
	PlayerPrefs.SetFloat("Player1Speed", 6.0f);
	PlayerPrefs.SetFloat("Player1Rotation", 75.0f);
	PlayerPrefs.SetInt("Player1MaxHits", 5);
}

function SelectSUV(){
	Debug.Log("SUV is selected for player1.");
	PlayerPrefs.SetString("Player1Choice", "Car_SUV");
	PlayerPrefs.SetString("Player1Source", "SUV_Src");
	PlayerPrefs.SetString("Player1Source2", "SUV_Src2");
	PlayerPrefs.SetInt("Player1Conf", 2);
	PlayerPrefs.SetFloat("Player1Speed", 4.0f);
	PlayerPrefs.SetFloat("Player1Rotation", 50.0f);
	PlayerPrefs.SetInt("Player1MaxHits", 7);
}

function LoadStart1() {
	Application.LoadLevel("Start_Screen");
}
function LoadStart2() {
	Application.LoadLevel("Start_Screen2");
}

function MainMenu() {
	Application.LoadLevel("Start_Screen");
}
function Update() {
		if(Input.GetKeyDown("escape")) {
			Debug.Log ("can't quit from editor");
				Application.Quit(); 
		}
}
