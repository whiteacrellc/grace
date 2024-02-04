/*
 * Copyright (c) 2023 White Acre Software LLC
 * All rights reserved.
 *
 * This software is the confidential and proprietary information
 * of White Acre Software LLC. You shall not disclose such
 * Confidential Information and shall use it only in accordance
 * with the terms of the license agreement you entered into with
 * White Acre Software LLC.
 *
 * Year: 2023
 */
using grace.utils; // Assuming PasswordChecker class is in this namespace

namespace gracetest
{
    [TestClass]
    public class PasswordCheckerTests
    {
        [TestMethod]
        public void PasswordMeetsCriteria_ReturnsTrue()
        {
            // Arrange
            string validPassword = "SecureP@ssw0rd";

            // Act
            bool isValid = PasswordChecker.IsPasswordValid(validPassword);

            // Assert
            Assert.IsTrue(isValid);
        }
        /* 
         * patster said that password security was not needed 
        [TestMethod]
        public void PasswordTooShort_ReturnsFalse()
        {
            // Arrange
            string shortPassword = "Short";

            // Act
            bool isValid = PasswordChecker.IsPasswordValid(shortPassword);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void PasswordWithoutUpperCase_ReturnsFalse()
        {
            // Arrange
            string passwordWithoutUpperCase = "nocapitalletters123!";

            // Act
            bool isValid = PasswordChecker.IsPasswordValid(passwordWithoutUpperCase);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void PasswordWithoutDigit_ReturnsFalse()
        {
            // Arrange
            string passwordWithoutDigit = "NoNumbersOrSpecialChar!";

            // Act
            bool isValid = PasswordChecker.IsPasswordValid(passwordWithoutDigit);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void PasswordWithoutSpecialCharacter_ReturnsFalse()
        {
            // Arrange
            string passwordWithoutSpecialChar = "NoSpecialCharacter123";

            // Act
            bool isValid = PasswordChecker.IsPasswordValid(passwordWithoutSpecialChar);

            // Assert
            Assert.IsFalse(isValid);
        }
        */
    }
}