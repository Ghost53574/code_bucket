using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Cryptography;

namespace CSDK {
	namespace Tools {
		public class FormatData {
			private Dictionary<string, byte[]> _flags = new Dictionary<string, byte[]>() {
			{ "save", new byte[] { 0x11, 0x00  } },
				{ "load", new byte[] { 0x11, 0x01 } },
				{ "attach", new byte[] { 0x11, 0x02 } },
				{ "detach", new byte[] { 0x11, 0x03 } },
				{ "memory", new byte[] { 0x10, 0x04 } },
				{ "handler", new byte[] { 0x10, 0x05 } }
			};

			private byte[] GetFlag(string key) {
				byte[] f = new byte[2];
				if (_flags.ContainsKey (key))
					_flags.TryGetValue (key, out f);
				return f;
			}

			private string Hash(byte[] data) {
				return new System.Security.Cryptography.SHA256Managed().ComputeHash(data).ToString();
			}

			private byte[] Verify(string flag) {
				byte[] _flag;
				switch (flag) {
				case "save":
				case "load":
				case "attach":
				case "detach":
				case "memory":
				case "handler":
					_flag = GetFlag (flag);
					break;
				default:
					_flag = new byte[] { (byte)'\x0A' };
					break;
				}
				return _flag;
			}

			private bool Verify(byte[] data, byte[] hash) {
				byte[] _hash = Encoding.ASCII.GetBytes (Hash (data));
				for (int i = 0; i < _hash.Length; i++) {
					if (_hash [i] != hash [i])
						return false;
				}
				return true;
			}

			private byte[] GrabBytes(byte[] data, int src, int dst, int count) {
				byte[] ret = new byte[count];
				Buffer.BlockCopy (data, src, ret, dst, count);
				return ret;
			}


			public FormatData() {
			}

			public byte[] Encode(string flag, object data) {
				byte[] _flag = Verify (flag);
				if (_flag [0] == 0x0A || _flag [0] == 0x00)
					return _flag;
				byte[] _data;
				if (data.GetType () == typeof(System.IO.MemoryStream))
					_data = ((MemoryStream)data).ToArray ();
				else if (data.GetType () == typeof(System.Byte[]))
					_data = (byte[])data;
				else {
					return _flag;
				}
				byte[] ret = new byte[_flag.Length + _data.Length];
				Buffer.BlockCopy (_flag, 0, ret, 0, _flag.Length);
				Buffer.BlockCopy (_data, 0, ret, _flag.Length, _data.Length);
				byte[] hash = Encoding.ASCII.GetBytes(Hash (ret));
				ret = null;
				ret = new byte[_flag.Length + _data.Length + hash.Length];
				Buffer.BlockCopy (_flag, 0, ret, 0, _flag.Length);
				Buffer.BlockCopy (_data, 0, ret, _flag.Length, _data.Length);
				Buffer.BlockCopy (hash, 0, ret, _flag.Length + _data.Length, hash.Length);
				return ret;
			}

			public KeyValuePair<byte[], byte[]> Decode(byte[] data) {
				byte[] nb = new byte[] { 0x00 };
				byte[] flag = new byte[2];
				byte[] hash = new byte[13];
				byte[] serial = new byte[data.Length - (flag.Length + hash.Length)];
				flag = GrabBytes (data, 0, 0, flag.Length);
				serial = GrabBytes (data, flag.Length, 0, serial.Length);
				hash = GrabBytes (data, serial.Length + flag.Length, 0, hash.Length);
				if (Verify (serial, hash))
					return new KeyValuePair<byte[], byte[]> (flag, serial);
				return new KeyValuePair<byte[], byte[]> (nb, nb); //We should never really return this
			}
		}
	}
}
