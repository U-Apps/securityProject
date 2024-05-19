# Hybird Encyption App

# Secure Text and File Encryption Tool

This WinForms application provides a user-friendly interface for encrypting and decrypting text and files using the DES (Data Encryption Standard) and Triple DES (3DES) algorithms.

## Features

Secure Encryption: Leverages DES and Triple DES for robust data protection.
User-Friendly Interface: Easy-to-use WinForms layout for seamless encryption and decryption tasks.
Text and File Support: Handles both plain text input and file encryption/decryption.
Multiple Algorithms: Provides options for choosing between DES and Triple DES based on your security needs.


## System Requirements

Microsoft Windows (32-bit or 64-bit)
.NET Framework (version to be specified based on your development environment)


## Installation

Download the application files (.exe or installer).
Run the downloaded file and follow the on-screen instructions.


## Usage

Text Encryption/Decryption:

Launch the application.
In the "Text" tab:
Enter the text you want to encrypt in the "Plain Text" field.
Choose the desired encryption algorithm (DES or Triple DES) from the "Algorithm" dropdown.
Enter a strong password in the "Password" field (important for security!).
Click the "Encrypt" button to encrypt the text. The encrypted text will be displayed in the "Encrypted Text" field.
To decrypt encrypted text, enter it in the "Encrypted Text" field, select the same algorithm, provide the password, and click "Decrypt." The decrypted text will appear in the "Plain Text" field.
File Encryption/Decryption:

In the "File" tab:
Click the "Browse" button to select the file you want to encrypt or decrypt.
Choose the desired encryption algorithm (DES or Triple DES).
Enter a strong password in the "Password" field.
Click "Encrypt" to encrypt the selected file. A new encrypted file will be created.
To decrypt an encrypted file, select it using the "Browse" button, choose the corresponding algorithm, provide the password, and click "Decrypt." The decrypted file will be created.


## Security Considerations

Strong Passwords: It is crucial to use strong and unique passwords for encryption. Weak passwords can be easily cracked, compromising your data.
Data Loss: Encrypted files cannot be accessed without the correct password. Ensure you remember or securely store the password used for encryption.


## Disclaimer

The developers of this program cannot be held responsible for any data loss or security breaches resulting from improper use of the application. It is recommended to back up your data before encryption and to use strong passwords.