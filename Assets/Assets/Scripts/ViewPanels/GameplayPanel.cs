using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayPanel : BasePanel
{
    public void ExtExit()
   {
       ServiceManager.ViewManager.TransitToMainMenu();
   }
}
