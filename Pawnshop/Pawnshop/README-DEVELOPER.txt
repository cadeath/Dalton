frmClient TUTORIAL
Phase 1 - Setting up Reload Information
At your original form, create a procedure(SUB) with FRIEND or PUBLIC identifier that will load your form. Include a parameter CLIENT class as your searched client information.

eg
Friend Sub LoadClientInfo(ByVal cl As Client)
    txtID.Text = cl.ID
    txtName.Text = cl.FirstName & " " & cl.LastName
End Sub

Phase 2 - Adding in the Form Switch
Step 1
Add your Form at the formSwitch Module under Friend Enum with the Form Name and an Integer Value, integer should be unique.
eg
Friend Enum FormName As Integer
    devForm = 0
    frmMT = 1 'Money Transfer
    frmORIGIN = 2 'Sample Origin form
End Enum
Step 2
Add a CASE STATEMENT and LOAD your SUB(Phase 1) with CLIENT(use Variable cl) as Parameter.
usage: 
 Case <Enum Form Name>
   FormName.LoadClientInfo(cl)
eg
Select Case gotoForm
    Case FormName.devForm
        devClient.LoadClientInfo(cl)
    Case FormName.frmMT
        frmMoneyTransfer.LoadClient_Sender(cl)
    Case FormName.frmORIGIN
        frmORIGIN.LoadClientInfo(cl)
End Select

Phase 3 - using frmClient
To use the frmClient use the form Sub SearchSelect with the parameters, Your Search Text and your formName(from the SwitchForm)
eg
frmClient.SearchSelect("Jacob Frye", FormName.frmORIGIN)
frmClient.Show()

After selecting SELECT button, it will return to your ORIGINAL form.