using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{

    public string name;
    
    //sets an array for the sentences to go inside and hte text area changes the size of the box for editing
    [TextArea(3, 10)]
    public string[] sentences;
}
