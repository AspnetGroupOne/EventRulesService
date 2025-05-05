# EventRulesService

Made by https://github.com/SimonR-prog

# Postman:

## POST and PUT: 

Is made by sending a request with no id at the end. 

www.url.net/api/EventRules/

The api needs data that looks like this: (All fields it takes in are handled like strings.)

```json
{
    "eventId": "56f58514-7581-4b18-97f5-b6eb5ba7b9c5",
    "gateOpenStart": "1030",
    "gateOpenEnd": "1200",
    "preShowStart": "1300",
    "preShowEnd": "1400",
    "ceremonyStart": "1500",
    "ceremonyEnd": "1530",
    "concertStart": "1600"
}
```

If sending a POST, then the data will be added. If PUT then the data will be updated if there is any with that eventId.

## GET:

Is made by sending a request with an id at the end. 

www.url.net/api/Schedules/56f58514-7581-4b18-97f5-b6eb5ba7b9c5

And you will recieve data in json format that looks like this on success:

```json
{
    "content": {
        "eventId": "56f58514-7581-4b18-97f5-b6eb5ba7b9c5",
        "gateOpenStart": "1130",
        "gateOpenEnd": "1200",
        "preShowStart": "1300",
        "preShowEnd": "1400",
        "ceremonyStart": "1500",
        "ceremonyEnd": "1530",
        "concertStart": "1600"
    },
    "success": true,
    "statusCode": 200,
    "message": null
}
```

## DELETE

Is made by sending a request with an id at the end. 

www.url.net/api/Schedules/56f58514-7581-4b18-97f5-b6eb5ba7b9c5

Upon success you will recieve:

```json
{
    "success": true,
    "statusCode": 200,
    "message": null
}
```

# Usage in the frontend:
