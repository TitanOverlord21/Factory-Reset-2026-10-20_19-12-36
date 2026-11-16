using UnityEngine;
using System.Collections.Generic;

public class KeyPadScript : MonoBehaviour
{

    [SerializeField] private List <int> CorrectCode = new List<int>();
    private List <int> CodeEntered = new List<int>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }



        private void OnEnable()
    {
        // StairsForNow.StairFixed1 += FixSelf1;
        Eyes.Interacted += ButtonIsClicked;
    }
    private void OnDisable()
    {
        // StairsForNow.StairFixed1 -= FixSelf1;
        Eyes.Interacted -= ButtonIsClicked;
    }

    //Just so it's easy to read, I'm going to bruteforce this in a way that doesn't scale at all to more keys
    private void ButtonIsClicked(string TargetStruck){
        if (TargetStruck == "Button01"){
            CodeEntered.Add(1);
        }
        else if (TargetStruck == "Button02"){
            CodeEntered.Add(2);
        }
        else if (TargetStruck == "Button03"){
            CodeEntered.Add(3);
        }
        else if (TargetStruck == "Button04"){
            CodeEntered.Add(4);
        }
        else if (TargetStruck == "Button05"){
            CodeEntered.Add(5);
        }
        else if (TargetStruck == "Button06"){
            CodeEntered.Add(6);
        }
        else if (TargetStruck == "Button07"){
            CodeEntered.Add(7);
        }
        else if (TargetStruck == "Button08"){
            CodeEntered.Add(8);
        }
        else if (TargetStruck == "Button09"){
            CodeEntered.Add(9);
        }
        else if (TargetStruck == "Button10"){
            CodeEntered.Clear();
        }
        else if (TargetStruck == "Button11"){
            CodeEntered.Add(0);
        }
        else if (TargetStruck == "Button12"){
            CheckCode();
            CodeEntered.Clear();
        }
    }

    private void CheckCode (){
    // Debug.Log(CorrectCode);
    // Debug.Log(CodeEntered); Won't work btw. It just says it's a list of ints or something lmao


    //Most disgusting brute force method known to man holy shit
    
    if (CodeEntered[0] == CorrectCode[0]){
        if (CodeEntered[1] == CorrectCode[1]){
            if (CodeEntered[2] == CorrectCode[2]){
                if (CodeEntered[3] == CorrectCode[3]){
        Debug.Log("This is where it does something for the right code");
    }   
    }
    }
    }
        // if (CorrectCode = CodeEntered){
        //     Debug.Log("This is where it does something for the right code");
        // }
    }
}
