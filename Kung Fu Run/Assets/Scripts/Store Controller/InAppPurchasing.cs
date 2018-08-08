using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Purchasing;
using UnityEngine.Purchasing;

public class InAppPurchasing : MonoBehaviour, IStoreListener {

    private static IStoreController m_StoreController;
    private static IExtensionProvider m_StoreExtensionProvider;

    public static string threeRubies = "kfr._threerubies3";
    public static string tenRubies = "kfr._tenrubies10";
    public static string fourtyRubies = "kfr._fourtyrubies40";

    public static string threeKDumplings = "kfr._threekdumplings3";
    public static string twentyKDumplings = "kfr._twentykdumplings20";
    public static string fourtyKDumplings = "kfr._fourtykdumplings40";


    // Use this for initialization
    void Start () {
        // If we haven't set up the Unity Purchasing reference
        if (m_StoreController == null)
        {
            // Begin to configure our connection to Purchasing
            InitializePurchasing();
        }
    }

    public void InitializePurchasing()
    {
        if(IsInitialized())
        {
            return;
        }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(threeRubies, ProductType.Consumable);
        builder.AddProduct(tenRubies, ProductType.Consumable);
        builder.AddProduct(fourtyRubies, ProductType.Consumable);
        builder.AddProduct(threeKDumplings, ProductType.Consumable);
        builder.AddProduct(twentyKDumplings, ProductType.Consumable);
        builder.AddProduct(fourtyKDumplings, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);

    }

    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }

    //Buy the products-------------------
    public void BuyThreeRubies()
    {
        BuyProductId(threeRubies);
    }
    public void BuyTenRubies()
    {
        BuyProductId(tenRubies);
    }
    public void BuyFourtyRubies()
    {
        BuyProductId(fourtyRubies);
    }
    public void BuyThreeKDumplings()
    {
        BuyProductId(threeKDumplings);
    }
    public void BuyTwentyKDumplings()
    {
        BuyProductId(twentyKDumplings);
    }
    public void BuyFourtyKDumplings()
    {
        BuyProductId(fourtyKDumplings);
    }
    //Buy the products-------------------

    void BuyProductId(string productID)
    {
        if(IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productID);

            if(product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asynchronously: '{0}'", product.definition.id));
                m_StoreController.InitiatePurchase(product);
            }

            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or not available for purchase");
            }
        }

        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized");
        }
    }

    public void RestorePurchases()
    {
        // If Purchasing has not yet been set up ...
        if (!IsInitialized())
        {
            // ... report the situation and stop restoring. Consider either waiting longer, or retrying initialization.
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        // If we are running on an Apple device ... 
        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            // ... begin restoring purchases
            Debug.Log("RestorePurchases started ...");

            // Fetch the Apple store-specific subsystem.
            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
            // Begin the asynchronous process of restoring purchases. Expect a confirmation response in 
            // the Action<bool> below, and ProcessPurchase if there are previously purchased products to restore.
            apple.RestoreTransactions((result) => {
                // The first phase of restoration. If no more responses are received on ProcessPurchase then 
                // no purchases are available to be restored.
                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
            });
        }
        // Otherwise ...
        else
        {
            // We are not running on an Apple device. No work is necessary to restore purchases.
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: PASS");
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializedFailed InitializationFailureReason:" + error);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if(string.Equals(args.purchasedProduct.definition.id, threeRubies, System.StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            IncreaseRubies(3);
        }
        else if (string.Equals(args.purchasedProduct.definition.id, tenRubies, System.StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            IncreaseRubies(10);
        }
        else if (string.Equals(args.purchasedProduct.definition.id, fourtyRubies, System.StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            IncreaseRubies(40);
        }

        else if (string.Equals(args.purchasedProduct.definition.id, threeKDumplings, System.StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            IncreaseDumplings(3000);
        }
        else if (string.Equals(args.purchasedProduct.definition.id, twentyKDumplings, System.StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            IncreaseDumplings(20000);
        }
        else if (string.Equals(args.purchasedProduct.definition.id, fourtyKDumplings, System.StringComparison.Ordinal))
        {
            Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
            IncreaseDumplings(40000);
        }

        else
        {
            Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
        }

        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
    






    //Rubies and Dumplings Purchase Aid Methods
    public void IncreaseRubies(int value)
    {
        int temp = GamePreferences.GetSpecialCoinCoint();
        temp += value;
        GamePreferences.SetSpecialCoinCount(temp);

        StoreController.instance.SetCount();
        CharSelectionController.instance.SetCount();
    }

    public void IncreaseDumplings(int value)
    {
        int temp = GamePreferences.GetDumplingCount();
        temp += value;
        GamePreferences.SetDumplingCount(temp);

        StoreController.instance.SetCount();
        CharSelectionController.instance.SetCount();
    }




}
