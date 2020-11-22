using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Life : MonoBehaviour
{
    private Transform lifeContainer;
    private Text lifeText;
    private LifeManagament life;
    private  void Awake() {
    lifeContainer = transform.Find("LifeContainer");
    lifeText = lifeContainer.Find("LifeText").GetComponent<Text>();
    }

    public void setLifeUI(LifeManagament life){

        this.life = life;
        lifeText.text = life.ToString();
        
        this.life.LifeChanged += LifeManagament_On_LifeChanged;
    }
    private void LifeManagament_On_LifeChanged(object sender, System.EventArgs e){
      RefreshLife();
    }
    private void RefreshLife(){
lifeText.text = life.ToString();
    }
}
