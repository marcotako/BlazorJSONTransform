# Blazor JSON Transform
 This is a Blazor WebAssembly PoC to transform JSON to JSON applying a JSON template based on JSONPath expressions and you can use it online here https://gentle-flower-038098c03.azurestaticapps.net/
 
 The structure of the template is as follows:
```javascript
//This is the root element of the JSON where we can define several properties
[  
  {
    "FieldName": string, //Name of the JSON property
    "JsonPath": string,  //JSON path expression for getting the value or values
    "IsArray": bool, //Indicates if this property is an array (JsonPath expression could return more than one value then)
    "IsFixedValue": bool, //Indicates if this property is a fixed value (JsonPath is null)
    "FixedValue": string or number, //The fixed value for this property. If IsArray is true, this value is parsed as an array so you can type something like "[1,2,3]"
    "Child": [  //This is an array of child elements of the same type in case we want nested elements
      {
        "FieldName": string, 
        "JsonPath": string,  //This JSON path expression is applied against the result returned by parent JSON Path expression
        "IsArray": bool,
        "IsFixedValue": bool,
        "FixedValue": string or number,
      },
      ...
    ]
  },
  ...
]
```
Here you are several examples of usage from the same original JSON:

Original JSON
```javascript
[
  [
    8603.51,
    40.4250801,
    -3.6853006,
    "#AAAAAA",
    "#000000",
    0.4
  ],
  [
    3308.2,
    40.3863945,
    -3.7697492,
    "#AAAAAA",
    "#000000",
    0.4
  ],
  [
    3310,
    40.350287,
    -3.6887243,
    "#AAAAAA",
    "#000000",
    0.4
  ],
  [
    6105.81,
    40.3654622,
    -3.5946563,
    "#AAAAAA",
    "#000000",
    0.4
  ],
  [
    4886.92,
    40.4729502,
    -3.5958151,
    "#AAAAAA",
    "#000000",
    0.4
  ],
  [
    8203.19,
    40.5211844,
    -3.757385,
    "#AAAAAA",
    "#000000",
    0.4
  ],
  [
    3784.53,
    40.6062118,
    -3.6489023,
    "#AAAAAA",
    "#000000",
    0.4
  ],
  [
    1541.8,
    40.4976963,
    -3.6468421,
    "#AAAAAA",
    "#000000",
    0.4
  ]
]
```
## Fixed values
Template JSON
```javascript
[  
  {
    "FieldName": "propery1", 
    "IsFixedValue": true, 
    "FixedValue": "Hola",
  },
  {
    "FieldName": "propery2", 
    "IsFixedValue": true, 
    "IsArray": true,
    "FixedValue": "[1,2,3]",
  }
]
```
Result JSON
```javascript
{
  "propery1": "Hola",
  "propery2": [
    1,
    2,
    3
  ]
}
```

## Array of simple values JSON property
Template JSON
```javascript
[
  {
    "FieldName": "latitude",
    "JsonPath": "$[*][*]",
    "IsArray": true
  }
]
```
Result JSON
```javascript
{
  "latitude": [
    8603.51,
    40.4250801,
    -3.6853006,
    "#AAAAAA",
    "#000000",
    0.4,
    3308.2,
    40.3863945,
    -3.7697492,
    "#AAAAAA",
    "#000000",
    0.4,
    3310,
    40.350287,
    -3.6887243,
    "#AAAAAA",
    "#000000",
    0.4,
    6105.81,
    40.3654622,
    -3.5946563,
    "#AAAAAA",
    "#000000",
    0.4,
    4886.92,
    40.4729502,
    -3.5958151,
    "#AAAAAA",
    "#000000",
    0.4,
    8203.19,
    40.5211844,
    -3.757385,
    "#AAAAAA",
    "#000000",
    0.4,
    3784.53,
    40.6062118,
    -3.6489023,
    "#AAAAAA",
    "#000000",
    0.4,
    1541.8,
    40.4976963,
    -3.6468421,
    "#AAAAAA",
    "#000000",
    0.4
  ]
}
```

## One JSON complex property
Template JSON
```javascript
[
  {
    "FieldName": "latitude",
    "JsonPath": "$[0]"    
  }
]
```
Result JSON
```javascript
{
  "latitude": [
    8603.51,
    40.4250801,
    -3.6853006,
    "#AAAAAA",
    "#000000",
    0.4
  ]
}
```

## Simple Child JSON object
Template JSON
```javascript
[
  {
    "FieldName": "servicepoints",
    "JsonPath": "$[0]",
    "Child": [
      {
        "FieldName": "latitude",
        "JsonPath": "$[1]"
      },
      {
        "FieldName": "longitude",
        "JsonPath": "$[2]"
      },
      {
        "FieldName": "distancethreshold",
        "JsonPath": "$[0]"
      }
    ]
  },
  {
    "FieldName": "propery1", 
    "IsFixedValue": true, 
    "FixedValue": "Hola",
  },
  {
    "FieldName": "propery2", 
    "IsFixedValue": true, 
    "IsArray": true,
    "FixedValue": "[1,2,3]",
  }
]
```
Result JSON
```javascript
{
  "servicepoints": {
    "latitude": 40.4250801,
    "longitude": -3.6853006,
    "distancethreshold": 8603.51
  },
  "propery1": "Hola",
  "propery2": [
    1,
    2,
    3
  ]
}
```

## Array of Child JSON object
Template JSON
```javascript
[
  {
    "FieldName": "servicepoints",
    "JsonPath": "$[*]",
    "IsArray": true,
    "Child": [
      {
        "FieldName": "latitude",
        "JsonPath": "$[1]"
      },
      {
        "FieldName": "longitude",
        "JsonPath": "$[2]"
      },
      {
        "FieldName": "distancethreshold",
        "JsonPath": "$[0]"
      }
    ]
  },
  {
    "FieldName": "propery1", 
    "IsFixedValue": true, 
    "FixedValue": "Hola",
  },
  {
    "FieldName": "propery2", 
    "IsFixedValue": true, 
    "IsArray": true,
    "FixedValue": "[1,2,3]",
  }
]
```
Result JSON
```javascript
{
  "servicepoints": [
    {
      "latitude": 40.4250801,
      "longitude": -3.6853006,
      "distancethreshold": 8603.51
    },
    {
      "latitude": 40.3863945,
      "longitude": -3.7697492,
      "distancethreshold": 3308.2
    },
    {
      "latitude": 40.350287,
      "longitude": -3.6887243,
      "distancethreshold": 3310
    },
    {
      "latitude": 40.3654622,
      "longitude": -3.5946563,
      "distancethreshold": 6105.81
    },
    {
      "latitude": 40.4729502,
      "longitude": -3.5958151,
      "distancethreshold": 4886.92
    },
    {
      "latitude": 40.5211844,
      "longitude": -3.757385,
      "distancethreshold": 8203.19
    },
    {
      "latitude": 40.6062118,
      "longitude": -3.6489023,
      "distancethreshold": 3784.53
    },
    {
      "latitude": 40.4976963,
      "longitude": -3.6468421,
      "distancethreshold": 1541.8
    }
  ],
  "propery1": "Hola",
  "propery2": [
    1,
    2,
    3
  ]
}
```

I recommend this online tool http://jsonpath.com/ to check JSON Path expressions and this one https://jsoneditoronline.org/ to format JSON.
