using ClosedObjectsCollectionApp;

ClosedObjectsList<int> myList = new ClosedObjectsList<int>();
myList.Add(1);
myList.Add(2);
myList.Add(5);
myList.Add(10);
myList.Remove(2);
myList.RemoveAt(1);
myList.Add(8);
myList.Add(12);
myList.MoveNext(2);
myList.MoveBack(3);
var item = myList.Current;
