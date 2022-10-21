## Exercise1:

Let’s create a console application that calls both the Ron Swanson API, and the Kanye West API. Using both APIs, make Ron Swanson and Kanye West have a conversation that prints to the console.

Here is some code to utilize for parsing the ron swanson response:
```
var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
```

Here are the API urls:

https://ron-swanson-quotes.herokuapp.com/v2/quotes

https://api.kanye.rest
