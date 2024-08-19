# SAP Business One Custom Fields and Tables Automation DLL

This DLL is designed to simplify and automate the creation of custom fields and tables within the SAP Business One system using the Service Layer (SL) API. It provides a streamlined, programmatic interface to manage customizations, ensuring consistency and reducing the risk of manual errors during the creation process. The DLL is ideal for developers and system integrators who need to efficiently extend SAP Business One's functionality to meet specific business requirements.

### Objectives

* Automation: Automate the creation of custom fields and tables in SAP Business One to save time and reduce errors.
* Consistency: Ensure that customizations are applied uniformly across different environments (development, testing, production).
* Flexibility: Allow for easy modifications and updates to existing custom fields and tables, enabling the system to adapt quickly to changing business needs.
* Scalability: Support large-scale customizations, making it easier to handle complex implementations or migrations.
* Integration: Seamlessly integrate with other software solutions and workflows, enhancing overall business processes.

## Key Features

* Create Custom Tables: Easily create custom tables within SAP Business One with a few lines of code.
* Add Custom Fields: Automate the addition of custom fields to existing tables, including setting field types, sizes, and other properties.
* Validation: Built-in validation to ensure that the fields and tables meet SAP Business One’s requirements.
* JSON Support: Leverages JSON for data serialization, making it compatible with modern web and mobile applications.

## Installation

1. Download the DLL file from the release page.
2. Reference the DLL in your project.
3. Ensure your project has access to the SAP Business One Service Layer.

## Usage example 

```csharp
using CreateDataBaseSL;

  // you must pass the service layer host
 CreateDataBaseSL.DataSL dataSl = new CreateDataBaseSL.DataSL(Host);

 // Create Table
 List<CreateDataBaseSL.Models.UserTablesMD> userTablesMDs = new List<CreateDataBaseSL.Models.UserTablesMD> 
 {
     new CreateDataBaseSL.Models.UserTablesMD
     {
         TableName = "Validation",
         TableDescription = "Validation Table",
         TableType = CreateDataBaseSL.Models.Enum.TableType.bott_NoObject
     }

 };
  // You must pass the login session token you made and the data that will be integrated from the service layer
  var retornCreateTable = dataSl.CreateTables(SessionId, userTablesMDs);

 var userFieldsMDLogServices = new List<CreateDataBaseSL.Models.UserFieldsMD>
  {
      new CreateDataBaseSL.Models.UserFieldsMD
      {
          Name = "Data",
          TableName = "@Validation",
          Description = "Data do Log",
          Mandatory = CreateDataBaseSL.Models.Enum.Mandatory.tYES,
          Size = 12,
          Type = CreateDataBaseSL.Models.Enum.BoFieldsType.db_Date,
          SubType = CreateDataBaseSL.Models.Enum.BoFldSubTypes.st_None
      },

  };

 var userFieldsOCRD = new List<CreateDataBaseSL.Models.UserFieldsMD>
  {
      new CreateDataBaseSL.Models.UserFieldsMD
      {
          Name = "validation",
          TableName = "OCRD",
          Description = "Example",
          Mandatory = CreateDataBaseSL.Models.Enum.Mandatory.tYES,
          Size = 50,
          Type = CreateDataBaseSL.Models.Enum.BoFieldsType.db_Alpha,
          SubType = CreateDataBaseSL.Models.Enum.BoFldSubTypes.st_None
      }
  };

 var userFieldsOINV = new List<CreateDataBaseSL.Models.UserFieldsMD>
  {
      new CreateDataBaseSL.Models.UserFieldsMD
      {
          Name = "Exemple",
          TableName = "OINV",
          Description = "Exemple",
          Mandatory = CreateDataBaseSL.Models.Enum.Mandatory.tYES,
          Size = 50,
          Type = CreateDataBaseSL.Models.Enum.BoFieldsType.db_Alpha,
          SubType = CreateDataBaseSL.Models.Enum.BoFldSubTypes.st_None
      },
      new CreateDataBaseSL.Models.UserFieldsMD
      {
          Name = "Exemple_Create",
          TableName = "OINV",
          Description = "Exemple is created?",
          Mandatory = CreateDataBaseSL.Models.Enum.Mandatory.tYES,
          Size = 10,
          Type = CreateDataBaseSL.Models.Enum.BoFieldsType.db_Alpha,
          SubType = CreateDataBaseSL.Models.Enum.BoFldSubTypes.st_None,
          ValidValues = new List<CreateDataBaseSL.Models.ValidValue>
          {
              new CreateDataBaseSL.Models.ValidValue { Value = "Y", Description = "Sim" },
              new CreateDataBaseSL.Models.ValidValue { Value = "N", Description = "Não" }
          },
          DefaultValue = "N"
      }
      
  };

 // Dictionary key-value
 var keyValues = new Dictionary<string, List<CreateDataBaseSL.Models.UserFieldsMD>>
 {
     ["Validation"] = userFieldsMDLogServices,
     ["OCRD"] = userFieldsOCRD,
     ["OINV"] = userFieldsOINV
 };

 // You must pass the login session token you made and the data that will be integrated from the service layer
 dataSl.CreateFields(SessionId, keyValues);
           
```
### Contributing

If you find any bugs or have suggestions for improvements, please open an issue or submit a pull request. Contributions are welcome!

### Support
For any questions or support, please contact alerrandrosimao44@outlook.com.

