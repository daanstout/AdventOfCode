using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventTests.Extensions;

[TestFixture]
public class CharExtensionsTest {
    [Test]
    public void ToInt32_WhenCalledWithValidDigit_ReturnsIntVersion() {
        // Arrange
        char c = '3';

        // Act
        var charAsInt = c.ToInt32();

        // Assert
        Assert.That(charAsInt, Is.EqualTo(3));
    }
}
