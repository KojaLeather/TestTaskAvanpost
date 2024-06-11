using System.Reflection;
using Task.Connector.Data.Models;

namespace Task.Connector.Helpers
{
    static public class DefaultUserValueSetter
    {
        //Sets null values of propetries to default values before saving to DB
        static public void SetDefaultValues(User user)
        {
            foreach (PropertyInfo property in user.GetType().GetProperties())
            {
                if (property.PropertyType == typeof(string))
                {
                    string s = (string)property.GetValue(user);
                    if (string.IsNullOrEmpty(s))
                    {
                        property.SetValue(user, "default");
                    }
                }
                else if (property.PropertyType == typeof(bool))
                {
                    bool? b = (bool)property.GetValue(user);
                    if (b == null)
                    {
                        property.SetValue(user, false);
                    }
                }
            }
        }
    }
}
