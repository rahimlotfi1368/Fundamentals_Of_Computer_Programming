﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    public class EncryptedPacket
    {
        public byte[] EncryptedSessionKey;
        public byte[] EncryptedData;
        public byte[] Iv;
        public byte[] Hmac;
        public byte[] Signature;
    }
}
