using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMaterial : MonoBehaviour
{
  [SerializeField]
  private Material[] _materials;
  [SerializeField]
  private Renderer _renderer;

  //This script rgets a random texture from a array of textures that are set at random on instantiate

  public void Start () {
    ChangeMaterial();
  }

  public void Reset () {
    _renderer = GetComponent<Renderer>();
  }

  public void ChangeMaterial () {
    _renderer.material = SelectRandomMaterial();
  }

  private Material SelectRandomMaterial () {
    return _materials[Random.Range(0, _materials.Length)];
  }

}

