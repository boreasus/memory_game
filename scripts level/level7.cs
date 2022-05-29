using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class level7 : MonoBehaviour
{
    



    public Text Score = GameObject.Find("Score").GetComponent<Text>();
    public Text Note = GameObject.Find("Note").GetComponent<Text>();


    // Start is called before the first frame update
  //Make sure to attach these Buttons in the Inspector
    public Button C, D, E, F, G, A, B;
    public AudioSource SC,SD,SE,SF,SG,SA,SB;
    public int counter,point =0;




IEnumerator playNote(int counter,AudioSource C,AudioSource D,AudioSource E,AudioSource F,AudioSource G,AudioSource A,AudioSource B,double time){
    yield return new WaitForSeconds((float)(1+time));
    if(counter == 1){
        C.Play();
        Note.text = "C";
    }else if(counter ==2){
        D.Play();
        Note.text = "D";        
    }
    else if(counter ==3){
        E.Play();
        Note.text = "E";
    }
    else if(counter ==4){
        F.Play();
        Note.text = "F";
    }
    else if(counter ==5){
        G.Play();
        Note.text = "G";
    }
    else if(counter ==6){
        A.Play();
        Note.text = "A";
    }
    else if(counter ==7){
        B.Play();
        Note.text = "B";
    }
        yield return new WaitForSeconds((float)(1+time));

}

    async void Start()
    {
        
        Score.text = "Score = "+point;
        int []arr = new int[7];
        int []control = new int[7];
        int i = 0;
        for(i = 0; i<7; i++){
            arr[i] = Random.Range(1,6);; 

        }   
   



        StartCoroutine(playNote(arr[0],SC,SD,SE,SF,SG,SA,SB,0));
        StartCoroutine(playNote(arr[1],SC,SD,SE,SF,SG,SA,SB,1));
        StartCoroutine(playNote(arr[2],SC,SD,SE,SF,SG,SA,SB,2));
        StartCoroutine(playNote(arr[3],SC,SD,SE,SF,SG,SA,SB,3));
        StartCoroutine(playNote(arr[4],SC,SD,SE,SF,SG,SA,SB,4));
        StartCoroutine(playNote(arr[5],SC,SD,SE,SF,SG,SA,SB,5));
        StartCoroutine(playNote(arr[6],SC,SD,SE,SF,SG,SA,SB,6));

        Note.text = "";



        C.onClick.AddListener(delegate {TaskWithParameters("C'YE BASILDI",arr,control,1,ref counter,SC,SD,SE,SF,SG,SA,SB); });
        D.onClick.AddListener(delegate {TaskWithParameters("D'YE BASILDI",arr,control,2,ref counter,SC,SD,SE,SF,SG,SA,SB); });
        E.onClick.AddListener(delegate {TaskWithParameters("E'YE BASILDI",arr,control,3,ref counter,SC,SD,SE,SF,SG,SA,SB); });
        F.onClick.AddListener(delegate {TaskWithParameters("F'YE BASILDI",arr,control,4,ref counter,SC,SD,SE,SF,SG,SA,SB); });
        G.onClick.AddListener(delegate {TaskWithParameters("G'YE BASILDI",arr,control,5,ref counter,SC,SD,SE,SF,SG,SA,SB); });
        A.onClick.AddListener(delegate {TaskWithParameters("A'YE BASILDI",arr,control,6,ref counter,SC,SD,SE,SF,SG,SA,SB); });
        B.onClick.AddListener(delegate {TaskWithParameters("B'YE BASILDI",arr,control,7,ref counter,SC,SD,SE,SF,SG,SA,SB); });
    

    }

    void TaskWithParameters(string message, int[]order,int[]control, int val,ref int _counter,
    AudioSource C,AudioSource D,AudioSource E,AudioSource F,AudioSource G,AudioSource A,AudioSource B)
    {
        
        Debug.Log(message);
        Debug.Log(val);
        Debug.Log(counter);
        control[counter] = val;
        Debug.Log(control[counter]);

        if(val == order[counter]){
            Debug.Log("Dogru nota"); 
            point+=10;
            Score.text = "Score = "+point;
            if(point == 70 )SceneManager.LoadScene("G8");


        }
        else{       
            Debug.Log("Yanlis Nota"); point = 0;
            Score.text = "Score = "+point;
            SceneManager.LoadScene("FAILED");

        }


        if(counter <6){
        _counter++;
        
        }
        else{
            point = 0;
        _counter = 0;
        Debug.Log("Girdi");}



    }
        
       void update(){
           if(point == 70){
               SceneManager.LoadScene("G8");
               Debug.Log("level2");
           }
       }      

}

