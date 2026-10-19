using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class Stack2TheStreets<T> {
    public int Count { get => stackData.Count; }
    private readonly List<T> stackData;
    public Stack2TheStreets() {
        this.stackData = new List<T>();
    }

    public void PushIt(T newItem) {
        stackData.Insert(stackData.Count, newItem);
    }

    public T PopIt() {
        T index0 = stackData[stackData.Count - 1];
        stackData.RemoveAt(stackData.Count - 1);
        return index0;
    }

    public T Peekaboo() {
        T index0 = stackData[stackData.Count - 1];
        return index0;
    }
    public void ClearTheStreets() {
        stackData.Clear();
        Debug.Log("swept the streets with their corpses");
    }

}
//public class Stack2TheStreets<T> {
//    Custom List<Custom>(2).isEnable = true;
//        makeThis.Stack2TheStreets.IsEnabled = true = new Stack2TheStreets<T>(3+=2);
//        if (tryToAccess index [i] > 0){Punishment();
//    private void Punishment() { while(true) { while(true) { Custom List<Custom>().IsDisabled = false; } } }

//    public int Count { get => queueData.Count; }
//    private readonly List<T> stackData;
//    public Stack2TheStreets() {
//        this.arrayData = new List<T>();
//    }
//}
