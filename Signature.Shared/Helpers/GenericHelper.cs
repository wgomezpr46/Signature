using System.Collections;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Signature.Shared.Helpers
{
    public class GenericHelper
    {
        /// <summary>
        /// Method to generate a security hash
        /// </summary>
        /// <param name="oHash"></param>
        /// <param name="sTimeStamp"></param>
        /// <returns></returns>
        public static string GeneratedSignatureWSAPITPV(Object oHash, String sTimeStamp)
        {
            return GenericHelper.GenerateSHA256(OrderObjectPropertiesValuesAlphabetically(oHash) + sTimeStamp + "IntegracionAPI15032018");
        }

        public static string GeneratedSignatureWSREST(Object oHash, String sTimeStamp)
        {
            return GenericHelper.GenerateSHA256(OrderObjectPropertiesValuesAlphabetically(oHash) + sTimeStamp + "IntegracionWSREST");
        }

        /// <summary>
        /// Generates a SHA256 string
        /// </summary>
        /// <param name="stringToHash">string to hash</param>
        /// <returns>hashed string</returns>
        public static string GenerateSHA256(string stringToHash)
        {
#pragma warning disable SYSLIB0021 // Type or member is obsolete
            SHA256 mySHA256 = SHA256Managed.Create();
#pragma warning restore SYSLIB0021 // Type or member is obsolete
#pragma warning disable CA1850 // Prefer static 'HashData' method over 'ComputeHash'
            byte[] hashedSignature = mySHA256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(stringToHash));
#pragma warning restore CA1850 // Prefer static 'HashData' method over 'ComputeHash'
            string hashedString = ByteArrayToHex(hashedSignature);

            return hashedString;
        }

        /// <summary>
        /// Converts a byte array to hex string.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>
        /// hex string
        /// </returns>
        public static string ByteArrayToHex(byte[] array)
        {
            if (array != null)
            {
                return BitConverter.ToString(array).Replace("-", string.Empty);
            }

            return null;
        }

        /// <summary>
        /// Orders alphabetically given object properties and return the concatenation of its values
        /// </summary>
        /// <param name="obj">Object to process</param>
        /// <returns>Resulting concatenation string</returns>
        public static string OrderObjectPropertiesValuesAlphabetically(object obj)
        {
            StringBuilder result = new();
            if (obj != null)
            {
#pragma warning disable IDE0305 // Simplify collection initialization
                List<PropertyInfo> props = obj.GetType().GetProperties().OrderBy(x => x.Name).ToList();
#pragma warning restore IDE0305 // Simplify collection initialization
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
                            }
                            else if (type.IsGenericType)
                            {
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
                            }
                            else if (type.IsEnum)
                            {
#pragma warning disable CS8605 // Unboxing a possibly null value.
                                result.Append((int)pi.GetValue(obj, null));
#pragma warning restore CS8605 // Unboxing a possibly null value.
                            }
                            else
                            {
                                result.Append(OrderObjectPropertiesValuesAlphabetically(pi.GetValue(obj, null)));
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