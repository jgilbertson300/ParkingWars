#pragma strict
function QuitGame() {
	Debug.Log("Quit doesn't work in editor.");				
	Application.Quit();
}
	function SelectSportsCar(){
	Debug.Log("SportsCar is selected for player2.");
	PlayerPrefs.SetString("Player2Choice", "Car_Sports");
	PlayerPrefs.SetString("Player2Source", "SportsCar_Src");
	PlayerPrefs.SetString("Player2Source2", "SportsCar_Src2");
	PlayerPrefs.SetInt("Player2Conf", 0);
	PlayerPrefs.SetFloat("Player2Speed", 8.0f);
	PlayerPrefs.SetFloat("Player2Rotation", 100.0f);
	PlayerPrefs.SetInt("Player2MaxHits", 3);
}

function SelectSedan(){
	Debug.Log("Sedan is selected for player2.");
	PlayerPrefs.SetString("Player2Choice", "Car_Sedan");
	PlayerPrefs.SetString("Player2Source", "Sedan_Src");
	PlayerPrefs.SetString("Player2Source2", "Sedan_Src2");
	PlayerPrefs.SetInt("Player2Conf", 2);
	PlayerPrefs.SetFloat("Player2Speed", 6.0f);
	PlayerPrefs.SetFloat("Player2Rotation", 75.0f);
	PlayerPrefs.SetInt("Player2MaxHits", 5);
}

function SelectSUV(){
	Debug.Log("SUV is selected for player2.");
	PlayerPrefs.SetString("Player2Choice", "Car_SUV");
	PlayerPrefs.SetString("Player2Source", "SUV_Src");
	PlayerPrefs.SetString("Player2Source2", "SUV_Src2");
	PlayerPrefs.SetInt("Player2Conf", 2);
	PlayerPrefs.SetFloat("Player2Speed", 4.0f);
	PlayerPrefs.SetFloat("Player2Rotation", 50.0f);
	PlayerPrefs.SetInt("Player2MaxHits", 7);
}
function StartGame() {
	Application.LoadLevel("Level_1");
}

function MainMenu() {
	Application.LoadLevel("Start_Screen");
}