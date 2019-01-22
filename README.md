# API-Project
Develop an answering machine library

It should be able to:

I.Add elements to collections.
II.Returns an answer.
III.Returns an answer which contains a specific word if possible.


Detailed Requirements


I.Adding elements to collections.This method accepts three parameters.Each parameter corresponds to the respective collection.If there is a parameters which is null or whitespace,it isn't added to the respective collection.If all three parameters are null or whitespace it throws an ArgumentException.

II.Returning an answer.This method is parameterless. If two or three of the collections are empty it will return a default answer. Defaults answers are set in advance.

III.Returning an answer with a specific word. It will return an answer wich contains a specific word if it is possible. If there is no such specific word in any of the collections,it calls the above method. It returns an answer as usual. 

