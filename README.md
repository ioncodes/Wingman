# Wingman

What's this? It's my attempt of cooking something special. First, take the list of ingredients:

* Postman
* .NET
* JSON

To cook this recipe, throw the power of Postman and the awesomeness of .NET in a bowl.  Strew some JSON properties over it. Now bake it in a oven with some love and voilà!  


## I'm confused, huh?

Ok, I fired our cooker. Maybe this will help you.  
Wingman is my attempt to cook... uhm, I mean, to implement Postman in C#! But the concept is a bit different, it's main purpose is for unittesting. So if you have to edit the parameters/payloads/headers often, [Postman](https://www.getpostman.com/) is the way to go!  
Configurations, such as urls, payloads, etc are configured and store in JSON files which can be called via ```wingman [configfile.json]```.  

> **Stranger:** Ya bruh, what's the point of this then?  
> **Me:** Wtf, who are you? Well, nvm, gotta be quick writing this, because I have to catch my bus!  

The special ability of this project is it's awesome plugin system! The combination of JSON and C# works as fine as chocolate and bananas!  

> **Stranger:** Yo, boi, ya craaazy? Never heard of pre-request scripts?  
> **Me:** I don't even know who you are!! So get the fuck outta here!  
> **Stranger:** ...  
> **Me:** Oh wait. Did you just ask me something? Well, you're the first person asking something about this project, so yeah... I guess... You can stay... :heart:  

So there are two problems with Postman:
1. Terminal users can't use it.
2. People that are not familiar with JS might not be able to write complex for authentication or whatever.

> **Stranger:** Yo, but isn't there Newman? It pretty much wraps postman into a console...  
> **Me:** Ofcourse, but the pre-request scripts are very difficult to use, since you need to insert your JS code into a string in the JSON collection file, have a look [here](https://github.com/postmanlabs/newman/blob/develop/examples/sample-collection.json).  
> **Stranger:** Oh shit bruh! Yeah, I see the problem. Damn, this project is so lit, god fuck.
> **Me:** Don't use these words! Maybe some childrens will hear us!!  
**Stranger:** Sorry, but it's kewl, really!  
> **Me:** Yeah, I know :smirk:  

Yeah, you heard right, you stalker! You can code plugins with C#/VB.NET. No need of any ninja reflection skills! I've done it all! Just take some eggs... Awwww, again: Just take the plugin dll, inherit the IPlugin interface and post like crazy!  It's only a single ```use_plugin: true``` away!  

Ofcourse, there's the problem that a pure C# coder wont be able to code a library in a terminal. But hey, you're a developer so your job is to solve problems, right? :stuck_out_tongue_winking_eye:  

But maybe this problem will be resolved if get a big enough userbase which develops lots of plugins which the handicapped terminal devs can download!  

However, it does also offers validation after the response has been received. It offers Regex, Substring, and (soon) more!  


## Any other reasons to use this?

You love me, I love you, we love .NET and you know it! C# kicks ass :tada:


## Uff, too much text...

Well, [here](https://raw.githubusercontent.com/ioncodes/Wingman/master/Examples/GET.json) ya go with a sample for a simple GET request using the test plugin which MD5s the current timestamp and sets it as MD5-Timestamp header!


## Compilation

Clone the repo, nuget restore and make sure you have .NET 4.7 installed!