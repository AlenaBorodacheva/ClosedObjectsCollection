using System;
using ClosedObjectsCollectionApp;
using ClosedObjectsListTest.Models;
using Xunit;

namespace ClosedObjectsListTest
{
    public class ClosedObjectsListTest
    {
        [Fact]
        public void AddAndHeadItemTest()
        {
            var list = new ClosedObjectsList<SomeClass>();
            Assert.Throws<NullReferenceException>(() => list.Head);
            list.Add(new SomeClass(){Value = 3});
            list.Add(new SomeClass(){Value = 5});
            Assert.Equal(3, list.Head.Value);
        }

        [Fact]
        public void AddAndCurrentItemTest()
        {
            var list = new ClosedObjectsList<SomeClass>();
            Assert.Throws<NullReferenceException>(() => list.Current);
            list.Add(new SomeClass() { Value = 3 });
            list.Add(new SomeClass() { Value = 5 });
            list.Add(new SomeClass() { Value = 8 });
            Assert.Equal(3, list.Current.Value);
            list.MoveNext(2);
            Assert.Equal(8, list.Current.Value);
            list.MoveBack();
            Assert.Equal(5, list.Current.Value);
        }

        [Fact]
        public void AddAndPreviousItemTest()
        {
            var list = new ClosedObjectsList<SomeClass>();
            Assert.Throws<NullReferenceException>(() => list.Previous);
            list.Add(new SomeClass() { Value = 3 });
            list.Add(new SomeClass() { Value = 5 });
            list.Add(new SomeClass() { Value = 8 });
            Assert.Equal(8, list.Previous.Value);
            list.MoveNext(2);
            Assert.Equal(5, list.Previous.Value);
            list.MoveBack();
            Assert.Equal(3, list.Previous.Value);
        }

        [Fact]
        public void AddAndNextItemTest()
        {
            var list = new ClosedObjectsList<SomeClass>();
            Assert.Throws<NullReferenceException>(() => list.Next);
            list.Add(new SomeClass() { Value = 3 });
            list.Add(new SomeClass() { Value = 5 });
            list.Add(new SomeClass() { Value = 8 });
            Assert.Equal(5, list.Next.Value);
            list.MoveNext(2);
            Assert.Equal(3, list.Next.Value);
            list.MoveBack();
            Assert.Equal(8, list.Next.Value);
        }

        [Fact]
        public void CountTest()
        {
            var list = new ClosedObjectsList<SomeClass>();
            Assert.Equal(0, list.Count);
            list.Add(new SomeClass() { Value = 3 });
            list.Add(new SomeClass() { Value = 5 });
            Assert.Equal(2, list.Count);
        }
        
        [Fact]
        public void RemoveItemsTest()
        {
            var list = new ClosedObjectsList<SomeClass>();
            var elem1 = new SomeClass() { Value = 3 };
            var elem2 = new SomeClass() { Value = 5 };
            list.Add(elem1);
            list.Add(elem2);
            Assert.Contains(elem1, list);
            list.RemoveAt(0);
            Assert.DoesNotContain(elem1, list);
            Assert.Equal(elem2, list.Head);
        }

        [Fact]
        public void GetByIndexTest()
        {
            var list = new ClosedObjectsList<SomeClass>();
            var elem1 = new SomeClass() { Value = 3 };
            var elem2 = new SomeClass() { Value = 5 };
            var elem3 = new SomeClass() { Value = 8 };
            list.Add(elem1);
            list.Add(elem2);
            list.Add(elem3);
            Assert.Equal(elem2, list[1]);
            list.RemoveAt(0);
            Assert.Equal(elem3, list[1]);
        }

        [Fact]
        public void EnumerableTest()
        {
            var list = new ClosedObjectsList<SomeClass>();
            list.Add(new SomeClass() { Value = 3 });
            list.Add(new SomeClass() { Value = 5 });
            list.Add(new SomeClass() { Value = 8 });
            foreach (var item in list)
            {
                item.Value += 1;
            }
            Assert.Equal(4, list[0].Value);
            Assert.Equal(9, list[2].Value);
        }

        [Fact]
        public void ClearTest()
        {
            var list = GetRefTypesList();
            list.Clear();
            list.Add(new SomeClass(){Value = 11});
            Assert.Equal(11, list.Head.Value);
            Assert.Single(list);
        }

        [Fact]
        public void ContainsAndRemoveTest()
        {
            var list = new ClosedObjectsList<SomeClass>();
            var elem1 = new SomeClass() { Value = 3 };
            var elem2 = new SomeClass() { Value = 5 };
            var elem3 = new SomeClass() { Value = 8 };
            list.Add(elem1);
            list.Add(elem2);
            Assert.Contains(elem1, list);
            list.MoveNext();
            Assert.Equal(list.Current, elem2);
            list.Remove(elem2);
            Assert.DoesNotContain(elem2, list);
            Assert.Equal(list.Current, elem1);
        }

        [Fact]
        public void CopyToTest()
        {
            var list = new ClosedObjectsList<SomeClass>();
            var elem1 = new SomeClass() { Value = 3 };
            var elem2 = new SomeClass() { Value = 5 };
            var elem3 = new SomeClass() { Value = 8 };
            list.Add(elem1);
            list.Add(elem2);
            list.Add(elem3);
            SomeClass[] arr = new SomeClass[4];
            list.CopyTo(arr, 1);
            Assert.Equal(elem1, arr[1]);
            Assert.Equal(elem3, arr[3]);
        }

        [Fact]
        public void IndexOfTest()
        {
            var list = new ClosedObjectsList<SomeClass>();
            var elem1 = new SomeClass() { Value = 3 };
            var elem2 = new SomeClass() { Value = 5 };
            var elem3 = new SomeClass() { Value = 8 };
            list.Add(elem1);
            list.Add(elem2);
            list.Add(elem3);
            Assert.Equal(1, list.IndexOf(elem2));
            list.RemoveAt(0);
            Assert.Equal(0, list.IndexOf(elem2));
        }

        [Fact]
        public void InsertTest()
        {
            var list = new ClosedObjectsList<SomeClass>();
            var elem1 = new SomeClass() { Value = 3 };
            var elem2 = new SomeClass() { Value = 5 };
            var elem3 = new SomeClass() { Value = 8 };
            list.Add(elem1);
            list.Add(elem3);
            list.Insert(1, elem2);
            Assert.Equal(elem1, list[0]);
            Assert.Equal(elem2, list[1]);
            Assert.Equal(elem3, list[2]);
        }

        [Fact]
        public void MoveNextTest()
        {
            var list = new ClosedObjectsList<SomeClass>();
            list.Add(new SomeClass() { Value = 3 });
            list.Add(new SomeClass() { Value = 5 });
            list.Add(new SomeClass() { Value = 8 });
            Assert.Equal(3, list.Current.Value);
            list.MoveNext(2);
            Assert.Equal(8, list.Current.Value);
        }

        [Fact]
        public void MoveBackTest()
        {
            var list = new ClosedObjectsList<SomeClass>();
            list.Add(new SomeClass() { Value = 3 });
            list.Add(new SomeClass() { Value = 5 });
            list.Add(new SomeClass() { Value = 8 });
            Assert.Equal(3, list.Current.Value);
            list.MoveBack();
            Assert.Equal(8, list.Current.Value);
        }

        [Fact]
        public void EventDuringMoveNextTest()
        {
            var list = GetRefTypesList();
            list.HeadReached += DoSomething;
            int k = 5;
            int count = list.Count;
            eventCount = 0;
            for (int i = 0; i < count * k; i++)
            {
                list.MoveNext();
            }
            Assert.Equal(k, eventCount);
        }

        [Fact]
        public void EventDuringMoveBackTest()
        {
            var list = GetRefTypesList();
            list.HeadReached += DoSomething;
            int k = 5;
            int count = list.Count;
            eventCount = 0;
            for (int i = 0; i < count * k; i++)
            {
                list.MoveBack();
            }
            Assert.Equal(k, eventCount);
        }

        private ClosedObjectsList<SomeClass> GetRefTypesList()
        {
            var list = new ClosedObjectsList<SomeClass>();
            list.Add(new SomeClass(){Value = 2});
            list.Add(new SomeClass(){Value = 5});
            list.Add(new SomeClass(){Value = 8});
            return list;
        }

        int eventCount;
        private void DoSomething(object sender, SomeClass e)
        {
            eventCount++;
        }
    }
}