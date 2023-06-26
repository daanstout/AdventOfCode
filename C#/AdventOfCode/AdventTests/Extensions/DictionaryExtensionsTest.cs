using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventTests.Extensions;

[TestFixture]
public class DictionaryExtensionsTest {
    #region Functions
    #region Get Or Create
    [Test]
    public void GetOrCreate_WhenCalledWithNullDictionary_ThrowsArgumentNullException() {
        // Arrange - Act - Assert
        Assert.Throws<ArgumentNullException>(() => (null as IDictionary<int, int>)!.GetOrCreate(5));
    }

    [Test]
    public void GetOrCreate_WhenCalledWithNullKey_ThrowsArgumentNullReference() {
        // Arrange
        var dictionary = new Dictionary<string, string>();

        // Act - Assert
        Assert.Throws<ArgumentNullException>(() => dictionary.GetOrCreate(null!));
    }

    [Test]
    public void GetOrCreate_WhenCalledWithNonExistantObjectAndNoFactory_AddsEmptyEntryAndReturnsDefault() {
        // Arrange
        var dictionary = new Dictionary<string, string>();

        // Act
        var result = dictionary.GetOrCreate("key");

        // Assert
        Assert.Multiple(() => {
            Assert.That(dictionary, Contains.Key("key"));
            Assert.That(result, Is.Null);
            Assert.That(dictionary, Has.ItemAt("key").Null);
        });
    }

    [Test]
    public void GetOrCreate_WhenCalledWithExistingObject_ReturnsItemWithoutCreatingNewItem() {
        // Arrange
        var dictionary = new Dictionary<string, string> {
            ["key"] = "value"
        };
        int itemCount = dictionary.Count;

        // Act
        var result = dictionary.GetOrCreate("key");

        // Assert
        Assert.Multiple(() => {
            Assert.That(dictionary, Contains.Key("key"));
            Assert.That(dictionary, Has.Exactly(itemCount).Items);
            Assert.That(result, Is.Not.Null);
            Assert.That(dictionary, Has.ItemAt("key").Not.Null);
        });
    }
    #endregion
    #endregion
}
