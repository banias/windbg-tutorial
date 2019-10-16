# Resources for WinDbg training
This repository contain several .NET Framework applications with various flaws that could be identified in WinDbg.

## MemoryLeakExample 
The application build an infinite tree structure where each node allocates a `byte[]`. The application is set to x86 intentially, after just few seconds it will throw OOM exception.

## PasswordInMemoryExample
Emulates the scenario where a lot users sends its credentials to a server and server keeps them in memory as `string`. The idea behind this example is to show that memory dumps should be handled with care, becasue all your production connection strings, user passwords may be available there in plaintext. 

## PasswordInMemorySecureExample
A demo for `SecureString` type, to show that it is not possible to easily read a string from such application. (of course this is usaable mostly for desktop applications, web applications typically need to have the password as `string` at some point in time - deserialization, hashing, etc.)

## StackOverflowExample 
Emulates an application that runs multiple threads and one them randomly gets a stackoverflow exception on one or more of them.

## XmlSerializerExample 
Emulates an application with a classic memory leaks in .NET Framework. multiple calls to constructor `new XmlSerializer(typeof(Foo), new Type[] { });` causes a memory leak due to lack of caching runtime types. 