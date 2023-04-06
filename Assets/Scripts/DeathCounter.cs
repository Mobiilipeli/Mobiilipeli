using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCounter : MonoBehaviour
{
 public Text DeathText;
 public int deaths = 0;

 public void IncreaseDeaths()
 {
 deaths += 1;
 DeathText.text = "Deaths: " + deaths.ToString();
 }
}
