# EventRulesService

Made by https://github.com/SimonR-prog

# Postman:

## Authentication:

All requests to this API require an API-Key to be passed in the header.

Invalid requests will be met with_
```json
{
    "success": false,
    "error": "Invalid api-key or api-key is missing."
}
```



## POST and PUT: 

Is made by sending a request with no id at the end. 

www.url.net/api/EventRules/

The api needs data that looks like this: (All fields except eventId it takes in are handled like bools.)

```json
{
    "eventId": "270e876e-1d6f-496e-bb7c-05fc71d38475",
    "alcohol": true,
    "bike": false,
    "camera": true,
    "hazard": false,
    "knife": false,
    "merch": false,
    "noise": false,
    "pets": true,
    "picnic": false,
    "pill": false,
    "tent": false,
    "umbrella": false
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
        "eventId": "270e876e-1d6f-496e-bb7c-05fc71d38475",
        "alcohol": false,
        "bike": false,
        "camera": false,
        "hazard": false,
        "knife": false,
        "merch": false,
        "noise": false,
        "pets": false,
        "picnic": false,
        "pill": false,
        "tent": false,
        "umbrella": false
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
