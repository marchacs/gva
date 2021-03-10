using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography; // used for PBKDF2
using System.Web;

namespace GreenValleyAuctionsSystem
{
    public class PasswordHash
    {
        // Declare Constants
        public const int SaltByteSize = 24; // Standard, secure size of salts
        public const int HashByteSize = 20; // To match the size of the PBKF2-HMAC-SHA-1 hash
        public const int PBKDF2Iterations = 1000;
        public const int IterationIndex = 0; // Used to find first section (number of iterations) of PasswordHash database field
        public const int SaltIndex = 1; // Used to find second section (salt) of PasswordHash database field
        public const int PBKDF2Index = 2; // Used to find third section (hash) of PasswordHash database field

        public static string HashPassword(string password)
        {
            // Create a new crypto provider
            var cryptoProvider = new RNGCryptoServiceProvider();
            // Create a new random salt of a certain length
            byte[] salt = new byte[SaltByteSize];
            // Fill array with cryptographically strong sequence of random values
            cryptoProvider.GetBytes(salt);
            // Call method to create the hash
            var hash = GetPBKDF2Bytes(password, salt, PBKDF2Iterations, HashByteSize);
            // Create string to store in database (return it also)
            return PBKDF2Iterations + ":" + Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
        }

        private static byte[] GetPBKDF2Bytes(string password, byte[] salt, int iterations, int outputBytes)
        {
            // Create a new key
            var PBKDF2 = new Rfc2898DeriveBytes(password, salt);
            // Assign number of iterations that the function will be run
            PBKDF2.IterationCount = iterations;
            return PBKDF2.GetBytes(outputBytes);
        }

        // Validate Password
        public static bool ValidatePassword(string password, string correctHash)
        {
            char[] setDelimiter = { ':' }; // Will take the whole stored string and split it up into the three corresponding parts
            // Split the long string at the : character
            var split = correctHash.Split(setDelimiter);
            // Selects first section and assigns the stored number of iterations to new variable
            var iterations = Int32.Parse(split[IterationIndex]);
            // Selects section section and assigns the stored salt to the new variable
            var salt = Convert.FromBase64String(split[SaltIndex]);
            // Selects third section and assigns stored password hash to new variable
            var hash = Convert.FromBase64String(split[PBKDF2Index]);
            // Create hash for the entered password
            var userHash = GetPBKDF2Bytes(password, salt, iterations, hash.Length);
            // Compared hash to userHash and return boolean value
            return SlowEquals(hash, userHash);
        }

        // Method to increase security
        private static bool SlowEquals(byte[] x, byte[] y)
        {
            var diff = (uint)x.Length ^ (uint)y.Length;
            for (int i = 0; i < x.Length && i < y.Length; i++)
            {
                diff |= (uint)(x[i] ^ y[i]);
            }
            return diff == 0;
        }

    }

}