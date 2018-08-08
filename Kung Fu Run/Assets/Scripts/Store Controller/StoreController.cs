using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreController : MonoBehaviour {

    public static StoreController instance;

    public Image exchangeStore;
    public Image dumplingStore;
    public Image rubyStore;

    public Text dumplingText;
    public Text rubyText;

	// Use this for initialization
	void Start () {
        MakeInstance();

        SetRubyStore();
        SetCount();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    public void SetRubyStore()
    {
        exchangeStore.gameObject.SetActive(false);
        dumplingStore.gameObject.SetActive(false);
        rubyStore.gameObject.SetActive(true);
    }

    public void SetDumplingStore()
    {
        exchangeStore.gameObject.SetActive(false);
        rubyStore.gameObject.SetActive(false);
        dumplingStore.gameObject.SetActive(true);
    }

    public void SetExchangeStore()
    {
        rubyStore.gameObject.SetActive(false);
        dumplingStore.gameObject.SetActive(false);
        exchangeStore.gameObject.SetActive(true);
    }

    public void SetCount()
    {
        dumplingText.text = "" + GamePreferences.GetDumplingCount();
        rubyText.text = "" + GamePreferences.GetSpecialCoinCoint();
    }

    public void Exchange()
    {
        if(GamePreferences.GetDumplingCount() >= 2000)
        {
            int dumpling = GamePreferences.GetDumplingCount();
            int ruby = GamePreferences.GetSpecialCoinCoint();

            dumpling -= 2000;
            ruby += 1;

            GamePreferences.SetDumplingCount(dumpling);
            GamePreferences.SetSpecialCoinCount(ruby);
            SetCount();
            CharSelectionController.instance.SetCount();
        }

        else
        {
            SetDumplingStore();
        }
    }
    


}
