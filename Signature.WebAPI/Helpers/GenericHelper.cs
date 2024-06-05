using System.Collections;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Signature.WebAPI.Helpers
{
#pragma warning disable S1118 // Utility classes should not have public constructors
    public class GenericHelper
#pragma warning restore S1118 // Utility classes should not have public constructors
    {
        /// <summary>
        /// Method to generate a security hash
        /// </summary>
        /// <param name="oHash"></param>
        /// <param name="sTimeStamp"></param>
        /// <returns></returns>
        internal static string GeneratedSignature(Object? oHash, String sTimeStamp)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            return GenericHelper.GenerateSHA256(OrderObjectPropertiesValuesAlphabetically(oHash) + sTimeStamp + "IntegracionAPI15032018");
#pragma warning restore CS8604 // Possible null reference argument.
        }

        /// <summary>
        /// Generates a SHA256 string
        /// </summary>
        /// <param name="stringToHash">string to hash</param>
        /// <returns>hashed string</returns>
        internal static string GenerateSHA256(string stringToHash)
        {
            string? hashedString = null;

#pragma warning disable SYSLIB0021 // Type or member is obsolete
            SHA256 mySHA256 = SHA256Managed.Create();
#pragma warning restore SYSLIB0021 // Type or member is obsolete
            byte[] hashedSignature = mySHA256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(stringToHash));
            hashedString = ByteArrayToHex(hashedSignature);

            return hashedString;
        }

        /// <summary>
        /// Converts a byte array to hex string.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>
        /// hex string
        /// </returns>
        internal static string ByteArrayToHex(byte[] array)
        {
            if (array != null)
            {
                return BitConverter.ToString(array).Replace("-", string.Empty);
            }

#pragma warning disable CS8603 // Possible null reference return.
            return null;
#pragma warning restore CS8603 // Possible null reference return.
        }

        /// <summary>
        /// Orders alphabetically given object properties and return the concatenation of its values
        /// </summary>
        /// <param name="obj">Object to process</param>
        /// <returns>Resulting concatenation string</returns>
        internal static string OrderObjectPropertiesValuesAlphabetically(object obj)
        {
            StringBuilder result = new StringBuilder();
            if (obj != null)
            {
                List<PropertyInfo> props = obj.GetType().GetProperties().OrderBy(x => x.Name).ToList();
                foreach (PropertyInfo pi in props)
                {
                    if (pi.Name != "Signature")
                    {
                        Type type = pi.PropertyType;
                        if (pi.GetValue(obj, null) != null)
                        {
                            if (type.IsPrimitive || type.Equals(typeof(string)))
                            {
                                result.Append(pi.GetValue(obj, null));
                            }
                            else if (type.Equals(typeof(decimal)) || type.Equals(typeof(decimal?)))
                            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                                result.Append(pi.GetValue(obj, null).ToString().Replace(",", "."));
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                            }
                            else if (type.Equals(typeof(Boolean?)))
                            {
                                result.Append(pi.GetValue(obj, null));
                            }
                            else if (type.Equals(typeof(Int16?)))
                            {
                                result.Append(pi.GetValue(obj, null));
                            }
                            else if (type.Equals(typeof(DateTime)))
                            {
                                result.Append(pi.GetValue(obj, null));
                            }
                            else if (type.IsArray)
                            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                                foreach (var p in (Array)pi.GetValue(obj, null))
                                {
                                    Type type2 = p.GetType();

                                    if (type2.IsPrimitive || type2.Equals(typeof(string)))
                                    {
                                        result.Append(p);
                                    }
                                    else
                                    {
                                        result.Append(OrderObjectPropertiesValuesAlphabetically(p));
                                    }
                                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                            }
                            else if (type.IsGenericType)
                            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                                foreach (var g in (IEnumerable)pi.GetValue(obj, null))
                                {
                                    Type type2 = g.GetType();

                                    if (type2.IsPrimitive || type2.Equals(typeof(string)))
                                    {
                                        result.Append(g);
                                    }
                                    else
                                    {
                                        result.Append(OrderObjectPropertiesValuesAlphabetically(g));
                                    }
                                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                            }
                            else if (type.IsEnum)
                            {
#pragma warning disable CS8605 // Unboxing a possibly null value.
                                result.Append((int)pi.GetValue(obj, null));
#pragma warning restore CS8605 // Unboxing a possibly null value.
                            }
                            else
                            {
#pragma warning disable CS8604 // Possible null reference argument.
                                result.Append(OrderObjectPropertiesValuesAlphabetically(pi.GetValue(obj, null)));
#pragma warning restore CS8604 // Possible null reference argument.
                            }
                        }
                        string strProcesoif = result.ToString();
                    }
                }
            }

            string strProceso = result.ToString();
            return result.ToString();
        }
    }
}