using System;
using System.Linq;

namespace AdventTests.Extensions;

[TestFixture]
public class ArrayExtensionsTest {
    #region Functions
    #region Slice Row
    [Test]
    public void SliceRow_WhenCalledWithAnInvalidArrayIndex_ThrowsIndexOutOfRangeException() {
        // Arrange
        var array = new int[5, 5] {
            { 0, 1, 2, 3, 4 },
            { 2, 3, 4, 5, 6 },
            { 4, 5, 6, 7, 8 },
            { 6, 7, 8, 9, 10 },
            { 8, 9, 10, 11, 12 },
        };

        // Act - Assert
        Assert.Throws<IndexOutOfRangeException>(() => array.SliceRow(5).GetEnumerator().MoveNext());
    }

    [Test]
    public void SliceRow_WhenCalledWithNullArray_ThrowsNullReferenceException() {
        // Arrange - Act - Assert
        Assert.Throws<NullReferenceException>(() => (null as int[,])!.SliceRow(5).GetEnumerator().MoveNext());
    }

    [TestCase(0, new int[] { 0, 1, 2, 3, 4 })]
    [TestCase(1, new int[] { 2, 3, 4, 5, 6 })]
    [TestCase(2, new int[] { 4, 5, 6, 7, 8 })]
    [TestCase(3, new int[] { 6, 7, 8, 9, 10 })]
    [TestCase(4, new int[] { 8, 9, 10, 11, 12 })]
    public void SliceRow_WhenCalledWithAValidRow_ReturnsRowFromArray(int row, int[] result) {
        // Arrange
        var array = new int[5, 5] {
            { 0, 1, 2, 3, 4 },
            { 2, 3, 4, 5, 6 },
            { 4, 5, 6, 7, 8 },
            { 6, 7, 8, 9, 10 },
            { 8, 9, 10, 11, 12 },
        };

        // Act
        var slice = array.SliceRow(row).ToArray();

        // Assert
        Assert.That(slice, Has.Exactly(5).Items);
        CollectionAssert.AreEqual(result, slice);
    }
    #endregion

    #region Slice Column
    [Test]
    public void SliceColumn_WhenCalledWithAnInvalidArrayIndex_ThrowsIndexOutOfRangeException() {
        // Arrange
        var array = new int[5, 5] {
            { 0, 1, 2, 3, 4 },
            { 2, 3, 4, 5, 6 },
            { 4, 5, 6, 7, 8 },
            { 6, 7, 8, 9, 10 },
            { 8, 9, 10, 11, 12 },
        };

        // Act - Assert
        Assert.Throws<IndexOutOfRangeException>(() => array.SliceColumn(5).GetEnumerator().MoveNext());
    }

    [Test]
    public void SliceColumn_WhenCalledWithNullArray_ThrowsNullReferenceException() {
        // Arrange - Act - Assert
        Assert.Throws<NullReferenceException>(() => (null as int[,])!.SliceColumn(5).GetEnumerator().MoveNext());
    }

    [TestCase(0, new int[] { 0, 2, 4, 6, 8 })]
    [TestCase(1, new int[] { 1, 3, 5, 7, 9 })]
    [TestCase(2, new int[] { 2, 4, 6, 8, 10 })]
    [TestCase(3, new int[] { 3, 5, 7, 9, 11 })]
    [TestCase(4, new int[] { 4, 6, 8, 10, 12 })]
    public void SliceColumn_WhenCalledWithAValidRow_ReturnsRowFromArray(int row, int[] result) {
        // Arrange
        var array = new int[5, 5] {
            { 0, 1, 2, 3, 4 },
            { 2, 3, 4, 5, 6 },
            { 4, 5, 6, 7, 8 },
            { 6, 7, 8, 9, 10 },
            { 8, 9, 10, 11, 12 },
        };

        // Act
        var slice = array.SliceColumn(row).ToArray();

        // Assert
        Assert.That(slice, Has.Exactly(5).Items);
        CollectionAssert.AreEqual(result, slice);
    }
    #endregion

    #region GetNeighbourCoords
    [Test]
    public void GetNeighbourCoords_WhenCalledWithNullSource_ThrowsNullReferenceException() {
        // Arrange - Act - Assert
        Assert.Throws<NullReferenceException>(() => (null as int[,])!.GetNeighbourCoords(5, 5).GetEnumerator().MoveNext());
    }

    [Test]
    public void GetNeighbourCoords_WhenCalledWithOutOfBoundsIndex_ThrowsIndexOutOfRangeException() {
        // Arrange
        var array = new int[5, 5] {
            { 0, 1, 2, 3, 4 },
            { 2, 3, 4, 5, 6 },
            { 4, 5, 6, 7, 8 },
            { 6, 7, 8, 9, 10 },
            { 8, 9, 10, 11, 12 },
        };

        // Act - Assert
        Assert.Throws<IndexOutOfRangeException>(() => array.GetNeighbourCoords(5, 5).GetEnumerator().MoveNext());
    }

    [TestCaseSource(nameof(GetNeighbourCoords_TestCases))]
    public void GetNeighbourCoords_WhenCalledWithValidIndex_ReturnsValidNeighbours(int x, int y, (int, int)[] expected, bool includeDiagonal) {
        // Arrange
        var array = new int[5, 5] {
            { 0, 1, 2, 3, 4 },
            { 2, 3, 4, 5, 6 },
            { 4, 5, 6, 7, 8 },
            { 6, 7, 8, 9, 10 },
            { 8, 9, 10, 11, 12 },
        };

        // Act
        var neighbourCoords = array.GetNeighbourCoords(x, y, includeDiagonal).ToArray();

        // Assert
        Assert.That(neighbourCoords, Has.Exactly(expected.Length).Items);
        CollectionAssert.AreEquivalent(expected, neighbourCoords);
    }
    #endregion

    #region GetNeighbours
    [Test]
    public void GetNeighbours_WhenCalledWithNullSource_ThrowsNullReferenceException() {
        // Arrange - Act - Assert
        Assert.Throws<NullReferenceException>(() => (null as int[,])!.GetNeighbours(5, 5).GetEnumerator().MoveNext());
    }

    [Test]
    public void GetNeighbour_WhenCalledWithOutOfBoundsIndex_ThrowsIndexOutOfRangeException() {
        // Arrange
        var array = new int[5, 5] {
            { 0, 1, 2, 3, 4 },
            { 2, 3, 4, 5, 6 },
            { 4, 5, 6, 7, 8 },
            { 6, 7, 8, 9, 10 },
            { 8, 9, 10, 11, 12 },
        };

        // Act - Assert
        Assert.Throws<IndexOutOfRangeException>(() => array.GetNeighbours(5, 5).GetEnumerator().MoveNext());
    }

    [TestCaseSource(nameof(GetNeighbours_TestCases))]
    public void GetNeighbours_WhenCalledWithValidIndex_ReturnsValidNeighbours(int x, int y, int[] expected, bool includeDiagonal) {
        // Arrange
        var array = new int[5, 5] {
            { 0, 1, 2, 3, 4 },
            { 2, 3, 4, 5, 6 },
            { 4, 5, 6, 7, 8 },
            { 6, 7, 8, 9, 10 },
            { 8, 9, 10, 11, 12 },
        };

        // Act
        var neighbours = array.GetNeighbours(x, y, includeDiagonal).ToArray();

        // Assert
        Assert.That(neighbours, Has.Exactly(expected.Length).Items);
        CollectionAssert.AreEquivalent(expected, neighbours);
    }
    #endregion

    #region Get
    [Test]
    public void Get_WhenCalledWithNullSource_ThrowsNullReferenceException() {
        // Arrange - Act - Assert
        Assert.Throws<NullReferenceException>(() => (null as int[,])!.Get((5, 5)));
    }

    [Test]
    public void Get_WhenCalledWithOutOfRangeIndex_ThrowsIndexOutOfRangeException() {
        // Arrange
        var array = new int[5, 5] {
            { 0, 1, 2, 3, 4 },
            { 2, 3, 4, 5, 6 },
            { 4, 5, 6, 7, 8 },
            { 6, 7, 8, 9, 10 },
            { 8, 9, 10, 11, 12 },
        };

        // Act - Assert
        Assert.Throws<IndexOutOfRangeException>(() => array.Get((5, 5)));
    }

    [TestCaseSource(nameof(Get_TestCases))]
    public void Get_WhenCalledWithValidIndex_ReturnsValueAtIndex((int, int) index, int expected) {
        // Arrange
        var array = new int[5, 5] {
            { 0, 1, 2, 3, 4 },
            { 2, 3, 4, 5, 6 },
            { 4, 5, 6, 7, 8 },
            { 6, 7, 8, 9, 10 },
            { 8, 9, 10, 11, 12 },
        };

        // Act
        var result = array.Get(index);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    #endregion

    #region Count
    [Test]
    public void Count_WhenCalledWithNullSource_ThrowsNullReferenceException() {
        // Arrange - Act - Assert
        Assert.Throws<NullReferenceException>(() => (null as int[,])!.Count(val => true));
    }

    [Test]
    public void Count_WhenCalledWithNullPredicate_ThrowsNullReferenceException() {
        // Arrange
        var array = new int[5, 5] {
            { 0, 1, 2, 3, 4 },
            { 2, 3, 4, 5, 6 },
            { 4, 5, 6, 7, 8 },
            { 6, 7, 8, 9, 10 },
            { 8, 9, 10, 11, 12 },
        };

        // Act - Assert
        Assert.Throws<NullReferenceException>(() => array.Count(null!));
    }

    [TestCaseSource(nameof(Count_TestCases))]
    public void Count_WhenCalledWithValidValues_CountsBasedOnPredicate(Func<int, bool> predicate, int expected) {
        // Arrange
        var array = new int[5, 5] {
            { 0, 1, 2, 3, 4 },
            { 2, 3, 4, 5, 6 },
            { 4, 5, 6, 7, 8 },
            { 6, 7, 8, 9, 10 },
            { 8, 9, 10, 11, 12 },
        };

        // Act
        var result = array.Count(predicate);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    #endregion

    #region Sum
    [Test]
    public void Sum_WhenCalledWithNullSource_ThrowNullReferenceException() {
        // Arrange - Act - Assert
        Assert.Throws<NullReferenceException>(() => (null as int[,])!.Sum());
    }

    [TestCaseSource(nameof(Sum_TestCases))]
    public void Sum_WhenCalledWithValidSource_SumsArray(int[,] array, int expected) {
        // Arrange - act
        var result = array.Sum();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    #endregion
    #endregion

    #region Helper Functions
    private static object[] GetNeighbourCoords_TestCases() {
        return new object[] {
            new object[] {
                1, 1, new (int, int)[] {
                    (0, 0),
                    (0, 1),
                    (0, 2),
                    (1, 0),
                    (1, 2),
                    (2, 0),
                    (2, 1),
                    (2, 2)
                }, true
            },
            new object[] {
                3, 4, new (int, int)[] {
                    (2, 3),
                    (2, 4),
                    (3, 3),
                    (4, 3),
                    (4, 4)
                }, true
            },
            new object[] {
                1, 1, new (int, int)[] {
                    (0, 1),
                    (1, 0),
                    (1, 2),
                    (2, 1)
                }, false
            },
            new object[] {
                3, 4, new (int, int)[] {
                    (2, 4),
                    (3, 3),
                    (4, 4)
                }, false
            }
        };
    }
    private static object[] GetNeighbours_TestCases() {
        return new object[] {
            new object[] {
                1, 1, new int[] { 0, 1, 2, 2, 4, 4, 5, 6 }, true
            },
            new object[] {
                3, 4, new int[] { 7, 8, 9, 11, 12 }, true
            },
            new object[] {
                1, 1, new int[] { 1, 2, 4, 5 }, false
            },
            new object[] {
                3, 4, new int[] { 8, 9, 12 }, false
            }
        };
    }
    private static object[] Get_TestCases() {
        return new object[] {
            new object[] { (1, 1), 3 },
            new object[] { (3, 3), 9 },
            new object[] { (4, 1), 9 }
        };
    }
    private static object[] Count_TestCases() {
        return new object[] {
            new object[] {(Func<int, bool>)(val => val % 2 == 0), 15},
            new object[] {(Func<int, bool>)(val => val % 3 == 0), 9},
            new object[] {(Func<int, bool>)(val => val == 5), 2}
        };
    }
    private static object[] Sum_TestCases() {
        return new object[] {
            new object[] {new int[3, 3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } }, 9 },
            new object[] {new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }, 45 },
            new object[] {new int[3, 3] { { 1, 3, 5 }, { 1, 3, 5 }, { 5, 3, 1 } }, 27 },
        };
    }
    #endregion
}
