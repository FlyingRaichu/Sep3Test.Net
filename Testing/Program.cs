// See https://aka.ms/new-console-template for more information

using RPCInterface;
using RPCInterface.RPCImplementations;

Console.WriteLine("Hello, World!");

var rpc = new ItemRpc();


foreach(Item item in rpc.Elements){
    Console.WriteLine(item);
}
