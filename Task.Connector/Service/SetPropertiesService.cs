using System.Reflection;
using Task.Connector.Data.Models;
using Task.Integration.Data.Models.Models;

namespace Task.Connector.Service
{
    internal class SetPropertiesService
    {
        //Set user properties from <UserProperties> via reflection
        public void SetUserProperties (IEnumerable<UserProperty> properties, User user)
        {
            Type type = user.GetType();

            foreach (UserProperty property in properties)
            {
                if (!String.IsNullOrEmpty(property.Name) && !String.IsNullOrEmpty(property.Value))
                {
                    PropertyInfo propertyInfo = type.GetProperty(property.Name);
                    propertyInfo?.SetValue(user, Convert.ChangeType(property.Value, propertyInfo.PropertyType));
                }
            }
        }
    }
}
