using System.Collections.Generic;
using UnityEngine;

public class Wiiwoo<T> {
    public int Count { get => qWooData.Count; }
    private readonly List<T> qWooData;
    public Wiiwoo() {
        this.qWooData = new List<T>();
    }

    public void Qit(T newItem) {
        if (qWooData.Count == 0) { qWooData.Insert(0, newItem); }
        else qWooData.Insert(qWooData.Count, newItem);
    }

    public T Dq() {
        T index0 = qWooData[0];
        qWooData.RemoveAt(0);
        return index0;
    }

    public T Pq() {
        T index0 = qWooData[0];
        return index0;
    }

    public void ClearQ() {
        qWooData.Clear();
        
    }

}
//public class Wiiwoo<T> {
//    Custom List<Custom>(2).isEnable = true;
//        makeThis.Wiiwoo.IsEnabled = true = new Wiiwoo<T>(3+=2);
//        if (tryToAccess index [i] > 0){Punishment();
//    private void Punishment() { while(true) { while(true) { Custom List<Custom>().IsDisabled = false; } } }

//    public int Count { get => queueData.Count; }
//    private readonly List<T> qWooData;
//    public Wiiwoo() {
//        this.arrayData = new List<T>();
//    }
//}
