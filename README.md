# Dalton
## Firebird Database

 Install the following dependencies
  - Firebird Server 2.x
  - Firebird ODBC
  - SQL Manager Lite Firebird (Optional)
    - Database Manager

## Codes
### Forms
#### frmExtractor
*Variable*

FormType as ExtractType
 - Expiry = 0
 - JournalEntry = 1

#### frmClientInformation
*Sub*

PhoneSeparator(TextBox,KeypressArgs,Optional isPhone Boolean=false)
 Identify if the entry encoded is a number or not

### Modules
#### mod_system
*Function*
DigitOnly(KeypressArgs)
 Allow only numbers and backspace
 Return: Boolean
