![KeyToVault Logo](https://thryn.fr/images/KeyToVault.png)

https://twitter.com/ThrynSec

------------------------------------------

**1. What is KeyToVault**

**2. Creating an encrypted folder to work on**

**3. KeyToVault configuration**

**4. Questions and troubleshooting**


------------------------------------------

# 1. What is KeyToVault

KeyToVault is a userfriendly VB.Net solution to encrypt/decrypt an encrypted shared folder on a Synology DiskStation NAS using SSH and Bash commands.
It is very light and easy to configure because of the simplicity of it.

This software can be very useful for small organisation that needs to protect sensitive datas without having to open up the Diskstation GUI in a browser, connect, decrypt, and do it all over to encrypt it. Plus it minimize the risk of the user forgetting to close it as it re-encrypt the folder when closed.

The user just have to launch the executable and within 25 seconds the folder will be avaible.
After he is done he can just close the software or click on "the close & encrypt" button within it.

If the user forget the software will automatically re-encrypt the folder after 2 hours or on computer shutdown.


# 2. Creating an encrypted folder 

The first step to secure your files within a folder and using KeyToVault is to create and encrypted folder to begin with.

For that you have to log in your Diskstation using the browser GUI
Then you go to Control Panel > Shared folder
And you create a folder, just tick "Encrypt this shared folder" and enter the passphrase.


# 3. KeyToVault configuration

All the configuration is to be done in the Main.vb file.

You have at first the variable configuration right at the beginning when you will have to enter already encrypted informations and the folder name in plaintext.

You have, next, the string decryption method. While I use Base64 to have an easy to use encryption method that don't require much configuration, it's not very protected and as .Net can be reversed, it is not very safe.
I'd recommand using any other encryption method but if you stick with Base64, just use an online converted to get encrypted strings you need for the configuration.

At least you have the launching time configuration. When I tested it, my DisktStation took ~27 seconds to decrypt the file. So, on launch, the software forces the user to wait for 20 seconds before using the folder. This can easily be removed or configured at will.


# 4. Questions and toubleshooting 

- Why VB.Net ?

Because this used to be a work project where I had to use VB.Net. I may redo this software in C# later, who knows ?

- I can't connect to SSH / Visual Studio can get Renci.SSHNet

Please install SSHNet Nugget package, it should solve this problem
