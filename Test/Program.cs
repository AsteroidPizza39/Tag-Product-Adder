using Cead;
using Cead.Handles;
using Cead.Interop;

DllManager.LoadCead();

string path = args[0];
Console.WriteLine(path);

using FileStream fs = File.OpenRead(path);
Span<byte> buffer = new byte[fs.Length];
fs.Read(buffer);

Byml byml = Byml.FromBinary(buffer);
Byml.Array array = byml.GetHash()["PathList"].GetArray();

// - Work/Actor/
// - AirWallStopFlow
// - .engine__actor__ActorParam.gyml

array.Add("Work/Actor/");
array.Add(args[1]);
array.Add(".engine__actor__ActorParam.gyml");

using DataHandle data = byml.ToBinary(false);
using FileStream writer = File.Create(args[2]);
writer.Write(data);