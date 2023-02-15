
Cryptography:Making Some Informathion Secret and this is done by the Process of Encryption.
1) Message => Encrypting with a key => Encrypted Message 
2) Encrypted Message => Decrypting With The Key => Message

Concepts of Cryptography:
1)confidentiality is a set of rules that limits access to information
2)integrity is the assurance that the information is trustworthy and accurate, 
	and availability is a guarantee of reliable access to the information by authorized people
3)Non-repudiation is the assurance that someone cannot deny the validity of something. 

What is the difference between authentication and Nonrepudiation?
	authenticity verifies the sender's identity and source of the message, 
	while non-repudiation confirms the validity and legitimacy(مشروعيت) of the message.

Hashing:Hashing (performing hashing algorithms) is the process of converting data into short and fixed length 
		unreadable form. This process is irreversible, i.e., you cannot convert hashed data back to the original one. 
		Every time you generate hash for specific data, it will be the same output (hashed form). It is used to check 
		the integrity of data, string comparison, Data authenticity and, most importantly for security, password 
		storage. Unlike encryption, Hashing is a one-way process.(Described as Data FingerPrint)
Message => Hash Function => Hash string
Hash Functions => MD5 , Sha1 ,Sha256, sha512

Hash MAC : To serve a purpose of authenticity in hashing Process ,we use HashMac.
			If you combine a one-way hash function with a secret cryptographic key,
			you get what is called a hash Message Authentication Code, or hash MAC for short

Salt Hashing : Salt is non-repetitive random data that is added with the hashed value to make it unique every time it is generated.
				string saltedPassword = password + salt;

Types of Encryption:
1-Symmetric Encryption
2-Asymmetric Encryption

Symmetric Encryption:Symmetric encryption is the encryption in which you send the key along with the data so that the user can 
	decrypt the data with the same key. It is also called shared secret encryption.(AES [very secure] & DES)

Asymmetric Encryption : Asymmetric encryption uses a pair of two keys instead of one for encryption. These two keys are 
	mathematically related to each other. One of the keys is called Public key and other one is called Private 
	key. You use one of the keys to encrypt data and other to decrypt data. The other key should be from the 
	pair of keys you generated. The encryption you do with these keys is interchangeable. For example, if key1 
	encrypts the data then key2 can decrypt it and if key2 encrypt the data then key1 can decrypt it, because one 
	of them can be given to everyone and the other one should be kept secret.
	The data gets encrypted with the receiver’s public key and can only be decrypted by the private key 
	from the specific receiver because only that user should have access to the private key.
	The public key transmits along the data while the secret key kept with the recipient.
	Asymmetric encryption avoids sharing the encryption key; that’s why it is more secure than a symmetric 
	key. But, on the other hand, it is slower than symmetric encryption.(RSA[SLOW])

Digital Signatures : Digital Signatures gives the recipient reason to believe that the message was created by
					 a known sender such that the sender can't deny having sent the message.Based on asymmetric cryptography
					 Digital signatures give both authentication and non-repudiation.
Digital signatures consist of Public and private key generation,Signing algorithm using the private key,Verification algorithm using the public key

Encryption (RSA) => Encrypt(public key) => Decrypt(private key)
Digital Signatures => Verify Signature (public key) => Sign Message (private key)