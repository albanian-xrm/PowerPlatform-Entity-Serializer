using AlbanianXrm.PowerPlatform;
using Microsoft.Xrm.Sdk;
using Xunit;
using Xunit.Abstractions;

namespace JsonConvertersTests
{
    public class FormattedValueCollectionConverterTests
    {
        ITestOutputHelper output { get; }

        public FormattedValueCollectionConverterTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void FormattedValueCollectionSerialization_AllowNulls()
        {
            var input = @"[{""key"":""statecode"",""value"":""Active""},{""key"":""new_dateto"",""value"":null},{""key"":""new_discounttype"",""value"":""None""}]";
            var deserialized = EntitySerializer.Deserialize<FormattedValueCollection>(input);
            Assert.NotNull(deserialized);
            Assert.Equal("Active", deserialized["statecode"]);
            Assert.Null(deserialized["new_dateto"]);
            Assert.Equal("None", deserialized["new_discounttype"]);
            var serialized = EntitySerializer.Serialize(deserialized, typeof(FormattedValueCollection));
            Assert.Equal(input, serialized);
        }
    }
}
