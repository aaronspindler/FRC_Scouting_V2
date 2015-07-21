#region License
//*********************************License***************************************
//===============================================================================
//The MIT License (MIT)

//Copyright (c) 2014 FRC_Scouting_V2

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.
//===============================================================================
#endregion
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace UsefulSnippets
{
    /// <summary>
    ///     Methods to inact security measures
    /// </summary>
    public class Security
    {
        /// <summary>
        ///     Encrypts a string with AES256 encryption
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string EncryptString(string plainText)
        {
            string encryptedText;
            const string key = ("abcdefghijklmnopqrstuvwxyz123456");
            const string IV = ("1234567890123456");
            byte[] plainTextBytes = Encoding.ASCII.GetBytes(plainText);
            var aes = new AesCryptoServiceProvider
            {
                BlockSize = 128,
                KeySize = 256,
                Key = Encoding.ASCII.GetBytes(key),
                IV = Encoding.ASCII.GetBytes(IV),
                Padding = PaddingMode.PKCS7,
                Mode = CipherMode.CBC
            };
            ICryptoTransform crypto = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] encrypted = crypto.TransformFinalBlock(plainTextBytes, 0, plainTextBytes.Length);
            encryptedText = Convert.ToBase64String(encrypted);
            return encryptedText;
        }

        /// <summary>
        ///     Decrypts a cipher-text that has been encrypted with AES256 Encryption
        /// </summary>
        /// <param name="encryptedText"></param>
        /// <returns></returns>
        public static string DeCryptString(string encryptedText)
        {
            string plainText;
            const string key = ("abcdefghijklmnopqrstuvwxyz123456");
            const string IV = ("1234567890123456");
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            var aes = new AesCryptoServiceProvider
            {
                BlockSize = 128,
                KeySize = 256,
                Key = Encoding.ASCII.GetBytes(key),
                IV = Encoding.ASCII.GetBytes(IV),
                Padding = PaddingMode.PKCS7,
                Mode = CipherMode.CBC
            };
            ICryptoTransform crypto = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] plainTextBytes = crypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
            plainText = Encoding.ASCII.GetString(plainTextBytes);
            return plainText;
        }

        /// <summary>
        ///     Returns a pseudo random number between a range
        /// </summary>
        /// <param name="startingNum"></param>
        /// <param name="endingNum"></param>
        /// <returns></returns>
        public static int GetSecureRandomNum(int startingNum, int endingNum)
        {
            int difference = endingNum - startingNum;
            var bytes = new byte[16];
            var r = new RNGCryptoServiceProvider();

            r.GetBytes(bytes);
            int number = (int) ((decimal) bytes[0]/256*difference) + startingNum;

            return number;
        }

        /// <summary>
        ///     Returns a random password based on the password type selected and the password length selected
        /// </summary>
        /// <param name="passwordType"></param>
        /// <param name="passwordLength"></param>
        /// <returns></returns>
        public static string MakeRandomPassword(int passwordType, int passwordLength)
        {
            //Password Types
            //0 - No Type Selected
            //1 - Numbers
            //2 - Letters (Uppercase and Lowercase)
            //3 - Numbers and Letters (Uppercase and Lowercase)
            //4 - All Characters (Numbers, Letters, and Special Characters)

            //Variables
            var gen = new Random();
            string passwordToString = ("");
            char[] numbers = {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0'};
            char[] letters =
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
                's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
            };
            char[] lettersAndNumbers =
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p',
                'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K',
                'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '1', '2', '3', '4', '5', '6',
                '7', '8', '9', '0'
            };
            char[] allCharacters =
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q',
                'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
                'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '1', '2', '3', '4', '5', '6', '7',
                '8', '9', '0', '!', '@', '#', '$', '%', '^', '&', '*', '<', '>', '?'
            };
            var passwordList = new List<char>();
            int randomNumber = 0;

            if (passwordType == 0)
            {
                Notifications.ErrorOccured("No password type selected!");
            }
            else
            {
                if (passwordType == 1)
                {
                    for (int i = 0; i < passwordLength; i++)
                    {
                        randomNumber = gen.Next(10);
                        passwordList.Add(numbers[randomNumber]);
                    }
                    passwordToString = string.Join("", passwordList.ToArray());
                }
                else
                {
                    if (passwordType == 2)
                    {
                        for (int i = 0; i < passwordLength; i++)
                        {
                            randomNumber = gen.Next(52);
                            passwordList.Add(letters[randomNumber]);
                        }
                        passwordToString = string.Join("", passwordList.ToArray());
                    }
                    else
                    {
                        if (passwordType == 3)
                        {
                            for (int i = 0; i < passwordLength; i++)
                            {
                                randomNumber = gen.Next(62);
                                passwordList.Add(lettersAndNumbers[randomNumber]);
                            }
                            passwordToString = string.Join("", passwordList.ToArray());
                        }
                        else
                        {
                            if (passwordType == 4)
                            {
                                for (int i = 0; i < passwordLength; i++)
                                {
                                    randomNumber = gen.Next(73);
                                    passwordList.Add(allCharacters[randomNumber]);
                                }
                                passwordToString = string.Join("", passwordList.ToArray());
                            }
                        }
                    }
                }
            }
            return passwordToString;
        }
    }
}