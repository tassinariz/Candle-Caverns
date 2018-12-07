using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField] Tilemap DarkMap;
    [SerializeField] Tilemap BlurryMap;
    [SerializeField] Tilemap Background;

    [SerializeField] Tile DarkTile;
    [SerializeField] Tile BlurryTile;

    // Use this for initialization
    void Start () {
        DarkMap.origin = BlurryMap.origin = Background.origin;
        DarkMap.size = BlurryMap.size = Background.size;

        foreach( Vector3Int p in DarkMap.cellBounds.allPositionsWithin)
        {
            DarkMap.SetTile(p, DarkTile);
        }
        foreach (Vector3Int p in BlurryMap.cellBounds.allPositionsWithin)
        {
            BlurryMap.SetTile(p, BlurryTile);
        }
    }
}// end class