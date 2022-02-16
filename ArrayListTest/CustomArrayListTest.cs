using ArrayList;
using NUnit.Framework;
using System;

namespace ArrayListTest
{
    public class CustomArrayListTests
    {
        [Test]
        public void CreateCustomArrayList_WhenPassNullArray_ShouldThrowNullReferenceException()
        {
            try
            {
                var testArray = new CustomArrayList(null);
            }

            catch (NullReferenceException ex)
            {
                Assert.AreEqual("array is null", ex.Message);
                Assert.Pass();
            }
            Assert.Fail();
        }

        [Test]
        public void CreateCustomArrayList_WhenPassNegativeSize_ShouldThrowArgumentException()
        {
            try
            {
                var testArray = new CustomArrayList(-1);
            }

            catch (ArgumentException ex)
            {
                Assert.AreEqual("size is negative", ex.Message);
                Assert.Pass();
            }
            Assert.Fail();
        }

        [TestCase(new int[] { 2, 1, 4 }, 2, 6, new int[] { 2, 1, 6, 4 })]
        [TestCase(new int[] { 2, 1, 4 }, 0, 6, new int[] { 6, 2, 1, 4 })]
        [TestCase(new int[] { 2, 1, 4 }, 3, 6, new int[] { 2, 1, 4, 6 })]
        public void AddByIndex_WhenCalled_ShouldAddValueToArrayByIndex(
            int[] arr, int index, int value, int[] expectedResult)
        {
            var testArray = new CustomArrayList(arr);

            testArray.AddByIndex(index, value);

            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestCase(new int[] { 2, 1, 4 }, 6, 6)]
        [TestCase(new int[] { 2, 1, 4 }, -1, 6)]
        public void AddByIndex_WhenCalled_ShouldThrowArgumentException(
            int[] arr, int index, int value)
        {
            var testArray = new CustomArrayList(arr);

            try
            {
                testArray.AddByIndex(index, value);
            }

            catch (ArgumentException ex)
            {
                Assert.AreEqual("Incorrect index", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 2, 1, 4 }, 2, new int[] { 6, 5, 9 }, new int[] { 2, 1, 6, 5, 9, 4 })]
        [TestCase(new int[] { 2, 1, 4 }, 0, new int[] { 6, 5, 9 }, new int[] { 6, 5, 9, 2, 1, 4 })]
        [TestCase(new int[] { 2, 1, 4 }, 3, new int[] { 6, 5, 9 }, new int[] { 2, 1, 4, 6, 5, 9 })]
        public void AddRangeToIndex_WhenCalled_ShouldAddRangeToArrayByIndex(
            int[] arr, int index, int[] value, int[] expectedResult)
        {
            var testArray = new CustomArrayList(arr);

            testArray.AddRangeToIndex(index, value);

            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestCase(new int[] { 2, 1, 4 }, 6, new int[] { 6, 2 })]
        [TestCase(new int[] { 2, 1, 4 }, -1, new int[] { 6, 2 })]
        public void AddRangeToIndex_WhenCalled_ShouldThrowArgumentException(
            int[] arr, int index, int[] value)
        {
            var testArray = new CustomArrayList(arr);

            try
            {
                testArray.AddRangeToIndex(index, value);
            }

            catch (ArgumentException ex)
            {
                Assert.AreEqual("Incorrect index", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 2, 1, 4 }, 6, new int[] { 2, 1, 4, 6 })]
        public void AddToEnd_WhenCalled_ShouldAddValueToEndOfArray(
            int[] arr, int value, int[] expectedResult)
        {
            var testArray = new CustomArrayList(arr);

            testArray.AddToEnd(value);

            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestCase(new int[] { 2, 1, 4 }, 1, 1)]
        [TestCase(new int[] { 2, 1, 4 }, 3, -1)]
        public void GetIndexByValue_WhenCalled_ShouldReturnIndexOfValueOrMinusOne(
            int[] arr, int value, int expectedResult)
        {
            var testArray = new CustomArrayList(arr);

            var result = testArray.GetIndexByValue(value);

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(new int[] { 2, 1, 4 }, 2)]
        public void IndexOfMax_WhenCalled_ShouldReturnIndexOfMax(
            int[] arr, int expectedResult)
        {
            var testArray = new CustomArrayList(arr);

            var result = testArray.IndexOfMax();

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(new int[] { 2, 1, 4 }, 1)]
        public void IndexOfMin_WhenCalled_ShouldReturnIndexOfMin(
            int[] arr, int expectedResult)
        {
            var testArray = new CustomArrayList(arr);

            var result = testArray.IndexOfMin();

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(new int[] { 2, 1, 4 }, 2, 1, new int[] { 2, 1, })]
        [TestCase(new int[] { 2, 1, 4 }, 0, 2, new int[] { 4 })]
        [TestCase(new int[] { 2, 1, 4 }, 1, 1, new int[] { 2, 4, })]
        public void RemoveRangeByIndex_WhenCalled_ShouldRemoveRangeFromArrayByIndex(
            int[] arr, int index, int count, int[] expectedResult)
        {
            var testArray = new CustomArrayList(arr);

            testArray.RemoveRangeByIndex(index, count);

            CollectionAssert.AreEqual(expectedResult, testArray);
        }

        [TestCase(new int[] { 2, 1, 4 }, 3, 3)]
        [TestCase(new int[] { 2, 1, 4 }, -1, 3)]
        public void RemoveRangeByIndex_WhenCalledWithIncorrectIndex_ShouldThrowArgumentException(
            int[] arr, int index, int count)
        {
            var testArray = new CustomArrayList(arr);

            try
            {
                testArray.RemoveRangeByIndex(index, count);
            }
            catch (ArgumentException ex)

            {
                Assert.AreEqual("Incorrect index", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }

        [TestCase(new int[] { 2, 1, 4 }, 1, 3)]
        [TestCase(new int[] { 2, 1, 4 }, 0, 4)]
        [TestCase(new int[] { 2, 1, 4 }, 2, 2)]
        public void RemoveRangeByIndex_WhenCalledWithIncorrectCount_ShouldThrowArgumentException(
            int[] arr, int index, int count)
        {
            var testArray = new CustomArrayList(arr);

            try
            {
                testArray.RemoveRangeByIndex(index, count);
            }

            catch (ArgumentException ex)
            {
                Assert.AreEqual("Invalid combination of index and count", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }
    }
}