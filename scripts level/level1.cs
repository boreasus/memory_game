using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class level1 : MonoBehaviour
{
    




    // Start is called before the first frame update
  //Make sure to attach these Buttons in the Inspector
    public Button C, D, E;
    public Text Score = GameObject.Find("Score").GetComponent<Text>();
    public Text Note = GameObject.Find("Note").GetComponent<Text>();

    public AudioSource SC,SD,SE;
    public int counter,point =0;




IEnumerator playNote(int counter,AudioSource C,AudioSource D,AudioSource E,int time){
    yield return new WaitForSeconds(1+time);
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
        yield return new WaitForSeconds(1+time);

}

    async void Start()
    {
        Score.text = "Score = "+point;
        int []arr = new int[7];
        int []control = new int[7];
        int i = 0;
        for(i = 0; i<5; i++){
            arr[i] = Random.Range(1,4); 

        }   
   



        StartCoroutine(playNote(arr[0],SC,SD,SE,0));
        StartCoroutine(playNote(arr[1],SC,SD,SE,1));
        StartCoroutine(playNote(arr[2],SC,SD,SE,2));
        StartCoroutine(playNote(arr[3],SC,SD,SE,3));
        StartCoroutine(playNote(arr[4],SC,SD,SE,4));

        Note.text = "";



        C.onClick.AddListener(delegate {TaskWithParameters("C'YE BASILDI",arr,control,1,ref counter,SC,SD,SE); });
        D.onClick.AddListener(delegate {TaskWithParameters("D'YE BASILDI",arr,control,2,ref counter,SC,SD,SE); });
        E.onClick.AddListener(delegate {TaskWithParameters("E'YE BASILDI",arr,control,3,ref counter,SC,SD,SE); });

    

    }

    void TaskWithParameters(string message, int[]order,int[]control, int val,ref int _counter,
    AudioSource C,AudioSource D,AudioSource E)
    {
        //Output this to console when the Button2 is clicked
        Debug.Log(message);
        Debug.Log(val);
        Debug.Log(counter);
        control[counter] = val;
        Debug.Log(control[counter]);

        if(val == order[counter]){
            Debug.Log("Dogru nota"); 
            point+=10;
            Score.text = "Score = "+point;
                if(point == 50)
               SceneManager.LoadScene("G2");

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
               SceneManager.LoadScene("G2");
           }
       }      

}

