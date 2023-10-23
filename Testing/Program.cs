// See https://aka.ms/new-console-template for more information

using RPCInterface;
using RPCInterface.RPCImplementations;
using Via.Sep4.Protobuf;

Console.WriteLine("Hello, World!");

var rpc = new ItemRpc();


foreach(Item item in rpc.Items){
    Console.WriteLine(item);
}
