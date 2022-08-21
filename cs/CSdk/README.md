# OCSdk - Open C# Software Development Kit
--------------------------------------------------------------------------------------------------------------------------------
This Open Csharp Software Development Kit is aimed at providing an interface for developers working with OpenGL and the Vulkan API. This project will reflect other projects in an attempt to make an easy to use all C# based framework. The purpose of developing this framework is to allow users another open source option for developing C# games without the need for roalities and without the known issues with the OpenTK project. 

This is a work in progress and not my primary goal in life at the moment but I will update the README.md file when changes do occur to either the framework, that warrents reflection, or my current life goals, that affect this framework. This framework is coded by an advanced level programmer and many of the class files included can be understood by beginners. As I move farther into my career, thus pursuing my life goals, many of these class file that compose the framework will change to become better optimized for latest stable version of the .NET framework and Mono libraries.

This framework will be divided into separate projects with one parent project managing the Sdk client and server, the example Game client and server, the
debugger that will work as a wrapper for anything related to framework, and the Game Engine. Contributions to this framework is accepted openly but I want to wait until my life stabilizes and the first Vulkan driver is released before opening this framework. This will allow the development to continue to a more productive level and will allow for a better overall feel of the framework as a whole.

Other projects, frameworks, or libraries will be listed here:

- Pencil.Gaming (https://github.com/andykorth/Pencil.Gaming)
- Vulkan (https://github.com/KhronosGroup/Vulkan-Docs/tree/1.0)
- Mono (https://github.com/mono/mono)

# Installation
---------------------------------------------------------------------------------------------------------------------------------
As of right now the installation is Make dependent for use as an automated building scheme. If you cannot use Make please grab
the commands from the respect Makefiles and run them directly in your console of choice from the parent directory of $(PWD)/CSdk.
This solves any issues with installation as the Makefiles use the `mcs` compiler for Linux, but does not yet support Windows
with `csc`. This will be fixed at a later date as I would like to complete the libraries first to test different platforms.

Currently normal installation is as follows:

    make
    make clean
    make install

To make exculsive Unit Tests and run them do:

    make unit
    mono Test.exe

Note that `make` is the same as `make all`

# Running
----------------------------------------------------------------------------------------------------------------------------------
Version: **0.0.2**

- Windows
: [![Build status](https://ci.appveyor.com/api/projects/status/ig5cge5k93kbeq39?svg=true)](https://ci.appveyor.com/project/Ghost53574/csdk)

- OSX & Linux
: [![Build Status](https://travis-ci.org/Ghost53574/CSdk.svg?branch=master)](https://travis-ci.org/Ghost53574/CSdk)

To run the the OCSDK simply do:

    mono ./CSDK.exe -r

Which should bring up a window with a blank screen, this is your output window. Other menu's can be pulled into view by using hotkeys and
your main source file will have to be edited with a textual editor in the likes of VIM/etc...

Once you have completed code for something, you can compile it using the runtime compiler or via the command line (if the program is closed).
Once compiled and automatically referenced into the main application you should see the output in the output window of the desired result.

This framework is for simplistic behaviour and advanced software development running on minimal hardware (that can run mono and/or GTK+)

# FAQ
------------------------------------------------------------------------------------------------------------------------------------

Q: The NUnit tests do not work.

A: They will once I figure out how to get the unit tests working without a solution file

----

Q: Why did you allow failures for OSX?

A: I am currently working through the build reqs for OSX. Once the build reqs are done it will be included with the Travis CI builds.

----

Q: Why does the Windows build fail?

A: Right now I am focusing on other things wihtin this project and don't care to create a fully working .msbuild configuration as of yet.

----

Q: If Xenko exists why create this project?

A: First this is a learning experience for me. To continue development with this project will only show that my knowledge for visual c# and
   game development is increasing. I am not looking at other peoples code, nor do I find that using the #UNSAFE keyword to build a "C#" project
   is really viable. To me if you're going to use possible unsafe code why not just create a C service that you can interface with your C#
   project? Of course those same people will say it's for the ease of use with .Net and other langauges alike. It also allows for creation for
   frameworks such as capnproto, protobuf, and fast message queueing systems (or other IPC).

   Anyway I am focusing on using other peoples libraries for specific functionality, like VulkanSharp for low level Vulkan bindings to C# or 
   CapnProto for faster serialization. Yes I understand that these libraries use #UNSAFE but to me that's acceptable because the project
   demands for that. I don't believe there needs to be any #UNSAFE code in this project, or others like it bare metal software development
   kit for Vulkan and OpenGL targeting C# developers. If I were to make this project into a full blown IDE like Xenko than I would be parsing
   a lot more than just meshes.

   My point is that this is a C# based only project that is going to just be a framework that allows you to incorperate the libraries into 
   your own project to make development easier and rapid. This is different than creating a full fledged IDE, this is different than using
   Unity, this is OCSdk. (i.e. rant)

----

Q: Is there a release date?

A: Nope, sometime in the future. I am a student working two jobs so time off alone is a luxury. The friend that was going to develop this with
   me bailed like a year ago and never offered any help.

---
