using System;
using ClosedObjectsCollectionApp;
using ClosedObjectsListTest.Models;
using Xunit;

namespace ClosedObjectsListTest
{
    public class ClosedObjectsListTest
    {
        [Fact]
        public void HeadItemTest()
        {
            var list = new ClosedObjectsList<SomeClass>();
            Assert.Throws<NullReferenceException>(() => list.Head);
            list.Add(new SomeClass(){Value = 3});
            list.Add(new SomeClass(){Value = 5});
            Assert.Equal(3, list.Head.Value);
        }

        [Fact]
        public void CurrentItemTest()
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
        public void PreviousItemTest()
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
        public void NextItemTest()
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
            Assert.Empty(list);
            list.Add(new SomeClass() { Value = 3 });
            list.Add(new SomeClass() { Value = 5 });
            Assert.Equal(2, list.Count);
        }

        [Fact]
        public void AddItemsTest()
        {

        }

        [Fact]
        public void RemoveItemsTest()
        {

        }

        [Fact]
        public void RemoveAtIndexTest()
        {

        }

        [Fact]
        public void GetByIndexTest()
        {

        }

        [Fact]
        public void EnumerableTest()
        {

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
        public void ContainsTest()
        {

        }

        [Fact]
        public void CopyToTest()
        {

        }

        [Fact]
        public void IndexOfTest()
        {

        }

        [Fact]
        public void InsertTest()
        {

        }

        [Fact]
        public void MoveNextTest()
        {

        }

        [Fact]
        public void MoveBackTest()
        {

        }

        private ClosedObjectsList<SomeClass> GetRefTypesList()
        {
            var list = new ClosedObjectsList<SomeClass>();
            list.Add(new SomeClass(){Value = 2});
            list.Add(new SomeClass(){Value = 5});
            list.Add(new SomeClass(){Value = 8});
            return list;
        }

        private ClosedObjectsList<SomeStruct> GetValTypesList()
        {
            var list = new ClosedObjectsList<SomeStruct>();
            list.Add(new SomeStruct() { Value = 2 });
            list.Add(new SomeStruct() { Value = 5 });
            list.Add(new SomeStruct() { Value = 8 });
            return list;
        }
    }
}