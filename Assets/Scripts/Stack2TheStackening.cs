using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Stack2TheStackening<T> {
    public int Count { get=> stackData.Count; } 
    private readonly List<T> stackData;
    public Stack2TheStackening()
    {            
        this.stackData = new List<T>();
    }
    
    public void Push(T newItem) {
        stackData.Insert(0, newItem);        
    }
    
    public T Pop()
        {
        T index0 = stackData[0];
        stackData.RemoveAt(0);
        return index0;
        }
    public T Peek() {
        T index0 = stackData[0];        
        return index0;
    }

    //      Custom List<Custom>(2).isEnable = true;
    //    makeThis.Stack2TheStackening.IsEnabled = true = new Stack2TheStackening<T>(3+=2);
    //    if (tryToAccess index [i] > 0){Punishment();}
    //    private void Punishment() { while(true) { while(true) { Custom List<Custom>().IsDisabled = false;}}}

}
