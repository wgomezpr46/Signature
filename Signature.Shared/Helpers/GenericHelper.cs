using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            SHA256 mySHA256 = SHA256Managed.Create();
            byte[] hashedSignature = mySHA256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(stringToHash));
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
                                result.Append(pi.GetValue(obj, null).ToString().Replace(",", "."));
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
                            }
                            else if (type.IsGenericType)
                            {
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
                            }
                            else if (type.IsEnum)
                            {
                                result.Append((int)pi.GetValue(obj, null));
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