# EventRulesService

# Postman:

## Authentication:

All requests to this API require an API-Key to be passed in the header under "X-API-KEY". 

Invalid requests will be met with:

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

# Sequence diagram plantuml

<img src="https://github.com/user-attachments/assets/7c01a89d-8c6b-4dd6-959d-7eae2c6d8727" width="400">

# Usage in the frontend:

## Adding rules to the event:

Adding rules is done in a modal where the admin can simply click whichever rules they want to add or remove.

<img src="https://github.com/user-attachments/assets/a83543de-3ad1-49ad-b8c1-1da091d850d8" width="400">

## Showing the rules of an event:

<img src="https://github.com/user-attachments/assets/5c1a6d6f-63b5-4298-8fcf-1f114425190c" width="400">

### Created By:

https://github.com/SimonR-prog
