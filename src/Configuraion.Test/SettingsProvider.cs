using System;
using System.Reflection;
using Configuration;
using Configuration.EnvironmentProvider;
using Moq;
using Xunit;

namespace Configuraion.Test
{
    public class SettingsProviderTest
    {
        private Mock<IEnvironmentProvider> _environmentProviderMock;

        public SettingsProviderTest()
        {
            _environmentProviderMock = new Mock<IEnvironmentProvider>();
            _environmentProviderMock.Setup(x => x.EnvironmentName).Returns("DEV");            
            _environmentProviderMock.Setup(x => x.SettingsPath).Returns(AppContext.BaseDirectory);
            
        }

        [Fact]
        public void GetConfigurationRoot_NormallInput_NotNullTest()
        {
            //Arrange
            var provider = _environmentProviderMock.Object;
            
            //Act
            var result = SettingsProvider.GetConfigurationRoot(provider);
            
            //Assert
            Assert.NotNull(result);
        }
        
        [Theory]
        [InlineData("rootProperty", "RootExists")]
        [InlineData("devProperty", "DevExists")] 
        public void GetConfigurationRoot_NormallInput_PropertiesFetchedTest(string field, string value)
        {
            //Arrange
            var provider = _environmentProviderMock.Object;
            
            //Act
            var result = SettingsProvider.GetConfigurationRoot(provider);
            
            //Assert
            Assert.Equal(result[field], value);
        }


    }
}