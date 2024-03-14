# OOmiNet

## Register OOmi
You can register the service in DI

```c#
services.AddOomi(c =>
{
	c.OomiAccessId = "{{OOMI_ACCESS_ID}}";
	c.OomiSecret = "{{OOMI_SECRET}}";
	c.BaseUrl = "{{YOUR_URL}}";
});
```

## Usage

### Using Custom Models
A default `OomiRecord` model exists for you to get records from the API. You can create your custom model to streamline the result and map to your custom model. An example below
```c#
public class TestOomiRecord : OomiRecord {
    public string RecordId { get; set; }
    public string LoginUserName { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
}

TestOomiRecord response = await _oomiService.GetApiResponse<TestOomiRecord>(request);
```

You can then access your values like

```c#
var firstName = response.FirstName;
var email = response.Email;
```

### Using the `CriteriaBuilder`
Using the criteria builder is simple, the criteria builder provides some helpful methods `And` and `Or` to help with creating the criteria list and logic. See below

```c#
var username = "user@yopmail.com";
var password = "UserPassword1234";

var criterias = new OomiCriteriaBuilder(
    OomiRequestCriteria.Create("LoginUserName", "3", username));

criterias.And(OomiRequestCriteria.Create("LoginPassword", "3", password));

var request = new OomiGetRequest("CONTACT");
request.SetCriterias(criterias.Build());
```

### Manually parsing an `OomiRecord` to a custom type
This can be sone using the `OomiRecordHelper` extension method `TryConvertTo<T>()`. See below (using the TestOomirecord class created above)

```c#
OomiRecord record = new OomiRecord();
TestOomiRecord testRecord = record.TryConvertTo<TestOomiRecord>();
```