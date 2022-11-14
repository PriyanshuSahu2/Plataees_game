using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERC721OwnerOfExample : MonoBehaviour
{
    async void Start()
    {
        string chain = "ethereum";
        string network = "mainnet";
        string contract = "0xd9145CCE52D386f254917e481eB44e9943F39138";
        string tokenId = "1";
        string account = "0x18745E02D015306a6e0BA24645BA694Adb3E26a4";
        string ownerOf = await ERC721.OwnerOf(chain, network, contract, tokenId);
        print(ownerOf);
    }
}
