using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class PlayerPlatzeesInfo : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] string[] platzees;
    [SerializeField] Image rawImages;
    [SerializeField] GameObject leftParent;
    [SerializeField] RectTransform scrollContainer;
    public static string[] myPlatzees;
    public static List<Texture> myPlatzeesTexture = new List<Texture>();
    public bool isDistrict = false;
    bool isOpened = false;
    
    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {

            if (PlayerPrefs.GetString("Account", "") != "" && isOpened == false)
            {

                CallSmartContract();
                isOpened = true;
            }
        }

    }
    private void Start()
    {
        
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {

            if (PlayerPrefs.GetString("Account", "") != "")
            {
                CallSmartContract();
            }
        }
    }
    
    public async void CallSmartContract()
    {
        // set chain: ethereum, moonbeam, polygon etc
        string chain = "polygon";
        // set network mainnet, testnet
        string network = "Mainnet";
        // smart contract method to call
        string method = "tokenByOwner";
        // abi in json format
        // address of contract
        string abi = "[{\"inputs\" : [ {\"internalType\" : \"string\", \"name\" : \"_name\", \"type\" : \"string\"}, {\"internalType\" : \"string\", \"name\" : \"_symbol\", \"type\" : \"string\"}, {\"internalType\" : \"string\", \"name\" : \"_initBaseURI\", \"type\" : \"string\"}, {\"internalType\" : \"string\", \"name\" : \"_initNotRevealedUri\", \"type\" : \"string\"} ], \"stateMutability\" : \"nonpayable\", \"type\" : \"constructor\"}, {\"anonymous\" : false, \"inputs\" : [ {\"indexed\" : true, \"internalType\" : \"address\", \"name\" : \"owner\", \"type\" : \"address\"}, {\"indexed\" : true, \"internalType\" : \"address\", \"name\" : \"approved\", \"type\" : \"address\"}, {\"indexed\" : true, \"internalType\" : \"uint256\", \"name\" : \"tokenId\", \"type\" : \"uint256\"} ], \"name\" : \"Approval\", \"type\" : \"event\"}, {\"anonymous\" : false, \"inputs\" : [ {\"indexed\" : true, \"internalType\" : \"address\", \"name\" : \"owner\", \"type\" : \"address\"}, {\"indexed\" : true, \"internalType\" : \"address\", \"name\" : \"operator\", \"type\" : \"address\"}, {\"indexed\" : false, \"internalType\" : \"bool\", \"name\" : \"approved\", \"type\" : \"bool\"} ], \"name\" : \"ApprovalForAll\", \"type\" : \"event\"}, {\"anonymous\" : false, \"inputs\" : [ {\"indexed\" : true, \"internalType\" : \"address\", \"name\" : \"previousOwner\", \"type\" : \"address\"}, {\"indexed\" : true, \"internalType\" : \"address\", \"name\" : \"newOwner\", \"type\" : \"address\"} ], \"name\" : \"OwnershipTransferred\", \"type\" : \"event\"}, {\"anonymous\" : false, \"inputs\" : [ {\"indexed\" : true, \"internalType\" : \"address\", \"name\" : \"from\", \"type\" : \"address\"}, {\"indexed\" : true, \"internalType\" : \"address\", \"name\" : \"to\", \"type\" : \"address\"}, {\"indexed\" : true, \"internalType\" : \"uint256\", \"name\" : \"tokenId\", \"type\" : \"uint256\"} ], \"name\" : \"Transfer\", \"type\" : \"event\"}, {\"anonymous\" : false, \"inputs\" : [ {\"indexed\" : false, \"internalType\" : \"address\", \"name\" : \"sender\", \"type\" : \"address\"} ], \"name\" : \"minted\", \"type\" : \"event\"}, {\"inputs\" : [ {\"internalType\" : \"address\", \"name\" : \"to\", \"type\" : \"address\"}, {\"internalType\" : \"uint256\", \"name\" : \"tokenId\", \"type\" : \"uint256\"} ], \"name\" : \"approve\", \"outputs\" : [], \"stateMutability\" : \"nonpayable\", \"type\" : \"function\"}, {\"inputs\" : [ {\"internalType\" : \"address\", \"name\" : \"owner\", \"type\" : \"address\"} ], \"name\" : \"balanceOf\", \"outputs\" : [ {\"internalType\" : \"uint256\", \"name\" : \"\", \"type\" : \"uint256\"} ], \"stateMutability\" : \"view\", \"type\" : \"function\"}, {\"inputs\" : [], \"name\" : \"baseExtension\", \"outputs\" : [ {\"internalType\" : \"string\", \"name\" : \"\", \"type\" : \"string\"} ], \"stateMutability\" : \"view\", \"type\" : \"function\"}, {\"inputs\" : [], \"name\" : \"cost\", \"outputs\" : [ {\"internalType\" : \"uint256\", \"name\" : \"\", \"type\" : \"uint256\"} ], \"stateMutability\" : \"view\", \"type\" : \"function\"}, {\"inputs\" : [ {\"internalType\" : \"uint256\", \"name\" : \"tokenId\", \"type\" : \"uint256\"} ], \"name\" : \"getApproved\", \"outputs\" : [ {\"internalType\" : \"address\", \"name\" : \"\", \"type\" : \"address\"} ], \"stateMutability\" : \"view\", \"type\" : \"function\"}, {\"inputs\" : [ {\"internalType\" : \"address\", \"name\" : \"owner\", \"type\" : \"address\"}, {\"internalType\" : \"address\", \"name\" : \"operator\", \"type\" : \"address\"} ], \"name\" : \"isApprovedForAll\", \"outputs\" : [ {\"internalType\" : \"bool\", \"name\" : \"\", \"type\" : \"bool\"} ], \"stateMutability\" : \"view\", \"type\" : \"function\"}, {\"inputs\" : [], \"name\" : \"maxMintAmount\", \"outputs\" : [ {\"internalType\" : \"uint256\", \"name\" : \"\", \"type\" : \"uint256\"} ], \"stateMutability\" : \"view\", \"type\" : \"function\"}, {\"inputs\" : [], \"name\" : \"maxSupply\", \"outputs\" : [ {\"internalType\" : \"uint256\", \"name\" : \"\", \"type\" : \"uint256\"} ], \"stateMutability\" : \"view\", \"type\" : \"function\"}, {\"inputs\" : [ {\"internalType\" : \"uint256\", \"name\" : \"_mintAmount\", \"type\" : \"uint256\"} ], \"name\" : \"mint\", \"outputs\" : [], \"stateMutability\" : \"payable\", \"type\" : \"function\"}, {\"inputs\" : [], \"name\" : \"name\", \"outputs\" : [ {\"internalType\" : \"string\", \"name\" : \"\", \"type\" : \"string\"} ], \"stateMutability\" : \"view\", \"type\" : \"function\"}, {\"inputs\" : [], \"name\" : \"notRevealedUri\", \"outputs\" : [ {\"internalType\" : \"string\", \"name\" : \"\", \"type\" : \"string\"} ], \"stateMutability\" : \"view\", \"type\" : \"function\"}, {\"inputs\" : [], \"name\" : \"owner\", \"outputs\" : [ {\"internalType\" : \"address\", \"name\" : \"\", \"type\" : \"address\"} ], \"stateMutability\" : \"view\", \"type\" : \"function\"}, {\"inputs\" : [ {\"internalType\" : \"uint256\", \"name\" : \"tokenId\", \"type\" : \"uint256\"} ], \"name\" : \"ownerOf\", \"outputs\" : [ {\"internalType\" : \"address\", \"name\" : \"\", \"type\" : \"address\"} ], \"stateMutability\" : \"view\", \"type\" : \"function\"}, {\"inputs\" : [], \"name\" : \"paused\", \"outputs\" : [ {\"internalType\" : \"bool\", \"name\" : \"\", \"type\" : \"bool\"} ], \"stateMutability\" : \"view\", \"type\" : \"function\"}, {\"inputs\" : [ {\"internalType\" : \"address\", \"name\" : \"adr\", \"type\" : \"address\"} ], \"name\" : \"pivote\", \"outputs\" : [], \"stateMutability\" : \"nonpayable\", \"type\" : \"function\"}, {\"inputs\" : [], \"name\" : \"renounceOwnership\", \"outputs\" : [], \"stateMutability\" : \"nonpayable\", \"type\" : \"function\"}, {\"inputs\" : [], \"name\" : \"reveal\", \"outputs\" : [], \"stateMutability\" : \"nonpayable\", \"type\" : \"function\"}, {\"inputs\" : [], \"name\" : \"revealed\", \"outputs\" : [ {\"internalType\" : \"bool\", \"name\" : \"\", \"type\" : \"bool\"} ], \"stateMutability\" : \"view\", \"type\" : \"function\"}, {\"inputs\" : [ {\"internalType\" : \"address\", \"name\" : \"from\", \"type\" : \"address\"}, {\"internalType\" : \"address\", \"name\" : \"to\", \"type\" : \"address\"}, {\"internalType\" : \"uint256\", \"name\" : \"tokenId\", \"type\" : \"uint256\"} ], \"name\" : \"safeTransferFrom\", \"outputs\" : [], \"stateMutability\" : \"nonpayable\", \"type\" : \"function\"}, {\"inputs\" : [ {\"internalType\" : \"address\", \"name\" : \"from\", \"type\" : \"address\"}, {\"internalType\" : \"address\", \"name\" : \"to\", \"type\" : \"address\"}, {\"internalType\" : \"uint256\", \"name\" : \"tokenId\", \"type\" : \"uint256\"}, {\"internalType\" : \"bytes\", \"name\" : \"_data\", \"type\" : \"bytes\"} ], \"name\" : \"safeTransferFrom\", \"outputs\" : [], \"stateMutability\" : \"nonpayable\", \"type\" : \"function\"}, {\"inputs\" : [ {\"internalType\" : \"address\", \"name\" : \"operator\", \"type\" : \"address\"}, {\"internalType\" : \"bool\", \"name\" : \"approved\", \"type\" : \"bool\"} ], \"name\" : \"setApprovalForAll\", \"outputs\" : [], \"stateMutability\" : \"nonpayable\", \"type\" : \"function\"}, {\"inputs\" : [ {\"internalType\" : \"string\", \"name\" : \"_newBaseExtension\", \"type\" : \"string\"} ], \"name\" : \"setBaseExtension\", \"outputs\" : [], \"stateMutability\" : \"nonpayable\", \"type\" : \"function\"}, {\"inputs\" : [ {\"internalType\" : \"string\", \"name\" : \"_newBaseURI\", \"type\" : \"string\"} ], \"name\" : \"setBaseURI\", \"outputs\" : [], \"stateMutability\" : \"nonpayable\", \"type\" : \"function\"}, {\"inputs\" : [ {\"internalType\" : \"uint256\", \"name\" : \"_newCost\", \"type\" : \"uint256\"} ], \"name\" : \"setCost\", \"outputs\" : [], \"stateMutability\" : \"nonpayable\", \"type\" : \"function\"}, {\"inputs\" : [ {\"internalType\" : \"string\", \"name\" : \"_notRevealedURI\", \"type\" : \"string\"} ], \"name\" : \"setNotRevealedURI\", \"outputs\" : [], \"stateMutability\" : \"nonpayable\", \"type\" : \"function\"}, {\"inputs\" : [ {\"internalType\" : \"bool\", \"name\" : \"_state\", \"type\" : \"bool\"} ], \"name\" : \"setPauseMint\", \"outputs\" : [], \"stateMutability\" : \"nonpayable\", \"type\" : \"function\"}, {\"inputs\" : [ {\"internalType\" : \"uint256\", \"name\" : \"_newmaxMintAmount\", \"type\" : \"uint256\"} ], \"name\" : \"setmaxMintAmount\", \"outputs\" : [], \"stateMutability\" : \"nonpayable\", \"type\" : \"function\"}, {\"inputs\" : [ {\"internalType\" : \"bytes4\", \"name\" : \"interfaceId\", \"type\" : \"bytes4\"} ], \"name\" : \"supportsInterface\", \"outputs\" : [ {\"internalType\" : \"bool\", \"name\" : \"\", \"type\" : \"bool\"} ], \"stateMutability\" : \"view\", \"type\" : \"function\"}, {\"inputs\" : [], \"name\" : \"symbol\", \"outputs\" : [ {\"internalType\" : \"string\", \"name\" : \"\", \"type\" : \"string\"} ], \"stateMutability\" : \"view\", \"type\" : \"function\"}, {\"inputs\" : [ {\"internalType\" : \"uint256\", \"name\" : \"index\", \"type\" : \"uint256\"} ], \"name\" : \"tokenByIndex\", \"outputs\" : [ {\"internalType\" : \"uint256\", \"name\" : \"\", \"type\" : \"uint256\"} ], \"stateMutability\" : \"view\", \"type\" : \"function\"}, {\"inputs\" : [ {\"internalType\" : \"address\", \"name\" : \"_owner\", \"type\" : \"address\"} ], \"name\" : \"tokenByOwner\", \"outputs\" : [ {\"internalType\" : \"uint256[]\", \"name\" : \"\", \"type\" : \"uint256[]\"} ], \"stateMutability\" : \"view\", \"type\" : \"function\"}, {\"inputs\" : [ {\"internalType\" : \"address\", \"name\" : \"owner\", \"type\" : \"address\"}, {\"internalType\" : \"uint256\", \"name\" : \"index\", \"type\" : \"uint256\"} ], \"name\" : \"tokenOfOwnerByIndex\", \"outputs\" : [ {\"internalType\" : \"uint256\", \"name\" : \"\", \"type\" : \"uint256\"} ], \"stateMutability\" : \"view\", \"type\" : \"function\"}, {\"inputs\" : [ {\"internalType\" : \"uint256\", \"name\" : \"tokenId\", \"type\" : \"uint256\"} ], \"name\" : \"tokenURI\", \"outputs\" : [ {\"internalType\" : \"string\", \"name\" : \"\", \"type\" : \"string\"} ], \"stateMutability\" : \"view\", \"type\" : \"function\"}, {\"inputs\" : [], \"name\" : \"totalSupply\", \"outputs\" : [ {\"internalType\" : \"uint256\", \"name\" : \"\", \"type\" : \"uint256\"} ], \"stateMutability\" : \"view\", \"type\" : \"function\"}, {\"inputs\" : [ {\"internalType\" : \"address\", \"name\" : \"from\", \"type\" : \"address\"}, {\"internalType\" : \"address\", \"name\" : \"to\", \"type\" : \"address\"}, {\"internalType\" : \"uint256\", \"name\" : \"tokenId\", \"type\" : \"uint256\"} ], \"name\" : \"transferFrom\", \"outputs\" : [], \"stateMutability\" : \"nonpayable\", \"type\" : \"function\"}, {\"inputs\" : [ {\"internalType\" : \"address\", \"name\" : \"newOwner\", \"type\" : \"address\"} ], \"name\" : \"transferOwnership\", \"outputs\" : [], \"stateMutability\" : \"nonpayable\", \"type\" : \"function\"}, {\"inputs\" : [], \"name\" : \"withdraw\", \"outputs\" : [], \"stateMutability\" : \"payable\", \"type\" : \"function\"}]";

        string contract = "0xFEc50dae05902f4A1C303Da8fB7477f7DEA751d5";
        // array of arguments for contract
        //setThis Argument to Player.pref()
        //setThis Argument to Player.pref()
        string args = $"[\"{PlayerPrefs.GetString("Account", "")}\"]";

        // string args = "[\"0x5829081B71eaf16d4563121275a285df1843f191\"]";

         Debug.Log(PlayerPrefs.GetString("Account", ""));
        // connects to user's browser wallet to call a transaction
        var response = await EVM.Call(chain, network, contract, abi, method, args);
        platzees = response.Split(',');
        // Debug.Log("7");
        foreach (string plat in platzees)
        {
            string s = plat.Replace("[", "");
            s = s.Replace(@"""", "");
            s = s.Replace("]", "");
            if (!isDistrict)
            {

                GetImages(s);
            }
            else
            {
                if (GameObject.Find(s))
                {
                    GetImages(s);
                }
            }
        }
    }

    // display response in game
    // print(response);


    string link = "https://platzees.mypinata.cloud/ipfs/";
    int posX = -140;
    int posY = 320;
    int count = 0;
    async void GetImages(string platNum)
    {
        count++;

        //scrollContainer.sizeDelta = new Vector2(295, scrollContainer.sizeDelta.y+180) ;

        string imageURI = $"ipfs://QmcTgNdk8RtvDCuD5pAXFbMqWKfSb8isk1GCCc12djFHTu/{platNum}.json";
        imageURI.Replace("ipfs://", link);
        string uri = $"https://platzees.mypinata.cloud/ipfs/QmYzo4hhMq75HGCoi5UxCz1NNX7GXLpbvyhmehhAw8fQqk/{platNum}.PNG";
        // img.Replace("ipfs://", link);
        Image images = Instantiate(rawImages, transform.position, transform.rotation, leftParent.transform);

        images.GetComponent<PlatzeeNames>().setText(platNum);
        RawImage rawI = images.GetComponentInChildren<RawImage>();

        StartCoroutine(DownloadImage(uri, rawI));
    }

    IEnumerator DownloadImage(string uri, RawImage img)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(uri);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else
        {
            img.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            myPlatzeesTexture.Add(img.texture);
            img.transform.parent.gameObject.SetActive(true);
        }
    }
}
