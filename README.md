# Chatter Bot API

A Mono/.NET, JAVA, Python and PHP chatter bot API that supports Cleverbot, JabberWacky and Pandorabots.

For a Ruby version, have a look at Gabriele Cirulli cleverbot-api implementation.

If you are planing using the .NET version, maybe this fork by Schumix on GitHub is worth looking at.

## News

**2014-10-11**: Moved to GitHub!

**2014-08-04**: The Java version is now on The Maven Central Repository. This is a request I get from time to time. I was too lazy to do it until now. But this time a user was kind enough, so I kick myself and did it (thanks Hardik!). Just add this dependency to your pom file.

**2014-03-31**: Cleverbot seems to stops working from time to time. You should expect it to be really unstable until I find a fix.

**2014-02-02**: Cleverbot stops working. Thanks to Matthew to let me know.

**2013-11-15**: Cleverbot stops working, they changed their API again. I am working on this.

**2013-08-29**: There is a bug with Cleverbot in any language right now. I will fix it as soon as possible. A bug with Cleverbot is now fixed in the new 1.3 revision release. Enjoy! (Kevin, Alienmario, Rai: Thanks to you guys for letting me know)

## Download

Maven users, you can use this dependency.

I encourage you to download a compiled version of the library, and try the example below in this page. I tried to keep all the libraries free from dependencies, so you do not need to download anything else.

Be sure to always use the latest version of the library, as the Cleverbot/JabberWacky Web Service is changing over time. I suppose it is not meant to be public.

Maven
Just add this dependency to your pom file:

```
<dependency>
    <groupId>ca.pjer</groupId>
    <artifactId>chatter-bot-api</artifactId>
    <version>1.3.2</version>
</dependency>
```

## Going further

If you like what you see, browse and comment the source code. If you found a bug or something missing, consult the issue list before posting a new defect or a new enhancement.

Issues you may be interested in
If you are interested in a PHP version of this library have a look at  issue 3 .

If you are interested in a Ruby version of this library have a look at issue 4, or go to Gabriele Cirulli's implementation.

A discusion about if I should port the Mono/.NET version to .NET Framework 4.0 in  issue 5 .

## Disclaimer

I am not the owner of Cleverbot/JabberWacky nor Pandorabots.

My work (the Cleverbot/JabberWacky part) is based on pycleverbot, a Python bindings for the Cleverbot.

## Contact

You can also let me know what you think.

## Examples

### Mono/.NET C#

```
using System;

using ChatterBotAPI;

namespace ChatterBotAPITest {
        
        class MainClass {
                
                public static void Main(string[] args) {
                        ChatterBotFactory factory = new ChatterBotFactory();
                        
                        ChatterBot bot1 = factory.Create(ChatterBotType.CLEVERBOT);
                        ChatterBotSession bot1session = bot1.CreateSession();
                        
                        ChatterBot bot2 = factory.Create(ChatterBotType.PANDORABOTS, "b0dafd24ee35a477");
                        ChatterBotSession bot2session = bot2.CreateSession();
                        
                        string s = "Hi";
                        while (true) {
                                
                                Console.WriteLine("bot1> " + s);
                                
                                s = bot2session.Think(s);
                                Console.WriteLine("bot2> " + s);
                                
                                s = bot1session.Think(s);
                        }
                }
        }
}
```

### Mono/.NET VB

```
Imports ChatterBotAPI

Public Class Application

        Public Shared Sub Main()
                Dim factory As ChatterBotFactory = new ChatterBotFactory()
                
                Dim bot1 As ChatterBot = factory.Create(ChatterBotType.CLEVERBOT)
                Dim bot1session As ChatterBotSession = bot1.CreateSession()
                
                Dim bot2 As ChatterBot = factory.Create(ChatterBotType.PANDORABOTS, "b0dafd24ee35a477")
                Dim bot2session As ChatterBotSession = bot2.CreateSession()
        
                Dim s As String = "Hi"
                Do While true
                
                        Console.WriteLine("bot1> " + s)
                        
                        s = bot2session.Think(s)
                        Console.WriteLine("bot2> " + s)
                                
                        s = bot1session.Think(s)
                Loop
        End Sub
End Class
```

### JAVA

```
package com.google.code.chatterbotapi.test;

import com.google.code.chatterbotapi.*;

public class ChatterBotApiTest {
    
    public static void main(String[] args) throws Exception {
        ChatterBotFactory factory = new ChatterBotFactory();

        ChatterBot bot1 = factory.create(ChatterBotType.CLEVERBOT);
        ChatterBotSession bot1session = bot1.createSession();

        ChatterBot bot2 = factory.create(ChatterBotType.PANDORABOTS, "b0dafd24ee35a477");
        ChatterBotSession bot2session = bot2.createSession();

        String s = "Hi";
        while (true) {

            System.out.println("bot1> " + s);

            s = bot2session.think(s);
            System.out.println("bot2> " + s);

            s = bot1session.think(s);
        }
    }
}
```

### Python

```
from chatterbotapi import ChatterBotFactory, ChatterBotType

factory = ChatterBotFactory()

bot1 = factory.create(ChatterBotType.CLEVERBOT)
bot1session = bot1.create_session()

bot2 = factory.create(ChatterBotType.PANDORABOTS, 'b0dafd24ee35a477')
bot2session = bot2.create_session()

s = 'Hi'
while (1):
    
    print 'bot1> ' + s
    
    s = bot2session.think(s);
    print 'bot2> ' + s
    
    s = bot1session.think(s);
```

### PHP

```
<?php
    require 'chatterbotapi.php';
    
    $factory = new ChatterBotFactory();
    
    $bot1 = $factory->create(ChatterBotType::CLEVERBOT);
    $bot1session = $bot1->createSession();
    
    $bot2 = $factory->create(ChatterBotType::PANDORABOTS, 'b0dafd24ee35a477');
    $bot2session = $bot2->createSession();
    
    $s = 'Hi';
    while (1) 
    {
        echo "bot1> $s\n";
        
        $s = $bot2session->think($s);
        echo "bot2> $s\n";
        
        $s = $bot1session->think($s);
    }
?>
```