using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GalleryBase", menuName = "GalleryBase")]
public class GalleryBase : ScriptableObject
{
    public List<PictureType> pictures;
}

