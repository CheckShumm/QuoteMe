using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanel : BasePanel
{

   public void ExtCreateRoom() {
        ServiceManager.ViewManager.TransitToRoom();
   }

   public void ExtPlay()
   {
       ServiceManager.ViewManager.TransitToGameplay();
   }
}
