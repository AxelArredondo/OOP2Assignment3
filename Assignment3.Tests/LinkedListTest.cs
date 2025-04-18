using NUnit.Framework;
using Assignment3;
using Assignment3.Utility;

namespace Assignment3.Tests
{
    public class LinkedListTest
    {
        private ILinkedListADT list;

        [SetUp]
        public void Setup()
        {
            list = new SLL();
        }

        [Test]
        public void TestIsEmptyInitially()
        {
            Assert.IsTrue(list.IsEmpty());
            Assert.AreEqual(0, list.Count());
        }

        [Test]
        public void TestAddFirst()
        {
            var user = new User(1, "John", "john@mail.com", "1234");
            list.AddFirst(user);

            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user, list.GetValue(0));
        }

        [Test]
        public void TestAddLast()
        {
            var user1 = new User(1, "John", "alice@mail.com", "1234");
            var user2 = new User(2, "Bob", "bob@mail.com", "5678");

            list.AddLast(user1);
            list.AddLast(user2);

            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(user2, list.GetValue(1));
        }

        [Test]
        public void TestAddAtIndex()
        {
            var user1 = new User(1, "John", "John@mail.com", "1234");
            var user2 = new User(2, "Bob", "bob@mail.com", "5678");
            var user3 = new User(3, "Charlie", "charlie@mail.com", "abcd");

            list.AddLast(user1);
            list.AddLast(user3);
            list.Add(user2, 1); // Insert Bob between Alice and Charlie

            Assert.AreEqual(user2, list.GetValue(1));
        }

        [Test]
        public void TestReplace()
        {
            var user1 = new User(1, "John", "john@mail.com", "1234");
            var user2 = new User(2, "Bob", "bob@mail.com", "5678");

            list.AddLast(user1);
            list.Replace(user2, 0);

            Assert.AreEqual(user2, list.GetValue(0));
        }

        [Test]
        public void TestRemoveFirst()
        {
            var user1 = new User(1, "John", "john@mail.com", "1234");
            var user2 = new User(2, "Bob", "bob@mail.com", "5678");

            list.AddLast(user1);
            list.AddLast(user2);
            list.RemoveFirst();

            Assert.AreEqual(user2, list.GetValue(0));
            Assert.AreEqual(1, list.Count());
        }

        [Test]
        public void TestRemoveLast()
        {
            var user1 = new User(1, "John", "john@mail.com", "1234");
            var user2 = new User(2, "Bob", "bob@mail.com", "5678");

            list.AddLast(user1);
            list.AddLast(user2);
            list.RemoveLast();

            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user1, list.GetValue(0));
        }

        [Test]
        public void TestRemoveAtIndex()
        {
            var user1 = new User(1, "John", "john@mail.com", "1234");
            var user2 = new User(2, "Bob", "bob@mail.com", "5678");
            var user3 = new User(3, "Charlie", "charlie@mail.com", "abcd");

            list.AddLast(user1);
            list.AddLast(user2);
            list.AddLast(user3);
            list.Remove(1); // Remove Bob

            Assert.AreEqual(user3, list.GetValue(1));
        }

        [Test]
        public void TestIndexOf()
        {
            var user1 = new User(1, "John", "alice@mail.com", "1234");
            var user2 = new User(2, "Bob", "bob@mail.com", "5678");

            list.AddLast(user1);
            list.AddLast(user2);

            Assert.AreEqual(1, list.IndexOf(user2));
        }

        [Test]
        public void TestContains()
        {
            var user = new User(1, "John", "alice@mail.com", "1234");

            list.AddLast(user);

            Assert.IsTrue(list.Contains(user));
        }

        [Test]
        public void TestClear()
        {
            list.AddLast(new User(1, "John", "alice@mail.com", "1234"));
            list.Clear();

            Assert.AreEqual(0, list.Count());
            Assert.IsTrue(list.IsEmpty());
        }

        [Test]
        public void TestReverse()
        {
            var user1 = new User(1, "One", "one@mail.com", "1");
            var user2 = new User(2, "Two", "two@mail.com", "2");
            var user3 = new User(3, "Three", "three@mail.com", "3");

            list.AddLast(user1);
            list.AddLast(user2);
            list.AddLast(user3);

            list.Reverse();

            Assert.AreEqual(user3, list.GetValue(0));
            Assert.AreEqual(user2, list.GetValue(1));
            Assert.AreEqual(user1, list.GetValue(2));
        }
    }
}
